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
            if (auto.Checked)
                board.AdjustSettings(0, 0);
            else if (custom.Checked)
                board.AdjustSettings(0, 1);

            board.generateBtn_Click(generate, new EventArgs());
        }

        private void revealQuestion_Click(object sender, EventArgs e)
        {
            board.reveal_Click(revealQuestion, new EventArgs());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            board.AdjustSettings(2, (int)numericUpDown2.Value);
        }

        private void response_Click(object sender, EventArgs e)
        {
            board.revealResponse_Click(response, new EventArgs());
        }

        private void clear_Click(object sender, EventArgs e)
        {
            board.clear_Click(clear, new EventArgs());
        }

        private void image_Click(object sender, EventArgs e)
        {
            board.button1_Click(image, new EventArgs());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            board.endBtn_Click(button18, new EventArgs());
        }

        private void sound_Click(object sender, EventArgs e)
        {
            board.soundBtn_Click(sound, new EventArgs());
        }

        private void export_Click(object sender, EventArgs e)
        {
            board.export_Click(export, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.unlock_Click(button2, new EventArgs());
            if (Lock)
            {
                button2.Text = "Unlock";
            }
            else
            {
                button2.Text = "Lock";
            }
        }

        private void award1_Click(object sender, EventArgs e)
        {
            board.awardAndRemove_Click((Button)sender, new EventArgs());
        }

        private void answerTimer_Tick(object sender, EventArgs e)
        {
            answerBox.Text = Answer;
            if (Lock)
            {
                button2.Text = "Unlock";
            }
            else
            {
                button2.Text = "Lock";
            }
        }
    }
}
