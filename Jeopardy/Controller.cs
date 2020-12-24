using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class Controller : Form
    {
        public Controller()
        {
            InitializeComponent();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (auto.Checked) { Globals.gameType = 0; }
            else if (custom.Checked) { Globals.gameType = 1; }
            if (radioButton1.Checked) { Globals.round = 0; }
            else if (radioButton2.Checked) { Globals.round = 1; }
            else if (radioButton3.Checked) { Globals.round = 2; }
            Globals.generate = true;
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globals.reveal = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Globals.unlockState)
            {
                button2.Text = "Lock";
            }
            else
            {
                button2.Text = "Unlock";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Globals.clear = true;
        }

        private void award1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Globals.round < 2)
            {
                Globals.clear = true;
            }

            if (numericUpDown2.Value == 0)
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] += Globals.currentValue;
            }
            else
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] += (int)numericUpDown2.Value;
                numericUpDown2.Value = 0;
            }

            Globals.flash = new int[] { (int.Parse(btn.Tag.ToString())), 1 };
        }

        private void remove1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (numericUpDown2.Value == 0)
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] -= Globals.currentValue;
            }
            else
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] -= (int)numericUpDown2.Value;
                numericUpDown2.Value = 0;
            }

            Globals.flash = new int[] { (int.Parse(btn.Tag.ToString())), 0 };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Globals.sound = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Globals.end = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.export = true;
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            label1.Text = Globals.playerNames[0];
            label2.Text = Globals.playerNames[1];
            label3.Text = Globals.playerNames[2];
            label4.Text = Globals.playerNames[3];
            label5.Text = Globals.playerNames[4];
            label6.Text = Globals.playerNames[5];

            doubles.Text = Globals.dailyDoubles;
            label7.Text = Globals.answer;

            if (Globals.playerNames[0] == "")
            {
                award1.Hide();
                remove1.Hide();
                label1.Hide();
            }
            else
            {
                award1.Show();
                remove1.Show();
                label1.Show();
            }

            if (Globals.playerNames[1] == "")
            {
                award2.Hide();
                remove2.Hide();
                label2.Hide();
            }
            else
            {
                award2.Show();
                remove2.Show();
                label2.Show();
            }

            if (Globals.playerNames[2] == "")
            {
                award3.Hide();
                remove3.Hide();
                label3.Hide();
            }
            else
            {
                award3.Show();
                remove3.Show();
                label3.Show();
            }

            if (Globals.playerNames[3] == "")
            {
                award4.Hide();
                remove4.Hide();
                label4.Hide();
            }
            else
            {
                award4.Show();
                remove4.Show();
                label4.Show();

            }
            if (Globals.playerNames[4] == "")
            {
                award5.Hide();
                remove5.Hide();
                label5.Hide();
            }
            else
            {
                award5.Show();
                remove5.Show();
                label5.Show();
            }

            if (Globals.playerNames[5] == "")
            {
                award6.Hide();
                remove6.Hide();
                label6.Hide();
            }
            else
            {
                award6.Show();
                remove6.Show();
                label6.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globals.unlockButton = true;
            if (button2.Text == "Unlock")
            {
                button2.Text = "Lock";
            }
            else
            {
                button2.Text = "Unlock";
            }
        }
    }
}
