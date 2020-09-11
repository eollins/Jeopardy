using Newtonsoft.Json;
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
using System.Xml;
using System.Xml.Linq;

namespace Jeopardy
{
    public partial class Form1 : Form
    {
        public Form1 form1;
        Random random = new Random();
        Dictionary<Category, CategoryInfo> clues = new Dictionary<Category, CategoryInfo>();
        List<Category> categories = new List<Category>();
        string dailyDouble = "";
        string djdd1 = "";
        string djdd2 = "";
        bool cont = false;
        int currentValue = 0;
        string currentBtn = "";
        bool doubleJeopardy = false;
        bool finalJeopardy = false;
        int finalJep = 0;

        int player1score = 0;
        int player2score = 0;
        int player3score = 0;
        int player4score = 0;
        int player5score = 0;
        int player6score = 0;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            form1 = this;
            string[] values = new string[] { "200", "400", "600", "800", "1000" };
            dailyDouble = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            djdd1 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            djdd2 = "c" + random.Next(1, 7) + "v" + values[random.Next(2, 5)];
            ToggleBoard(false);

            doubles.Text = "Daily Doubles:\n" + dailyDouble + "\n" + djdd1 + " & " + djdd2;
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
        
        public void ToggleBoard(bool enab)
        {
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Enabled = enab;
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

            Clue[] cl = clues[categories[catID]].clues;

            bool cluePresent;
            Clue c;

            c = cl[valueIndex];
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
                label7.Text = c.answer.Replace("&", "&&");
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
                label7.Text = "";
            }
        }

        public void updateName()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //player.SoundLocation = "Theme.wav";
            //player.Play();
        }

        bool generate = true;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            categories.Clear();
            clues.Clear();
            DialogResult result = MessageBox.Show("Upload a custom game file?", "Game Source", buttons);
            if (result == DialogResult.Yes)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XDocument doc = new XDocument();
                        doc = XDocument.Load(openFileDialog1.FileName);
                        var nodes = doc.Element("GameBoard").Descendants();
                        for (int i = 0; i < nodes.Count(); i += 6)
                        {
                            XElement el = nodes.ElementAt(i);
                            string categoryName = el.Attribute("name").Value;
                            Category cat = new Category(categoryName);
                            categories.Add(cat);
                            Clue[] clues2 = new Clue[5];

                            var nodelist = from ele in el.Descendants("Clue")
                                           orderby int.Parse(ele.Attribute("value").Value)
                                           select ele;

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid file. Please try again.");
                }
            }

            player.Stop();
            ToggleBoard(true);
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'g'))
            {
                btnn.Tag = "board@" + btnn.Name.Substring(3);
                ShowBoard();
            }

            if (textBox1.Text == "Player One")
            {
                textBox1.Visible = false;
                p1score.Visible = false;
                award1.Visible = false;
                remove1.Visible = false;
            }
            else
            {
                textBox1.Enabled = false;
                p1score.Visible = true;
            }

            if (textBox2.Text == "Player Two")
            {
                textBox2.Visible = false;
                p2score.Visible = false;
                award2.Visible = false;
                remove2.Visible = false;
            }
            else
            {
                textBox2.Enabled = false;
                p2score.Visible = true;
            }

            if (textBox3.Text == "Player Three")
            {
                textBox3.Visible = false;
                p3score.Visible = false;
                award3.Visible = false;
                remove3.Visible = false;
            }
            else
            {
                textBox3.Enabled = false;
                p3score.Visible = true;
            }

            if (textBox4.Text == "Player Four")
            {
                textBox4.Visible = false;
                p4score.Visible = false;
                award4.Visible = false;
                remove4.Visible = false;
            }
            else
            {
                textBox4.Enabled = false;
                p4score.Visible = true;
            }

            if (textBox5.Text == "Player Five")
            {
                textBox5.Visible = false;
                p5score.Visible = false;
                award5.Visible = false;
                remove5.Visible = false;
            }
            else
            {
                textBox5.Enabled = false;
                p5score.Visible = true;
            }

            if (textBox6.Text == "Player Six")
            {
                textBox6.Visible = false;
                p6score.Visible = false;
                award6.Visible = false;
                remove6.Visible = false;
            }
            else
            {
                textBox6.Enabled = false;
                p6score.Visible = true;
            }

            generateGame();
        }

        public void generateGame()
        {
            if (generate)
            {
                foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'g'))
                {
                    btnn.Tag = "board@" + btnn.Tag.ToString().Substring(btnn.Tag.ToString().IndexOf('@') + 1);
                }

                if (radioButton3.Checked)
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
                    finalJep = int.Parse(category[0].id);
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
                            label1.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 1:
                            label2.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 2:
                            label3.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 3:
                            label4.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 4:
                            label5.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 5:
                            label6.Text = cat.title.ToUpper().Replace("&", "&&");
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
                        if (cl.question == "")
                        {
                            string btnName = "c" + i + "v" + val;

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
                            label1.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 1:
                            label2.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 2:
                            label3.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 3:
                            label4.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 4:
                            label5.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                        case 5:
                            label6.Text = cat.title.ToUpper().Replace("&", "&&");
                            break;
                    }

                    int val = 200;
                    foreach (Clue cl in clues[cat].clues)
                    {
                        if (cl == null)
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

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            if (radioButton1.Checked)
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
            else if (radioButton2.Checked)
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

        private void button4_Click(object sender, EventArgs e)
        { 
            if (radioButton3.Checked)
            {
                WebRequest clueRequest = WebRequest.Create("http://jservice.io/api/category?id=" + finalJep);
                WebResponse clueResponse = clueRequest.GetResponse();
                StreamReader reader2 = new StreamReader(clueResponse.GetResponseStream());
                string json2 = reader2.ReadToEnd();
                CategoryInfo cat2 = JsonConvert.DeserializeObject<CategoryInfo>(json2);
                clue.Text = cat2.clues[0].question;
                label7.Text = cat2.clues[0].answer;

                label1.Text = cat2.title.ToUpper();
                label2.Text = cat2.title.ToUpper();
                label3.Text = cat2.title.ToUpper();
                label4.Text = cat2.title.ToUpper();
                label5.Text = cat2.title.ToUpper();
                label6.Text = cat2.title.ToUpper();

                player.SoundLocation = "Final.wav";
                player.Play();

                return;
            }

            if (clue.Text == label1.Text)
            {
                clue.Text = label2.Text;
                return;
            }
            else if (clue.Text == label2.Text)
            {
                clue.Text = label3.Text;
                return;
            }
            else if (clue.Text == label3.Text)
            {
                clue.Text = label4.Text;
                return;
            }
            else if (clue.Text == label4.Text)
            {
                clue.Text = label5.Text;
                return;
            }
            else if (clue.Text == label5.Text)
            {
                clue.Text = label6.Text;
                return;
            }
            else if (clue.Text == label6.Text)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

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
                    label7.Text = c.answer;
                    currentValue = int.Parse(value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value > 0)
            {
                currentValue = (int)numericUpDown2.Value;
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
                numericUpDown2.Value = 0;
                ShowBoard();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clue.Visible = false;
            numericUpDown2.Value = 0;
            ShowBoard();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            HideBoard();
            //int[] scores = new int[6] { 99999, 99999, 99999, 99999, 99999, 99999 };
            Dictionary<string, int> scores = new Dictionary<string, int>();
            if (p1score.Visible)
            {
                scores.Add(textBox1.Text, int.Parse(p1score.Text.Substring(1)));
            }
            if (p2score.Visible)
            {
                scores.Add(textBox2.Text, int.Parse(p2score.Text.Substring(1)));
            }
            if (p3score.Visible)
            {
                scores.Add(textBox3.Text, int.Parse(p3score.Text.Substring(1)));
            }
            if (p4score.Visible)
            {
                scores.Add(textBox4.Text, int.Parse(p4score.Text.Substring(1)));
            }
            if (p5score.Visible)
            {
                scores.Add(textBox5.Text, int.Parse(p5score.Text.Substring(1)));
            }
            if (p6score.Visible)
            {
                scores.Add(textBox6.Text, int.Parse(p6score.Text.Substring(1)));
            }
            string[] names = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text };
            
            clue.Visible = true;
            clue.Text = "FINAL SCORES\n\n";
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

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
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
                    label1.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 1:
                    label2.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 2:
                    label3.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 3:
                    label4.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 4:
                    label5.Text = cat2.title.ToUpper().Replace("  ", " & ");
                    break;
                case 5:
                    label6.Text = cat2.title.ToUpper().Replace("  ", " & ");
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

        private void button6_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "Time.wav";
            player.Play();
        }
    }
}
