using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        int numberOfPlayers = 1;
        int gameNumber = -3;
        string gameCodeNum = "";
        int[] wagerIndex = new int[] { 1, 1 };
        int[] scores = new int[6];

        string tournamentConfigLocation;
        TournamentInfo tournamentInfo = new TournamentInfo();
        Dictionary<string, int> NamesAndIDs = new Dictionary<string, int>();

        int player1score = 0;
        int player2score = 0;
        int player3score = 0;
        int player4score = 0;
        int player5score = 0;
        int player6score = 0;

        List<int> prevBuzzed = new List<int>();

        int endStage = 1;

        string jeopardyPreload;
        string doublePreload;
        string finalPreload;

        bool magnitude = false;
        System.Timers.Timer buzzTimer = new System.Timers.Timer();

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        bool buzzed = false;
        int buzzID = 0;
        int buzzIndex = 0;

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
            public string table { get; set; }
        }

        public class PlayerConfig
        {
            public string currentID { get; set; }
            public string nextID { get; set; }
            public string nextName { get; set; }
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
            prevBuzzed.Clear();
            
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
                Globals.answer = c.answer.Replace("&", "&&");
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
            gameCode.Hide();
            website.Hide();
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
            HideBoard();

            doubles.Text = "Daily Doubles:\n" + dailyDouble + "\n" + djdd1 + " & " + djdd2;
            Globals.dailyDoubles = doubles.Text;
            gameModeComboBox.SelectedIndex = 0;

            string code = GameFunction("beginGame", null, null);

            gameCode.Text = code;
            gameCodeNum = code;

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new ElapsedEventHandler(playerTimerHandler);
            t.Start();

            buzzTimer = new System.Timers.Timer(400);
            buzzTimer.Elapsed += new ElapsedEventHandler(CheckForBuzzes);

            updateNames.Enabled = true;

        }

        Dictionary<string, int> wagers = new Dictionary<string, int>();
        Dictionary<string, string> answers = new Dictionary<string, string>();
        private async void playerTimerHandler(object sender, ElapsedEventArgs e)
        {
            string data = await GameFunctionAsync("getPlayers", gameCodeNum, null);

            string[] players = data.Split(new string[] { "<br>" }, StringSplitOptions.None);
            for (int i = 0; i < players.Length - 1; i++)
            {
                string p = players[i];
                string[] comp = p.Split('`');

                if (!NamesAndIDs.ContainsKey(comp[0]))
                {
                    NamesAndIDs.Add(comp[0], int.Parse(comp[1]));
                }

                if (finalJeopardy)
                {
                    if (comp[2] != "null")
                    {
                        int num;
                        bool test = int.TryParse(comp[2], out num);
                        if (test)
                        {
                            if (!wagers.ContainsKey(comp[0]))
                            {
                                wagers.Add(comp[0], int.Parse(comp[2]));
                            }

                            int index = 0;
                            for (int c = 0; c < NamesAndIDs.Count; c++)
                            {
                                if (NamesAndIDs.Keys.ElementAt(c) == comp[0])
                                {
                                    index = c;
                                }
                            }
                        }
                    }
                    if (comp.Length > 3)
                    {
                        if (!answers.ContainsKey(comp[0]) && comp[3] != "")
                        {
                            answers.Add(comp[0], comp[3]);
                        }
                    }
                }
            }
        }

        public class BuzzList
        {
            public Buzz[] buzzes { get; set; }
        }

        public class Buzz
        {
            public string timestamp { get; set; }
            public string playerID { get; set; }
        }

        private async void CheckForBuzzes(object sender, ElapsedEventArgs e)
        {
            string data = await GameFunctionAsync("buzzerInfo", gameCodeNum, null);
            BuzzList b = JsonConvert.DeserializeObject<BuzzList>(data);
            List<Buzz> sorted = b.buzzes.OrderBy(o => o.timestamp).ToList();

            foreach (Buzz bz in sorted)
            {
                Debug.WriteLine(bz.playerID + " " + bz.timestamp);
            }

            if (sorted.Count > 0)
            {
                buzzed = true;
                buzzID = int.Parse(sorted[0].playerID);

                Debug.WriteLine("Chosen: " + buzzID);

                for (int i = 1; i < sorted.Count; i++)
                {
                    data = await GameFunctionAsync("clear", gameCodeNum, sorted[i].playerID);
                }

                foreach (string k in NamesAndIDs.Keys)
                {
                    if (player1name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 1;
                    if (player2name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 2;
                    if (player3name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 3;
                    if (player4name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 4;
                    if (player5name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 5;
                    if (player6name.Text == k && buzzID == NamesAndIDs[k])
                        buzzIndex = 6;
                }
            }
        }

        bool generate = true;
        private void generateBtn_Click(object sender, EventArgs e)
        {
            ShowBoard();
            gameCode.Visible = false;
            website.Visible = false;

            categories.Clear();
            clues.Clear();
            Globals.playerNames = new string[] { player1name.Text, player2name.Text, player3name.Text, player4name.Text, player5name.Text, player6name.Text };

            for (int i = numberOfPlayers; i < 6; i++)
            {
                Globals.playerNames[i] = "";
            }

            if (customRadioBtn.Checked || (magnitude && Globals.gameType == 1))
            {
                customRadioBtn.Checked = true;

                string fileUpload = "";
                if (jeopardyRadioBtn.Checked && jeopardyPreload != null)
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

                    string data = GameFunction("setGameLock", gameCodeNum, "3");
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

            player.Stop();
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'g'))
            {
                btnn.Tag = "board@" + btnn.Name.Substring(3);
                ShowBoard();
            }

            player1name.Enabled = false;
            player2name.Enabled = false;
            player3name.Enabled = false;
            player4name.Enabled = false;
            player5name.Enabled = false;
            player6name.Enabled = false;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                switch (i)
                {
                    case 0:
                        p1score.Visible = true;
                        break;
                    case 1:
                        p2score.Visible = true;
                        break;
                    case 2:
                        p3score.Visible = true;
                        break;
                    case 3:
                        p4score.Visible = true;
                        break;
                    case 4:
                        p5score.Visible = true;
                        break;
                    case 5:
                        p6score.Visible = true;
                        break;
                }
            }

            if (doubleJeopardyBtn.Checked)
            {
                int lowestScore = 99999;
                int index = 0;
                for (int i = 0; i < Globals.playerScores.Length; i++)
                {
                    if (Globals.playerScores[i] < lowestScore)
                    {
                        lowestScore = Globals.playerScores[i];
                        index = i;
                    }
                }

                player1name.BackColor = Color.White;
                player2name.BackColor = Color.White;
                player3name.BackColor = Color.White;
                player4name.BackColor = Color.White;
                player5name.BackColor = Color.White;
                player6name.BackColor = Color.White;
                switch (index)
                {
                    case 0:
                        player1name.BackColor = Color.LightPink;
                        break;
                    case 1:
                        player2name.BackColor = Color.LightPink;
                        break;
                    case 2:
                        player3name.BackColor = Color.LightPink;
                        break;
                    case 3:
                        player4name.BackColor = Color.LightPink;
                        break;
                    case 4:
                        player5name.BackColor = Color.LightPink;
                        break;
                    case 5:
                        player6name.BackColor = Color.LightPink;
                        break;
                }
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

                    string data = GameFunction("setGameLock", gameCodeNum, "3");

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
                    int i = random.Next(0, cat2.clues.Length);
                    clue.Text = cat2.clues[i].question;
                    answerBox.Text = cat2.clues[i].answer;
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

                if (wagerIndex[0] == 0)
                {
                    endBtn_Click(endBtn, new EventArgs());
                    return;
                }

                if (finalBegan && (wagerIndex[0] > 0  || wagerIndex[1] > 0))
                {
                    HideBoard();
                    clue.Visible = true;

                    if (scores[wagerIndex[0] - 1] < 0)
                    {
                        wagerIndex[0]--;
                        reveal_Click(revealButton, new EventArgs());
                    }

                    if (wagerIndex[1] == 1)
                    {
                        clue.Text = answers[answers.Keys.ElementAt(wagerIndex[0] - 1)];
                        wagerIndex[1]--;
                    }
                    else
                    {
                        int wager = wagers[wagers.Keys.ElementAt(wagerIndex[0] - 1)];
                        if (wager > scores[wagerIndex[0] - 1])
                        {
                            wagers[wagers.Keys.ElementAt(wagerIndex[0] - 1)] = scores[wagerIndex[0] - 1];
                        }
                        currentValue = wagers[wagers.Keys.ElementAt(wagerIndex[0] - 1)];
                        customWager.Value = wagers[wagers.Keys.ElementAt(wagerIndex[0] - 1)];

                        clue.Text = answers[answers.Keys.ElementAt(wagerIndex[0] - 1)] + "\n\n$" + wagers[wagers.Keys.ElementAt(wagerIndex[0] - 1)];
                        wagerIndex[1] = 1;
                        wagerIndex[0]--;
                    }

                    for (int i = 1; i < 7; i++)
                    {
                        ColorBoxes(i, Color.White);
                    }
                    ColorBoxes(wagerIndex[0], Color.LightYellow);
                }

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
            tag = btn.Tag.ToString();

            if ((btn.Text == "Remove" && currentValue > 0) || (btn.Text == "Award" && currentValue < 0))
            {
                currentValue *= -1;
                unlock_Click(unlock, new EventArgs());
                Globals.unlockState = true;
            }

            if (tag == "1")
            {
                player1score += currentValue;
                p1score.Text = "$" + player1score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player1name.BackColor = Color.LightPink;
                    new Task(() => Flash(1, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(1, 0)).Start();
                }
            }
            else if (tag == "2")
            {
                player2score += currentValue;
                p2score.Text = "$" + player2score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player2name.BackColor = Color.LightPink;
                    new Task(() => Flash(2, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(2, 0)).Start();
                }
            }
            else if (tag == "3")
            {
                player3score += currentValue;
                p3score.Text = "$" + player3score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player3name.BackColor = Color.LightPink;
                    new Task(() => Flash(3, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(3, 0)).Start();
                }
            }
            else if (tag == "4")
            {
                player4score += currentValue;
                p4score.Text = "$" + player4score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player4name.BackColor = Color.LightPink;
                    new Task(() => Flash(4, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(4, 0)).Start();
                }
            }
            else if (tag == "5")
            {
                player5score += currentValue;
                p5score.Text = "$" + player5score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player5name.BackColor = Color.LightPink;
                    new Task(() => Flash(5, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(5, 0)).Start();
                }
            }
            else if (tag == "6")
            {
                player6score += currentValue;
                p6score.Text = "$" + player6score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player6name.BackColor = Color.LightPink;
                    new Task(() => Flash(6, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(6, 0)).Start();
                }
            }

            if (btn.Text == "Award" && !finalJeopardy)
            {
                clue.Visible = false;
                customWager.Value = 0;
                ShowBoard();
                clear_Click(clearBtn, new EventArgs());
            }

            Globals.playerScores = new int[] { player1score, player2score, player3score, player4score, player5score, player6score };
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clue.Visible = false;
            customWager.Value = 0;
            ShowBoard();

            string data = GameFunction("setGameLock", gameCodeNum, "2");

            if (unlock.Text == "Lock")
            {
                unlock_Click(unlock, new EventArgs());
                for (int i = 1; i < 7; i++)
                {
                    ColorBoxes(i, Color.White);
                }
            }
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
            if (endStage == 1)
            {
                if (tournamentEnabled)
                {
                    string connectionString = "Server=" + tournamentInfo.url + ";Database=" + tournamentInfo.db + ";Uid=" + tournamentInfo.user + ";Pwd=" + tournamentInfo.pswd + ";";
                    MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("select playerName, playerID from Players");
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

                    int firstPlaceID = NamesAndIDs[firstPlaceName];
                    int secondPlaceID = NamesAndIDs[secondPlaceName];
                    int thirdPlaceID = NamesAndIDs[thirdPlaceName];

                    string query = "select firstTo, secondTo, thirdTo, firstNextSeed, secondNextSeed, roundNumber from Games where gameID = " + gameNumber;
                    MySqlDataReader next = ExecuteQuery(query);
                    while (next.Read())
                    {
                        string firstSeed = next[3].ToString();
                        string secondSeed = next[4].ToString();

                        if (firstSeed == "1") { firstSeed = "firstSeed"; }
                        else if (firstSeed == "2") { firstSeed = "secondSeed"; }
                        else if (firstSeed == "3") { firstSeed = "thirdSeed"; }
                        else { firstSeed = ""; }

                        if (secondSeed == "1") { secondSeed = "firstSeed"; }
                        else if (secondSeed == "2") { secondSeed = "secondSeed"; }
                        else if (secondSeed == "3") { secondSeed = "thirdSeed"; }
                        else { secondSeed = ""; }

                        string q = "update Games set " + firstSeed + " = " + firstPlaceID + " where gameID = " + next[0] + ";";
                        if (secondSeed != "")
                        {
                            q += "update Games set " + secondSeed + " = " + secondPlaceID + " where gameID = " + next[1] + ";";
                        }

                        q += "update Games set firstPlace = " + firstPlaceID + " where gameID = " + gameNumber + ";";
                        q += "update Games set secondPlace = " + secondPlaceID + " where gameID = " + gameNumber + ";";
                        q += "update Games set thirdPlace = " + thirdPlaceID + " where gameID = " + gameNumber + ";";

                        q += "update Games set firstTotal = " + scoresSorted.ElementAt(0).Value + " where gameID = " + gameNumber + ";";
                        q += "update Games set secondTotal = " + scoresSorted.ElementAt(1).Value + " where gameID = " + gameNumber + ";";
                        q += "update Games set thirdTotal = " + scoresSorted.ElementAt(2).Value + " where gameID = " + gameNumber + ";";

                        q += "update Players set winnings = winnings + " + scoresSorted.ElementAt(0).Value + " where playerID = " + firstPlaceID + ";";
                        q += "update Players set winnings = winnings + " + scoresSorted.ElementAt(1).Value + " where playerID = " + secondPlaceID + ";";
                        q += "update Players set winnings = winnings + " + scoresSorted.ElementAt(2).Value + " where playerID = " + thirdPlaceID + ";";
                        q += "update Games set completed = 1 where gameID = " + gameNumber;

                        ExecuteQuery(q);

                        if (next[5].ToString() == "2")
                        {
                            ExecuteQuery(ShiftQuery());
                        }
                    }
                    endStage--;
                }
                else
                {
                    clue.Visible = true;
                    clue.Text = "\nFINAL SCORES\n\n";
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
            }
            else
            {
                clue.Visible = true;
                clue.Text = "\nFINAL SCORES\n\n";
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
            Label t = (Label)sender;
            int index = int.Parse(t.Tag.ToString().Substring(1)) - 1;
            string key = NamesAndIDs.Keys.ElementAt(index);
            NamesAndIDs.Remove(key);
            ToggleNamePlate(index, false);

            string data = GameFunction("removePlayer", key, null);
        }

        private void ToggleNamePlate(int index, bool state)
        {
            if (!state)
            {
                if (index == 1)
                {
                    p1score.Visible = false;
                    player1name.Visible = false;
                    award1.Visible = false;
                    remove1.Visible = false;
                }
                else if (index == 2)
                {
                    p2score.Visible = false;
                    player2name.Visible = false;
                    award2.Visible = false;
                    remove2.Visible = false;
                }
                else if (index == 3)
                {
                    p3score.Visible = false;
                    player3name.Visible = false;
                    award3.Visible = false;
                    remove3.Visible = false;
                }
                else if (index == 4)
                {
                    p4score.Visible = false;
                    player4name.Visible = false;
                    award4.Visible = false;
                    remove4.Visible = false;
                }
                else if (index == 5)
                {
                    p5score.Visible = false;
                    player5name.Visible = false;
                    award5.Visible = false;
                    remove5.Visible = false;
                }
                else if (index == 6)
                {
                    p6score.Visible = false;
                    player6name.Visible = false;
                    award6.Visible = false;
                    remove6.Visible = false;
                }
            }
            else if (state)
            {
                if (index == 1)
                {
                    p1score.Visible = true;
                    player1name.Visible = true;
                    award1.Visible = true;
                    remove1.Visible = true;
                }
                else if (index == 2)
                {
                    p2score.Visible = true;
                    player2name.Visible = true;
                    award2.Visible = true;
                    remove2.Visible = true;
                }
                else if (index == 3)
                {
                    p3score.Visible = true;
                    player3name.Visible = true;
                    award3.Visible = true;
                    remove3.Visible = true;
                }
                else if (index == 4)
                {
                    p4score.Visible = true;
                    player4name.Visible = true;
                    award4.Visible = true;
                    remove4.Visible = true;
                }
                else if (index == 5)
                {
                    p5score.Visible = true;
                    player5name.Visible = true;
                    award5.Visible = true;
                    remove5.Visible = true;
                }
                else if (index == 6)
                {
                    p6score.Visible = true;
                    player6name.Visible = true;
                    award6.Visible = true;
                    remove6.Visible = true;
                }
            }
        }

        bool finalBegan = false;
        private void soundBtn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "Time.wav";
            if (finalJeopardyBtn.Checked)
            {
                player.SoundLocation = "Final.wav";

                string data = GameFunction("setGameLock", gameCodeNum, "4");
                ColorBoxes(1, Color.White);
                ColorBoxes(2, Color.White);
                ColorBoxes(3, Color.White);
                ColorBoxes(4, Color.White);
                ColorBoxes(5, Color.White);
                ColorBoxes(6, Color.White);
            }
            finalBegan = true;
            wagerIndex[0] = wagers.Count;
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
            if (Globals.export)
            {
                export_Click(export, new EventArgs());
                Globals.export = false;
            }
            if (Globals.flash != null)
            {
                if (Globals.flash[0] == 0)
                {
                    new Task(() => Flash(1, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player1name.BackColor = Color.LightPink;
                    }
                }
                else if (Globals.flash[0] == 1)
                {
                    new Task(() => Flash(2, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player2name.BackColor = Color.LightPink;
                    }
                }
                else if(Globals.flash[0] == 2)
                {
                    new Task(() => Flash(3, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player3name.BackColor = Color.LightPink;
                    }
                }
                else if(Globals.flash[0] == 3)
                {
                    new Task(() => Flash(4, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player4name.BackColor = Color.LightPink;
                    }
                }
                else if(Globals.flash[0] == 4)
                {
                    new Task(() => Flash(5, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player5name.BackColor = Color.LightPink;
                    }
                }
                else if(Globals.flash[0] == 5)
                {
                    new Task(() => Flash(6, Globals.flash[1])).Start();
                    if (Globals.flash[1] == 1)
                    {
                        ResetLabelColors();
                        player6name.BackColor = Color.LightPink;
                    }
                }
                Globals.flash = null;
            }
            if (Globals.unlockButton)
            {
                unlock_Click(unlock, new EventArgs());
                Globals.unlockButton = false;
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
                StreamReader reader = new StreamReader(tournamentConfigLocation);
                string json = reader.ReadToEnd();
                tournamentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<TournamentInfo>(json);

                try
                {
                    string query = "select * from Games where completed = 0 and bye = 0 and firstSeed <> 'null'";
                    MySqlDataReader data = ExecuteQuery(query);
                    while (data.Read())
                    {
                        roundBox.Items.Add(data["gameName"]);
                    }
                    roundBox.SelectedIndex = 0;
                    configIndicator.BackColor = Color.Green;
                    tournamentEnabled = true;
                }
                catch
                {
                    MessageBox.Show("Could not connect to the database. Is your IP included in the jerseymikes security group, chief?");
                }
            }
        }

        private void roundBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roundBox.SelectedIndex < 0)
            {
                return;
            }

            player1name.Clear();
            player2name.Clear();
            player3name.Clear();
            NamesAndIDs.Clear();

            p1score.Visible = true;
            p2score.Visible = true;
            p3score.Visible = true;

            player1name.Enabled = false;
            player2name.Enabled = false;
            player3name.Enabled = false;

            player1name.Visible = true;
            player2name.Visible = true;
            player3name.Visible = true;

            //award2.Visible = true;
            //remove2.Visible = true;
            //award3.Visible = true;
            //remove3.Visible = true;

            string query = "select firstSeed, secondSeed, thirdSeed, gameID from Games where gameName = \"" + roundBox.SelectedItem.ToString() + "\"";
            string[] names = new string[3];
            MySqlDataReader reader = ExecuteQuery(query);
            while (reader.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    query = "select playerName from Players where playerID = " + reader[i].ToString();
                    MySqlDataReader reader2 = ExecuteQuery(query);
                    while (reader2.Read())
                    {
                        NamesAndIDs.Add(reader2[0].ToString(), int.Parse(reader[i].ToString()));
                        names[i] = reader2[0].ToString();
                    }
                }
                gameNumber = int.Parse(reader[3].ToString());
            }
            player1name.Text = names[0];
            player2name.Text = names[1];
            player3name.Text = names[2];
        }

        private void ResetLabelColors()
        {
            player1name.BackColor = Color.White;
            player2name.BackColor = Color.White;
            player3name.BackColor = Color.White;
            player4name.BackColor = Color.White;
            player5name.BackColor = Color.White;
            player6name.BackColor = Color.White;
        }

        const int flashDelay = 100;
        private void Flash(int toFlash, int status)
        {
            Color color;
            switch (status)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.LightGreen;
                    break;
                default:
                    return;
            }

            for (int i = 0; i < 3; i++)
            {
                switch (toFlash)
                {
                    case 1:
                        p1score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p1score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                    case 2:
                        p2score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p2score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                    case 3:
                        p3score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p3score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                    case 4:
                        p4score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p4score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                    case 5:
                        p5score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p5score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                    case 6:
                        p6score.ForeColor = color;
                        Thread.Sleep(flashDelay);
                        p6score.ForeColor = Color.White;
                        Thread.Sleep(flashDelay);
                        break;
                }
            }
        }

        private void addPlayer_Click(object sender, EventArgs e)
        {
            //numberOfPlayers++;
            //if (numberOfPlayers == 2)
            //{
            //    player2name.Visible = true;
            //    addPlayer.Location = new Point(374, 528);
            //    award2.Visible = true;
            //    remove2.Visible = true;
            //    p2timer.Visible = true;
            //}
            //else if (numberOfPlayers == 3)
            //{
            //    player3name.Visible = true;
            //    addPlayer.Location = new Point(553, 528);
            //    award3.Visible = true;
            //    remove3.Visible = true;
            //    p3timer.Visible = true;
            //}
            //else if (numberOfPlayers == 4)
            //{
            //    player4name.Visible = true;
            //    addPlayer.Location = new Point(734, 528);
            //    award4.Visible = true;
            //    remove4.Visible = true;
            //    p4timer.Visible = true;
            //}
            //else if (numberOfPlayers == 5)
            //{
            //    player5name.Visible = true;
            //    addPlayer.Location = new Point(915, 528);
            //    award5.Visible = true;
            //    remove5.Visible = true;
            //    p5timer.Visible = true;
            //}
            //else if (numberOfPlayers == 6)
            //{
            //    player6name.Visible = true;
            //    addPlayer.Visible = false;
            //    award6.Visible = true;
            //    remove6.Visible = true;
            //    p6timer.Visible = true;
            //}
        }

        private string ShiftQuery()
        {
            return 
            @"set @topSeed = 0; 
            select firstPlace into @topSeed from Games join Players on firstPlace = playerID where roundNumber = 1 order by winnings desc limit 1;
            update Games set firstSeed = @topSeed where final = 1;
            set @secondSeed = 0;
            select secondSeed into @secondSeed from Games where roundNumber = 2;
            set @thirdSeed = 0;
            select thirdSeed into @thirdSeed from Games where roundNumber = 2;
            update Games set firstSeed = @secondSeed where roundNumber = 2;
            update Games set secondSeed = @thirdSeed where roundNumber = 2;
            update Games set thirdSeed = firstPlace where roundNumber = 1;";
        }

        private void GameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            string data = GameFunction("endGame", gameCodeNum, null);
        }

        private void updateNames_Tick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (string key in NamesAndIDs.Keys)
            {
                string[] comp = new string[] { key, NamesAndIDs[key].ToString() };

                scores[0] = int.Parse(p1score.Text.Substring(1));
                scores[1] = int.Parse(p2score.Text.Substring(1));
                scores[2] = int.Parse(p3score.Text.Substring(1));
                scores[3] = int.Parse(p4score.Text.Substring(1));
                scores[4] = int.Parse(p5score.Text.Substring(1));
                scores[5] = int.Parse(p6score.Text.Substring(1));

                if (i == 0)
                {
                    player1name.Text = comp[0];
                    ToggleNamePlate(1, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player1name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 1)
                {
                    player2name.Text = comp[0];
                    ToggleNamePlate(2, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player2name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 2)
                {
                    player3name.Text = comp[0];
                    ToggleNamePlate(3, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player3name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 3)
                {
                    player4name.Text = comp[0];
                    ToggleNamePlate(4, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player4name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 4)
                {
                    player5name.Text = comp[0];
                    ToggleNamePlate(5, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player5name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 5)
                {
                    player6name.Text = comp[0];
                    ToggleNamePlate(6, true);

                    if (wagers.ContainsKey(comp[0]))
                    {
                        player6name.BackColor = Color.LightGreen;
                    }
                }

                i++;
            }
        }

        private void unlock_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Unlock")
            {
                buzzTimer.Enabled = true;
                string data = GameFunction("setGameLock", gameCodeNum, "0");
                btn.Text = "Lock";
                Globals.unlockState = true;
            }
            else if (btn.Text == "Lock")
            {
                buzzTimer.Enabled = false;
                string data = GameFunction("setGameLock", gameCodeNum, "1");
                btn.Text = "Unlock";
                Globals.unlockState = false;
            }
        }

        private void synchBuzzTimer_Tick(object sender, EventArgs e)
        {
            if (buzzed)
            {
                unlock_Click(unlock, new EventArgs());
                synchBuzzTimer.Enabled = false;
                int i = 1;
                foreach (string key in NamesAndIDs.Keys)
                {
                    int playerID = NamesAndIDs[key];
                    if (playerID == buzzID)
                    {
                        prevBuzzed.Add(playerID);
                        break;
                    }
                    i++;
                }

                buzzed = false;

                player.SoundLocation = "Buzz.wav";
                player.Play();

                ColorBoxes(i, Color.LightBlue);

                synchBuzzTimer.Enabled = true;
            }
        }

        private void decreaseProgBar(ProgressBar progBar)
        {
            for (int i = 100; i >= 0; i -= 5)
            {
                Task.Run(() => { progBar.Value = i; Thread.Sleep(100); });
            }
        }

        private void award_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            awardAndRemove_Click(btn, new EventArgs());
        }

        private void ColorBoxes(int i, Color color)
        {
            if (i == 1)
            {
                player1name.BackColor = color;
                player2name.BackColor = Color.White;
                player3name.BackColor = Color.White;
                player4name.BackColor = Color.White;
                player5name.BackColor = Color.White;
                player6name.BackColor = Color.White;
            }
            if (i == 2)
            {
                player1name.BackColor = Color.White;
                player2name.BackColor = color;
                player3name.BackColor = Color.White;
                player4name.BackColor = Color.White;
                player5name.BackColor = Color.White;
                player6name.BackColor = Color.White;
            }
            if (i == 3)
            {
                player1name.BackColor = Color.White;
                player2name.BackColor = Color.White;
                player3name.BackColor = color;
                player4name.BackColor = Color.White;
                player5name.BackColor = Color.White;
                player6name.BackColor = Color.White;
            }
            if (i == 4)
            {
                player1name.BackColor = Color.White;
                player2name.BackColor = Color.White;
                player3name.BackColor = Color.White;
                player4name.BackColor = color;
                player5name.BackColor = Color.White;
                player6name.BackColor = Color.White;
            }
            if (i == 5)
            {
                player1name.BackColor = Color.White;
                player2name.BackColor = Color.White;
                player3name.BackColor = Color.White;
                player4name.BackColor = Color.White;
                player5name.BackColor = color;
                player6name.BackColor = Color.White;
            }
            if (i == 6)
            {
                player1name.BackColor = Color.White;
                player2name.BackColor = Color.White;
                player3name.BackColor = Color.White;
                player4name.BackColor = Color.White;
                player5name.BackColor = Color.White;
                player6name.BackColor = color;
            }
        }

        private string GameFunction(string function, string var1, string var2)
        {
            Uri uri = new Uri(@"http://hamijeopardy.com/gameFunctions.php");
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";

            string form = "function=" + function;
            if (var1 != null)
            {
                form += "&variable1=" + var1;
            }
            if (var2 != null)
            {
                form += "&variable2=" + var2;
            }
            byte[] data = Encoding.ASCII.GetBytes(form);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            WebResponse resp = request.GetResponse();
            StreamReader reader = new StreamReader(resp.GetResponseStream());

            return reader.ReadToEnd();
        }

        private async Task<string> GameFunctionAsync(string function, string var1, string var2)
        {
            Uri uri = new Uri(@"http://hamijeopardy.com/gameFunctions.php");
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";

            string form = "function=" + function;
            if (var1 != null)
            {
                form += "&variable1=" + var1;
            }
            if (var2 != null)
            {
                form += "&variable2=" + var2;
            }
            byte[] data = Encoding.ASCII.GetBytes(form);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            WebResponse resp = await request.GetResponseAsync();
            StreamReader reader = new StreamReader(resp.GetResponseStream());

            return await reader.ReadToEndAsync();
        }

        private void revealFinal(object sender, EventArgs e)
        {
            TextBox btn = (TextBox)sender;
            if (finalBegan)
            {
                HideBoard();
                clue.Visible = true;
                if (clue.Text != answers[btn.Text])
                {
                    clue.Text = answers[btn.Text];
                }
                else
                {
                    clue.Text = answers[btn.Text] + "\n\n" + wagers[btn.Text];
                }
            }
        }
    }
}
