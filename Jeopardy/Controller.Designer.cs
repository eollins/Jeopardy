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
            this.sound = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.doubles = new System.Windows.Forms.Label();
            this.revealQuestion = new System.Windows.Forms.Button();
            this.finalJeopardy = new System.Windows.Forms.RadioButton();
            this.doubleJeopardy = new System.Windows.Forms.RadioButton();
            this.jeopardy = new System.Windows.Forms.RadioButton();
            this.answerBox = new System.Windows.Forms.Label();
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
            this.answerTimer = new System.Windows.Forms.Timer(this.components);
            this.export = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.image = new System.Windows.Forms.Button();
            this.response = new System.Windows.Forms.Button();
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
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
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
            // sound
            // 
            this.sound.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sound.Location = new System.Drawing.Point(633, 67);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(72, 23);
            this.sound.TabIndex = 96;
            this.sound.Tag = "c";
            this.sound.Text = "Sound";
            this.sound.UseVisualStyleBackColor = true;
            this.sound.Click += new System.EventHandler(this.sound_Click);
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
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.Control;
            this.clear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clear.Location = new System.Drawing.Point(473, 85);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(61, 39);
            this.clear.TabIndex = 94;
            this.clear.Tag = "c";
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
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
            // revealQuestion
            // 
            this.revealQuestion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.revealQuestion.Location = new System.Drawing.Point(12, 96);
            this.revealQuestion.Name = "revealQuestion";
            this.revealQuestion.Size = new System.Drawing.Size(152, 27);
            this.revealQuestion.TabIndex = 92;
            this.revealQuestion.Tag = "cont";
            this.revealQuestion.Text = "Reveal Question or Category";
            this.revealQuestion.UseVisualStyleBackColor = true;
            this.revealQuestion.Click += new System.EventHandler(this.revealQuestion_Click);
            // 
            // finalJeopardy
            // 
            this.finalJeopardy.AutoSize = true;
            this.finalJeopardy.ForeColor = System.Drawing.SystemColors.Control;
            this.finalJeopardy.Location = new System.Drawing.Point(443, 62);
            this.finalJeopardy.Name = "finalJeopardy";
            this.finalJeopardy.Size = new System.Drawing.Size(96, 17);
            this.finalJeopardy.TabIndex = 91;
            this.finalJeopardy.Text = "Final Jeopardy!";
            this.finalJeopardy.UseVisualStyleBackColor = true;
            // 
            // doubleJeopardy
            // 
            this.doubleJeopardy.AutoSize = true;
            this.doubleJeopardy.ForeColor = System.Drawing.SystemColors.Control;
            this.doubleJeopardy.Location = new System.Drawing.Point(329, 62);
            this.doubleJeopardy.Name = "doubleJeopardy";
            this.doubleJeopardy.Size = new System.Drawing.Size(108, 17);
            this.doubleJeopardy.TabIndex = 90;
            this.doubleJeopardy.Text = "Double Jeopardy!";
            this.doubleJeopardy.UseVisualStyleBackColor = true;
            // 
            // jeopardy
            // 
            this.jeopardy.AutoSize = true;
            this.jeopardy.Checked = true;
            this.jeopardy.ForeColor = System.Drawing.SystemColors.Control;
            this.jeopardy.Location = new System.Drawing.Point(244, 62);
            this.jeopardy.Name = "jeopardy";
            this.jeopardy.Size = new System.Drawing.Size(71, 17);
            this.jeopardy.TabIndex = 89;
            this.jeopardy.TabStop = true;
            this.jeopardy.Text = "Jeopardy!";
            this.jeopardy.UseVisualStyleBackColor = true;
            // 
            // answerBox
            // 
            this.answerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerBox.ForeColor = System.Drawing.SystemColors.Control;
            this.answerBox.Location = new System.Drawing.Point(224, 12);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(326, 49);
            this.answerBox.TabIndex = 86;
            this.answerBox.Text = "ANSWER";
            this.answerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.award1.Tag = "1";
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
            this.remove1.Tag = "1";
            this.remove1.Text = "Remove";
            this.remove1.UseVisualStyleBackColor = true;
            this.remove1.Click += new System.EventHandler(this.award1_Click);
            // 
            // remove2
            // 
            this.remove2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove2.Location = new System.Drawing.Point(131, 169);
            this.remove2.Name = "remove2";
            this.remove2.Size = new System.Drawing.Size(96, 27);
            this.remove2.TabIndex = 104;
            this.remove2.Tag = "2";
            this.remove2.Text = "Remove";
            this.remove2.UseVisualStyleBackColor = true;
            this.remove2.Click += new System.EventHandler(this.award1_Click);
            // 
            // award2
            // 
            this.award2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award2.Location = new System.Drawing.Point(131, 141);
            this.award2.Name = "award2";
            this.award2.Size = new System.Drawing.Size(96, 27);
            this.award2.TabIndex = 103;
            this.award2.Tag = "2";
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
            this.remove4.Tag = "4";
            this.remove4.Text = "Remove";
            this.remove4.UseVisualStyleBackColor = true;
            this.remove4.Click += new System.EventHandler(this.award1_Click);
            // 
            // award4
            // 
            this.award4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award4.Location = new System.Drawing.Point(371, 141);
            this.award4.Name = "award4";
            this.award4.Size = new System.Drawing.Size(96, 27);
            this.award4.TabIndex = 107;
            this.award4.Tag = "4";
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
            this.remove3.Tag = "3";
            this.remove3.Text = "Remove";
            this.remove3.UseVisualStyleBackColor = true;
            this.remove3.Click += new System.EventHandler(this.award1_Click);
            // 
            // award3
            // 
            this.award3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award3.Location = new System.Drawing.Point(252, 141);
            this.award3.Name = "award3";
            this.award3.Size = new System.Drawing.Size(96, 27);
            this.award3.TabIndex = 105;
            this.award3.Tag = "3";
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
            this.remove6.Tag = "6";
            this.remove6.Text = "Remove";
            this.remove6.UseVisualStyleBackColor = true;
            this.remove6.Click += new System.EventHandler(this.award1_Click);
            // 
            // award6
            // 
            this.award6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award6.Location = new System.Drawing.Point(609, 141);
            this.award6.Name = "award6";
            this.award6.Size = new System.Drawing.Size(96, 27);
            this.award6.TabIndex = 111;
            this.award6.Tag = "6";
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
            this.remove5.Tag = "5";
            this.remove5.Text = "Remove";
            this.remove5.UseVisualStyleBackColor = true;
            this.remove5.Click += new System.EventHandler(this.award1_Click);
            // 
            // award5
            // 
            this.award5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award5.Location = new System.Drawing.Point(490, 141);
            this.award5.Name = "award5";
            this.award5.Size = new System.Drawing.Size(96, 27);
            this.award5.TabIndex = 109;
            this.award5.Tag = "5";
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
            // answerTimer
            // 
            this.answerTimer.Enabled = true;
            this.answerTimer.Interval = 250;
            this.answerTimer.Tick += new System.EventHandler(this.answerTimer_Tick);
            // 
            // export
            // 
            this.export.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.export.Location = new System.Drawing.Point(556, 67);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(71, 23);
            this.export.TabIndex = 119;
            this.export.Tag = "c";
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(556, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 49);
            this.button2.TabIndex = 120;
            this.button2.Tag = "1";
            this.button2.Text = "Unlock";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.SystemColors.Control;
            this.image.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.image.Location = new System.Drawing.Point(556, 94);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(71, 33);
            this.image.TabIndex = 121;
            this.image.Tag = "c";
            this.image.Text = "Image";
            this.image.UseVisualStyleBackColor = false;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // response
            // 
            this.response.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.response.Location = new System.Drawing.Point(387, 85);
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(80, 39);
            this.response.TabIndex = 122;
            this.response.Tag = "cont";
            this.response.Text = "Reveal Response";
            this.response.UseVisualStyleBackColor = true;
            this.response.Click += new System.EventHandler(this.response_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(717, 217);
            this.Controls.Add(this.response);
            this.Controls.Add(this.image);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.export);
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
            this.Controls.Add(this.sound);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.doubles);
            this.Controls.Add(this.revealQuestion);
            this.Controls.Add(this.finalJeopardy);
            this.Controls.Add(this.doubleJeopardy);
            this.Controls.Add(this.jeopardy);
            this.Controls.Add(this.answerBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Controller";
            this.Text = "Controller";
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
        private System.Windows.Forms.Button sound;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label doubles;
        private System.Windows.Forms.Button revealQuestion;
        private System.Windows.Forms.RadioButton finalJeopardy;
        private System.Windows.Forms.RadioButton doubleJeopardy;
        private System.Windows.Forms.RadioButton jeopardy;
        private System.Windows.Forms.Label answerBox;
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
        private System.Windows.Forms.Timer answerTimer;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.Button response;
    }
}