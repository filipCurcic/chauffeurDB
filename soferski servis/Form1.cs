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
            string q = "INSERT INTO vozilo(brend, model, pocetak_rada) VALUES ('Mercedes Benz', 'S400', 2013), ('BMW', 'x5', 2012), ('Audi', 'A8', 2015), ('BMW', '750i', 2012), ('Audi', 'q7', 2011), ('Opel', 'Insignia', 2012), ('Lincoln', 'Navigator', 2010), ('Chrysler', 'One', 2010), ('Mazda', '6', 2015), ('Mercedes Benz', 'E200', 2016), ('Audi', 'TT', 2012), ('VW', 'Passat', 2017), ('Audi', 'A3', 2012), ('Range Rover', 'Sport', 2011), ('Bentley', 'Continental', 2014)";
            runQuery(q);
            databaseConnection.Close();
            string nacin_p = "INSERT INTO nacin_placanja(naziv) VALUES ('Kes'), ('Kreditna Kartica'), ('Online');";
            runQuery(nacin_p);
            databaseConnection.Close();
        }

        private void createTables()
        {
            string q1 = "CREATE TABLE sofer " +
                " (idsofer INT NOT NULL AUTO_INCREMENT," +
                " ime VARCHAR(45), prezime VARCHAR(45)," +
                " godina_zaposljavanja INT," +
                " PRIMARY KEY(idsofer));";


            string q2 = "CREATE TABLE vozilo " +
                " (idvozilo INT NOT NULL AUTO_INCREMENT," +
                " brend VARCHAR(45)," +
                " model VARCHAR(45)," +
                " pocetak_rada INT," +
                " PRIMARY KEY(idvozilo));";
            


            string q4 = "CREATE TABLE gorivo " +
                "(idgorivo INT NOT NULL AUTO_INCREMENT, " +
                "cena INT, " +
                "kolicina INT, " +
                "PRIMARY KEY(idgorivo));";


            string q5 = "CREATE TABLE tura " +
                " (idtura INT NOT NULL AUTO_INCREMENT," +
                " datum DATE," +
                " pocetna_lokacija VARCHAR(100)," +
                " destinacija VARCHAR(100)," +
                " iznos INT," +
                " kilometraza INT," +
                " rejting_sofera INT, " +
                " sofer_idsofer INT NOT NULL," +
                " vozilo_idvozilo INT NOT NULL," +
                " gorivo_idgorivo INT NOT NULL," +
                " idnp INT NOT NULL," +
                " PRIMARY KEY(idtura)," +
                " FOREIGN KEY(sofer_idsofer) REFERENCES sofer(idsofer), " +
                " FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo)," +
                " FOREIGN KEY(gorivo_idgorivo) REFERENCES gorivo(idgorivo), " +
                " FOREIGN KEY(idnp) REFERENCES nacin_placanja(idnacin_placanja));";

            string q6 = "CREATE TABLE putnik" +
                " (idputnik INT NOT NULL AUTO_INCREMENT," +
                " ime VARCHAR(100)," +
                " prezime VARCHAR(100)," +
                " godina_rodjenja INT," +
                " clanstvo ENUM('STANDARD', 'PREMIUM')," +
                " PRIMARY KEY(idputnik));";


            string q7 = "CREATE TABLE servis " +
                " (idservis INT NOT NULL AUTO_INCREMENT, " +
                " datum DATE," +
                " cena INT," +
                " vozilo_idvozilo INT NOT NULL, " +
                " PRIMARY KEY(idservis), " +
                " FOREIGN KEY(vozilo_idvozilo) REFERENCES vozilo(idvozilo));";

            string q9 = "CREATE TABLE nacin_placanja" +
                " (idnacin_placanja INT NOT NULL AUTO_INCREMENT," +
                " naziv VARCHAR(45), " +
                " PRIMARY KEY(idnacin_placanja));";

            string q11 = "CREATE TABLE premium_putnici " +
                " (idpremium_putnici INT NOT NULL AUTO_INCREMENT, " +
                " putnik_idputnik INT NOT NULL, " +
                " predjen_put INT," +
                " PRIMARY KEY(idpremium_putnici)," +
                " FOREIGN KEY(putnik_idputnik) REFERENCES putnik(idputnik));";

            string q12 = "CREATE TABLE plate" +
                " (idplate INT NOT NULL AUTO_INCREMENT, " +
                " sofer_idsofer INT NOT NULL," +
                " iznos INT," +
                " datum DATE, " +
                " PRIMARY KEY(idplate), " +
                " FOREIGN KEY (sofer_idsofer) REFERENCES sofer(idsofer));";

            string q13 = "CREATE TABLE putnici_u_turi" +
                " (putnik_idputnik INT NOT NULL, " +
                " tura_idtura INT NOT NULL, " +
                " FOREIGN KEY(putnik_idputnik) REFERENCES putnik(idputnik), " +
                " FOREIGN KEY (tura_idtura) REFERENCES tura(idtura));";

            string[] queries = new string[10] { q1, q2, q4, q6, q9, q7, q5, q11, q12, q13 };

            for (int i = 0; i<10; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(queries[i]);
                runQuery(queries[i]);
                databaseConnection.Close();
                if (i == 9)
                {
                    MessageBox.Show("Success");
                }
            }

            
        }

        MySqlDataReader myReader;

        public void runQuery(string query1)
        {
            
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();

            myReader = commandDatabase.ExecuteReader();
        }

        private string GetResult(MySqlDataReader rd)
        {
            if (rd.HasRows)
            {
                MessageBox.Show("Your query generated results");
                StringBuilder rezultat = new StringBuilder();

                while (rd.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        rezultat.Append(myReader.GetString(i));
                        rezultat.Append(" ");
                        
                    }
                    rezultat.Append("\n");

                }
                return rezultat.ToString();
            }
            return null;
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string tst = " JOIN sofer ON tura.sofer_idsofer = sofer.idsofer";
            string q;
            switch (index)
            {
                case 0:
                    q = "SELECT tura.sofer_idsofer, sofer.ime, sofer.prezime FROM tura JOIN sofer ON tura.sofer_idsofer = sofer.idsofer WHERE tura.datum > (SELECT DATE_ADD(NOW(), INTERVAL -1 YEAR)) GROUP BY tura.sofer_idsofer ORDER BY COUNT(*) DESC LIMIT 1;";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 1:
                    q = "SELECT AVG(rejting_sofera), sofer.ime, sofer.prezime, sofer_idsofer FROM tura JOIN sofer ON tura.sofer_idsofer = sofer.idsofer WHERE tura.datum > (SELECT DATE_ADD(NOW(), INTERVAL -1 YEAR)) GROUP BY sofer_idsofer ASC LIMIT 1";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 2:
                    q = "SELECT tura_idtura, pocetna_lokacija, destinacija, COUNT(*) AS avg_tura FROM putnici_u_turi JOIN tura ON putnici_u_turi.tura_idtura = tura.idtura GROUP BY tura_idtura ORDER BY avg_tura DESC LIMIT 1";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 3:
                    q = "SELECT pocetna_lokacija, destinacija, tura.iznos - gorivo.cena AS mks FROM tura JOIN gorivo ON tura.gorivo_idgorivo = gorivo.idgorivo ORDER BY mks DESC LIMIT 1;";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 4:
                    textBox1.Text = "5";
                    break;
                case 5:
                    q = "SELECT sofer.ime, sofer.prezime, tura.kilometraza / gorivo.kolicina as odn FROM tura JOIN sofer on tura.sofer_idsofer = sofer.idsofer JOIN gorivo ON tura.gorivo_idgorivo = gorivo.idgorivo GROUP BY tura.sofer_idsofer ORDER BY odn DESC LIMIT 1";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 6:
                    q = "SELECT vozilo.brend, vozilo.model, SUM(CENA) as suma FROM servis JOIN vozilo ON servis.vozilo_idvozilo = vozilo.idvozilo WHERE servis.datum > (SELECT DATE_ADD(NOW(), INTERVAL -1 YEAR)) GROUP BY servis.vozilo_idvozilo ORDER BY suma DESC LIMIT 1";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 7:
                    textBox1.Text = "8";
                    break;
                case 8:
                    textBox1.Text = "9";
                    break;
                case 9:
                    q = "SELECT nacin_placanja.naziv, COUNT(nacin_placanja.naziv) AS npz FROM tura JOIN nacin_placanja ON tura.idnp = nacin_placanja.idnacin_placanja JOIN putnici_u_turi ON tura.idtura = putnici_u_turi.tura_idtura JOIN putnik ON putnici_u_turi.putnik_idputnik = putnik.idputnik WHERE YEAR(NOW()) - putnik.godina_rodjenja <= 25 GROUP BY nacin_placanja.naziv ORDER BY npz DESC LIMIT 1;";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 10:
                    textBox1.Text = "11";
                    break;
                case 11:
                    q = "SELECT YEAR(NOW()) - putnik.godina_rodjenja AS gd FROM premium_putnici JOIN putnik ON premium_putnici.putnik_idputnik = putnik.idputnik GROUP BY putnik.godina_rodjenja ORDER BY putnik.godina_rodjenja DESC LIMIT 1";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
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
                    q = "SELECT vozilo.brend, vozilo.model FROM tura JOIN vozilo ON tura.vozilo_idvozilo = vozilo.idvozilo JOIN putnici_u_turi ON tura.idtura = putnici_u_turi.tura_idtura GROUP BY putnici_u_turi.tura_idtura ORDER BY COUNT(putnici_u_turi.tura_idtura) DESC LIMIT 1;";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 18:
                    q = "SELECT tura.pocetna_lokacija, tura.destinacija FROM putnici_u_turi JOIN tura ON putnici_u_turi.tura_idtura = tura.idtura GROUP BY putnici_u_turi.tura_idtura ORDER BY COUNT(putnici_u_turi.tura_idtura) DESC LIMIT 3";
                    runQuery(q);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 19:
                    textBox1.Text = "20";
                    break;
                

            }
            
        }
        
        private void addToTb(string text)
        {
            textBox1.Text = text;
            textBox1.Text = text.Replace("\n", Environment.NewLine);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public static string dtfordb(DateTime dt)
        {
            return dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.TimeOfDay;
        }

        private void generateData()
        {
            string[] imena1 = new string[10] {"Jovana", "Dragan", "Dejan", "Dragana", "Petar", "Marko", "Aleksandar", "Luka", "Ivan", "Tijana"};
            string[] prezimena = new string[10] { "Milanovic", "Petrovic", "Dejanovic", "Pavlovic", "Markovic", "Vujosevic", "Mitrovic", "Vucic", "Maksimovic", "Stanic"};
            int[] godine = new int[10] { 1994, 1992, 1999, 1991, 1994, 1998, 1997, 2000, 1989, 2001};
            int[] gorivoCena = new int[10] {1000, 2000, 1500, 800, 1620, 750, 500, 1100, 1700, 1600 };
            int[] gorivoKolicina = new int[10] { 10, 20, 25, 30, 50, 100, 55, 40, 90, 85 };
            int[] godineZaDatum = new int[10] {2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018};
            int[] meseciZaDatum = new int[10] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] daniZaDatum = new int[10] { 12, 20, 28, 9, 1, 6, 16, 22, 4, 15 };
            int[] servisCena = new int[10] { 12000, 20000, 5000, 50000, 100000, 15000, 30000, 8000, 19000, 20000 };
            int[] predjenPut = new int[10] { 100, 500, 50, 250, 1020, 130, 300, 20, 500, 91 };
            string[] destinacije = new string[10] { "Beograd", "Fruska Gora", "Sremski Karlovci", "Subotica", "Nis", "Novi Sad", "Jagodina", "Kragujevac", "Zrenjanin", "Uzice" };
            string[] pocetna_lokacija = new string[10] { "Sremska Mitrovica", "Becej", "Titel", "Sajkas", "Sombor", "Valjevo", "Kraljevo", "Futog", "Zemun", "Obrenovac" };
            int[] iznos = new int[10] {2200, 2800, 5000, 3000, 2500, 13000, 5000, 2500, 2705, 8000};
            int[] kilometraza = new int[10] { 100, 200, 300, 150, 50, 70, 80, 250, 30, 220 };
            int[] iznosPlate = new int[10] { 40000, 50000, 45000, 55000, 60000, 65000, 70000, 80000, 43000, 71000 };
            int[] insertedIds = new int[20] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int[] rejtinzi = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Random r2 = new Random();
            Random r3 = new Random();
            Random r4 = new Random(); 

            for (int i = 0; i < 20; i++)
            {
                int s2 = r2.Next(0, i+1);
                int s3 = r2.Next(0, i + 1);
                int s4 = r2.Next(0, i + 1);
                int vh = r4.Next(1, 16);
                int ss = r3.Next(1, 4);
                string dtServis = dtfordb(new DateTime(godineZaDatum[Ran()], meseciZaDatum[Ran()], daniZaDatum[Ran()]));
                string dtPlate = dtfordb(new DateTime(godineZaDatum[Ran()], meseciZaDatum[Ran()], daniZaDatum[Ran()]));
                string dTure = dtfordb(new DateTime(godineZaDatum[Ran()], meseciZaDatum[Ran()], daniZaDatum[Ran()]));

                insertedIds[i] = i + 1;
                Console.WriteLine(insertedIds[0 + i]);
                
                string putnik = "INSERT INTO putnik(ime, prezime, godina_rodjenja) VALUES ('" + imena1[Ran()] + "','" + prezimena[Ran()] + "','" + godine[Ran()] + "')";

                string sofer = "INSERT INTO sofer(ime, prezime, godina_zaposljavanja) VALUES ('" + imena1[Ran()] + "','" + prezimena[Ran()] + "','" + godine[Ran()] + "')";

                string gorivo = "INSERT INTO gorivo(cena, kolicina) VALUES('" + gorivoCena[Ran()] + "','" + gorivoKolicina[Ran()] + "')";

                string servis = "INSERT INTO servis(datum, cena, vozilo_idvozilo) VALUES('" + dtServis + "','" + servisCena[Ran()] + "' ,'" + vh + "')";

                string premium_putnici = "INSERT INTO premium_putnici(putnik_idputnik, predjen_put) VALUES ( '" + insertedIds[s2] + "', '" + predjenPut[Ran()] + "')";

                string plate = "INSERT INTO plate(sofer_idsofer, iznos, datum) VALUES ( '" + insertedIds[s2] + "', '" + iznosPlate[Ran()] + "', '" + dtPlate + "')";

                string putnici_u_turi = "INSERT INTO putnici_u_turi(putnik_idputnik, tura_idtura) VALUES ( '" + insertedIds[s2] + "', '" + insertedIds[s3] + "')";

                string tura = "INSERT INTO tura" +
                    " (datum, pocetna_lokacija, destinacija," +
                    " iznos, kilometraza, rejting_sofera, sofer_idsofer, " +
                    "vozilo_idvozilo, gorivo_idgorivo, idnp) VALUES ( '" + dTure + "', '" + pocetna_lokacija[Ran()] + "', '" + destinacije[Ran()] + "', '" + iznos[Ran()] + "'" +
                    ", '" + kilometraza[Ran()] + "', '" + rejtinzi[Ran()] + "', '" + insertedIds[s2] + "', '" + vh + "', '" + insertedIds[s4] + "', '" + ss + "')";

                string[] queries = new string[8] { putnik, sofer, gorivo, tura, putnici_u_turi, servis, premium_putnici, plate };

                for (int j = 0; j<queries.Length; j++)
                {
                    runQuery(queries[j]);
                    databaseConnection.Close();
                    if (i == queries.Length)
                    {
                        MessageBox.Show("Success");
                    }
                }
            }


        }
        static Random rnd = new Random();
        private int Ran()
        {
            int single = rnd.Next(1, 10);
            return single;
        }

        
        
        private void onloadCb()
        {
    
            comboBox1.Items.Add("1. Šofer sa najviše obavljenih tura u prethodnoj godini poslovanja");
            comboBox1.Items.Add("2. Šofer sa najboljim prosecnim rejtingom na godisnjim nivou");
            comboBox1.Items.Add("3. Tura sa najvećim prosečnim brojem putnika u letnjem periodu");
            comboBox1.Items.Add("4. Tura koja donosi najveći profit");
            comboBox1.Items.Add("5. Lokacija sa najvećim padom popularnosti u poslednjih 3 godine");
            comboBox1.Items.Add("6.  Šofer sa najboljim odnosom potrošenog goriva i pređene kilometraže");
            comboBox1.Items.Add("7. Vozilo sa najvecim troskovima servis u poslednji godinu dana");
            comboBox1.Items.Add("8. Najmanje popularno vozilo kod putnika mladjih od 25 godina u letnjem periodu");
            comboBox1.Items.Add("9.  Nacin placanja koji donosi najmanji profit");
            comboBox1.Items.Add("10.  Najpopularniji nacin placanja kod putnika ispod 25 godina");
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
            DialogResult result = MessageBox.Show("Are you sure you want to drop all the tables?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    string drop = "DROP TABLE premium_putnici, putnici_u_turi, tura, nacin_placanja, plate, servis, vozilo, sofer, gorivo, putnik";
                    MessageBox.Show("Success");
                    runQuery(drop);
                    databaseConnection.Close();
                    break;

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generateData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            createTables();
            fillTable();
        }

        
    }
}
