using System;
using System.Collections;
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
        
        private void fillTable()
        {

            string q2 = "CREATE TABLE IF NOT EXISTS vozilo (idvozilo INT NOT NULL AUTO_INCREMENT, brend VARCHAR(45), model VARCHAR(45), pocetak_rada INT, PRIMARY KEY(idvozilo));";
            runQuery(q2);
            databaseConnection.Close();
            string q = "INSERT INTO vozilo(brend, model, pocetak_rada) VALUES ('Mercedes Benz', 'S400', 2013), ('BMW', 'x5', 2012), ('Audi', 'A8', 2015), ('BMW', '750i', 2012), ('Audi', 'q7', 2011), ('Opel', 'Insignia', 2012), ('Lincoln', 'Navigator', 2010), ('Chrysler', 'One', 2010), ('Mazda', '6', 2015), ('Mercedes Benz', 'E200', 2016), ('Audi', 'TT', 2012), ('VW', 'Passat', 2017), ('Audi', 'A3', 2012), ('Range Rover', 'Sport', 2011), ('Bentley', 'Continental', 2014)";
            runQuery(q);
            databaseConnection.Close();
        }

        private void createTables()
        {
            string q1 = "CREATE TABLE sofer (idsofer INT NOT NULL AUTO_INCREMENT, ime VARCHAR(45), prezime VARCHAR(45), datum_zaposljavanja VARCHAR(45), PRIMARY KEY(idsofer));";
            string q2 = "CREATE TABLE vozilo (idvozilo INT NOT NULL AUTO_INCREMENT, brend VARCHAR(45), model VARCHAR(45), pocetak_rada INT, PRIMARY KEY(idvozilo));";
            string q3 = "CREATE TABLE lokacija (idlokacija INT NOT NULL AUTO_INCREMENT, naziv VARCHAR(500), PRIMARY KEY(idlokacija));";
            string q4 = "CREATE TABLE gorivo (idgorivo INT NOT NULL AUTO_INCREMENT, cena INT, PRIMARY KEY(idgorivo));";
            string q5 = "CREATE TABLE tura (idtura INT NOT NULL AUTO_INCREMENT, datum DATE, predjeni_put INT, sofer_idsofer INT, vozilo_idvozilo INT, lokacija_idlokacija INT, gorivno_idgorivo INT, kolicina_goriva INT, PRIMARY KEY(idtura), FOREIGN KEY(sofer_idsofer) REFERENCES sofer(idsofer), FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo), FOREIGN KEY(lokacija_idlokacija) REFERENCES lokacija(idlokacija), FOREIGN KEY(gorivo_idgorivo) REFERENCES gorivo(idgorivo);";
            string q6 = "CREATE TABLE putnik (idputnik INT NOT NULL AUTO_INCREMENT, ime VARCHAR(100), prezime VARCHAR(100), godina_rodjenja INT, clanstvo ENUM('STANDARD', 'PREMIUM'), PRIMARY KEY(idputnik)";
            string q7 = "CREATE TABLE servis (idservis INT NOT NULL AUTO_INCREMENT, datum DATE, cena INT, vozilo_idvozilo INT, PRIMARY KEY(idservis), FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo);";
            string q8 = "CREATE TABLE soferi_voila (sofer_idsofer INT NOT NULL, vozilo_idvozilo INT NOT NULL, FOREIGN KEY(sofer_idsofer) REFERENCES sofer(idsofer), FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo);";
            string q9 = "CREATE TABLE nacin_placanja (idnacin_placanja INT NOT NULL AUTO_INCREMENT, naziv VARCHAR(45), PRIMARY KEY(idnacin_placanja);";
            string q10 = "CREATE TABLE racun (idracun INT NOT NULL AUTO_INCREMENT, iznos INT, datum DATE, nacin_placanja_id INT NOT NULL, tura_idtura INT NOT NULL, PRIMARY KEY(idracun), FOREIGN KEY(nacin_placanja_id) REFERENCES nacin_placanja(idnacin_placanja), FOREIGN KEY (tura_idtura) REFERENCES tura(idtura);";
            string q11 = "CREATE TABLE premium_putnici (idpremium_putnici INT NOT NULL AUTO_INCREMENT, putnik_idputnik INT NOT NULL, predjen_put INT, PRIMARY KEY(idpremium_putnici), FOREIGN KEY(putnik_idputnik) REFERENCES putnik(idputnik);";
            string q12 = "CREATE TABLE plate (idplate INT NOT NULL AUTO_INCREMENT, sofer_idsofer INT NOT NULL, iznos INT, datum DATE, PRIMARY KEY(idplate), FOREIGN KEY (sofer_idsofer) REFERENCES sofer(idsofer);";
            string q13 = "CREATE TABLE putnici_u_turi (putnik_idputnik INT NOT NULL, tura_idtura INT NOT NULL, FOREIGN KEY(putnik_idputnik) REFERENCES putnik(idputnik), FOREIGN KEY (tura_idtura) REFERENCES tura(idtura);";

            
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
                    q = "CREATE TABLE IF NOT EXISTS gorivo (idgorivo INT NOT NULL AUTO_INCREMENT, cena INT, kolicina INT, PRIMARY KEY(idgorivo));";
                    runQuery(q);
                    databaseConnection.Close();
                    break;
                case 1:
                    q = "CREATE TABLE IF NOT EXISTS servis (idservis INT NOT NULL AUTO_INCREMENT, datum INT, cena INT, vozilo_idvozilo INT, PRIMARY KEY(idservis), FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo));";
                    runQuery(q);
                    databaseConnection.Close();
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

        private void generateData()
        {
            string[] imena1 = new string[10] {"Jovana", "Dragan", "Dejan", "Dragana", "Petar", "Marko", "Aleksandar", "Luka", "Ivan", "Tijana"};
            string[] prezimena = new string[10] { "Milanovic", "Petrovic", "Dejanovic", "Pavlovic", "Markovic", "Vujosevic", "Mitrovic", "Vucic", "Maksimovic", "Stanic"};
            int[] godine = new int[10] { 1994, 1992, 1999, 1991, 1994, 1998, 1997, 2000, 1989, 2001};
            string[] clanstvo = new string[10] { "STANDARD", "PREMIUM", "STANDARD", "STANDARD", "PREMIUM", "PREMIUM", "PREMIUM", "STANDARD", "STANDARD", "PREMIUM" };
            int[] gorivoCena = new int[10] {1000, 2000, 3000, 4000, 10000, 12000, 2500, 9000, 5000, 7600 };
            int[] gorivoKolicina = new int[10] { 10, 20, 25, 30, 50, 100, 55, 40, 90, 85 };
            int[] servisDatum = new int[10] { 2017-03-15, 2015-06-02, 2011-01-19, 2014-09-22, 2013-12-12, 2015-05-21, 2017-09-29, 2017-03-15, 2016-01-03, 2010-10-20 };
            int[] servisCena = new int[10] { 12000, 20000, 5000, 50000, 100000, 15000, 30000, 8000, 19000, 20000 };
            for (int i = 0; i < 20; i++)
            {
                
                string putnik = "INSERT INTO putnik(ime, prezime, godina_rodjenja, clanstvo) VALUES ('" + imena1[Ran()] + "','" + prezimena[Ran()] + "','" + godine[Ran()] + "','" + clanstvo[Ran()] + "')";
                string sofer = "INSERT INTO sofer(ime, prezime, godina_zaposljavanja) VALUES ('" + imena1[Ran()] + "','" + prezimena[Ran()] + "','" + godine[Ran()] + "')";
                string gorivo = "INSERT INTO gorivo(cena, kolicina) VALUES('" + gorivoCena[Ran()] + "','" + gorivoKolicina[Ran()] + "')";
                string servis = "INSERT INTO servis(datum, cena, vozilo_idvozilo) VALUES('" + servisDatum[Ran()] + "','" + servisCena[Ran()] + "' ,'" + Ran() + "')";

                runQuery(servis);
                databaseConnection.Close();
                
                runQuery(gorivo);
                databaseConnection.Close();

            }


        }
        static Random rnd = new Random();
        private int Ran()
        {
            int single = rnd.Next(1, 10);
            
            return single;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            fillTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generateData();
        }
    }
}
