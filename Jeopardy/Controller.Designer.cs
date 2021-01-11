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
            this.button1 = new System.Windows.Forms.Button();
            this.revealResponse = new System.Windows.Forms.Button();
            this.unlock = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customRadioBtn = new System.Windows.Forms.RadioButton();
            this.autoRadioBtn = new System.Windows.Forms.RadioButton();
            this.customWager = new System.Windows.Forms.NumericUpDown();
            this.dollarSign = new System.Windows.Forms.Label();
            this.soundBtn = new System.Windows.Forms.Button();
            this.endBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.doubles = new System.Windows.Forms.Label();
            this.revealButton = new System.Windows.Forms.Button();
            this.finalJeopardyBtn = new System.Windows.Forms.RadioButton();
            this.doubleJeopardyBtn = new System.Windows.Forms.RadioButton();
            this.jeopardyRadioBtn = new System.Windows.Forms.RadioButton();
            this.customWagerLabel = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.remove6 = new System.Windows.Forms.Button();
            this.award6 = new System.Windows.Forms.Button();
            this.remove5 = new System.Windows.Forms.Button();
            this.award5 = new System.Windows.Forms.Button();
            this.remove4 = new System.Windows.Forms.Button();
            this.award4 = new System.Windows.Forms.Button();
            this.remove3 = new System.Windows.Forms.Button();
            this.award3 = new System.Windows.Forms.Button();
            this.remove2 = new System.Windows.Forms.Button();
            this.award2 = new System.Windows.Forms.Button();
            this.remove1 = new System.Windows.Forms.Button();
            this.award1 = new System.Windows.Forms.Button();
            this.infoUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customWager)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(874, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 31);
            this.button1.TabIndex = 143;
            this.button1.Tag = "";
            this.button1.Text = "Image";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.image_Click);
            // 
            // revealResponse
            // 
            this.revealResponse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.revealResponse.Location = new System.Drawing.Point(535, 128);
            this.revealResponse.Name = "revealResponse";
            this.revealResponse.Size = new System.Drawing.Size(160, 31);
            this.revealResponse.TabIndex = 142;
            this.revealResponse.Tag = "";
            this.revealResponse.Text = "Reveal Response";
            this.revealResponse.UseVisualStyleBackColor = true;
            this.revealResponse.Visible = false;
            this.revealResponse.Click += new System.EventHandler(this.response_Click);
            // 
            // unlock
            // 
            this.unlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unlock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.unlock.Location = new System.Drawing.Point(228, 128);
            this.unlock.Name = "unlock";
            this.unlock.Size = new System.Drawing.Size(131, 31);
            this.unlock.TabIndex = 141;
            this.unlock.Tag = "";
            this.unlock.Text = "Unlock";
            this.unlock.UseVisualStyleBackColor = true;
            this.unlock.Click += new System.EventHandler(this.button2_Click);
            // 
            // export
            // 
            this.export.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.export.Location = new System.Drawing.Point(874, 105);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(79, 20);
            this.export.TabIndex = 140;
            this.export.Tag = "";
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customRadioBtn);
            this.panel1.Controls.Add(this.autoRadioBtn);
            this.panel1.Location = new System.Drawing.Point(12, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 23);
            this.panel1.TabIndex = 138;
            // 
            // customRadioBtn
            // 
            this.customRadioBtn.AutoSize = true;
            this.customRadioBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.customRadioBtn.Location = new System.Drawing.Point(119, 3);
            this.customRadioBtn.Name = "customRadioBtn";
            this.customRadioBtn.Size = new System.Drawing.Size(91, 17);
            this.customRadioBtn.TabIndex = 84;
            this.customRadioBtn.Text = "Custom Game";
            this.customRadioBtn.UseVisualStyleBackColor = true;
            // 
            // autoRadioBtn
            // 
            this.autoRadioBtn.AutoSize = true;
            this.autoRadioBtn.Checked = true;
            this.autoRadioBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.autoRadioBtn.Location = new System.Drawing.Point(0, 3);
            this.autoRadioBtn.Name = "autoRadioBtn";
            this.autoRadioBtn.Size = new System.Drawing.Size(103, 17);
            this.autoRadioBtn.TabIndex = 83;
            this.autoRadioBtn.TabStop = true;
            this.autoRadioBtn.Text = "Automatic Game";
            this.autoRadioBtn.UseVisualStyleBackColor = true;
            // 
            // customWager
            // 
            this.customWager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customWager.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.customWager.Location = new System.Drawing.Point(577, 73);
            this.customWager.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.customWager.Name = "customWager";
            this.customWager.Size = new System.Drawing.Size(89, 26);
            this.customWager.TabIndex = 127;
            // 
            // dollarSign
            // 
            this.dollarSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dollarSign.ForeColor = System.Drawing.SystemColors.Control;
            this.dollarSign.Location = new System.Drawing.Point(553, 73);
            this.dollarSign.Name = "dollarSign";
            this.dollarSign.Size = new System.Drawing.Size(25, 27);
            this.dollarSign.TabIndex = 137;
            this.dollarSign.Text = "$";
            // 
            // soundBtn
            // 
            this.soundBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.soundBtn.Location = new System.Drawing.Point(1001, 66);
            this.soundBtn.Name = "soundBtn";
            this.soundBtn.Size = new System.Drawing.Size(78, 33);
            this.soundBtn.TabIndex = 136;
            this.soundBtn.Tag = "";
            this.soundBtn.Text = "Play Sound";
            this.soundBtn.UseVisualStyleBackColor = true;
            this.soundBtn.Click += new System.EventHandler(this.sound_Click);
            // 
            // endBtn
            // 
            this.endBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endBtn.Location = new System.Drawing.Point(1001, 103);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(78, 54);
            this.endBtn.TabIndex = 135;
            this.endBtn.Tag = "";
            this.endBtn.Text = "End";
            this.endBtn.UseVisualStyleBackColor = true;
            this.endBtn.Click += new System.EventHandler(this.button18_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearBtn.Location = new System.Drawing.Point(365, 128);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(122, 31);
            this.clearBtn.TabIndex = 134;
            this.clearBtn.Tag = "";
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clear_Click);
            // 
            // doubles
            // 
            this.doubles.AutoSize = true;
            this.doubles.ForeColor = System.Drawing.SystemColors.Control;
            this.doubles.Location = new System.Drawing.Point(871, 62);
            this.doubles.Name = "doubles";
            this.doubles.Size = new System.Drawing.Size(82, 39);
            this.doubles.TabIndex = 133;
            this.doubles.Text = "Daily Doubles:\r\nc1v200\r\nc2v400 c3v600";
            // 
            // revealButton
            // 
            this.revealButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.revealButton.Location = new System.Drawing.Point(535, 128);
            this.revealButton.Name = "revealButton";
            this.revealButton.Size = new System.Drawing.Size(160, 31);
            this.revealButton.TabIndex = 132;
            this.revealButton.Tag = "";
            this.revealButton.Text = "Reveal Question or Category";
            this.revealButton.UseVisualStyleBackColor = true;
            this.revealButton.Click += new System.EventHandler(this.revealQuestion_Click);
            // 
            // finalJeopardyBtn
            // 
            this.finalJeopardyBtn.AutoSize = true;
            this.finalJeopardyBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.finalJeopardyBtn.Location = new System.Drawing.Point(738, 123);
            this.finalJeopardyBtn.Name = "finalJeopardyBtn";
            this.finalJeopardyBtn.Size = new System.Drawing.Size(96, 17);
            this.finalJeopardyBtn.TabIndex = 131;
            this.finalJeopardyBtn.Text = "Final Jeopardy!";
            this.finalJeopardyBtn.UseVisualStyleBackColor = true;
            // 
            // doubleJeopardyBtn
            // 
            this.doubleJeopardyBtn.AutoSize = true;
            this.doubleJeopardyBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.doubleJeopardyBtn.Location = new System.Drawing.Point(738, 103);
            this.doubleJeopardyBtn.Name = "doubleJeopardyBtn";
            this.doubleJeopardyBtn.Size = new System.Drawing.Size(108, 17);
            this.doubleJeopardyBtn.TabIndex = 130;
            this.doubleJeopardyBtn.Text = "Double Jeopardy!";
            this.doubleJeopardyBtn.UseVisualStyleBackColor = true;
            // 
            // jeopardyRadioBtn
            // 
            this.jeopardyRadioBtn.AutoSize = true;
            this.jeopardyRadioBtn.Checked = true;
            this.jeopardyRadioBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.jeopardyRadioBtn.Location = new System.Drawing.Point(738, 83);
            this.jeopardyRadioBtn.Name = "jeopardyRadioBtn";
            this.jeopardyRadioBtn.Size = new System.Drawing.Size(71, 17);
            this.jeopardyRadioBtn.TabIndex = 129;
            this.jeopardyRadioBtn.TabStop = true;
            this.jeopardyRadioBtn.Text = "Jeopardy!";
            this.jeopardyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // customWagerLabel
            // 
            this.customWagerLabel.AutoSize = true;
            this.customWagerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.customWagerLabel.Location = new System.Drawing.Point(590, 105);
            this.customWagerLabel.Name = "customWagerLabel";
            this.customWagerLabel.Size = new System.Drawing.Size(58, 13);
            this.customWagerLabel.TabIndex = 128;
            this.customWagerLabel.Text = "Clue Value";
            // 
            // answerBox
            // 
            this.answerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerBox.ForeColor = System.Drawing.SystemColors.Control;
            this.answerBox.Location = new System.Drawing.Point(228, 68);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(259, 52);
            this.answerBox.TabIndex = 126;
            this.answerBox.Text = "ANSWER";
            this.answerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generateBtn.Location = new System.Drawing.Point(12, 68);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(206, 60);
            this.generateBtn.TabIndex = 125;
            this.generateBtn.Tag = "";
            this.generateBtn.Text = "Generate Game";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generate_Click);
            // 
            // remove6
            // 
            this.remove6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove6.Location = new System.Drawing.Point(1003, 12);
            this.remove6.Name = "remove6";
            this.remove6.Size = new System.Drawing.Size(78, 30);
            this.remove6.TabIndex = 155;
            this.remove6.Tag = "6";
            this.remove6.Text = "Remove";
            this.remove6.UseVisualStyleBackColor = true;
            this.remove6.Visible = false;
            this.remove6.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award6
            // 
            this.award6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award6.Location = new System.Drawing.Point(915, 12);
            this.award6.Name = "award6";
            this.award6.Size = new System.Drawing.Size(82, 30);
            this.award6.TabIndex = 154;
            this.award6.Tag = "6";
            this.award6.Text = "Award";
            this.award6.UseVisualStyleBackColor = true;
            this.award6.Visible = false;
            this.award6.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // remove5
            // 
            this.remove5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove5.Location = new System.Drawing.Point(822, 12);
            this.remove5.Name = "remove5";
            this.remove5.Size = new System.Drawing.Size(78, 30);
            this.remove5.TabIndex = 153;
            this.remove5.Tag = "5";
            this.remove5.Text = "Remove";
            this.remove5.UseVisualStyleBackColor = true;
            this.remove5.Visible = false;
            this.remove5.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award5
            // 
            this.award5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award5.Location = new System.Drawing.Point(734, 12);
            this.award5.Name = "award5";
            this.award5.Size = new System.Drawing.Size(82, 30);
            this.award5.TabIndex = 152;
            this.award5.Tag = "5";
            this.award5.Text = "Award";
            this.award5.UseVisualStyleBackColor = true;
            this.award5.Visible = false;
            this.award5.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // remove4
            // 
            this.remove4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove4.Location = new System.Drawing.Point(641, 12);
            this.remove4.Name = "remove4";
            this.remove4.Size = new System.Drawing.Size(78, 30);
            this.remove4.TabIndex = 151;
            this.remove4.Tag = "4";
            this.remove4.Text = "Remove";
            this.remove4.UseVisualStyleBackColor = true;
            this.remove4.Visible = false;
            this.remove4.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award4
            // 
            this.award4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award4.Location = new System.Drawing.Point(553, 12);
            this.award4.Name = "award4";
            this.award4.Size = new System.Drawing.Size(82, 30);
            this.award4.TabIndex = 150;
            this.award4.Tag = "4";
            this.award4.Text = "Award";
            this.award4.UseVisualStyleBackColor = true;
            this.award4.Visible = false;
            this.award4.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // remove3
            // 
            this.remove3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove3.Location = new System.Drawing.Point(462, 12);
            this.remove3.Name = "remove3";
            this.remove3.Size = new System.Drawing.Size(78, 30);
            this.remove3.TabIndex = 149;
            this.remove3.Tag = "3";
            this.remove3.Text = "Remove";
            this.remove3.UseVisualStyleBackColor = true;
            this.remove3.Visible = false;
            this.remove3.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award3
            // 
            this.award3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award3.Location = new System.Drawing.Point(374, 12);
            this.award3.Name = "award3";
            this.award3.Size = new System.Drawing.Size(82, 30);
            this.award3.TabIndex = 148;
            this.award3.Tag = "3";
            this.award3.Text = "Award";
            this.award3.UseVisualStyleBackColor = true;
            this.award3.Visible = false;
            this.award3.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // remove2
            // 
            this.remove2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove2.Location = new System.Drawing.Point(281, 12);
            this.remove2.Name = "remove2";
            this.remove2.Size = new System.Drawing.Size(78, 30);
            this.remove2.TabIndex = 147;
            this.remove2.Tag = "2";
            this.remove2.Text = "Remove";
            this.remove2.UseVisualStyleBackColor = true;
            this.remove2.Visible = false;
            this.remove2.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award2
            // 
            this.award2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award2.Location = new System.Drawing.Point(193, 12);
            this.award2.Name = "award2";
            this.award2.Size = new System.Drawing.Size(82, 30);
            this.award2.TabIndex = 146;
            this.award2.Tag = "2";
            this.award2.Text = "Award";
            this.award2.UseVisualStyleBackColor = true;
            this.award2.Visible = false;
            this.award2.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // remove1
            // 
            this.remove1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remove1.Location = new System.Drawing.Point(100, 12);
            this.remove1.Name = "remove1";
            this.remove1.Size = new System.Drawing.Size(78, 30);
            this.remove1.TabIndex = 145;
            this.remove1.Tag = "1";
            this.remove1.Text = "Remove";
            this.remove1.UseVisualStyleBackColor = true;
            this.remove1.Visible = false;
            this.remove1.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // award1
            // 
            this.award1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.award1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.award1.Location = new System.Drawing.Point(12, 12);
            this.award1.Name = "award1";
            this.award1.Size = new System.Drawing.Size(82, 30);
            this.award1.TabIndex = 144;
            this.award1.Tag = "1";
            this.award1.Text = "Award";
            this.award1.UseVisualStyleBackColor = true;
            this.award1.Visible = false;
            this.award1.Click += new System.EventHandler(this.awardAndRemove_Click);
            // 
            // infoUpdate
            // 
            this.infoUpdate.Enabled = true;
            this.infoUpdate.Tick += new System.EventHandler(this.infoUpdate_Tick);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1089, 166);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.revealResponse);
            this.Controls.Add(this.unlock);
            this.Controls.Add(this.export);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customWager);
            this.Controls.Add(this.dollarSign);
            this.Controls.Add(this.soundBtn);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.doubles);
            this.Controls.Add(this.revealButton);
            this.Controls.Add(this.finalJeopardyBtn);
            this.Controls.Add(this.doubleJeopardyBtn);
            this.Controls.Add(this.jeopardyRadioBtn);
            this.Controls.Add(this.customWagerLabel);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.generateBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Controller";
            this.Text = "Controller";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customWager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void EndBtn_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button revealResponse;
        private System.Windows.Forms.Button unlock;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton customRadioBtn;
        private System.Windows.Forms.RadioButton autoRadioBtn;
        private System.Windows.Forms.NumericUpDown customWager;
        private System.Windows.Forms.Label dollarSign;
        private System.Windows.Forms.Button soundBtn;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label doubles;
        private System.Windows.Forms.Button revealButton;
        private System.Windows.Forms.RadioButton finalJeopardyBtn;
        private System.Windows.Forms.RadioButton doubleJeopardyBtn;
        private System.Windows.Forms.RadioButton jeopardyRadioBtn;
        private System.Windows.Forms.Label customWagerLabel;
        private System.Windows.Forms.Label answerBox;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button remove6;
        private System.Windows.Forms.Button award6;
        private System.Windows.Forms.Button remove5;
        private System.Windows.Forms.Button award5;
        private System.Windows.Forms.Button remove4;
        private System.Windows.Forms.Button award4;
        private System.Windows.Forms.Button remove3;
        private System.Windows.Forms.Button award3;
        private System.Windows.Forms.Button remove2;
        private System.Windows.Forms.Button award2;
        private System.Windows.Forms.Button remove1;
        private System.Windows.Forms.Button award1;
        private System.Windows.Forms.Timer infoUpdate;
    }
}