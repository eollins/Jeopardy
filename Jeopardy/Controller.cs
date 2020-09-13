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
            label1.Text = Globals.playerNames[0];
            label2.Text = Globals.playerNames[1];
            label3.Text = Globals.playerNames[2];
            label4.Text = Globals.playerNames[3];
            label5.Text = Globals.playerNames[4];
            label6.Text = Globals.playerNames[5];

            doubles.Text = Globals.dailyDoubles;
            label7.Text = Globals.answer;

            if (Globals.playerNames[0] == "Player One")
            {
                award1.Hide();
                remove1.Hide();
                label1.Hide();
            }
            if (Globals.playerNames[1] == "Player Two")
            {
                award2.Hide();
                remove2.Hide();
                label2.Hide();
            }
            if (Globals.playerNames[2] == "Player Three")
            {
                award3.Hide();
                remove3.Hide();
                label3.Hide();
            }
            if (Globals.playerNames[3] == "Player Four")
            {
                award4.Hide();
                remove4.Hide();
                label4.Hide();
            }
            if (Globals.playerNames[4] == "Player Five")
            {
                award5.Hide();
                remove5.Hide();
                label5.Hide();
            }
            if (Globals.playerNames[5] == "Player Six")
            {
                award6.Hide();
                remove6.Hide();
                label6.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Globals.clear = true;
        }

        private void award1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (numericUpDown2.Value == 0)
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] += Globals.currentValue;
            }
            else
            {
                Globals.playerScores[int.Parse(btn.Tag.ToString())] += (int)numericUpDown2.Value;
                numericUpDown2.Value = 0;
            }
            Globals.clear = true;
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Globals.sound = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Globals.end = true;
        }
    }
}
