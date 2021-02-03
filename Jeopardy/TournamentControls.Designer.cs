namespace Jeopardy
{
    partial class TournamentControls
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
            this.gameList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.preloadJep = new System.Windows.Forms.Button();
            this.preloadDouble = new System.Windows.Forms.Button();
            this.preloadFinal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.jepLabel = new System.Windows.Forms.Label();
            this.doubleLabel = new System.Windows.Forms.Label();
            this.finalLabel = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // gameList
            // 
            this.gameList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameList.FormattingEnabled = true;
            this.gameList.ItemHeight = 20;
            this.gameList.Items.AddRange(new object[] {
            "Standard Game"});
            this.gameList.Location = new System.Drawing.Point(13, 30);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(369, 124);
            this.gameList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // connect
            // 
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.Location = new System.Drawing.Point(13, 160);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(369, 29);
            this.connect.TabIndex = 2;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // preloadJep
            // 
            this.preloadJep.Location = new System.Drawing.Point(13, 225);
            this.preloadJep.Name = "preloadJep";
            this.preloadJep.Size = new System.Drawing.Size(119, 23);
            this.preloadJep.TabIndex = 3;
            this.preloadJep.Tag = "1";
            this.preloadJep.Text = "Jeopardy";
            this.preloadJep.UseVisualStyleBackColor = true;
            this.preloadJep.Click += new System.EventHandler(this.preloadJep_Click);
            // 
            // preloadDouble
            // 
            this.preloadDouble.Location = new System.Drawing.Point(138, 225);
            this.preloadDouble.Name = "preloadDouble";
            this.preloadDouble.Size = new System.Drawing.Size(119, 23);
            this.preloadDouble.TabIndex = 4;
            this.preloadDouble.Tag = "2";
            this.preloadDouble.Text = "Double Jeopardy";
            this.preloadDouble.UseVisualStyleBackColor = true;
            this.preloadDouble.Click += new System.EventHandler(this.preloadJep_Click);
            // 
            // preloadFinal
            // 
            this.preloadFinal.Location = new System.Drawing.Point(263, 225);
            this.preloadFinal.Name = "preloadFinal";
            this.preloadFinal.Size = new System.Drawing.Size(119, 23);
            this.preloadFinal.TabIndex = 5;
            this.preloadFinal.Tag = "3";
            this.preloadFinal.Text = "Final Jeopardy";
            this.preloadFinal.UseVisualStyleBackColor = true;
            this.preloadFinal.Click += new System.EventHandler(this.preloadJep_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(13, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Preload Games";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // jepLabel
            // 
            this.jepLabel.BackColor = System.Drawing.Color.Red;
            this.jepLabel.Location = new System.Drawing.Point(13, 251);
            this.jepLabel.Name = "jepLabel";
            this.jepLabel.Size = new System.Drawing.Size(119, 8);
            this.jepLabel.TabIndex = 7;
            // 
            // doubleLabel
            // 
            this.doubleLabel.BackColor = System.Drawing.Color.Red;
            this.doubleLabel.Location = new System.Drawing.Point(138, 251);
            this.doubleLabel.Name = "doubleLabel";
            this.doubleLabel.Size = new System.Drawing.Size(119, 8);
            this.doubleLabel.TabIndex = 8;
            // 
            // finalLabel
            // 
            this.finalLabel.BackColor = System.Drawing.Color.Red;
            this.finalLabel.Location = new System.Drawing.Point(263, 251);
            this.finalLabel.Name = "finalLabel";
            this.finalLabel.Size = new System.Drawing.Size(119, 8);
            this.finalLabel.TabIndex = 9;
            // 
            // openFile
            // 
            this.openFile.Filter = "XML Game Files|*.xml";
            this.openFile.Title = "Open Game File";
            // 
            // TournamentControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(394, 267);
            this.Controls.Add(this.finalLabel);
            this.Controls.Add(this.doubleLabel);
            this.Controls.Add(this.jepLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.preloadFinal);
            this.Controls.Add(this.preloadDouble);
            this.Controls.Add(this.preloadJep);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TournamentControls";
            this.Text = "Tournament Controls";
            this.Load += new System.EventHandler(this.TournamentControls_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox gameList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button preloadJep;
        private System.Windows.Forms.Button preloadDouble;
        private System.Windows.Forms.Button preloadFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label jepLabel;
        private System.Windows.Forms.Label doubleLabel;
        private System.Windows.Forms.Label finalLabel;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}