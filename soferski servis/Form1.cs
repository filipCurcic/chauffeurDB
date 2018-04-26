using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace soferski_servis
{
    public partial class Form1 : Form
    {
        static string MySqlConnectionString = "datasource=localhost;port=3306;username=root;password=;database=123";
        MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
        public Form1()
        {
            InitializeComponent();
            onloadCb();
           
            
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
        private void createTables()
        {

        }

        

        public void runQuery(string query1)
        {
            
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myReader = commandDatabase.ExecuteReader();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            string q;
            switch (index)
            {
                case 0:
                    q = "CREATE TABLE asd (id INT);";
                    runQuery(q);
                    break;
                case 1:
                    q = "CREATE TABLE k2 (kejs2 INT);";
                    runQuery(q);
                    break;
                case 2:
                    textBox1.Text = "3";
                    break;
                case 3:
                    textBox1.Text = "4";
                    break;
                case 4:
                    textBox1.Text = "5";
                    break;
                case 5:
                    textBox1.Text = "6";
                    break;
                case 6:
                    textBox1.Text = "7";
                    break;
                case 7:
                    textBox1.Text = "8";
                    break;
                case 8:
                    textBox1.Text = "9";
                    break;
                case 9:
                    textBox1.Text = "10";
                    break;
                case 10:
                    textBox1.Text = "11";
                    break;
                case 11:
                    textBox1.Text = "12";
                    break;
                case 12:
                    textBox1.Text = "13";
                    break;
                case 13:
                    textBox1.Text = "14";
                    break;
                case 14:
                    textBox1.Text = "15";
                    break;
                case 15:
                    textBox1.Text = "16";
                    break;
                case 16:
                    textBox1.Text = "17";
                    break;
                case 17:
                    textBox1.Text = "18";
                    break;
                case 18:
                    textBox1.Text = "19";
                    break;
                case 19:
                    textBox1.Text = "20";
                    break;
                

            }
            
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
        private void onloadCb()
        {
    
            comboBox1.Items.Add("1. Šofer sa najviše obavljenih tura u prethodnom mesecu poslovanja");
            comboBox1.Items.Add("2. Šofer sa najboljim prosecnim rejtingom na godisnjim nivou");
            comboBox1.Items.Add("3. Tura sa najvećim prosečnim brojem putnika u letnjem periodu");
            comboBox1.Items.Add("4. Tura koja donosi najveći profit");
            comboBox1.Items.Add("5. Lokacija sa najvećim padom popularnosti u poslednjih 3 godine");
            comboBox1.Items.Add("6.  Šofer sa najboljim odnosom potrošenog goriva i pređene kilometraže");
            comboBox1.Items.Add("7. Vozilo sa najvecim troskovima servis u poslednji godinu dana");
            comboBox1.Items.Add("8. Najmanje popularno vozilo kod putnika mladjih od 25 godina u letnjem periodu");
            comboBox1.Items.Add("9.  Nacin placanja koji donosi najmanji profit");
            comboBox1.Items.Add("10.  Najpopularniji nacin placanja kod putnika ispod 30 godina");
            comboBox1.Items.Add("11. Vozilo sa najvećim porastom kilometraže u poslednjoj godini poslovanja");
            comboBox1.Items.Add("12. Starost putnika sa najmanje zastupljenim premium clanstvom  ");
            comboBox1.Items.Add("13. Vozilo sa najmanjim odnosom potrošenog goriva i prihoda po turi");
            comboBox1.Items.Add("14. Soferi koji imaju bolje prosecne ocene od putnika ove godine u poredjenju sa proslom");
            comboBox1.Items.Add("15.  Promena profita u odnosu na prethodnu godinu poslovanja");
            comboBox1.Items.Add("16. Premium putnik sa najvecim rastom predjenog puta u poslednjih 6 meseci");
            comboBox1.Items.Add("17. Šofer sa najvećim padom rejtinga u poslednjih 3 meseca poslovanja");
            comboBox1.Items.Add("18. Vozilo sa najvećim prosečnim brojem putnika po turi ");
            comboBox1.Items.Add("19. 3 najčešće ture sa 3 ili više putnika u vozilu");
            comboBox1.Items.Add("20. Koji mesec u godini donosi najveci profit");
        }

        
    }
}
