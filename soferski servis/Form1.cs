using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soferski_servis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void addToCb()
        {
            comboBox1.Items.Add("aasd");
            comboBox1.Items.Add("aas");
            comboBox1.Items.Add("ggggd");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addToCb();
        }
        private string addToTb()
        {
            string tekst = comboBox1.SelectedItem.ToString();
            return tekst;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = addToTb();
        }
    }
}
