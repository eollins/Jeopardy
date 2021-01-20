using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JeopardyGameMaker
{
    public partial class Form1 : Form
    {
        XmlDocument doc = new XmlDocument();
        string category = "0";
        string value = "0";
        bool present = false;
        int cluesAdded = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void HideBoard()
        {
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Hide();
                textBox2.Show();
            }
        }

        public void ShowBoard()
        {
            foreach (var btnn in Controls.OfType<Button>().Where(x => x.Tag.ToString()[0] == 'b'))
            {
                btnn.Show();
                textBox2.Hide();
            }
        }

        private void c1v200_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            category = (int.Parse(btn.Name[1].ToString()) - 1).ToString();
            value = btn.Name.Substring(3);
            btn.ForeColor = Color.Green;
            HideBoard();

            XmlNode nodes = doc.FirstChild.ChildNodes[int.Parse(category)];
            foreach (XmlElement el2 in nodes)
            {
                if (el2.GetAttribute("value") == value)
                {
                    textBox2.Text = el2.InnerText;
                    textBox1.Text = el2.GetAttribute("answer");
                    present = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.AppendChild(doc.CreateElement("GameBoard"));
            XmlElement[] elements = new XmlElement[] { doc.CreateElement("Category"), doc.CreateElement("Category"), doc.CreateElement("Category"), doc.CreateElement("Category"), doc.CreateElement("Category"), doc.CreateElement("Category") };
            foreach (XmlElement el in elements)
            {
                el.Attributes.Append(doc.CreateAttribute("name"));
                doc.ChildNodes[0].AppendChild(el);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlElement el = doc.CreateElement("Clue");
            el.Attributes.Append(doc.CreateAttribute("answer"));
            el.Attributes.Append(doc.CreateAttribute("value"));
            el.InnerText = textBox2.Text;
            el.SetAttribute("answer", textBox1.Text);
            el.SetAttribute("value", value);

            if (textBox9.Text != "")
            {
                el.Attributes.Append(doc.CreateAttribute("image"));
                el.SetAttribute("image", textBox9.Text);
            }

            XmlNode nodes = doc.FirstChild.ChildNodes[int.Parse(category)];

            if (!present)
            {
                cluesAdded++;
            }
            else
            {
                foreach (XmlElement el2 in nodes)
                {
                    if (el2.GetAttribute("value") == value)
                    {
                        nodes.RemoveChild(el2);
                    }
                }
            }

            nodes.AppendChild(el);
            Button btn = (Button)sender;
            textBox1.Clear();
            textBox2.Clear();
            ShowBoard();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            XmlElement nodes = (XmlElement)doc.FirstChild.ChildNodes[int.Parse(tb.Tag.ToString()[6].ToString())];
            nodes.Attributes.Append(doc.CreateAttribute("name"));
            nodes.SetAttribute("name", tb.Text.ToUpper());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveFileDialog1.FileName);
                Application.Exit();
            }
        }
    }
}
