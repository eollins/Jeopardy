using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Jeopardy
{
    public partial class GameBoard : Form
    {
        public GameBoard form1;
        Random random = new Random();
        Dictionary<Category, CategoryInfo> clues = new Dictionary<Category, CategoryInfo>();
        List<Category> categories = new List<Category>();
        string dailyDouble = "";
        string djdd1 = "";
        string djdd2 = "";
        int currentValue = 0;
        string currentBtn = "";
        bool doubleJeopardy = false;
        bool finalJeopardy = false;
        Category finalJep;
        CategoryInfo finalJepInfo;
        bool tournamentEnabled = false;

        string tournamentConfigLocation;
        TournamentInfo tournamentInfo = new TournamentInfo();

        int player1score = 0;
        int player2score = 0;
        int player3score = 0;
        int player4score = 0;
        int player5score = 0;
        int player6score = 0;

        string jeopardyPreload;
        string doublePreload;
        string finalPreload;

        bool magnitude = false;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public GameBoard()
        {
            InitializeComponent();
            form1 = this;
        }

        public class Category
        {
            public Category(string Title)
            {
                title = Title;
            }

            public string id { get; set; }
            public string title { get; set; }
            public string clues_count { get; set; }
        }

        public class TournamentInfo
        {
            public string url { get; set; }
            public string user { get; set; }
            public string pswd { get; set; }
            public string db { get; set; }
            public Round[] rounds { get; set; }
            public string table { get; set; }
        }

        public class Round
        {
            public string name { get; set; }
            public string player1 { get; set; }
            public string player2 { get; set; }
            public string player3 { get; set; }
            public string player1Next { get; set; }
            public string player2Next { get; set; }
            public string player3Next { get; set; }
        }

        public class CategoryInfo
        {
            public CategoryInfo(string Title, Clue[] Clues)
            {
                title = Title;
                clues = Clues;
            }

            public string id { get; set; }
            public string title { get; set; }
            public string clues_count { get; set; }
            public Clue[] clues { get; set; }
        }

        public class Clue
        {
            public Clue(string Answer, string Question, string Value)
            {
                answer = Answer;
                question = Question;
                value = Value;
            }

            public string id { get; set; }
            public string answer { get; set; }
            public string question { get; set; }
            public string value { get; set; }
            public string airdate { get; set; }
            public string category_id { get; set; }
            public string game_id { get; set; }
            public string invalid_count { get; set; }
        }

        int delay = 400;
        public void ToggleBoard(bool enab)
        {
            if (!enab)
            {
                foreach (var btn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
                {
                    btn.Enabled = false;
                }
            }
            else
            {
                player.SoundLocation = "Board.wav";
                player.Play();
                for (int i = 1; i < 7; i++)
                {
                    foreach (var btn in Controls.OfType<Button>().Where(x => x.AccessibleDescription == i.ToString()))
                    {
                        btn.Enabled = true;
                    }
                    Thread.Sleep(delay);
                }
            }
        }

        private void c1v200_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Name;
            currentBtn = name;
            char category = name[1];
            int catID = int.Parse(category.ToString()) - 1;
            string value = name.Substring(3);
            HideBoard();
            btn.Tag = "gaert@" + value;

            clue.Visible = true;

            int valueIndex = 0;
            switch (value)
            {
                case "200":
                    valueIndex = 0;
                    break;
                case "400":
                    valueIndex = 1;
                    break;
                case "600":
                    valueIndex = 2;
                    break;
                case "800":
                    valueIndex = 3;
                    break;
                case "1000":
                    valueIndex = 4;
                    break;
            }


            
            List<Clue> cl = clues[categories[catID]].clues.Where(x => x.value == value).ToList();

            bool cluePresent;
            Clue c = null;

            try
            {
                c = cl[random.Next(0, cl.Count)];
            }
            catch
            {
                cluePresent = false;
            }

            cluePresent = true;
            if (c == null)
            {
                cluePresent = false;
            }

            if ((doubleJeopardy == false && name == dailyDouble) || (doubleJeopardy == true && (name == djdd1 || name == djdd2)))
            {
                clue.Text = "DAILY DOUBLE";
                player.SoundLocation = "DD.wav";
                player.Play();
                return;
            }

            if (cluePresent)
            {
                clue.Text = c.question.Replace("&", "&&");
                answerBox.Text = c.answer.Replace("&", "&&");
                currentValue = int.Parse(value);
                if (doubleJeopardy)
                {
                    currentValue *= 2;
                }
            }
            else
            {
                clue.Text = "NO CLUE AVAILABLE";
            }
        }

        public void HideBoard()
        {
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Hide();
            }
        }

        public void ShowBoard()
        {
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Show();
                answerBox.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] values = new string[] { "200", "400", "600", "800", "1000" };
            dailyDouble = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            djdd1 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            djdd2 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            ToggleBoard(false);

            doubles.Text = "Daily Doubles:\n" + dailyDouble + "\n" + djdd1 + " & " + djdd2;
            Globals.dailyDoubles = doubles.Text;
            gameModeComboBox.SelectedIndex = 0;
        }

        bool generate = true;
        private void generateBtn_Click(object sender, EventArgs e)
        {
            categories.Clear();
            clues.Clear();
            popOutBtn.Enabled = false;
            Globals.playerNames = new string[] { player1name.Text, player2name.Text, player3name.Text, player4name.Text, player5name.Text, player6name.Text };
            if (customRadioBtn.Checked || (magnitude && Globals.gameType == 1))
            {
                customRadioBtn.Checked = true;

                string fileUpload = "";
                if (jeopardyRadioBtn.Checked && jeopardyPreload != "")
                {
                    fileUpload = jeopardyPreload;
                }
                else if (doubleJeopardyBtn.Checked && doublePreload != null)
                {
                    fileUpload = doublePreload;
                }
                else if (finalJeopardyBtn.Checked && finalPreload != null)
                {
                    fileUpload = finalPreload;
                }
                else
                {
                    if (openGameBoard.ShowDialog() == DialogResult.OK)
                    {
                        fileUpload = openGameBoard.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                

                XDocument doc = new XDocument();
                doc = XDocument.Load(fileUpload);
                var nodes = doc.Element("GameBoard").Descendants().Where(t => t.Name == "Category");


                if (finalJeopardyBtn.Checked)
                {
                    var clueNode = nodes.ElementAt(0).Descendants("Clue").ElementAt(0);
                    string categoryName = nodes.ElementAt(0).Attribute("name").Value;
                    string answer = clueNode.Attribute("answer").Value;
                    string question = clueNode.Value;
                    string value = clueNode.Attribute("value").Value;
                    finalJepInfo = new CategoryInfo(categoryName, new Clue[] { new Clue(answer, question, value) });

                    HideBoard();
                    clue.Text = categoryName;
                    finalJeopardy = true;
                    clue.Visible = true;
                }

                for (int i = 0; i < nodes.Count(); i++)
                {
                    XElement el = nodes.ElementAt(i);
                    string categoryName = el.Attribute("name").Value;
                    Category cat = new Category(categoryName);
                    categories.Add(cat);

                    var nodelist = from ele in el.Descendants("Clue")
                                    orderby int.Parse(ele.Attribute("value").Value)
                                    select ele;

                    Clue[] clues2 = new Clue[nodelist.Count()];

                    int i2 = 0;
                    foreach (XElement el2 in nodelist)
                    {
                        clues2[i2] = new Clue(el2.Attribute("answer").Value, el2.Value, el2.Attribute("value").Value);
                        i2++;
                    }
                    CategoryInfo info = new CategoryInfo(categoryName, clues2);
                    clues.Add(cat, info);
                }

                generate = false;
            }
            else
            {
                MessageBox.Show("Invalid file. Please try again.");
            }

            player.Stop();
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'g'))
            {
                btnn.Tag = "board@" + btnn.Name.Substring(3);
                ShowBoard();
            }

            if (player1name.Text == "Player One")
            {
                player1name.Visible = false;
                p1score.Visible = false;
                award1.Visible = false;
                remove1.Visible = false;
            }
            else
            {
                player1name.Enabled = false;
                p1score.Visible = true;
            }

            if (player2name.Text == "Player Two")
            {
                player2name.Visible = false;
                p2score.Visible = false;
                award2.Visible = false;
                remove2.Visible = false;
            }
            else
            {
                player2name.Enabled = false;
                p2score.Visible = true;
            }

            if (player3name.Text == "Player Three")
            {
                player3name.Visible = false;
                p3score.Visible = false;
                award3.Visible = false;
                remove3.Visible = false;
            }
            else
            {
                player3name.Enabled = false;
                p3score.Visible = true;
            }

            if (player4name.Text == "Player Four")
            {
                player4name.Visible = false;
                p4score.Visible = false;
                award4.Visible = false;
                remove4.Visible = false;
            }
            else
            {
                player4name.Enabled = false;
                p4score.Visible = true;
            }

            if (player5name.Text == "Player Five")
            {
                player5name.Visible = false;
                p5score.Visible = false;
                award5.Visible = false;
                remove5.Visible = false;
            }
            else
            {
                player5name.Enabled = false;
                p5score.Visible = true;
            }

            if (player6name.Text == "Player Six")
            {
                player6name.Visible = false;
                p6score.Visible = false;
                award6.Visible = false;
                remove6.Visible = false;
            }
            else
            {
                player6name.Enabled = false;
                p6score.Visible = true;
            }

            if (c1v200.Enabled == false && !finalJeopardyBtn.Checked)
            {
                ToggleBoard(true);
            }

            generateGame();
        }

        public void generateGame()
        {
            if (generate)
            {
                autoRadioBtn.Checked = true;
                foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'g'))
                {
                    btnn.Tag = "board@" + btnn.Tag.ToString().Substring(btnn.Tag.ToString().IndexOf('@') + 1);
                }

                if (finalJeopardyBtn.Checked)
                {
                    int randomOffset2 = random.Next(0, 5000);
                    WebRequest request2 = WebRequest.Create("http://jservice.io/api/categories?count=1&offset=" + randomOffset2);
                    WebResponse response2 = request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                    string json3 = reader2.ReadToEnd();

                    Category[] category = JsonConvert.DeserializeObject<Category[]>(json3);
                    HideBoard();
                    clue.Visible = true;
                    clue.Text = category[0].title.ToUpper();
                    finalJep = category[0];
                    finalJeopardy = true;

                    return;
                }

                clues.Clear();
                categories.Clear();

                int randomOffset = random.Next(0, 5000);
                WebRequest request = WebRequest.Create("http://jservice.io/api/categories?count=6&offset=" + randomOffset);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();

                Category[] categories2 = JsonConvert.DeserializeObject<Category[]>(json);

                for (int i = 0; i < 6; i++)
                {
                    Category cat = categories2[i];
                    categories.Add(cat);
                    switch (i)
                    {
                        case 0:
                            cat1label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 1:
                            cat2label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 2:
                            cat3label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 3:
                            cat4label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 4:
                            cat5label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 5:
                            cat6label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                    }

                    WebRequest clueRequest = WebRequest.Create("http://jservice.io/api/category?id=" + cat.id);
                    WebResponse clueResponse = clueRequest.GetResponse();
                    StreamReader reader2 = new StreamReader(clueResponse.GetResponseStream());
                    string json2 = reader2.ReadToEnd();
                    CategoryInfo cat2 = JsonConvert.DeserializeObject<CategoryInfo>(json2);
                    clues.Add(cat, cat2);

                    int val = 200;
                    foreach (Clue cl in cat2.clues)
                    {
                        if (cl == null || cl.question == "")
                        {
                            string btnName = "c" + (i + 1) + "v" + val;

                            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Name == btnName))
                            {
                                btnn.Tag = "gaert@" + val;
                                btnn.Hide();
                            }
                        }
                        val += 200;
                    }
                }
            }
            else
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    Category cat = categories[i];
                    switch (i)
                    {
                        case 0:
                            cat1label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 1:
                            cat2label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 2:
                            cat3label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 3:
                            cat4label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 4:
                            cat5label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 5:
                            cat6label.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                    }

                    int val = 200;
                    foreach (Clue cl in clues[cat].clues)
                    {
                        if (cl == null || cl.question == "")
                        {
                            string btnName = "c" + (i + 1) + "v" + val;

                            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Name == btnName))
                            {
                                btnn.Tag = "gaert@" + val;
                                btnn.Hide();
                            }
                        }
                        val += 200;
                    }
                }
            }

            generate = true;

            HideBoard();
            clue.Visible = true;
            clue.Text = categories[0].title.ToUpper();

            cat1label.Visible = false;
            cat2label.Visible = false;
            cat3label.Visible = false;
            cat4label.Visible = false;
            cat5label.Visible = false;
            cat6label.Visible = false;

            if (jeopardyRadioBtn.Checked)
            {
                doubleJeopardy = false;
                finalJeopardy = false;
                foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
                {
                    if (btnn.Tag.ToString() == "board@200") { btnn.Text = "$200"; }
                    if (btnn.Tag.ToString() == "board@400") { btnn.Text = "$400"; }
                    if (btnn.Tag.ToString() == "board@600") { btnn.Text = "$600"; }
                    if (btnn.Tag.ToString() == "board@800") { btnn.Text = "$800"; }
                    if (btnn.Tag.ToString() == "board@1000") { btnn.Text = "$1000"; }
                }
            }
            else if (doubleJeopardyBtn.Checked)
            {
                doubleJeopardy = true;
                finalJeopardy = false;
                foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
                {
                    if (btnn.Tag.ToString() == "board@200") { btnn.Text = "$400"; }
                    if (btnn.Tag.ToString() == "board@400") { btnn.Text = "$800"; }
                    if (btnn.Tag.ToString() == "board@600") { btnn.Text = "$1200"; }
                    if (btnn.Tag.ToString() == "board@800") { btnn.Text = "$1600"; }
                    if (btnn.Tag.ToString() == "board@1000") { btnn.Text = "$2000"; }
                }
            }

        }

        private void reveal_Click(object sender, EventArgs e)
        { 
            if (finalJeopardyBtn.Checked)
            {
                CategoryInfo cat2 = null;
                if (autoRadioBtn.Checked)
                {
                    WebRequest clueRequest = WebRequest.Create("http://jservice.io/api/category?id=" + finalJep.id);
                    WebResponse clueResponse = clueRequest.GetResponse();
                    StreamReader reader2 = new StreamReader(clueResponse.GetResponseStream());
                    string json2 = reader2.ReadToEnd();
                    cat2 = JsonConvert.DeserializeObject<CategoryInfo>(json2);
                    clue.Text = cat2.clues[0].question;
                    answerBox.Text = cat2.clues[0].answer;
                }
                else
                {
                    cat2 = finalJepInfo;
                    clue.Text = finalJepInfo.clues[0].question;
                    answerBox.Text = finalJepInfo.clues[0].answer;
                }

                cat1label.Text = cat2.title.ToUpper().Replace("&", "&&");
                cat2label.Text = cat2.title.ToUpper().Replace("&", "&&");
                cat3label.Text = cat2.title.ToUpper().Replace("&", "&&");
                cat4label.Text = cat2.title.ToUpper().Replace("&", "&&");
                cat5label.Text = cat2.title.ToUpper().Replace("&", "&&");
                cat6label.Text = cat2.title.ToUpper().Replace("&", "&&");

                cat1label.Visible = true; cat2label.Visible = true; cat3label.Visible = true; cat4label.Visible = true; cat5label.Visible = true; cat6label.Visible = true;

                return;
            }

            if (clue.Text == cat1label.Text)
            {
                clue.Text = cat2label.Text;
                return;
            }
            else if (clue.Text == cat2label.Text)
            {
                clue.Text = cat3label.Text;
                return;
            }
            else if (clue.Text == cat3label.Text)
            {
                clue.Text = cat4label.Text;
                return;
            }
            else if (clue.Text == cat4label.Text)
            {
                clue.Text = cat5label.Text;
                return;
            }
            else if (clue.Text == cat5label.Text)
            {
                clue.Text = cat6label.Text;
                return;
            }
            else if (clue.Text == cat6label.Text)
            {
                cat1label.Visible = true;
                cat2label.Visible = true;
                cat3label.Visible = true;
                cat4label.Visible = true;
                cat5label.Visible = true;
                cat6label.Visible = true;

                clue.Visible = false;
                ShowBoard();
                return;
            }

            char category = currentBtn[1];
            int catID = int.Parse(category.ToString()) - 1;
            string value = currentBtn.Substring(3);

            Clue[] cl = clues[categories[catID]].clues;
            foreach (Clue c in cl)
            {
                if (c == null)
                {
                    continue;
                }

                if (c.value == value)
                {
                    if (c.question.Contains("&"))
                    {
                        c.question = c.question.Replace("&", "&&");
                    }

                    clue.Text = c.question;
                    answerBox.Text = c.answer;
                    currentValue = int.Parse(value);
                }
            }
        }

        private void awardAndRemove_Click(object sender, EventArgs e)
        {
            if (customWager.Value > 0)
            {
                currentValue = (int)customWager.Value;
            }

            Button btn = (Button)sender;
            string tag;
            tag = (string)btn.Tag;

            if ((btn.Text == "Remove" && currentValue > 0) || (btn.Text == "Award" && currentValue < 0))
            {
                currentValue *= -1;
            }

            if (tag == "1")
            {
                player1score += currentValue;
                p1score.Text = "$" + player1score;
            }
            else if (tag == "2")
            {
                player2score += currentValue;
                p2score.Text = "$" + player2score;
            }
            else if (tag == "3")
            {
                player3score += currentValue;
                p3score.Text = "$" + player3score;
            }
            else if (tag == "4")
            {
                player4score += currentValue;
                p4score.Text = "$" + player4score;
            }
            else if (tag == "5")
            {
                player5score += currentValue;
                p5score.Text = "$" + player5score;
            }
            else if (tag == "6")
            {
                player6score += currentValue;
                p6score.Text = "$" + player6score;
            }

            if (btn.Text == "Award" && !finalJeopardy)
            {
                clue.Visible = false;
                customWager.Value = 0;
                ShowBoard();
            }

            Globals.playerScores = new int[] { player1score, player2score, player3score, player4score, player5score, player6score };
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clue.Visible = false;
            customWager.Value = 0;
            ShowBoard();
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            HideBoard();
            Dictionary<string, int> scores = new Dictionary<string, int>();
            if (p1score.Visible)
            {
                scores.Add(player1name.Text, int.Parse(p1score.Text.Substring(1)));
            }
            if (p2score.Visible)
            {
                scores.Add(player2name.Text, int.Parse(p2score.Text.Substring(1)));
            }
            if (p3score.Visible)
            {
                scores.Add(player3name.Text, int.Parse(p3score.Text.Substring(1)));
            }
            if (p4score.Visible)
            {
                scores.Add(player4name.Text, int.Parse(p4score.Text.Substring(1)));
            }
            if (p5score.Visible)
            {
                scores.Add(player5name.Text, int.Parse(p5score.Text.Substring(1)));
            }
            if (p6score.Visible)
            {
                scores.Add(player6name.Text, int.Parse(p6score.Text.Substring(1)));
            }
            string[] names = new string[] { player1name.Text, player2name.Text, player3name.Text, player4name.Text, player5name.Text, player6name.Text };

            if (tournamentEnabled)
            {
                string connectionString = "Server=" + tournamentInfo.url + ";Database=" + tournamentInfo.db + ";Uid=" + tournamentInfo.user + ";Pwd=" + tournamentInfo.pswd + ";";
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("select playerName, playerID from Players;");
                command.Connection = connection;

                Dictionary<string, int> players = new Dictionary<string, int>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    players.Add(reader[0].ToString(), int.Parse(reader[1].ToString()));
                }

                var scoresSorted = scores.OrderByDescending(key => key.Value);
                string firstPlaceName = scoresSorted.ElementAt(0).Key;
                string secondPlaceName = scoresSorted.ElementAt(1).Key;
                string thirdPlaceName = scoresSorted.ElementAt(2).Key;

                int firstPlaceID = PlayerNameToID(firstPlaceName);
                int secondPlaceID = PlayerNameToID(secondPlaceName);
                int thirdPlaceID = PlayerNameToID(thirdPlaceName);

                string first = tournamentInfo.rounds[roundBox.SelectedIndex].player1;
                string second = tournamentInfo.rounds[roundBox.SelectedIndex].player2;
                string third = tournamentInfo.rounds[roundBox.SelectedIndex].player3;

                clue.Visible = true;
                string query = "";
                clue.Text = "";
                if (first == "winner")
                {
                    clue.Text = firstPlaceName.ToUpper() + " WINS THE TOURNAMENT!";
                    query += "update Brackets set winner = " + firstPlaceID + " where officialBracket = 1;";
                    //player1name.BackColor = Color.LightGreen;
                }
                else
                {
                    query += "update Brackets set " + first + " = " + firstPlaceID + " where officialBracket = 1;";
                    clue.Text += "\n" + firstPlaceName + " moves on to the " + tournamentInfo.rounds[roundBox.SelectedIndex].player1Next;
                    //player1name.BackColor = Color.LightGreen;
                }

                if (second == "elim")
                {
                    query += "update Players set eliminated = 1 where PlayerID = " + secondPlaceID + ";";
                    clue.Text += "\n" + secondPlaceName + " has been eliminated";
                    //player2name.BackColor = Color.Pink;
                }
                else
                {
                    query += "update Brackets set " + second + " = " + secondPlaceID + " where officialBracket = 1;";
                    clue.Text += "\n" + secondPlaceName + " moves on to the " + tournamentInfo.rounds[roundBox.SelectedIndex].player2Next;
                    //player2name.BackColor = Color.LightYellow;
                }

                if (third == "elim")
                {
                    query += "update Players set eliminated = 1 where PlayerID = " + thirdPlaceID + ";";
                    clue.Text += "\n" + thirdPlaceName + " has been eliminated\n";
                    //player3name.BackColor = Color.Pink;
                }
                
                foreach (string name in scores.Keys)
                {
                    query += "update Players set winnings = winnings + " + scores[name] + " where playerID = " + PlayerNameToID(name) + ";";
                }

                ExecuteQuery(query);
            }
            else
            {
                clue.Visible = true;
                clue.Text += "\nFINAL SCORES\n\n";
                int t = 0;
                string winner = "";
                foreach (var player in scores.OrderByDescending(key => key.Value))
                {
                    if (t == 0)
                    {
                        winner = player.Key;
                    }

                    t++;
                    clue.Text += t + ". " + player.Key + " - $" + player.Value + "\n";
                }
            }

            cat1label.Visible = false;
            cat2label.Visible = false;
            cat3label.Visible = false;
            cat4label.Visible = false;
            cat5label.Visible = false;
            cat6label.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private int PlayerNameToID(string playerName)
        {
            string connectionString = "Server=" + tournamentInfo.url + ";Database=" + tournamentInfo.db + ";Uid=" + tournamentInfo.user + ";Pwd=" + tournamentInfo.pswd + ";";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select PlayerID from Players where playerName = '" + playerName + "'");
            command.Connection = connection;

            Dictionary<string, int> players = new Dictionary<string, int>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return int.Parse(reader[0].ToString());
            }

            return 0;
        }

        private MySqlDataReader ExecuteQuery(string query)
        {
            string connectionString = "Server=" + tournamentInfo.url + ";Database=" + tournamentInfo.db + ";Uid=" + tournamentInfo.user + ";Pwd=" + tournamentInfo.pswd + ";";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connection;

            Dictionary<string, int> players = new Dictionary<string, int>();
            return command.ExecuteReader();
        }

        private void categoryLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            foreach (Category c in clues.Keys)
            {
                if (c.title.ToUpper() == lbl.Text)
                {
                    clues.Remove(c);
                    break;
                }
            }

            int cat = int.Parse(lbl.Tag.ToString()[lbl.Tag.ToString().Length - 1].ToString()) - 1;
            int randomOffset = random.Next(0, 5000);

            WebRequest request = WebRequest.Create("http://jservice.io/api/categories?count=1&offset=" + randomOffset);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            Category[] categories2 = JsonConvert.DeserializeObject<Category[]>(json);

            WebRequest clueRequest = WebRequest.Create("http://jservice.io/api/category?id=" + categories2[0].id);
            WebResponse clueResponse = clueRequest.GetResponse();
            StreamReader reader2 = new StreamReader(clueResponse.GetResponseStream());
            string json2 = reader2.ReadToEnd();
            CategoryInfo cat2 = JsonConvert.DeserializeObject<CategoryInfo>(json2);

            clues.Add(categories2[0], cat2);
             categories[cat] = categories2[0];

            switch (cat)
            {
                case 0:
                    cat1label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 1:
                    cat2label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 2:
                    cat3label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 3:
                    cat4label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 4:
                    cat5label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 5:
                    cat6label.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
            }

            string cID = "c" + lbl.Tag.ToString()[lbl.Tag.ToString().Length - 1].ToString();
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Name.Substring(0, 2) == cID))
            {
                btnn.Tag = "board@" + btnn.Name.Substring(2);
                ShowBoard();
            }
        }

        private void p6score_Click(object sender, EventArgs e)
        {
            //numericUpDown1.Value = int.Parse(((Label)sender).Tag.ToString()[1].ToString());
        }

        private void soundBtn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "Time.wav";
            if (finalJeopardyBtn.Checked)
            {
                player.SoundLocation = "Final.wav";
            }
            player.Play();
        }

        private void popOutBtn_Click(object sender, EventArgs e)
        {
            new Controller().Show();
            magnitude = true;
            this.Size = new Size(this.Width, 607);
            clock.Enabled = true;
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            clock.Enabled = false;
            Globals.currentValue = currentValue;
            if (Globals.generate)
            {
                if (Globals.round == 0) { jeopardyRadioBtn.Checked = true; }
                else if (Globals.round == 1) { doubleJeopardyBtn.Checked = true; }
                else if (Globals.round == 2) { finalJeopardyBtn.Checked = true; }
                generateBtn_Click(generateBtn, new EventArgs());
                Globals.generate = false;
            }
            if (Globals.reveal)
            {
                reveal_Click(revealButton, new EventArgs());
                Globals.reveal = false;
            }
            if (Globals.clear)
            {
                clear_Click(clearBtn, new EventArgs());
                Globals.clear = false;
            }
            Globals.answer = answerBox.Text;

            p1score.Text = "$" + Globals.playerScores[0].ToString();
            p2score.Text = "$" + Globals.playerScores[1].ToString();
            p3score.Text = "$" + Globals.playerScores[2].ToString();
            p4score.Text = "$" + Globals.playerScores[3].ToString();
            p5score.Text = "$" + Globals.playerScores[4].ToString();
            p6score.Text = "$" + Globals.playerScores[5].ToString();

            if (Globals.sound)
            {
                if (finalJeopardyBtn.Checked)
                {
                    player.SoundLocation = "Final.wav";
                    player.Play();
                }
                else
                {
                    player.SoundLocation = "Time.wav";
                    player.Play();
                }
                Globals.sound = false;
            }

            if (Globals.end)
            {
                endBtn_Click(endBtn, new EventArgs());
                Globals.end = false;
            }

            clock.Enabled = true;
        }

        private void export_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("GameBoard"));
            XmlNode firstNode = doc.FirstChild;
            foreach (Category ci in clues.Keys)
            {
                XmlElement node = doc.CreateElement("Category");
                XmlAttribute attr = doc.CreateAttribute("name");
                attr.Value = ci.title.ToUpper();
                node.Attributes.Append(attr);

                foreach (Clue cl in clues[ci].clues)
                {
                    XmlElement clue = doc.CreateElement("Clue");
                    clue.InnerText = cl.question;
                    XmlAttribute answer = doc.CreateAttribute("answer");
                    answer.Value = cl.answer.Replace("\"", "");
                    XmlAttribute value = doc.CreateAttribute("value");
                    value.Value = cl.value;

                    try
                    {
                        int value2 = int.Parse(cl.value);

                        clue.Attributes.Append(answer);
                        clue.Attributes.Append(value);
                        node.AppendChild(clue);
                    }
                    catch
                    {
                        MessageBox.Show("Skipped empty-value clue.");
                    }
                }

                firstNode.AppendChild(node);
            }
            
            if (saveGameBoard.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveGameBoard.FileName);
                MessageBox.Show("File successfully saved.");
            }
            else
            {
                MessageBox.Show("File was not saved.");
            }
        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            if (openGameBoard.ShowDialog() == DialogResult.OK)
            {
                if (gameModeComboBox.SelectedIndex == 0)
                {
                    jeopardyPreload = openGameBoard.FileName;
                    jepIndicator.BackColor = Color.Green;
                }
                else if (gameModeComboBox.SelectedIndex == 1)
                {
                    doublePreload = openGameBoard.FileName;
                    djepIndicator.BackColor = Color.Green;
                }
                else if (gameModeComboBox.SelectedIndex == 2)
                {
                    finalPreload = openGameBoard.FileName;
                    finalIndicator.BackColor = Color.Green;
                }
            }
        }

        private void chooseConfig_Click(object sender, EventArgs e)
        {
            if (openTournament.ShowDialog() == DialogResult.OK)
            {
                tournamentConfigLocation = openTournament.FileName;
                configIndicator.BackColor = Color.Green;
                StreamReader reader = new StreamReader(tournamentConfigLocation);
                string json = reader.ReadToEnd();
                tournamentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<TournamentInfo>(json);

                roundBox.Items.Clear();
                foreach (Round round in tournamentInfo.rounds)
                {
                    roundBox.Items.Add(round.name);
                }
                roundBox.SelectedIndex = 0;
                tournamentEnabled = true;
            }
        }

        private void roundBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
