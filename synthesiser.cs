using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace synth_project
{
    public partial class synthesiser : Form
    {
        const int sample_rate = 44100; //setting the sample rate to 44100 samples a second
        const short bitdepth = 16; //setting the bit depth to 16 bit
        float octaveswitch = 0;   //initialising the octaveswitch variable 
        float volume = 10;       //starting the volume at max
        bool vibratoOn = false;  //starting the program with the vibrato function off
        bool OverdriveOn = false;  //starting the program with the Overdrive function off
        float vibratofreq = 40;  //setting an initial vibrato frequency 
        float frequency = 0; //initialising the frequency variable
        short tempvar;       //initialising a variable used in the overdrive process
        byte[] binarywave;
        short tempsample;
        int samplesPerWavelength;
        short ampstep;
        float finalvol;
        int oscillator_count;
        bool accepted_key;
        public synthesiser()
        {
            InitializeComponent(); 
        }

        private void synthesiser_KeyDown(object sender, KeyEventArgs e)  //this code is run everytime a key is pressed
        {
           
        
            IEnumerable<oscillator> oscillators = this.Controls.OfType<oscillator>().Where(o => o.On); //bringing in the oscilltors
            accepted_key = true;
            short[] wave = new short[sample_rate]; // this will generate one second of audio
            oscillator_count = oscillators.Count(); //checking how many oscillators there are int the synthesiser (3)
            
            
            switch (e.KeyCode)     //checking against the keycode of the button and selecting the right frequency for each note
            {
                case Keys.A:
                        frequency = ((float)(261.63 * Math.Pow(2, octaveswitch)));  //C4
                        break;
                case Keys.W:
                        frequency = ((float)(277.18 * Math.Pow(2, octaveswitch)));  //C#4
                        break;
                case Keys.S:
                        frequency = ((float)(293.66 * Math.Pow(2, octaveswitch)));  //D4
                        break;
                case Keys.E:
                        frequency = ((float)(311.13 * Math.Pow(2, octaveswitch)));  //D#4
                        break;
                case Keys.D:
                        frequency = ((float)(329.63 * Math.Pow(2, octaveswitch)));  //E4
                        break;
                case Keys.F:
                        frequency = ((float)(349.23 * Math.Pow(2, octaveswitch)));  //F4
                        break;
                case Keys.T:
                        frequency = ((float)(369.99 * Math.Pow(2, octaveswitch)));  //F#4
                        break;
                case Keys.G:
                        frequency = ((float)(392.00 * Math.Pow(2, octaveswitch)));  //G4
                        break;
                case Keys.Y:
                        frequency = ((float)(415.30 * Math.Pow(2, octaveswitch)));  //G#4
                        break;
                case Keys.H:
                        frequency = ((float)(440.00 * Math.Pow(2, octaveswitch)));  //A4
                        break;
                case Keys.U:
                        frequency = ((float)(466.16 * Math.Pow(2, octaveswitch)));  //A#4
                        break;
                case Keys.J:
                        frequency = ((float)(493.88 * Math.Pow(2, octaveswitch)));  //B#4
                        break;
                case Keys.K:
                        frequency = ((float)(523.25 * Math.Pow(2, octaveswitch)));  //C5
                        break;
                default:
                        accepted_key = false;                                       //if the key pressed is not one of the ones wanted then the accepted_key variable is made false
                        break;
            }

            if (accepted_key == true) // if an accepted key is pressed then sound synthesis can begin
            {


                foreach (oscillator oscillator in oscillators) // the function will run once for each oscillator  
                {
                    
                    binarywave = new byte[sample_rate * sizeof(short)]; //setting up information for the soundplayer function
                    samplesPerWavelength = (int)(sample_rate / frequency);  //how many samples will there be per one wavelength
                    ampstep = (short)(((short.MaxValue * 2) / samplesPerWavelength));  
                    Random rnd = new Random();     //setting up the random function for the noise waveform
                    tempvar = 0;
                    
                    finalvol = 0;      //setting up the function for volume control

                    switch (oscillator.waveform)     //checks for the current oscillators selected waveform
                    {
                        
                        case waveform.sine:
                            finalvol = short.MaxValue * (volume / 20);  //setting up the volume function to be inserted in the final equation
                            
                            for (int i = 0; i < sample_rate; i++) //loops 44100 times so that there are that many samples are in one second of audio 
                            {
                               
                                if (vibratoOn == true) //if the vibrato checkbox is selected then a moddified version of the equation will play incorporating the extra oscillation into it
                                {
                                    tempvar += Convert.ToInt16((finalvol * (Math.Sin(((Math.PI * 2 * frequency) / sample_rate) * i) * Math.Sin(((vibratofreq) * i) / sample_rate) / oscillator_count))); //sine wave mixed with LFO
                                }
                                else
                                {
                                    tempvar += Convert.ToInt16((finalvol * (Math.Sin(((Math.PI * 2 * frequency) / sample_rate) * i)  / oscillator_count))); //sine wave generation
                                }
                                wave[i] += ApplyOverdrive(tempvar);   //running the final result through the distortion algorithm
                            }
                            break;

                        case waveform.Square:
                            finalvol = short.MaxValue * (volume / 20); //setting up the volume function for this wavetype

                            for (int i = 0; i < sample_rate; i++)
                            {
                                if (vibratoOn == true) //if the vibrato checkbox is selected then a moddified version of the equation will play incorporating the extra oscillation into it
                                {
                                    tempvar += Convert.ToInt16((finalvol * (Math.Sign(Math.Sin(((Math.PI * 2 * frequency) / sample_rate) * i))) * (Math.Sin(((vibratofreq) * i) / sample_rate)) / oscillator_count)); //square with LFO 

                                }
                                else
                                {
                                    finalvol = short.MaxValue * (volume / 20);
                                    tempvar += Convert.ToInt16((finalvol * (Math.Sign(Math.Sin(((Math.PI * 2 * frequency) / sample_rate) * i))) / oscillator_count)); //square (made by taking a sine wave and using the Math.Sign function)

                                }
                                wave[i] = ApplyOverdrive(tempvar);    //running the final result through the distortion algorithm
                            }
                            break;


                        case waveform.Saw:
                            finalvol = (volume / 20); //setting up the volume function for this wavetype
                            for (int i = 0; i < sample_rate; i++)
                            {
                                tempvar = 0;
                                tempsample = -short.MaxValue;
                                for (int u = 0; u < samplesPerWavelength && i < sample_rate; u++)
                                {
                                    tempsample += ampstep;
                                    if (vibratoOn == true) //if the vibrato checkbox is selected then a moddified version of the equation will play incorporating the extra oscillation into it
                                    {
                                        tempvar += Convert.ToInt16(((tempsample * Math.Sin(((vibratofreq) * i) / sample_rate))) / oscillator_count * finalvol); //saw wave with LFO
                                    }
                                    else
                                    {
                                        tempvar += Convert.ToInt16((tempsample / oscillator_count) * finalvol); //saw wave generation
                                    }
                                    wave[i++] += ApplyOverdrive(tempvar); //running the final result through the distortion algorithm
                                }

                                i--;

                            }
                            break;

                        case waveform.Triangle:

                            tempsample = -short.MaxValue;
                            finalvol = (volume / 20); //setting up the volume function for this wavetype
                            for (int i = 0; i < sample_rate; i++)
                            {
                                tempvar = 0;
                                if (Math.Abs(tempsample + ampstep) > short.MaxValue)
                                {  
                                    ampstep = (short)-ampstep;
                                }
                                tempsample += ampstep;
                                if (vibratoOn == true) //if the vibrato checkbox is selected then a moddified version of the equation will play incorporating the extra oscillation into it
                                {
                                    tempvar += Convert.ToInt16(((tempsample * (Math.Sin(((vibratofreq) * i) / sample_rate))) / oscillator_count) * finalvol);
                                }
                                else
                                {
                                    tempvar += Convert.ToInt16((tempsample / oscillator_count) * finalvol);
                                }
                                wave[i] = ApplyOverdrive(tempvar); //running the final result through the distortion algorithm
                            }
                            break;


                        case waveform.Noise:
                            finalvol = (volume / 20); //setting up the volume function for this wavetype
                            for (int i = 0; i < sample_rate; i++)
                            {
                                tempvar = 0;
                                if (vibratoOn == true) //if the vibrato checkbox is selected then a moddified version of the equation will play incorporating the extra oscillation into it
                                {
                                    tempvar = Convert.ToInt16((((rnd.Next(-short.MaxValue, short.MaxValue)) * (Math.Sin(((vibratofreq) * i) / sample_rate))) / oscillator_count) * finalvol);
                                }
                                else
                                {
                                    tempvar = Convert.ToInt16(((rnd.Next(-short.MaxValue, short.MaxValue)) / oscillator_count) * finalvol);
                                }
                                
                                wave[i] += ApplyOverdrive(tempvar); //running the final result through the distortion algorithm
                            }
                            break;
                        
                    }
                  
                   
                
                    Buffer.BlockCopy(wave, 0, binarywave, 0, wave.Length * sizeof(short));

                    using (MemoryStream memoryStream = new MemoryStream())
                    using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                    {
                        short blockAlign = bitdepth / 8;
                        int subChunkTwoSize = sample_rate * blockAlign;
                        binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                        binaryWriter.Write(36 + subChunkTwoSize);
                        binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                        binaryWriter.Write(16);
                        binaryWriter.Write((short)1);
                        binaryWriter.Write((short)1);
                        binaryWriter.Write(sample_rate);
                        binaryWriter.Write(sample_rate * blockAlign);
                        binaryWriter.Write(blockAlign);
                        binaryWriter.Write(bitdepth);
                        binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                        binaryWriter.Write(subChunkTwoSize);
                        binaryWriter.Write(binarywave);
                        memoryStream.Position = 0;
                        
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(memoryStream);
                        player.Play();
                     

                    }
                }
            }
            
            
        }


        private void synthesiser_Load_1(object sender, EventArgs e)  //setting up some default states
        {
            octave_display.Text = Convert.ToString(octaveswitch);
            trackBar1.Value = 10;
            vibratofreqbox.Text = "40";
        }

        private void button1_Click(object sender, EventArgs e)   //if the octave switch is not too low then increase the function and display the new value on the textbox
        {
            if (octaveswitch > -3)
            {
                octaveswitch -= 1;
                octave_display.Text = Convert.ToString(octaveswitch);
            }
        }

        private void button2_Click(object sender, EventArgs e) //if the octave switch is not too high then increase the function and display the new value on the textbox
        {
            if (octaveswitch < 4)
            {
                octaveswitch += 1;
                octave_display.Text = Convert.ToString(octaveswitch);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)  //updating the volume to the amount given by the user on the trackbar
        {
            volume = trackBar1.Value;
        
        }

        private void vibratoCheck_CheckedChanged(object sender, EventArgs e)  //updating the corresponding variable when the user changes the vibrato checkbox
        {
            if (vibratoCheck.Checked == true)
            {
                vibratoOn = true;
            }
            else
            {
                vibratoOn = false;
            }
        }

     

        private void VibratoPlus_Click(object sender, EventArgs e)  //increasing the frequency of the LFO/vibrato
        {
            if (vibratofreq < 100)
            {
                vibratofreq = (float)(vibratofreq + 5);
                vibratofreqbox.Text = (Convert.ToString(vibratofreq));
            }
        }

        private void vibratoMinus_Click(object sender, EventArgs e) //decreasing the frequency of the LFO/vibrato
        {
            if (vibratofreq > 0)
            {
                vibratofreq = (float)(vibratofreq - 5);
                vibratofreqbox.Text = (Convert.ToString(vibratofreq));
            }
        }

        

      

        private void Overdrive_toggle_CheckedChanged(object sender, EventArgs e)  //updating the corresponding variable when the user changes the overdrive toggle checkbox
        {
           
            if (Overdrive_toggle.Checked == true)
            {
                OverdriveOn = true;
            }
            else
            {
                OverdriveOn = false;
            }
        }
        private short ApplyOverdrive(short numb) //applies the overdrive effect when requested
        {

            if (OverdriveOn == true)
            {
                
                if (numb >= short.MaxValue/2)      //if the amplitude surpasses the threshold then the wave is clipped
                {
                    numb = Convert.ToInt16(short.MaxValue);
                    return numb;
                }
                else if(numb <= -short.MaxValue / 2)      //if the amplitude surpasses the threshold then the wave is clipped
                {
                    numb = Convert.ToInt16(-short.MaxValue);
                    return numb;
                }
                else
                {
                    return numb;
                }
            }
            else
            {
                tempvar = 0;
                return numb;
            }
            
        }

       
    }
    public enum waveform
    {
        sine, Square, Saw, Triangle, Noise
    }
    
}
