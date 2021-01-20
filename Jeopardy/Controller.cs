using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class Controller : Form
    {
        public static string Answer = "ANSWER";
        public static bool Lock = false;
        public static string DailyDoubles = "";
        public static int PlayerCount = 0;
        public static int WagerValue = 0;

        public Controller()
        {
            InitializeComponent();
        }

        GameBoard board = null;
        public Controller(Form board)
        {
            InitializeComponent();
            this.board = board as GameBoard;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (autoRadioBtn.Checked)
                board.AdjustSettings(0, 0);
            else if (customRadioBtn.Checked)
                board.AdjustSettings(0, 1);

            if (jeopardyRadioBtn.Checked)
                board.AdjustSettings(1, 0);
            else if (doubleJeopardyBtn.Checked)
                board.AdjustSettings(1, 1);
            else if (finalJeopardyBtn.Checked)
                board.AdjustSettings(1, 2);

            if (jeopardyRadioBtn.Checked || doubleJeopardyBtn.Checked)
            {
                revealButton.Visible = true;
                revealResponse.Visible = false;
            }

            board.generateBtn_Click(generateBtn, new EventArgs());
        }

        private void revealQuestion_Click(object sender, EventArgs e)
        {
            board.reveal_Click(revealButton, new EventArgs());
            if (finalJeopardyBtn.Checked)
            {
                revealButton.Visible = false;
                revealResponse.Visible = true;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            board.AdjustSettings(2, (int)customWager.Value);
        }

        private void response_Click(object sender, EventArgs e)
        {
            board.revealResponse_Click(revealResponse, new EventArgs());
        }

        private void clear_Click(object sender, EventArgs e)
        {
            board.clear_Click(clearBtn, new EventArgs());
        }

        private void image_Click(object sender, EventArgs e)
        {
            board.button1_Click(button1, new EventArgs());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            board.endBtn_Click(endBtn, new EventArgs());
        }

        private void sound_Click(object sender, EventArgs e)
        {
            board.soundBtn_Click(soundBtn, new EventArgs());
        }

        private void export_Click(object sender, EventArgs e)
        {
            board.export_Click(export, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.unlock_Click(unlock, new EventArgs());
            if (Lock)
            {
                unlock.Text = "Unlock";
            }
            else
            {
                unlock.Text = "Lock";
            }
        }

        private void award1_Click(object sender, EventArgs e)
        {

        }

        private void answerTimer_Tick(object sender, EventArgs e)
        {

        }

        private void awardAndRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            board.AdjustSettings(2, (int)customWager.Value);
            board.awardAndRemove_Click(btn, new EventArgs());
        }

        private void infoUpdate_Tick(object sender, EventArgs e)
        {
            doubles.Text = DailyDoubles;
            answerBox.Text = Answer;

            answerBox.Text = Answer;
            if (Lock)
            {
                unlock.Text = "Unlock";
            }
            else
            {
                unlock.Text = "Lock";
            }

            customWager.Value = WagerValue;

            if (PlayerCount == 0)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) < 7))
                {
                    btn.Visible = false;
                }
            }
            else if (PlayerCount == 1)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) > 1))
                {
                    btn.Visible = false;
                }

                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 1))
                {
                    btn.Visible = true;
                }
            }
            else if (PlayerCount == 2)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) > 2))
                {
                    btn.Visible = false;
                }

                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 2))
                {
                    btn.Visible = true;
                }
            }
            else if (PlayerCount == 3)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) > 3))
                {
                    btn.Visible = false;
                }

                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 3))
                {
                    btn.Visible = true;
                }
            }
            else if (PlayerCount == 4)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) > 4))
                {
                    btn.Visible = false;
                }

                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 4))
                {
                    btn.Visible = true;
                }
            }
            else if (PlayerCount == 5)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) > 5))
                {
                    btn.Visible = false;
                }

                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 5))
                {
                    btn.Visible = true;
                }
            }
            else if (PlayerCount == 6)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString() != "" && int.Parse(x.Tag.ToString()) <= 6))
                {
                    btn.Visible = true;
                }
            }
        }
    }
}
