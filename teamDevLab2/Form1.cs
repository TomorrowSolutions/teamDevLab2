using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;

namespace teamDevLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<KeyValuePair<string,int>> tovar= new List<KeyValuePair<string, int>>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null||textBox1.Text!="")
            {
                tovar.Add(new KeyValuePair<string, int>(textBox1.Text,(int)numericUpDown1.Value));                
            }
            else
            {
                MessageBox.Show("err");
                return;
            }
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var kvPair in tovar)
            {
                string[] row = new string[] {(tovar.IndexOf(kvPair)+1).ToString(), kvPair.Key , kvPair.Value.ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tovar.RemoveAt((Convert.ToInt32(textBox2.Text) - 1));
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var output = JsonConvert.SerializeObject(tovar, Formatting.Indented);
            string path = Path.Combine(Environment.CurrentDirectory, "tovars.json");
            using (var sr= new StreamWriter(path,true))
            {
                sr.Write(output);
            }
            MessageBox.Show("succ");
        }
        public class kvp
        {
            string key;
            int n;
            public kvp(string k, int num)
            {
                key= k;
                n= num;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string json;
            string path = Path.Combine(Environment.CurrentDirectory, "tovars.json");
            using(var r= new StreamReader(path))
            {
                json = r.ReadToEnd();
            }
            tovar = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(json);
        }
    }
}
