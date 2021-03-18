namespace synth_project
{
    partial class synthesiser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.octave_display = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vibratoCheck = new System.Windows.Forms.CheckBox();
            this.vibratofreqbox = new System.Windows.Forms.TextBox();
            this.VibratoPlus = new System.Windows.Forms.Button();
            this.vibratoMinus = new System.Windows.Forms.Button();
            this.oscillator6 = new synth_project.oscillator();
            this.oscillator5 = new synth_project.oscillator();
            this.oscillator4 = new synth_project.oscillator();
            this.label3 = new System.Windows.Forms.Label();
            this.Overdrive = new System.Windows.Forms.Label();
            this.Overdrive_toggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // octave_display
            // 
            this.octave_display.Location = new System.Drawing.Point(359, 104);
            this.octave_display.Name = "octave_display";
            this.octave_display.ReadOnly = true;
            this.octave_display.Size = new System.Drawing.Size(39, 22);
            this.octave_display.TabIndex = 5;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(378, 21);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Octave";
            // 
            // vibratoCheck
            // 
            this.vibratoCheck.AutoSize = true;
            this.vibratoCheck.Location = new System.Drawing.Point(404, 152);
            this.vibratoCheck.Name = "vibratoCheck";
            this.vibratoCheck.Size = new System.Drawing.Size(49, 21);
            this.vibratoCheck.TabIndex = 10;
            this.vibratoCheck.Text = "On";
            this.vibratoCheck.UseVisualStyleBackColor = true;
            this.vibratoCheck.CheckedChanged += new System.EventHandler(this.vibratoCheck_CheckedChanged);
            // 
            // vibratofreqbox
            // 
            this.vibratofreqbox.BackColor = System.Drawing.SystemColors.Control;
            this.vibratofreqbox.Location = new System.Drawing.Point(359, 196);
            this.vibratofreqbox.Name = "vibratofreqbox";
            this.vibratofreqbox.ReadOnly = true;
            this.vibratofreqbox.Size = new System.Drawing.Size(39, 22);
            this.vibratofreqbox.TabIndex = 11;
            // 
            // VibratoPlus
            // 
            this.VibratoPlus.Location = new System.Drawing.Point(404, 196);
            this.VibratoPlus.Name = "VibratoPlus";
            this.VibratoPlus.Size = new System.Drawing.Size(75, 23);
            this.VibratoPlus.TabIndex = 12;
            this.VibratoPlus.Text = "+";
            this.VibratoPlus.UseVisualStyleBackColor = true;
            this.VibratoPlus.Click += new System.EventHandler(this.VibratoPlus_Click);
            // 
            // vibratoMinus
            // 
            this.vibratoMinus.Location = new System.Drawing.Point(278, 196);
            this.vibratoMinus.Name = "vibratoMinus";
            this.vibratoMinus.Size = new System.Drawing.Size(75, 23);
            this.vibratoMinus.TabIndex = 13;
            this.vibratoMinus.Text = "-";
            this.vibratoMinus.UseVisualStyleBackColor = true;
            this.vibratoMinus.Click += new System.EventHandler(this.vibratoMinus_Click);
            // 
            // oscillator6
            // 
            this.oscillator6.Location = new System.Drawing.Point(12, 224);
            this.oscillator6.Name = "oscillator6";
            this.oscillator6.Size = new System.Drawing.Size(260, 100);
            this.oscillator6.TabIndex = 2;
            this.oscillator6.TabStop = false;
            this.oscillator6.Text = "oscillator 3";
            // 
            // oscillator5
            // 
            this.oscillator5.Location = new System.Drawing.Point(12, 118);
            this.oscillator5.Name = "oscillator5";
            this.oscillator5.Size = new System.Drawing.Size(260, 100);
            this.oscillator5.TabIndex = 1;
            this.oscillator5.TabStop = false;
            this.oscillator5.Text = "oscillator 2";
            // 
            // oscillator4
            // 
            this.oscillator4.Location = new System.Drawing.Point(12, 12);
            this.oscillator4.Name = "oscillator4";
            this.oscillator4.Size = new System.Drawing.Size(260, 100);
            this.oscillator4.TabIndex = 0;
            this.oscillator4.TabStop = false;
            this.oscillator4.Text = "oscillator 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Vibrato/LFO";
            // 
            // Overdrive
            // 
            this.Overdrive.AutoSize = true;
            this.Overdrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Overdrive.Location = new System.Drawing.Point(298, 267);
            this.Overdrive.Name = "Overdrive";
            this.Overdrive.Size = new System.Drawing.Size(70, 17);
            this.Overdrive.TabIndex = 15;
            this.Overdrive.Text = "Overdrive";
            // 
            // Overdrive_toggle
            // 
            this.Overdrive_toggle.AutoSize = true;
            this.Overdrive_toggle.Location = new System.Drawing.Point(404, 267);
            this.Overdrive_toggle.Name = "Overdrive_toggle";
            this.Overdrive_toggle.Size = new System.Drawing.Size(49, 21);
            this.Overdrive_toggle.TabIndex = 16;
            this.Overdrive_toggle.Text = "On";
            this.Overdrive_toggle.UseVisualStyleBackColor = true;
            this.Overdrive_toggle.CheckedChanged += new System.EventHandler(this.Overdrive_toggle_CheckedChanged);
            // 
            // synthesiser
            // 
            this.ClientSize = new System.Drawing.Size(507, 338);
            this.Controls.Add(this.Overdrive_toggle);
            this.Controls.Add(this.Overdrive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vibratoMinus);
            this.Controls.Add(this.VibratoPlus);
            this.Controls.Add(this.vibratofreqbox);
            this.Controls.Add(this.vibratoCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.octave_display);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.oscillator6);
            this.Controls.Add(this.oscillator5);
            this.Controls.Add(this.oscillator4);
            this.KeyPreview = true;
            this.Name = "synthesiser";
            this.Text = "synthesiser";
            this.Load += new System.EventHandler(this.synthesiser_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.synthesiser_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button add_octave;
        private System.Windows.Forms.TextBox octave_indicator;
        private System.Windows.Forms.Button minus_octave;
        private oscillator oscillator1;
        private oscillator oscillator2;
        private oscillator oscillator3;
        private oscillator oscillator4;
        private oscillator oscillator5;
        private oscillator oscillator6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox octave_display;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox vibratoCheck;
        private System.Windows.Forms.TextBox vibratofreqbox;
        private System.Windows.Forms.Button VibratoPlus;
        private System.Windows.Forms.Button vibratoMinus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Overdrive;
        private System.Windows.Forms.CheckBox Overdrive_toggle;
    }
}

