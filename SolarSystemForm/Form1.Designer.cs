namespace SolarSystemForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSolarSystem;
        private System.Windows.Forms.Timer timer1;
       
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loadPlanets = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.planetsDescription = new System.Windows.Forms.RichTextBox();
            this.planetsList_Box = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.simulateSystem = new System.Windows.Forms.Button();
            this.panelSolarSystem = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadPlanets
            // 
            this.loadPlanets.Location = new System.Drawing.Point(28, 22);
            this.loadPlanets.Name = "loadPlanets";
            this.loadPlanets.Size = new System.Drawing.Size(122, 23);
            this.loadPlanets.TabIndex = 0;
            this.loadPlanets.Text = "Load Planets";
            this.loadPlanets.UseVisualStyleBackColor = true;
            this.loadPlanets.Click += new System.EventHandler(this.loadPlanets_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(222, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(611, 367);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1085, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Calculate Escape Velocity ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(994, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(359, 206);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(377, 31);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(291, 34);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "Planets in the Solar System";
            // 
            // planetsDescription
            // 
            this.planetsDescription.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planetsDescription.Location = new System.Drawing.Point(292, 455);
            this.planetsDescription.Name = "planetsDescription";
            this.planetsDescription.Size = new System.Drawing.Size(429, 40);
            this.planetsDescription.TabIndex = 8;
            this.planetsDescription.Text = "";
            // 
            // planetsList_Box
            // 
            this.planetsList_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planetsList_Box.FormattingEnabled = true;
            this.planetsList_Box.ItemHeight = 25;
            this.planetsList_Box.Location = new System.Drawing.Point(28, 97);
            this.planetsList_Box.Name = "planetsList_Box";
            this.planetsList_Box.Size = new System.Drawing.Size(161, 279);
            this.planetsList_Box.TabIndex = 1;
            this.planetsList_Box.SelectedIndexChanged += new System.EventHandler(this.planetsList_Box_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1102, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "Get time and distance";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TimeAndDistance);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(1492, 428);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(422, 525);
            this.richTextBox3.TabIndex = 10;
            this.richTextBox3.Text = "Rocket: number of rocket engines: 4, acceleration per engine: 10 m/s^2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1500, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Planet";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1568, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1568, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1469, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Destination Planet";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1692, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Calculate ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CalculateDistance);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1786, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Initial location";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1786, 88);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Static System";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(1773, 120);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(125, 17);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "With Dinamic System";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(66, 473);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 22);
            this.button4.TabIndex = 19;
            this.button4.Text = "Solar System Info";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SolarSystemInfo);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.Location = new System.Drawing.Point(28, 517);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(665, 347);
            this.richTextBox4.TabIndex = 20;
            this.richTextBox4.Text = "1 AU (astronomical unit) is equal to 149597870.7 km";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(1492, 171);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(420, 231);
            this.richTextBox5.TabIndex = 21;
            this.richTextBox5.Text = "";
            // 
            // simulateSystem
            // 
            this.simulateSystem.Enabled = false;
            this.simulateSystem.Location = new System.Drawing.Point(1100, 948);
            this.simulateSystem.Name = "simulateSystem";
            this.simulateSystem.Size = new System.Drawing.Size(162, 29);
            this.simulateSystem.TabIndex = 22;
            this.simulateSystem.Text = "Simulate Solar System";
            this.simulateSystem.UseVisualStyleBackColor = true;
            this.simulateSystem.Click += new System.EventHandler(this.simulateSystem_Click);
            // 
            // panelSolarSystem
            // 
            this.panelSolarSystem.Location = new System.Drawing.Point(881, 362);
            this.panelSolarSystem.Name = "panelSolarSystem";
            this.panelSolarSystem.Size = new System.Drawing.Size(566, 580);
            this.panelSolarSystem.TabIndex = 0;
            this.panelSolarSystem.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSolarSystem_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1924, 1040);
            this.Controls.Add(this.simulateSystem);
            this.Controls.Add(this.panelSolarSystem);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.planetsDescription);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.planetsList_Box);
            this.Controls.Add(this.loadPlanets);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadPlanets;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox planetsDescription;
        private System.Windows.Forms.ListBox planetsList_Box;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.Button simulateSystem;
    }
}

