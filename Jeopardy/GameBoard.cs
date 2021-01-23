using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        bool dailyDoubleState = false;
        Category finalJep;
        CategoryInfo finalJepInfo;
        int numberOfPlayers = 1;
        string gameCodeNum = "";
        Clue currentClue;
        Button unlockBtnRef;
        public static string GameCode = "";
        bool gameStarted = false;

        public class Player
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Score { get; set; }
            public string Wager { get; set; }
            public string Answer { get; set; }
            public int Visited { get; set; }
            public int Admitted { get; set; }
            public Player Teammate { get; set; }

            public Player(string Name, int ID)
            {
                this.Name = Name;
                this.ID = ID;
                Visited = 0;
                Admitted = 0;
                Teammate = null;
            }
        }

        public static List<Player> gamePlayers = new List<Player>();
        List<int> prevBuzzed = new List<int>();
        List<int> TeammateIDs = new List<int>();

        int endStage = 1;

        string jeopardyPreload;
        string doublePreload;
        string finalPreload;

        bool clueOpen = false;
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
            clueOpen = true;

            timeToAnswer.Maximum = (BuzzerList.SecondsToGive * 1000);
            timeToAnswer.Value = (BuzzerList.SecondsToGive * 1000);
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

            currentClue = c;
            if ((doubleJeopardy == false && name == dailyDouble) || (doubleJeopardy == true && (name == djdd1 || name == djdd2)))
            {
                clue.Text = "DAILY DOUBLE";
                player.SoundLocation = "DD.wav";
                player.Play();
                dailyDoubleState = true;
                return;
            }

            if (cluePresent)
            {
                clue.Text = c.question.Replace("&", "&&");
                answerBox.Text = c.answer.Replace("&", "&&");
                Controller.Answer = c.answer.Replace("&", "&&");
                currentValue = int.Parse(value);
                if (doubleJeopardy)
                {
                    currentValue *= 2;
                }
                customWager.Value = currentValue;
                Controller.WagerValue = (int)customWager.Value;

                if (clue.Text.ToLower().Contains("seen here"))
                {
                    button1_Click(button1, new EventArgs());
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
            codeLabel.Visible = false;
        }

        public void ShowBoard()
        {
            gameCode.Hide();
            website.Hide();
            timeToAnswer.Hide();
            pictureBox.Visible = false;
            clueImage.Visible = false;
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Show();
                answerBox.Text = "";
            }
            codeLabel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] values = new string[] { "200", "400", "600", "800", "1000" };
            dailyDouble = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            djdd1 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];

            do
            {
                djdd2 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            } while (djdd2 == djdd1);

            ToggleBoard(false);
            HideBoard();

            doubles.Text = "Daily Doubles:\n" + dailyDouble + "\n" + djdd1 + " & " + djdd2;
            Controller.DailyDoubles = doubles.Text;
            gameModeComboBox.SelectedIndex = 0;

            string code = GameFunction("beginGame", null, null);

            gameCode.Text = code;
            gameCodeNum = code;
            codeLabel.Text = "Game Code: " + code;
            GameCode = code;

            System.Timers.Timer t = new System.Timers.Timer(400);
            t.Elapsed += new ElapsedEventHandler(playerTimerHandler);
            t.Start();

            BuzzerList list = new BuzzerList(this);
            list.Show();

            buzzTimer = new System.Timers.Timer(400);
            buzzTimer.Elapsed += new ElapsedEventHandler(CheckForBuzzes);
            buzzTimer.Enabled = true;
            unlockBtnRef = unlock;

            updateNames.Enabled = true;
        }

        private bool PlayerPresent(int ID)
        {
            foreach (Player p in gamePlayers)
            {
                if (p.ID == ID)
                {
                    return true;
                }
            }

            return false;
        }

        bool hidePlates = false;
        private async void playerTimerHandler(object sender, ElapsedEventArgs e)
        {
            string data = await GameFunctionAsync("getPlayers", gameCodeNum, null);

            string[] players = data.Split(new string[] { "<br>" }, StringSplitOptions.None);
            for (int i = 0; i < players.Length - 1; i++)
            {
                string p = players[i];
                string[] comp = p.Split('`');

                if (!PlayerPresent(int.Parse(comp[1])) && !TeammateIDs.Contains(int.Parse(comp[1])))
                {
                    gamePlayers.Add(new Player(comp[0], int.Parse(comp[1])));
                }
            }

            for (int i = 0; i < gamePlayers.Count; i++)
            {
                if (!data.Contains(gamePlayers[i].ID.ToString()))
                {
                    gamePlayers.RemoveAt(i);
                    hidePlates = true;
                }
            }

            if (finalJeopardy)
            {
                data = await GameFunctionAsync("getWagers", gameCodeNum, null);
                players = data.Split(new string[] { "<br>" }, StringSplitOptions.None);
                for (int i = 0; i < players.Length - 1; i++)
                {
                    string w = players[i];
                    string[] comp = w.Split('`');
                    foreach (Player p in gamePlayers)
                    {
                        if (p.ID == int.Parse(comp[0]))
                        {
                            p.Wager = comp[1];
                            if (int.Parse(p.Wager) > p.Score)
                            {
                                p.Wager = p.Score.ToString();
                            }

                            p.Answer = comp[2];
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
            public string early { get; set; }
        }

        public static BuzzList buzzes;
        bool[] earlyBuzzed = new bool[6];
        private async void CheckForBuzzes(object sender, ElapsedEventArgs e)
        {
            string data = await GameFunctionAsync("buzzerInfo", gameCodeNum, null);
            BuzzList b = JsonConvert.DeserializeObject<BuzzList>(data);
            List<Buzz> sorted = b.buzzes.OrderBy(o => o.timestamp).ToList();
            buzzes = b;

            if (clueOpen)
            {
                List<Buzz> remove = new List<Buzz>();
                for (int i = 0; i < sorted.Count; i++)
                {
                    if (sorted[i].early == "1")
                    {
                        string playerID = sorted[i].playerID;

                        for (int v = 0; v < gamePlayers.Count; v++)
                        {
                            if (gamePlayers[v].ID.ToString() == playerID)
                            {
                                earlyBuzzed[v] = true;
                            }
                        }

                        remove.Add(sorted[i]);
                    }
                }

                foreach (Buzz s in remove)
                {
                    sorted.Remove(s);
                }
            }

            if (checkBuzzes)
            {
                if (sorted.Count > 0)
                {
                    int index = 0;

                    if (BuzzerList.RandomizeSelection[0] == 1)
                    {
                        if (sorted.Count > 1)
                        {
                            if (double.Parse(sorted[1].timestamp) - double.Parse(sorted[0].timestamp) < BuzzerList.RandomizeSelection[1])
                            {
                                index = random.Next(0, 2);
                            }
                        }
                    }

                    buzzed = true;
                    buzzID = int.Parse(sorted[0].playerID);

                        Debug.WriteLine("Chosen: " + buzzID);

                    for (int i = 1; i < sorted.Count; i++)
                    {
                        data = await GameFunctionAsync("clear", gameCodeNum, sorted[i].playerID);
                    }

                    foreach (Player player in gamePlayers)
                    {
                        if ((player1name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 1;
                        else if ((player2name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 2;
                        else if ((player3name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 3;
                        else if ((player4name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 4;
                        else if ((player5name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 5;
                        else if ((player6name.Text == player.Name && buzzID == player.ID) || (player.Teammate != null && player.Teammate.ID == buzzID))
                            buzzIndex = 6;

                        if (player.Teammate != null && player.Teammate.ID == buzzID)
                        {
                            buzzID = player.ID;
                        }
                    }
                }
            }
        }

        bool generate = true;

        public void AdjustSettings(int type, int value)
        {
            switch (type)
            {
                case 0: //game type
                    if (value == 0)
                        autoRadioBtn.Checked = true;
                    else if (value == 1)
                        customRadioBtn.Checked = true;
                    break;
                case 1: //round
                    if (value == 0)
                        jeopardyRadioBtn.Checked = true;
                    else if (value == 1)
                        doubleJeopardyBtn.Checked = true;
                    else if (value == 2)
                        finalJeopardyBtn.Checked = true;
                    break;
                case 2: //wager
                    customWager.Value = value;
                    break;
            }
        }

        public void generateBtn_Click(object sender, EventArgs e)
        {
            ShowBoard();
            gameCode.Visible = false;
            website.Visible = false;
            gameStarted = true;

            categories.Clear();
            clues.Clear();

            player1name.Enabled = false;
            player2name.Enabled = false;
            player3name.Enabled = false;
            player4name.Enabled = false;
            player5name.Enabled = false;
            player6name.Enabled = false;

            if (customRadioBtn.Checked)
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
                    try
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
                    catch
                    {
                        MessageBox.Show("Invalid file!");
                    }
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
                for (int i = 0; i < gamePlayers.Count; i++)
                {
                    if (gamePlayers[i].Score < lowestScore)
                    {
                        lowestScore = gamePlayers[i].Score;
                        index = i;
                    }
                }
                highlightedPlayer = index;
                ColorBoxes(1, Color.White);
                ColorBoxes(2, Color.White);
                ColorBoxes(3, Color.White);
                ColorBoxes(4, Color.White);
                ColorBoxes(5, Color.White);
                ColorBoxes(6, Color.White);

                ColorBoxes(index, Color.LightPink);
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

        public void reveal_Click(object sender, EventArgs e)
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
                    currentClue = cat2.clues[i];
                    clue.Text = cat2.clues[i].question;
                    answerBox.Text = cat2.clues[i].answer;
                }
                else
                {
                    cat2 = finalJepInfo;
                    clue.Text = finalJepInfo.clues[0].question.Replace("&", "&&") ;
                    answerBox.Text = finalJepInfo.clues[0].answer;
                }

                cat1label.Text = cat2.title.ToUpper().Replace('&', ' ');
                cat2label.Text = cat2.title.ToUpper().Replace('&', ' ');
                cat3label.Text = cat2.title.ToUpper().Replace('&', ' ');
                cat4label.Text = cat2.title.ToUpper().Replace('&', ' ');
                cat5label.Text = cat2.title.ToUpper().Replace('&', ' ');
                cat6label.Text = cat2.title.ToUpper().Replace('&', ' ');

                cat1label.Visible = true; cat2label.Visible = true; cat3label.Visible = true; cat4label.Visible = true; cat5label.Visible = true; cat6label.Visible = true;
                revealButton.Visible = false;
                revealResponse.Visible = true;

                return;
            }

            if (clue.Text.Replace('&', ' ') == cat1label.Text.Replace('&', ' '))
            {
                clue.Text = cat2label.Text;
                return;
            }
            else if (clue.Text.Replace('&', ' ') == cat2label.Text.Replace('&', ' '))
            {
                clue.Text = cat3label.Text;
                return;
            }
            else if (clue.Text.Replace('&', ' ') == cat3label.Text.Replace('&', ' '))
            {
                clue.Text = cat4label.Text;
                return;
            }
            else if (clue.Text.Replace('&', ' ') == cat4label.Text.Replace('&', ' '))
            {
                clue.Text = cat5label.Text;
                return;
            }
            else if (clue.Text.Replace('&', ' ') == cat5label.Text.Replace('&', ' '))
            {
                clue.Text = cat6label.Text;
                return;
            }
            else if (clue.Text.Replace('&', ' ') == cat6label.Text.Replace('&', ' '))
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

        int highlightedPlayer = 0;
        public void awardAndRemove_Click(object sender, EventArgs e)
        {
            currentValue = (int)customWager.Value;
            Button btn = (Button)sender;
            string tag;
            tag = btn.Tag.ToString();

            if (btn.Text == "Admit")
            {
                gamePlayers[int.Parse(tag) - 1].Admitted = 1;
                return;
            }

            if (btn.Text == "Deny")
            {
                Label label = new Label();
                label.Tag = "q" + tag;
                p6score_Click(label, new EventArgs());

                if (tag == "1")
                    player1name.Text = "`";
                else if (tag == "2")
                    player2name.Text = "`";
                else if (tag == "3")
                    player3name.Text = "`";
                else if (tag == "4")
                    player4name.Text = "`";
                else if (tag == "5")
                    player5name.Text = "`";
                else if (tag == "6")
                    player6name.Text = "`";

                return;
            }

            if ((btn.Text == "Remove" && currentValue > 0) || (btn.Text == "Award" && currentValue < 0))
            {
                currentValue *= -1;

                if (!dailyDoubleState && !finalJeopardy)
                {
                    Unlock();
                }

                dailyDoubleState = false;
            }

            if (tag == "1")
            {
                gamePlayers[0].Score += currentValue;
                p1score.Text = "$" + gamePlayers[0].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player1name.BackColor = Color.LightPink;
                    highlightedPlayer = 1;
                    new Task(() => Flash(1, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(1, 0)).Start();
                }
            }
            else if (tag == "2")
            {
                gamePlayers[1].Score += currentValue;
                p2score.Text = "$" + gamePlayers[1].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player2name.BackColor = Color.LightPink;
                    highlightedPlayer = 2;
                    new Task(() => Flash(2, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(2, 0)).Start();
                }
            }
            else if (tag == "3")
            {
                gamePlayers[2].Score += currentValue;
                p3score.Text = "$" + gamePlayers[2].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player3name.BackColor = Color.LightPink;
                    highlightedPlayer = 3;
                    new Task(() => Flash(3, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(3, 0)).Start();
                }
            }
            else if (tag == "4")
            {
                gamePlayers[3].Score += currentValue;
                p4score.Text = "$" + gamePlayers[3].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player4name.BackColor = Color.LightPink;
                    highlightedPlayer = 4;
                    new Task(() => Flash(4, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(4, 0)).Start();
                }
            }
            else if (tag == "5")
            {
                gamePlayers[4].Score += currentValue;
                p5score.Text = "$" + gamePlayers[4].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player5name.BackColor = Color.LightPink;
                    highlightedPlayer = 5;
                    new Task(() => Flash(5, 1)).Start();
                }
                else
                {
                    new Task(() => Flash(5, 0)).Start();
                }
            }
            else if (tag == "6")
            {
                gamePlayers[5].Score += currentValue;
                p6score.Text = "$" + gamePlayers[5].Score;

                if (currentValue > 0)
                {
                    ResetLabelColors();
                    player6name.BackColor = Color.LightPink;
                    highlightedPlayer = 6;
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

            //Globals.playerScores = new int[] { player1score, player2score, player3score, player4score, player5score, player6score };
        }

        public void clear_Click(object sender, EventArgs e)
        {
            clue.Visible = false;
            customWager.Value = 0;
            countDown = false;
            ShowBoard();
            clueOpen = false;

            string data = GameFunction("setGameLock", gameCodeNum, "2");
            buzzes = new BuzzList();

            if (unlock.Text == "Lock")
            {
                Lock();
            }

            for (int i = 1; i < 7; i++)
            {
                ColorBoxes(i, Color.White);
            }

            ColorBoxes(highlightedPlayer, Color.LightPink);
        }

        public void endBtn_Click(object sender, EventArgs e)
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
            Player p = gamePlayers[index];
            gamePlayers.Remove(p);

            player1name.Text = "`";
            player2name.Text = "`";
            player3name.Text = "`";
            player4name.Text = "`";
            player5name.Text = "`";
            player6name.Text = "`";

            ToggleNamePlate(1, false);
            ToggleNamePlate(2, false);
            ToggleNamePlate(3, false);
            ToggleNamePlate(4, false);
            ToggleNamePlate(5, false);
            ToggleNamePlate(6, false);

            string data = GameFunction("removePlayer", p.Name, null);
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
        public void soundBtn_Click(object sender, EventArgs e)
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
            player.Play();
        }

        Controller activeController;
        public void popOutBtn_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller(this);
            controller.Show();
            this.Size = new Size(this.Width, 629);
            //unlockBtnRef = controller.unlock;
            clock.Enabled = true;
            activeController = controller;
        }

        public void export_Click(object sender, EventArgs e)
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

        public void chooseFile_Click(object sender, EventArgs e)
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

        private void roundBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        int lastAmount = 0;
        bool prevEarlyBuzz = false;
        private void updateNames_Tick(object sender, EventArgs e)
        {
            if (hidePlates)
            {
                ToggleNamePlate(1, false);
                ToggleNamePlate(2, false);
                ToggleNamePlate(3, false);
                ToggleNamePlate(4, false);
                ToggleNamePlate(5, false);
                ToggleNamePlate(6, false);
                hidePlates = false;
            }

            for (int c = 0; c < gamePlayers.Count; c++)
            {
                if (gamePlayers[c].Admitted == 2)
                {
                    gamePlayers.RemoveAt(c);
                }
            }

            int offset = 0;
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                Player player = gamePlayers[i - offset];
                if (gamePlayers.Count < lastAmount)
                {
                    ToggleNamePlate(1, false);
                    ToggleNamePlate(2, false);
                    ToggleNamePlate(3, false);
                    ToggleNamePlate(4, false);
                    ToggleNamePlate(5, false);
                    ToggleNamePlate(6, false);
                }

                if (player.Admitted == 0)
                {
                    offset++;
                    continue;
                }

                if (player.Admitted == 2)
                {
                    offset++;
                    //call to deny
                    continue;
                }

                lastAmount = gamePlayers.Count;

                if (i == 0)
                {
                    if (player.Teammate == null)
                    {
                        player1name.Text = player.Name;
                    }
                    else
                    {
                        player1name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(1, true);
                    p1score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player1name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 1)
                {
                    if (player.Teammate == null)
                    {
                        player2name.Text = player.Name;
                    }
                    else
                    {
                        player2name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(2, true);
                    p2score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player2name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 2)
                {
                    if (player.Teammate == null)
                    {
                        player3name.Text = player.Name;
                    }
                    else
                    {
                        player3name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(3, true);
                    p3score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player3name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 3)
                {
                    if (player.Teammate == null)
                    {
                        player4name.Text = player.Name;
                    }
                    else
                    {
                        player4name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(4, true);
                    p4score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player4name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 4)
                {
                    if (player.Teammate == null)
                    {
                        player5name.Text = player.Name;
                    }
                    else
                    {
                        player5name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(5, true);
                    p5score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player5name.BackColor = Color.LightGreen;
                    }
                }
                else if (i == 5)
                {
                    if (player.Teammate == null)
                    {
                        player6name.Text = player.Name;
                    }
                    else
                    {
                        player6name.Text = player.Name + "/" + player.Teammate.Name;
                    }

                    ToggleNamePlate(6, true);
                    p6score.Text = "$" + player.Score;

                    if (player.Wager != null && finalJeopardy && player.Score > 0)
                    {
                        player6name.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        bool countDown = false;
        DateTime start;
        public void unlock_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Unlock")
            {
                Unlock();
            }
            else if (btn.Text == "Lock")
            {
                Lock();
            }
        }

        bool checkBuzzes = false;
        public void Lock()
        {
            //buzzTimer.Enabled = false;
            checkBuzzes = false;
            string data = GameFunction("setGameLock", gameCodeNum, "1");
            unlock.Text = "Unlock";
            Controller.Lock = true;
            countDown = false;
            ResizeTimer(-1);
        }

        public void Unlock()
        {
            //buzzTimer.Enabled = true;
            checkBuzzes = true;
            string data = GameFunction("setGameLock", gameCodeNum, "0");
            unlock.Text = "Lock";
            Controller.Lock = false;
            countDown = true;
            ResizeTimer(0);
            start = DateTime.Now;
        }

        bool indivResponse = false;
        private void synchBuzzTimer_Tick(object sender, EventArgs e)
        {
            if (BuzzerList.EarlyBuzzPenalty != prevEarlyBuzz)
            {
                if (BuzzerList.EarlyBuzzPenalty)
                {
                    GameFunction("setPenalty", gameCodeNum, "1");
                }
                else
                {
                    GameFunction("setPenalty", gameCodeNum, "0");
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (earlyBuzzed[i] && !buzzed)
                {
                    ColorBoxes(i + 1, Color.LightYellow);
                    player.SoundLocation = "Early.wav";
                    player.Play();
                }
            }
            earlyBuzzed = new bool[6];

            if (buzzed)
            {
                Lock();
                synchBuzzTimer.Enabled = false;
                int i = 1;
                foreach (Player player in gamePlayers)
                {
                    if (player.ID == buzzID)
                    {
                        prevBuzzed.Add(player.ID);
                        break;
                    }
                    i++;
                }

                buzzed = false;

                player.SoundLocation = "Buzz.wav";
                player.Play();

                ColorBoxes(i, Color.LightBlue);
                ResizeTimer(i);
                start = DateTime.Now;
                indivResponse = true;
                countDown = true;

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

        public void award_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            awardAndRemove_Click(btn, new EventArgs());
        }

        private void ColorBoxes(int i, Color color)
        {
            if (i == 1)
            {
                player1name.BackColor = color;
            }
            if (i == 2)
            {
                player2name.BackColor = color;
            }
            if (i == 3)
            {
                player3name.BackColor = color;
            }
            if (i == 4)
            {
                player4name.BackColor = color;
            }
            if (i == 5)
            {
                player5name.BackColor = color;
            }
            if (i == 6)
            {
                player6name.BackColor = color;
            }
        }

        public string GameFunction(string function, string var1, string var2)
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
            form += "&key=" + ConfigurationManager.AppSettings["GameAPIKey"];
            byte[] data = Encoding.ASCII.GetBytes(form);

            try
            {
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                WebResponse resp = request.GetResponse();
                StreamReader reader = new StreamReader(resp.GetResponseStream());

                return reader.ReadToEnd();
            }
            catch
            {
                MessageBox.Show("Network error.");
            }

            return null;
        }

        public async Task<string> GameFunctionAsync(string function, string var1, string var2)
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
            form += "&key=" + ConfigurationManager.AppSettings["GameAPIKey"];
            byte[] data = Encoding.ASCII.GetBytes(form);

            try
            {
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                WebResponse resp = await request.GetResponseAsync();
                StreamReader reader = new StreamReader(resp.GetResponseStream());

                return await reader.ReadToEndAsync();
            }
            catch
            {
                MessageBox.Show("Network error.");
            }

            return null;
        }

        public void revealResponse_Click(object sender, EventArgs e)
        {
            HideBoard();
            pictureBox.Visible = false;
            clue.Visible = true;
            ColorBoxes(1, Color.White);
            ColorBoxes(2, Color.White);
            ColorBoxes(3, Color.White);
            ColorBoxes(4, Color.White);
            ColorBoxes(5, Color.White);
            ColorBoxes(6, Color.White);

            if (gamePlayers.Count == 0)
            {
                return;
            }

            if (gamePlayers[0].Visited == 2)
            {
                endBtn_Click(endBtn, new EventArgs());
                return;
            }

            for (int i = gamePlayers.Count - 1; i >= 0; i--)
            {
                Player player = gamePlayers[i];
                if (player.Score <= 0 || player.Wager == null)
                {
                    continue;
                }

                if (player.Visited == 0)
                {
                    if (player.Teammate == null)
                    {
                        clue.Text = player.Answer;
                        player.Visited++;
                        cat1label.Text = player.Name; cat2label.Text = player.Name; cat3label.Text = player.Name; cat4label.Text = player.Name; cat5label.Text = player.Name; cat6label.Text = player.Name;
                    }
                    else
                    {
                        clue.Text = player.Name + ": " + player.Answer + "\n" + player.Teammate.Name + ": " + player.Teammate.Answer;
                        player.Visited++;
                        cat1label.Text = player.Name; cat2label.Text = player.Teammate.Name; cat3label.Text = player.Name; cat4label.Text = player.Teammate.Name; cat5label.Text = player.Name; cat6label.Text = player.Teammate.Name;
                    }
                    break;
                }
                else if (player.Visited == 1)
                {
                    if (player.Teammate == null)
                    {
                        clue.Text = player.Answer + "\n\n$" + player.Wager;
                        customWager.Value = int.Parse(player.Wager);
                        player.Visited++;
                    }
                    else
                    {
                        clue.Text = player.Name + ": " + player.Answer + " - $" + player.Wager + "\n" + player.Teammate.Name + ": " + player.Teammate.Answer + " - $" + player.Teammate.Wager;
                        player.Visited++;
                    }
                    Controller.WagerValue = int.Parse(player.Wager);
                    break;
                }
                else if (player.Visited == 2)
                {
                    continue;
                }
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri = new Uri("https://www.googleapis.com/customsearch/v1?key=" + ConfigurationManager.AppSettings["APIKey"] + "&cx=" + ConfigurationManager.AppSettings["EngineID"] + "&searchType=image&q=" + currentClue.answer);
                WebRequest request = WebRequest.Create(uri);
                WebResponse resp = request.GetResponse();
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                string data = reader.ReadToEnd();

                clue.Visible = false;
                clueImage.Visible = true;
                pictureBox.Visible = true;

                var result = JsonConvert.DeserializeObject<JToken>(data);
                string link = result.Last.First.First["link"].ToString();
                clueImage.Text = currentClue.question;

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                request = WebRequest.Create(new Uri(link));
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox.Image = Bitmap.FromStream(stream);
                }
            }
            catch
            {
                MessageBox.Show("Error retrieving image.");
            }
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            Controller.Answer = answerBox.Text;
            Controller.DailyDoubles = doubles.Text;
            Controller.PlayerCount = gamePlayers.Count;
            foreach (Player p in gamePlayers)
            {
                if (p.Admitted == 0)
                {
                    Controller.PlayerCount--;
                }
            }

            if (unlock.Text == "Unlock")
            {
                Controller.Lock = true;
            }
            else if (unlock.Text == "Lock")
            {
                Controller.Lock = false;
            }
        }

        public string IDtoName(int playerID)
        {
            foreach (Player player in gamePlayers)
            {
                if (player.ID == playerID)
                    return player.Name;
            }

            return "not found";
        }

        private void GameBoard_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameStarted)
            {
                if (e.KeyCode == Keys.Space)
                {
                    unlock_Click(unlock, new EventArgs());
                }

                if (e.KeyCode == Keys.I)
                {
                    button1_Click(button1, new EventArgs());
                }
            }
        }

        private void updateBar_Tick(object sender, EventArgs e)
        {
            if (countDown)
            {
                TimeSpan span = DateTime.Now - start;
                timeToAnswer.Maximum = (BuzzerList.SecondsToGive * 1000);
                double seconds = (BuzzerList.SecondsToGive * 1000) - span.TotalMilliseconds;

                if (seconds < 0)
                {
                    countDown = false;
                    player.SoundLocation = "Time.wav";
                    player.Play();

                    if (!indivResponse)
                    {
                        Lock();
                    }

                    indivResponse = false;
                }
                else
                {
                    timeToAnswer.Value = (int)seconds;
                }
            }
        }

        public void ResizeTimer(int player)
        {
            switch (player)
            {
                case -1:
                    timeToAnswer.Size = new Size(1069, 15);
                    timeToAnswer.Location = new Point(12, 563);
                    timeToAnswer.Visible = false;
                    break;
                case 0:
                    timeToAnswer.Size = new Size(1069, 20);
                    timeToAnswer.Location = new Point(12, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 1:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(12, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 2:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(193, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 3:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(374, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 4:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(553, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 5:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(734, 563);
                    timeToAnswer.Visible = true;
                    break;
                case 6:
                    timeToAnswer.Size = new Size(166, 15);
                    timeToAnswer.Location = new Point(915, 563);
                    timeToAnswer.Visible = true;
                    break;
            }
        }

        int[] clickedNames = new int[2] { -1, -1 };
        private void NameClicked(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.BackColor = Color.LightSteelBlue;

            if (clickedNames[0] == -1)
            {
                clickedNames[0] = int.Parse(box.Tag.ToString()) - 1;
            }
            else if (clickedNames[1] == -1)
            {
                clickedNames[1] = int.Parse(box.Tag.ToString()) - 1;

                TeammateIDs.Add(gamePlayers[clickedNames[1]].ID);
                gamePlayers[clickedNames[0]].Teammate = gamePlayers[clickedNames[1]];
                gamePlayers.RemoveAt(clickedNames[1]);
                clickedNames = new int[] { -1, -1 };

                ToggleNamePlate(1, false);
                ToggleNamePlate(2, false);
                ToggleNamePlate(3, false);
                ToggleNamePlate(4, false);
                ToggleNamePlate(5, false);
                ToggleNamePlate(6, false);

                ColorBoxes(1, Color.White);
                ColorBoxes(2, Color.White);
                ColorBoxes(3, Color.White);
                ColorBoxes(4, Color.White);
                ColorBoxes(5, Color.White);
                ColorBoxes(6, Color.White);
            }
        }

        private void NameClicked(object sender, MouseEventArgs e)
        {
            
        }
    }
}