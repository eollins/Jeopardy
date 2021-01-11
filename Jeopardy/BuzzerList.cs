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
                listBox1.Items.Clear();
                double timestampOne = double.Parse(GameBoard.buzzes.buzzes[0].timestamp);
                foreach (GameBoard.Buzz b in GameBoard.buzzes.buzzes)
                {
                    listBox1.Items.Add(Board.IDtoName(int.Parse(b.playerID)) + " - " + (int)(double.Parse(b.timestamp) - timestampOne));
                }
                lastList = GameBoard.buzzes;
            }
        }
    }
}
