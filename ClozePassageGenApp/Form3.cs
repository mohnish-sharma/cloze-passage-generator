using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClozePassageGenApp
{
    public partial class Form3 : Form
    {
        int questionNumber = 0;
        string[] boxAns;

        public Form3()
        {
            InitializeComponent();
            
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            boxAns = Form2.pasWords.OrderBy(x => random.Next()).ToArray();


            richTextBox1.Text = String.Join(" ", Form2.nothing);
            comboBox1.Text = "Select Words";


            label2.Hide();

            foreach (var i in boxAns)
            {
                comboBox1.Items.Add(i);
            }



        }

        public void button1_Click(object sender, EventArgs e)
        {
            string userAns = Convert.ToString(comboBox1.SelectedItem);


            string correctAnswer = Form2.pasWords[questionNumber];

                if (correctAnswer == userAns)
            {
                label2.Show();
                label2.ForeColor = System.Drawing.Color.Green;
                label2.Text = "Nice Job!, you got it correct! :)";
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                questionNumber++;
            }
                else if (correctAnswer != userAns)
            {
                label2.Show();
                label2.ForeColor = System.Drawing.Color.Red;
                label2.Text = "Ooo thats wrong.... Maybe try again?";

            }
        }
    }
}
