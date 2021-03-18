using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace synth_project
{
    public class oscillator : GroupBox
    {
        public oscillator()
        {
            //a button is made for each wavetype within the oscillator
            this.Controls.Add(new Button()
            {
                Name = "sine",
                Location = new Point(10,15),
                Text = "sine",
                BackColor = Color.Lime


            });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(65, 15),
                Text = "Saw",
               
            }); this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(120, 15),
                Text = "Square",
           
            });
            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(10, 50),
                Text = "Triangle",
            }); this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise",
            
            });
            foreach (Control control in this.Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsoft Sans Serif", 6.75f);
                control.Click += Wavebutton_click;

            }
            this.Controls.Add(new CheckBox()
            {
                Name = "on/off",
                Location = new Point(210, 10),
                Size = new Size(40,30),
                Text = "on",
                Checked = true
            });
         
        }
        public waveform waveform { get; private set;  }
        public bool On => ((CheckBox)this.Controls["on/off"]).Checked;

        
        private void Wavebutton_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.waveform = (waveform)Enum.Parse(typeof(waveform), button.Text);
            foreach (Button other_button in this.Controls.OfType<Button>())
            {
                other_button.UseVisualStyleBackColor = true;
            }
            button.BackColor = Color.Lime;
        }

        
    }
}
