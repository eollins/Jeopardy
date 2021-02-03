using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Jeopardy
{
    public partial class TournamentControls : Form
    {
        public class Game
        {
            public string gameID { get; set; }
            public List<string> firstID { get; set; }
            public List<string> secondID { get; set; }
            public List<string> thirdID { get; set; }
            public string name { get; set; }
        }

        GameBoard Board;

        public static Dictionary<GameBoard.Category, GameBoard.CategoryInfo> PreloadedJeopardy { get; set; }
        public static Dictionary<GameBoard.Category, GameBoard.CategoryInfo> PreloadedDouble { get; set; }
        public static Dictionary<GameBoard.Category, GameBoard.CategoryInfo> PreloadedFinal { get; set; }

        public TournamentControls(GameBoard board)
        {
            InitializeComponent();
            Board = board;
        }

        private void TournamentControls_Load(object sender, EventArgs e)
        {
            string data = Board.GameFunction("getTournamentGames", null, null);
            var result = JsonConvert.DeserializeObject<Game[]>(data);
            for (int i = 0; i < result.Length; i++)
            {
                gameList.Items.Add(result[i].name);
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            Board.BeginTournament(gameList.SelectedItem.ToString());
        }

        private void preloadJep_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Dictionary<GameBoard.Category, GameBoard.CategoryInfo> clues = new Dictionary<GameBoard.Category, GameBoard.CategoryInfo>();
                XmlDocument doc = new XmlDocument();
                doc.Load(openFile.FileName);
                XmlNodeList categories = ((XmlElement)doc.GetElementsByTagName("GameBoard")[0]).GetElementsByTagName("Category");

                foreach (XmlElement ele in categories)
                {
                    GameBoard.Category category = new GameBoard.Category(ele.GetAttribute("name"));
                    XmlNodeList clueList = ele.GetElementsByTagName("Clue");
                    GameBoard.Clue[] clueArray = new GameBoard.Clue[clueList.Count];
                    for (int i = 0; i < clueList.Count; i++)
                    {
                        XmlElement el = (XmlElement)clueList[i];
                        clueArray[i] = new GameBoard.Clue(el.GetAttribute("answer"), el.InnerText, el.GetAttribute("value"));
                        if (el.HasAttribute("image"))
                        {
                            clueArray[i].imageURL = el.GetAttribute("image");
                        }
                    }
                    GameBoard.CategoryInfo info = new GameBoard.CategoryInfo(ele.GetAttribute("name"), clueArray);
                    clues.Add(category, info);
                }

                Button btn = (Button)sender;
                if (btn.Tag.ToString() == "1")
                {
                    PreloadedJeopardy = clues;
                    jepLabel.BackColor = Color.LightGreen;
                }
                else if (btn.Tag.ToString() == "2")
                {
                    PreloadedDouble = clues;
                    doubleLabel.BackColor = Color.LightGreen;
                }
                else if (btn.Tag.ToString() == "3")
                {
                    PreloadedFinal = clues;
                    finalLabel.BackColor = Color.LightGreen;
                }
            }
        }
    }
}
