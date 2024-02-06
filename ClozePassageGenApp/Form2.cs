using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;
namespace ClozePassageGenApp

{
    public partial class Form2 : Form
    {
        string[] closePassageArray;
        int freq;
        public static string[] nothing;
        public static string[] pasWords;
        public static string[] sortWords;
        public static string inputPassage;
        public static string[] PASSWORDS;
        public static int NoOfQuestions;



        public Form2()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MenuPage = new Form1();
            MenuPage.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Enter close passage text...";
            listBox1.Hide();
            button7.Hide();
            button4.Hide();
            button8.Hide();
        }


        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Enter close passage text...")
            {
                richTextBox1.Text = "";
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Enter close passage text...";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                richTextBox1.Text = text;
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {






        }

        public void button2_Click(object sender, EventArgs e)
        {
            button8.Show();
            inputPassage = richTextBox1.Text;
            richTextBox3.Text = inputPassage;
            closePassageArray = inputPassage.Split(' ');
            closePassageArray = (from i in closePassageArray
                                 select i.Trim(new Char[] { ',', ' ', '.', '/', '!', '?', '(', ')', ':' })).ToArray();
            closePassageArray = closePassageArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            richTextBox2.Text = string.Join("\n", closePassageArray);

            int z = closePassageArray.Length;
            numericUpDown1.Maximum = z - 2;

        }

        public void button8_Click(object sender, EventArgs e)
        {
            button7.Show();
            freq = Convert.ToInt32(numericUpDown1.Value);

            int x = freq;

            int y = 0;

            nothing = new string[closePassageArray.Length];

            nothing = inputPassage.Split(' ');
            int z = closePassageArray.Length;

            NoOfQuestions = z;

            System.Diagnostics.Debug.WriteLine("closePassageArray: " + String.Concat(closePassageArray));
            System.Diagnostics.Debug.WriteLine("length of array:" + z);
            System.Diagnostics.Debug.WriteLine("freq chosen: " + freq);
            System.Diagnostics.Debug.WriteLine("Nothingval: " + String.Concat(nothing));
            System.Diagnostics.Debug.WriteLine("removed words: " + nothing[x]);
            System.Diagnostics.Debug.WriteLine("sortWords " + sortWords);
            System.Diagnostics.Debug.WriteLine("pasWords " + pasWords);

            pasWords = new string[closePassageArray.Length];
            sortWords = new string[pasWords.Length];



            while (x < z)
            {
                pasWords[y] = closePassageArray[x];


                
                nothing[x] = "_________" + "(" + (y + 1) + ")";
                

                foreach (var i in nothing)
                {
                    richTextBox3.Text = String.Join(" ", nothing);
                }

            

                x += freq;
                y++;



            }

            richTextBox2.Text = string.Join("\n", pasWords);

            pasWords = pasWords.Distinct().ToArray();
            pasWords = pasWords.Reverse().Skip(1).Reverse().ToArray();
            
            
            button4.Show();

 

        }



        private void button7_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            pasWords = pasWords.OrderBy(x => random.Next()).ToArray();

                richTextBox2.Text = String.Join("\n", pasWords);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("clicked");
        }

        public void button5_Click_1(object sender, EventArgs e)
        {
            listBox1.Show();
            listBox1.BringToFront();
            listBox1.Items.Clear();

            foreach (var i in closePassageArray)
            {
                listBox1.Items.Add(i);
            }

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = " ";

            string passWords = listBox1.GetItemText(listBox1.SelectedItem);

            richTextBox2.Text += passWords;

            listBox1.Items.Remove(listBox1.SelectedItem);



        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //PrintDialog;
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            //PrintDialog;
        }
    }


    }
  
