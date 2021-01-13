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
    }
}
