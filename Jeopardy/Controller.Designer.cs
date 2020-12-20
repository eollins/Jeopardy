namespace Jeopardy
{
    partial class Controller
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
            this.components = new System.ComponentModel.Container();
            this.generate = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.doubles = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.auto = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.custom = new System.Windows.Forms.RadioButton();
            this.award1 = new System.Windows.Forms.Button();
            this.remove1 = new System.Windows.Forms.Button();
            this.remove2 = new System.Windows.Forms.Button();
            this.award2 = new System.Windows.Forms.Button();
            this.remove4 = new System.Windows.Forms.Button();
            this.award4 = new System.Windows.Forms.Button();
            this.remove3 = new System.Windows.Forms.Button();
            this.award3 = new System.Windows.Forms.Button();
            this.remove6 = new System.Windows.Forms.Button();
            this.award6 = new System.Windows.Forms.Button();
            this.remove5 = new System.Windows.Forms.Button();
            this.award5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generate.Location = new System.Drawing.Point(12, 12);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(206, 49);
            this.generate.TabIndex = 85;
            this.generate.Tag = "j";
            this.generate.Text = "Generate Game";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(121, -374);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(91, 17);
            this.radioButton5.TabIndex = 99;
            this.radioButton5.Text = "Custom Game";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(2, -374);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(103, 17);
            this.radioButton4.TabIndex = 98;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Automatic Game";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(195, 97);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(89, 26);
            this.numericUpDown2.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(171, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 27);
            this.label9.TabIndex = 97;
            this.label9.Text = "$";
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(477, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(27, 29);
            this.button6.TabIndex = 96;
            this.button6.Tag = "c";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button18
            // 
            this.button18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button18.Location = new System.Drawing.Point(633, 94);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(72, 33);
            this.button18.TabIndex = 95;
            this.button18.Tag = "c";
            this.button18.Text = "End";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(410, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 29);
            this.button5.TabIndex = 94;
            this.button5.Tag = "c";
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // doubles
            // 
            this.doubles.AutoSize = true;
            this.doubles.BackColor = System.Drawing.SystemColors.Control;
            this.doubles.Location = new System.Drawing.Point(299, 85);
            this.doubles.Name = "doubles";
            this.doubles.Size = new System.Drawing.Size(82, 39);
            this.doubles.TabIndex = 93;
            this.doubles.Text = "Daily Doubles:\r\nc1v200\r\nc2v400 c3v600";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(12, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 27);
            this.button4.TabIndex = 92;
            this.button4.Tag = "cont";
            this.button4.Text = "Reveal Question or Category";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton3.Location = new System.Drawing.Point(609, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(96, 17);
            this.radioButton3.TabIndex = 91;
            this.radioButton3.Text = "Final Jeopardy!";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton2.Location = new System.Drawing.Point(495, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 90;
            this.radioButton2.Text = "Double Jeopardy!";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton1.Location = new System.Drawing.Point(410, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 89;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Jeopardy!";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(224, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(481, 49);
            this.label7.TabIndex = 86;
            this.label7.Text = "ANSWER";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // auto
            // 
            this.auto.AutoSize = true;
            this.auto.Checked = true;
            this.auto.ForeColor = System.Drawing.SystemColors.Control;
            this.auto.Location = new System.Drawing.Point(0, 2);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(103, 17);
            this.auto.TabIndex = 83;
            this.auto.TabStop = true;
            this.auto.Text = "Automatic Game";
            this.auto.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.custom);
            this.panel1.Controls.Add(this.auto);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 23);
            this.panel1.TabIndex = 100;
            // 
            // custom
            // 
            this.custom.AutoSize = true;
            this.custom.ForeColor = System.Drawing.SystemColors.Control;
            this.custom.Location = new System.Drawing.Point(119, 2);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(91, 17);
            this.custom.TabIndex = 84;
            this.custom.Text = "Custom Game";
            this.custom.UseVisualStyleBackColor = true;
            // 
            // award1
            // 
            this.award1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award1.Location = new System.Drawing.Point(12, 141);
            this.award1.Name = "award1";
            this.award1.Size = new System.Drawing.Size(96, 27);
            this.award1.TabIndex = 101;
            this.award1.Tag = "0";
            this.award1.Text = "Award";
            this.award1.UseVisualStyleBackColor = true;
            this.award1.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove1
            // 
            this.remove1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove1.Location = new System.Drawing.Point(12, 169);
            this.remove1.Name = "remove1";
            this.remove1.Size = new System.Drawing.Size(96, 27);
            this.remove1.TabIndex = 102;
            this.remove1.Tag = "0";
            this.remove1.Text = "Remove";
            this.remove1.UseVisualStyleBackColor = true;
            this.remove1.Click += new System.EventHandler(this.remove1_Click);
            // 
            // remove2
            // 
            this.remove2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove2.Location = new System.Drawing.Point(131, 169);
            this.remove2.Name = "remove2";
            this.remove2.Size = new System.Drawing.Size(96, 27);
            this.remove2.TabIndex = 104;
            this.remove2.Tag = "1";
            this.remove2.Text = "Remove";
            this.remove2.UseVisualStyleBackColor = true;
            this.remove2.Click += new System.EventHandler(this.remove1_Click);
            // 
            // award2
            // 
            this.award2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award2.Location = new System.Drawing.Point(131, 141);
            this.award2.Name = "award2";
            this.award2.Size = new System.Drawing.Size(96, 27);
            this.award2.TabIndex = 103;
            this.award2.Tag = "1";
            this.award2.Text = "Award";
            this.award2.UseVisualStyleBackColor = true;
            this.award2.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove4
            // 
            this.remove4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove4.Location = new System.Drawing.Point(371, 169);
            this.remove4.Name = "remove4";
            this.remove4.Size = new System.Drawing.Size(96, 27);
            this.remove4.TabIndex = 108;
            this.remove4.Tag = "3";
            this.remove4.Text = "Remove";
            this.remove4.UseVisualStyleBackColor = true;
            this.remove4.Click += new System.EventHandler(this.remove1_Click);
            // 
            // award4
            // 
            this.award4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award4.Location = new System.Drawing.Point(371, 141);
            this.award4.Name = "award4";
            this.award4.Size = new System.Drawing.Size(96, 27);
            this.award4.TabIndex = 107;
            this.award4.Tag = "3";
            this.award4.Text = "Award";
            this.award4.UseVisualStyleBackColor = true;
            this.award4.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove3
            // 
            this.remove3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove3.Location = new System.Drawing.Point(252, 169);
            this.remove3.Name = "remove3";
            this.remove3.Size = new System.Drawing.Size(96, 27);
            this.remove3.TabIndex = 106;
            this.remove3.Tag = "2";
            this.remove3.Text = "Remove";
            this.remove3.UseVisualStyleBackColor = true;
            this.remove3.Click += new System.EventHandler(this.remove1_Click);
            // 
            // award3
            // 
            this.award3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award3.Location = new System.Drawing.Point(252, 141);
            this.award3.Name = "award3";
            this.award3.Size = new System.Drawing.Size(96, 27);
            this.award3.TabIndex = 105;
            this.award3.Tag = "2";
            this.award3.Text = "Award";
            this.award3.UseVisualStyleBackColor = true;
            this.award3.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove6
            // 
            this.remove6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove6.Location = new System.Drawing.Point(609, 169);
            this.remove6.Name = "remove6";
            this.remove6.Size = new System.Drawing.Size(96, 27);
            this.remove6.TabIndex = 112;
            this.remove6.Tag = "5";
            this.remove6.Text = "Remove";
            this.remove6.UseVisualStyleBackColor = true;
            this.remove6.Click += new System.EventHandler(this.remove1_Click);
            // 
            // award6
            // 
            this.award6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award6.Location = new System.Drawing.Point(609, 141);
            this.award6.Name = "award6";
            this.award6.Size = new System.Drawing.Size(96, 27);
            this.award6.TabIndex = 111;
            this.award6.Tag = "5";
            this.award6.Text = "Award";
            this.award6.UseVisualStyleBackColor = true;
            this.award6.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove5
            // 
            this.remove5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove5.Location = new System.Drawing.Point(490, 169);
            this.remove5.Name = "remove5";
            this.remove5.Size = new System.Drawing.Size(96, 27);
            this.remove5.TabIndex = 110;
            this.remove5.Tag = "4";
            this.remove5.Text = "Remove";
            this.remove5.UseVisualStyleBackColor = true;
            this.remove5.Click += new System.EventHandler(this.remove1_Click);
            // 
            // award5
            // 
            this.award5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award5.Location = new System.Drawing.Point(490, 141);
            this.award5.Name = "award5";
            this.award5.Size = new System.Drawing.Size(96, 27);
            this.award5.TabIndex = 109;
            this.award5.Tag = "4";
            this.award5.Text = "Award";
            this.award5.UseVisualStyleBackColor = true;
            this.award5.Click += new System.EventHandler(this.award1_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "Player One";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(131, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 114;
            this.label2.Text = "Player Two";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(252, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 115;
            this.label3.Text = "Player Three";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(371, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 116;
            this.label4.Text = "Player Four";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(490, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 117;
            this.label5.Text = "Player Five";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(609, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 118;
            this.label6.Text = "Player Six";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(530, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 29);
            this.button1.TabIndex = 119;
            this.button1.Tag = "c";
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(717, 217);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remove6);
            this.Controls.Add(this.award6);
            this.Controls.Add(this.remove5);
            this.Controls.Add(this.award5);
            this.Controls.Add(this.remove4);
            this.Controls.Add(this.award4);
            this.Controls.Add(this.remove3);
            this.Controls.Add(this.award3);
            this.Controls.Add(this.remove2);
            this.Controls.Add(this.award2);
            this.Controls.Add(this.remove1);
            this.Controls.Add(this.award1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.doubles);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Controller";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label doubles;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton auto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton custom;
        private System.Windows.Forms.Button award1;
        private System.Windows.Forms.Button remove1;
        private System.Windows.Forms.Button remove2;
        private System.Windows.Forms.Button award2;
        private System.Windows.Forms.Button remove4;
        private System.Windows.Forms.Button award4;
        private System.Windows.Forms.Button remove3;
        private System.Windows.Forms.Button award3;
        private System.Windows.Forms.Button remove6;
        private System.Windows.Forms.Button award6;
        private System.Windows.Forms.Button remove5;
        private System.Windows.Forms.Button award5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}