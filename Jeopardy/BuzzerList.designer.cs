namespace Jeopardy
{
    partial class BuzzerList
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
            this.listOfBuzzes = new System.Windows.Forms.ListBox();
            this.checkForBuzzes = new System.Windows.Forms.Timer(this.components);
            this.allowNew = new System.Windows.Forms.CheckBox();
            this.earlyPenalty = new System.Windows.Forms.CheckBox();
            this.autoImg = new System.Windows.Forms.CheckBox();
            this.timerLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.randomSelection = new System.Windows.Forms.CheckBox();
            this.millis = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.admit = new System.Windows.Forms.Button();
            this.deny = new System.Windows.Forms.Button();
            this.noPlayersMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.millis)).BeginInit();
            this.SuspendLayout();
            // 
            // listOfBuzzes
            // 
            this.listOfBuzzes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfBuzzes.FormattingEnabled = true;
            this.listOfBuzzes.ItemHeight = 24;
            this.listOfBuzzes.Location = new System.Drawing.Point(13, 13);
            this.listOfBuzzes.Name = "listOfBuzzes";
            this.listOfBuzzes.Size = new System.Drawing.Size(287, 124);
            this.listOfBuzzes.TabIndex = 0;
            // 
            // checkForBuzzes
            // 
            this.checkForBuzzes.Enabled = true;
            this.checkForBuzzes.Tick += new System.EventHandler(this.checkForBuzzes_Tick);
            // 
            // allowNew
            // 
            this.allowNew.AutoSize = true;
            this.allowNew.Checked = true;
            this.allowNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowNew.ForeColor = System.Drawing.SystemColors.Control;
            this.allowNew.Location = new System.Drawing.Point(13, 143);
            this.allowNew.Name = "allowNew";
            this.allowNew.Size = new System.Drawing.Size(113, 17);
            this.allowNew.TabIndex = 1;
            this.allowNew.Text = "Allow New Players";
            this.allowNew.UseVisualStyleBackColor = true;
            // 
            // earlyPenalty
            // 
            this.earlyPenalty.AutoSize = true;
            this.earlyPenalty.Checked = true;
            this.earlyPenalty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.earlyPenalty.ForeColor = System.Drawing.SystemColors.Control;
            this.earlyPenalty.Location = new System.Drawing.Point(13, 189);
            this.earlyPenalty.Name = "earlyPenalty";
            this.earlyPenalty.Size = new System.Drawing.Size(113, 17);
            this.earlyPenalty.TabIndex = 2;
            this.earlyPenalty.Text = "Early Buzz Penalty";
            this.earlyPenalty.UseVisualStyleBackColor = true;
            this.earlyPenalty.CheckedChanged += new System.EventHandler(this.earlyPenalty_CheckedChanged);
            // 
            // autoImg
            // 
            this.autoImg.AutoSize = true;
            this.autoImg.ForeColor = System.Drawing.SystemColors.Control;
            this.autoImg.Location = new System.Drawing.Point(13, 211);
            this.autoImg.Name = "autoImg";
            this.autoImg.Size = new System.Drawing.Size(110, 17);
            this.autoImg.TabIndex = 3;
            this.autoImg.Text = "Automatic Images";
            this.autoImg.UseVisualStyleBackColor = true;
            this.autoImg.CheckedChanged += new System.EventHandler(this.autoImg_CheckedChanged);
            // 
            // timerLength
            // 
            this.timerLength.Location = new System.Drawing.Point(156, 143);
            this.timerLength.Name = "timerLength";
            this.timerLength.Size = new System.Drawing.Size(43, 20);
            this.timerLength.TabIndex = 4;
            this.timerLength.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.timerLength.ValueChanged += new System.EventHandler(this.timerLength_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(205, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "seconds to answer";
            // 
            // randomSelection
            // 
            this.randomSelection.AutoSize = true;
            this.randomSelection.ForeColor = System.Drawing.SystemColors.Control;
            this.randomSelection.Location = new System.Drawing.Point(13, 234);
            this.randomSelection.Name = "randomSelection";
            this.randomSelection.Size = new System.Drawing.Size(270, 17);
            this.randomSelection.TabIndex = 6;
            this.randomSelection.Text = "Randomize selection under                    milliseconds";
            this.randomSelection.UseVisualStyleBackColor = true;
            this.randomSelection.CheckedChanged += new System.EventHandler(this.randomSelection_CheckedChanged);
            // 
            // millis
            // 
            this.millis.Location = new System.Drawing.Point(168, 233);
            this.millis.Name = "millis";
            this.millis.Size = new System.Drawing.Size(44, 20);
            this.millis.TabIndex = 7;
            this.millis.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(13, 166);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Require Player Approval";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Entering Players";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(13, 313);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(287, 29);
            this.nameBox.TabIndex = 10;
            this.nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameBox.Visible = false;
            // 
            // admit
            // 
            this.admit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admit.Location = new System.Drawing.Point(13, 349);
            this.admit.Name = "admit";
            this.admit.Size = new System.Drawing.Size(140, 32);
            this.admit.TabIndex = 11;
            this.admit.Text = "Admit";
            this.admit.UseVisualStyleBackColor = true;
            this.admit.Visible = false;
            this.admit.Click += new System.EventHandler(this.admit_Click);
            // 
            // deny
            // 
            this.deny.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deny.Location = new System.Drawing.Point(159, 349);
            this.deny.Name = "deny";
            this.deny.Size = new System.Drawing.Size(141, 32);
            this.deny.TabIndex = 12;
            this.deny.Text = "Deny";
            this.deny.UseVisualStyleBackColor = true;
            this.deny.Visible = false;
            this.deny.Click += new System.EventHandler(this.deny_Click);
            // 
            // noPlayersMsg
            // 
            this.noPlayersMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noPlayersMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPlayersMsg.ForeColor = System.Drawing.SystemColors.Control;
            this.noPlayersMsg.Location = new System.Drawing.Point(13, 313);
            this.noPlayersMsg.Name = "noPlayersMsg";
            this.noPlayersMsg.Size = new System.Drawing.Size(287, 68);
            this.noPlayersMsg.TabIndex = 13;
            this.noPlayersMsg.Text = "No players in queue";
            this.noPlayersMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Adj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BuzzerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(313, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deny);
            this.Controls.Add(this.admit);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.millis);
            this.Controls.Add(this.randomSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerLength);
            this.Controls.Add(this.autoImg);
            this.Controls.Add(this.earlyPenalty);
            this.Controls.Add(this.allowNew);
            this.Controls.Add(this.listOfBuzzes);
            this.Controls.Add(this.noPlayersMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BuzzerList";
            this.Text = "Buzzer List";
            ((System.ComponentModel.ISupportInitialize)(this.timerLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.millis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listOfBuzzes;
        private System.Windows.Forms.Timer checkForBuzzes;
        private System.Windows.Forms.CheckBox allowNew;
        private System.Windows.Forms.CheckBox earlyPenalty;
        private System.Windows.Forms.CheckBox autoImg;
        private System.Windows.Forms.NumericUpDown timerLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox randomSelection;
        private System.Windows.Forms.NumericUpDown millis;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button admit;
        private System.Windows.Forms.Button deny;
        private System.Windows.Forms.Label noPlayersMsg;
        private System.Windows.Forms.Button button1;
    }
}