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
    public partial class BuzzerList : Form
    {
        GameBoard Board;
        public static int SecondsToGive = 7;
        public static int[] RandomizeSelection = new int[] { 0, 0 };
        public static bool AutoImages = false;
        public static bool AcceptPlayers = true;
        public static bool EarlyBuzzPenalty = true;
        public BuzzerList(GameBoard board)
        {
            Board = board;
            InitializeComponent();
        }

        public void ChangeAcceptanceSetting(bool setting)
        {
            checkBox1.Checked = setting;
        }

        bool playerDisplayed = false;
        GameBoard.Player currentPlayer;
        List<GameBoard.Player> toBeAdmitted = new List<GameBoard.Player>();
        GameBoard.BuzzList lastList = null;
        private void checkForBuzzes_Tick(object sender, EventArgs e)
        {
            if (GameBoard.buzzes != null && GameBoard.buzzes.buzzes != null && GameBoard.buzzes != lastList && GameBoard.buzzes.buzzes.Length > 0)
            {
                listOfBuzzes.Items.Clear();
                double timestampOne = double.Parse(GameBoard.buzzes.buzzes[0].timestamp);
                foreach (GameBoard.Buzz b in GameBoard.buzzes.buzzes)
                {
                    listOfBuzzes.Items.Add(Board.IDtoName(int.Parse(b.playerID)) + " - " + (int)(double .Parse(b.timestamp) - timestampOne));
                }
                lastList = GameBoard.buzzes;
            }

            try
            {
                List<GameBoard.Player> players = GameBoard.gamePlayers;
                foreach (GameBoard.Player player in players)
                {
                    if (player.Admitted == 0 && !toBeAdmitted.Contains(player))
                    {
                        if (!checkBox1.Checked)
                            player.Admitted = 1;
                        else
                            toBeAdmitted.Add(player);
                    }
                }
            }
            catch
            {
                return;
            }

            if (!playerDisplayed && toBeAdmitted.Count > 0)
            {
                noPlayersMsg.Visible = false;
                nameBox.Visible = true;
                admit.Visible = true;
                deny.Visible = true;

                nameBox.Text = toBeAdmitted[0].Name;
                currentPlayer = toBeAdmitted[0];
                playerDisplayed = true;
            }
            else if (toBeAdmitted.Count == 0)
            {
                noPlayersMsg.Visible = true;
                nameBox.Visible = false;
                admit.Visible = false;
                deny.Visible = false;
            }
        }

        private void timerLength_ValueChanged(object sender, EventArgs e)
        {
            SecondsToGive = (int)timerLength.Value;
        }

        private void randomSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (randomSelection.Checked)
            {
                RandomizeSelection = new int[] { 1, (int)millis.Value };
            }
            else
            {
                RandomizeSelection = new int[] { 0, 0 };
            }
        }

        private void autoImg_CheckedChanged(object sender, EventArgs e)
        {
            AutoImages = autoImg.Checked;
        }

        private void earlyPenalty_CheckedChanged(object sender, EventArgs e)
        {
            EarlyBuzzPenalty = earlyPenalty.Checked;

            if (EarlyBuzzPenalty) 
            {
                Board.GameFunction("setPenalty", GameBoard.GameCode, "1");
            }
            else
            {
                Board.GameFunction("setPenalty", GameBoard.GameCode, "0");
            }
        }

        private void admit_Click(object sender, EventArgs e)
        {
            currentPlayer.Name = nameBox.Text;
            currentPlayer.Admitted = 1;
            toBeAdmitted.Remove(currentPlayer);
            Board.GameFunction("renamePlayer", nameBox.Text, currentPlayer.ID.ToString());
            playerDisplayed = false;
        }

        private void deny_Click(object sender, EventArgs e)
        {
            GameBoard.gamePlayers.Remove(currentPlayer);
            Board.GameFunction("removePlayer", currentPlayer.Name, null);
            toBeAdmitted.Remove(currentPlayer);
            playerDisplayed = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Size = new Size(329, 432);
            }
            else
            {
                this.Size = new Size(329, 302);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://random-word-api.herokuapp.com/word?number=1");
            WebResponse resp = request.GetResponse();
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            string data = reader.ReadToEnd().Substring(2);
            string word = "";
            word += data[0].ToString().ToUpper();
            for (int i = 1; i < data.Length - 2; i++)
            {
                word += data[i];
            }
            nameBox.Text = word + " " + nameBox.Text;
        }
    }
}
