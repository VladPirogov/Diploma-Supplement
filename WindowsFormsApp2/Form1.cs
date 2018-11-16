using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection1;
        string connectionString = null;
        private string server = "localhost";
        private string database = "Euro-ap";
        private string uid = "root";
        private string password = "password";
        private string port = "3306";
        //private string server = "193.151.13.70";
        //private string database = "euro_ad";
        //private string uid = "euro_ad";
        //private string password = "rooteuro";
        //private string port = "3306"; 
        public Form1()
        {
            InitializeComponent();
        }
        /*
        //Excell
        private HSSFWorkbook hssfwb;
        private OpenFileDialog ofd;
        private ISheet sheet0 = null;
        private ISheet sheet1 = null;
        private ISheet sheet2 = null;
        private ISheet sheet3 = null;
        private ISheet sheet4 = null;
        private ISheet sheet5 = null*/

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {


                    string connectionString;
                    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                    database + ";" +
                    "port=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8;";
                    connection1 = new MySqlConnection(connectionString);
                    connection1.Open();

                    string charsetQuerySEr = "character_set_server = utf8";
                    MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

                    string charsetQuery = "SET NAMES utf8";
                    MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);




                    string ComandSQL = "SELECT COUNT(Qualification.Qualification_ID) AS COUNT_ID  FROM Qualification WHERE Qualification.Qualification_UA =CONVERT('%" + textBox1.Text + "%'USING utf8) OR Qualification.Qualification_EN =CONVERT('%" + textBox1.Text + "%'USING utf8)";
                    MySqlCommand command = new MySqlCommand(ComandSQL, connection1);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int CUoNT = reader.GetInt32(0);
                    if (reader != null)
                        reader.Close();
                    if (CUoNT > 1)
                    {
                        IFnotOnes SearchIFnotOnes = new IFnotOnes();
                        //SearchIFnotOnes.ForSEARCH = textBox1.Text;
                        SearchIFnotOnes.StringConnection = connectionString;
                        SearchIFnotOnes.ShowDialog();
                    }
                    else if (CUoNT == 1)
                    {
                        string ComandSQL2 = "SELECT Qualification.Qualification_ID FROM Qualification WHERE Qualification.Qualification_UA ='" + textBox1.Text + "' OR Qualification.Qualification_EN ='" + textBox1.Text + "'";
                        command = new MySqlCommand(ComandSQL, connection1);
                        MySqlDataReader reader2 = command.ExecuteReader();

                        reader2.Read();
                        int p = reader2.GetInt32(0);

                        MessageBox.Show(reader2.GetString(0));

                        if (reader2 != null)
                            reader2.Close();
                        if (connection1 != null && connection1.State != ConnectionState.Closed)
                        {
                            connection1.Close();
                        }
                        SEARCH Search = new SEARCH();
                        Search.ID = p;
                        Search.StringConnection = connectionString;
                        Search.NewOrOld = false;
                        this.Visible = false;
                        Search.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {

                        string message = "Нажаль спеціальності з назвою " + textBox1.Text + ". Бажаете переглянути всі спеціальності?";
                        string caption = "Пошук";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (connection1 != null && connection1.State != ConnectionState.Closed)
                            {
                                connection1.Close();
                            }
                            IFnotOnes SearchIFnotOnes = new IFnotOnes();
                            SearchIFnotOnes.StringConnection = connectionString;
                            this.Visible = false;
                            SearchIFnotOnes.ShowDialog();
                            this.Visible = true;
                        }
                    }
                }
                else { MessageBox.Show("Введіть назву"); }
            } catch (Exception exs) { MessageBox.Show(exs.Message); this.Close(); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_ClickAsync(object sender, EventArgs e)
        {

            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Влад\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database2.mdf;
            try
            {
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" +
                "port=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8;";
                connection1 = new MySqlConnection(connectionString);

                try
                {
                    connection1.Open();
                    string charsetQuerySEr = "character_set_server = utf8";
                    MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

                    string charsetQuery = "SET NAMES utf8";
                    MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);

                    MessageBox.Show("Соединено");
                    if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                        !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        string ComandSQL = "SELECT COUNT(Qualification_ID) AS COUNT_ID  FROM Qualification WHERE Qualification.Qualification_UA ='" + textBox1.Text + "' OR Qualification.Qualification_EN='" + textBox1.Text + "'";
                        MySqlCommand command1 = new MySqlCommand(ComandSQL, connection1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        reader1.Read();
                        int CUoNT1 = reader1.GetInt32(0);
                        if (reader1 != null)
                            reader1.Close();
                        if (CUoNT1 == 0)
                        {
                            if (radioButton1.Checked || radioButton2.Checked)
                            {

                                MySqlCommand command = new MySqlCommand("INSERT INTO Qualification (Qualification_EN, Qualification_UA, Main_field_study_UA, Main_field_study_EN, Degree,Date)" +
                                    " VALUES (@Qualification_EN, @Qualification_UA,@Main_field_study_UA, @Main_field_study_EN, @Degree,@Date)", connection1);
                                command.Parameters.AddWithValue("Qualification_EN", textBox3.Text);
                                command.Parameters.AddWithValue("Qualification_UA", textBox2.Text);
                                command.Parameters.AddWithValue("Main_field_study_UA", textBox4.Text);
                                command.Parameters.AddWithValue("Main_field_study_EN", textBox5.Text);

                                if (radioButton1.Checked) command.Parameters.AddWithValue("Degree", radioButton1.Text);
                                else command.Parameters.AddWithValue("Degree", radioButton2.Text);
                                command.Parameters.AddWithValue("Date", DateTime.Now);
                                command.ExecuteNonQuery();
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                radioButton1.Checked = false;
                                radioButton2.Checked = false;


                                string StringComand2Id = "select max(Qualification.Qualification_ID) from Qualification";
                                MySqlCommand command2Id = new MySqlCommand(StringComand2Id, connection1);
                                MySqlDataReader reader = command2Id.ExecuteReader();
                                reader.Read();
                                int CUoNT = reader.GetInt32(0);
                                reader.Close();

                                if (connection1 != null && connection1.State != ConnectionState.Closed)
                                {
                                    connection1.Close();
                                }
                                SEARCH Search = new SEARCH();
                                Search.ID = CUoNT;
                                Search.StringConnection = connectionString;
                                Search.NewOrOld = true;
                                this.Visible = false;
                                Search.ShowDialog();
                                this.Visible = true;


                            }
                            else { MessageBox.Show("Оберіть ступінь!"); }
                        }
                        else
                        {
                            MessageBox.Show("Спеціальність з такою назвою вже існує");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Для створення необхідно ввести назву спеціальності англійською та українською");
                    }
                }
                catch (Exception help)
                {
                    MessageBox.Show(help.Message);
                    //this.Close();
                }

                if (connection1 != null && connection1.State != ConnectionState.Closed)
                {
                    connection1.Close();
                }


            }
            catch (Exception help)
            {
                MessageBox.Show(help.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection1 != null && connection1.State != ConnectionState.Closed)
            {
                connection1.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" +
            "port=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8;";
            connection1 = new MySqlConnection(connectionString);
            connection1.Open();

            bool T = true;
            string ForAbdete = "show columns FROM Qualification";
            MySqlCommand ForAbdete2 = new MySqlCommand(ForAbdete, connection1);
            MySqlDataReader readerForAbdete = ForAbdete2.ExecuteReader();

            while (readerForAbdete.Read())
            {
                if (readerForAbdete[0].ToString() == "FieldStudy_UA")
                {
                    T = false;
                }
            }
            readerForAbdete.Close();
            if (T)
            {

                string AddColum = "ALTER TABLE Qualification ADD COLUMN FieldStudy_UA TEXT DEFAULT NULL";
                MySqlCommand commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN FieldStudy_EN TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN FirstSpecialty_UA TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN FirstSpecialty_EN TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN SecondSpecialty_UA TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN SecondSpecialty_EN TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN Specialization_UA TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE Qualification ADD COLUMN Specialization_EN TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE graduates ADD COLUMN DecisionDate DATETIME DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE graduates ADD COLUMN ProtNum INT(110) DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE graduates ADD COLUMN QualificationAwardedUA TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE graduates ADD COLUMN QualificationAwardedEN TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

                AddColum = "ALTER TABLE graduates ADD COLUMN IssuedBy TEXT DEFAULT NULL";
                commandAddColum = new MySqlCommand(AddColum, connection1);
                commandAddColum.ExecuteNonQuery();

            }

            connection1.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void estimatesFunc(int StudId, int row, Dictionary<int, int> countries, MySqlConnection connection1, ISheet sheet4)
        {
            string com = "INSERT INTO estimates (Graduat_ID, Disciptine_ID, Estimat_NUM, Estimat_CHAR, Estimat_UA) VALUES (@Graduat_ID, @Disciptine_ID, @Estimat_NUM, @Estimat_CHAR, @Estimat_UA)";
            int One = 1;
            int Two = 2;
            int three = 3;
            MySqlCommand command = null;
            
            foreach (int i in countries.Values)
            {
                try
                {
                    command = new MySqlCommand(com, connection1);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("Graduat_ID", StudId);
                    command.Parameters.AddWithValue("Disciptine_ID", i);
                    command.Parameters.AddWithValue("Estimat_NUM", sheet4.GetRow(row).GetCell(One).NumericCellValue);
                    command.Parameters.AddWithValue("Estimat_UA", sheet4.GetRow(row).GetCell(Two).StringCellValue);
                    command.Parameters.AddWithValue("Estimat_CHAR", sheet4.GetRow(row).GetCell(three).StringCellValue);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    string ComandSQ = "SELECT graduates.Lastname_UA FROM graduates WHERE graduates.Graduat_ID =" + StudId.ToString();
                    command = new MySqlCommand(ComandSQ, connection1);
                    MySqlDataReader reader3 = command.ExecuteReader();
                    reader3.Read();
                    string Lastname = reader3.GetString(0);
                    reader3.Close();
                    MessageBox.Show(" Проблема з оцінками студента "+ Lastname+
                        ". Перевірте оцінки у праграммі чи у файлі після завершення роботи");
                    return;
                }
                //rbStatus.Text += sheet4.GetRow(row).GetCell(three).StringCellValue + '\n';

                One += 3;
                Two += 3;
                three+= 3;
            }
        }

        private void studentFunc(HSSFWorkbook hssfwb, Dictionary<int, int> countries, MySqlConnection connection1, int IdQ)
        {
            MySqlCommand command = null;
            ISheet sheet0 = hssfwb.GetSheetAt(0);
            ISheet sheet4 = hssfwb.GetSheetAt(4);

            string ComandString = "INSERT INTO graduates" +
                    " (Qualification_ID,Lastname_UA,Lastname_EN,Firstname_UA,Firstname_EN,birthday,SerialDiploma,NumberDiploma," +
                            "NumberAddition,PrevDocument_UA,PrevDocument_EN,prevSerialNumberAddition,TrainingStar,TrainingEnd,DurationOfTraining_UA,DurationOfTraining_EN," +
                            " DecisionDate, ProtNum, QualificationAwardedUA, QualificationAwardedEN, IssuedBy)" +
                            "VALUES(@Qualification_ID,@Lastname_UA,@Lastname_EN,@Firstname_UA," +
                            "@Firstname_EN,@birthday,@SerialDiploma,@NumberDiploma," +
                            "@NumberAddition,@PrevDocument_UA,@PrevDocument_EN,@prevSerialNumberAddition," +
                            "@TrainingStar,@TrainingEnd,@DurationOfTraining_UA,@DurationOfTraining_EN," +
                            "@DecisionDate, @ProtNum, @QualificationAwardedUA, @QualificationAwardedEN, @IssuedBy)";




            for (int row = 1; row <= sheet0.LastRowNum; row++)
            {

                if (sheet0.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    command = new MySqlCommand(ComandString, connection1);
                    // Создание обьекта студент
                    command.Parameters.AddWithValue("Qualification_ID", IdQ.ToString());
                    command.Parameters.AddWithValue("Lastname_UA", sheet0.GetRow(row).GetCell(0).StringCellValue);
                    try { command.Parameters.AddWithValue("Lastname_EN", sheet0.GetRow(row).GetCell(1).StringCellValue); }
                        catch { command.Parameters.AddWithValue("Lastname_EN", ""); }
                    try { command.Parameters.AddWithValue("Firstname_UA", sheet0.GetRow(row).GetCell(2).StringCellValue); }
                        catch { command.Parameters.AddWithValue("Firstname_UA", ""); }
                    try { command.Parameters.AddWithValue("Firstname_EN", sheet0.GetRow(row).GetCell(3).StringCellValue); }
                        catch { command.Parameters.AddWithValue("Firstname_EN", ""); }
                    try { command.Parameters.AddWithValue("birthday", sheet0.GetRow(row).GetCell(4).DateCellValue); }//////
                        catch { command.Parameters.AddWithValue("birthday", DateTime.Now); }
                    try { command.Parameters.AddWithValue("SerialDiploma", sheet0.GetRow(row).GetCell(5).StringCellValue); }
                        catch { command.Parameters.AddWithValue("SerialDiploma", ""); }/////////////////////
                    try { command.Parameters.AddWithValue("NumberDiploma", (sheet0.GetRow(row).GetCell(6).NumericCellValue).ToString()); }
                        catch { command.Parameters.AddWithValue("NumberDiploma", ""); }
                    try { command.Parameters.AddWithValue("NumberAddition", sheet0.GetRow(row).GetCell(7).StringCellValue); }
                        catch { command.Parameters.AddWithValue("NumberAddition", ""); }
                    try { command.Parameters.AddWithValue("DecisionDate", sheet0.GetRow(row).GetCell(8).DateCellValue); }
                        catch { command.Parameters.AddWithValue("DecisionDate", DateTime.Now); }
                    try { command.Parameters.AddWithValue("ProtNum", sheet0.GetRow(row).GetCell(9).NumericCellValue.ToString()); }
                        catch { command.Parameters.AddWithValue("ProtNum", 0); }
                    try { command.Parameters.AddWithValue("QualificationAwardedUA", sheet0.GetRow(row).GetCell(10).StringCellValue); }
                        catch { command.Parameters.AddWithValue("QualificationAwardedUA", ""); }
                    try { command.Parameters.AddWithValue("QualificationAwardedEN", sheet0.GetRow(row).GetCell(11).StringCellValue); }
                        catch { command.Parameters.AddWithValue("QualificationAwardedEN", ""); }
                    try { command.Parameters.AddWithValue("PrevDocument_UA", sheet0.GetRow(row).GetCell(12).StringCellValue); }
                        catch { command.Parameters.AddWithValue("PrevDocument_UA", ""); }
                    try { command.Parameters.AddWithValue("PrevDocument_EN", sheet0.GetRow(row).GetCell(13).StringCellValue); }
                        catch { command.Parameters.AddWithValue("PrevDocument_EN", ""); }
                    try { command.Parameters.AddWithValue("prevSerialNumberAddition", sheet0.GetRow(row).GetCell(14).StringCellValue); }
                        catch { command.Parameters.AddWithValue("prevSerialNumberAddition", ""); }
                    try { command.Parameters.AddWithValue("IssuedBy", sheet0.GetRow(row).GetCell(15).StringCellValue); }
                        catch { command.Parameters.AddWithValue("IssuedBy", ""); }
                    try { command.Parameters.AddWithValue("DurationOfTraining_UA", sheet0.GetRow(row).GetCell(16).StringCellValue); }
                        catch { command.Parameters.AddWithValue("DurationOfTraining_UA", ""); }
                    try { command.Parameters.AddWithValue("DurationOfTraining_EN", sheet0.GetRow(row).GetCell(17).StringCellValue); }
                        catch { command.Parameters.AddWithValue("DurationOfTraining_EN", ""); }
                    try { command.Parameters.AddWithValue("TrainingStar", sheet0.GetRow(row).GetCell(18).DateCellValue); }
                        catch { command.Parameters.AddWithValue("TrainingStar", DateTime.Now); }
                    try { command.Parameters.AddWithValue("TrainingEnd", sheet0.GetRow(row).GetCell(19).DateCellValue); }
                        catch { command.Parameters.AddWithValue("TrainingEnd", DateTime.Now); }

                    command.ExecuteNonQuery();

                    string ComandSQ = "SELECT MAX(graduates.Graduat_ID) AS expr1 FROM graduates WHERE graduates.Qualification_ID =" + IdQ.ToString();
                    command = new MySqlCommand(ComandSQ, connection1);
                    MySqlDataReader reader3 = command.ExecuteReader();
                    reader3.Read();
                    int StudId = reader3.GetInt32(0);
                    reader3.Close();
                    //rbStatus.Text += sheet0.GetRow(row).GetCell(0).StringCellValue + '\n';
                    estimatesFunc(StudId, row + 1, countries, connection1, sheet4);
                    

                    processPb.Value += 1;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Excell
            HSSFWorkbook hssfwb;
            OpenFileDialog ofd;
            ISheet sheet0 = null;
            ISheet sheet1 = null;
            ISheet sheet2 = null;
            ISheet sheet3 = null;
            ISheet sheet4 = null;
            ISheet sheet5 = null;
            System.Collections.Generic.Dictionary<int, string> filesPath = new System.Collections.Generic.Dictionary<int, string>();

            ofd = new OpenFileDialog();
            ofd.Filter = "Excell table Microsoft Office 1998-2003 (*.xls)|*.xls";
            Stream myStream = null;

            processPb.Value = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int IdQ = 0;
                try
                {

                    DateTime localDate = DateTime.Now;

                    filesPath.Add(0, ofd.FileName); // Добавление файлового пути
                    using (FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        hssfwb = new HSSFWorkbook(file);

                    }
                    bool EROR = true;
                    // Получение листов из Excell
                    sheet0 = hssfwb.GetSheetAt(0);
                    sheet1 = hssfwb.GetSheetAt(1);
                    sheet2 = hssfwb.GetSheetAt(2);
                    sheet3 = hssfwb.GetSheetAt(3);
                    sheet4 = hssfwb.GetSheetAt(4);
                    sheet5 = hssfwb.GetSheetAt(5);
                    processPb.Maximum = sheet0.LastRowNum+5;

                    string connectionString;
                    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                    database + ";" +
                    "port=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8;";
                    connection1 = new MySqlConnection(connectionString);
                    connection1.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO Qualification (Qualification_EN, Qualification_UA, Degree,Date," +
                    " FieldStudy_UA, FieldStudy_EN, FirstSpecialty_UA, FirstSpecialty_EN, SecondSpecialty_UA, SecondSpecialty_EN, Specialization_UA, Specialization_EN)" +
                            " VALUES (@Qualification_EN, @Qualification_UA,@Degree,@Date,@FieldStudy_UA, @FieldStudy_EN, @FirstSpecialty_UA, @FirstSpecialty_EN," +
                            " @SecondSpecialty_UA, @SecondSpecialty_EN, @Specialization_UA, @Specialization_EN)", connection1);
                    command.Parameters.AddWithValue("Qualification_EN",  sheet1.GetRow(1).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Qualification_UA",  sheet1.GetRow(0).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("FieldStudy_UA",     sheet1.GetRow(2).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("FieldStudy_EN",     sheet1.GetRow(3).GetCell(1).StringCellValue);
                    try { command.Parameters.AddWithValue("FirstSpecialty_UA", sheet1.GetRow(4).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("FirstSpecialty_UA", ""); }
                    try { command.Parameters.AddWithValue("FirstSpecialty_EN", sheet1.GetRow(5).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("FirstSpecialty_EN", ""); }
                    try { command.Parameters.AddWithValue("SecondSpecialty_UA", sheet1.GetRow(6).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("SecondSpecialty_UA", ""); }
                    try { command.Parameters.AddWithValue("SecondSpecialty_EN", sheet1.GetRow(7).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("SecondSpecialty_EN", ""); }
                    try { command.Parameters.AddWithValue("Specialization_UA", sheet1.GetRow(8).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("Specialization_UA", ""); }
                    try { command.Parameters.AddWithValue("Specialization_EN", sheet1.GetRow(9).GetCell(1).StringCellValue); }
                    catch { command.Parameters.AddWithValue("Specialization_EN", ""); }
                    command.Parameters.AddWithValue("Degree",            sheet1.GetRow(10).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Date", DateTime.Now);
                    command.ExecuteNonQuery();

                    string ComandSQL2 = "SELECT qualification.Qualification_ID FROM qualification ORDER BY" +
                    " qualification.Qualification_ID DESC LIMIT 1";
                    command = new MySqlCommand(ComandSQL2, connection1);
                    MySqlDataReader reader2 = command.ExecuteReader();
                    reader2.Read();
                    IdQ = reader2.GetInt32(0);
                    processPb.Value+= 1;
                    reader2.Close();
                    
                    string upDate = "UPDATE `National_framework` SET Level_qualification_UA=@Level_qualification_UA," +
                    "`Level_qualification_EN`=@Level_qualification_EN," +
                    "`Official_duration_programme_UA`=@Official_duration_programme_UA," +
                    "`Official_duration_programme_EN`=@Official_duration_programme_EN," +
                    "`Access_requirements_UA`=@Access_requirements_UA" +
                    ",`Access_requirements_EN`=@Access_requirements_EN " +
                    ",`Access_further_study_UA`=@Access_further_study_UA," +
                    "`Access_further_study_EN`=@Access_further_study_EN," +
                    "`Professional_status_UA`=@Professional_status_UA," +
                    "`Professional_status_EN`=@Professional_status_EN" +
                    "  WHERE National_framework.Qualification_ID=@Qualification_ID";
                    command = new MySqlCommand(upDate, connection1);

                    command.Parameters.AddWithValue("Qualification_ID", IdQ.ToString());
                    command.Parameters.AddWithValue("Level_qualification_UA",         sheet2.GetRow(0).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Level_qualification_EN",         sheet2.GetRow(1).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Official_duration_programme_UA", sheet2.GetRow(2).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Official_duration_programme_EN", sheet2.GetRow(3).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Access_requirements_UA",         sheet2.GetRow(4).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Access_requirements_EN",         sheet2.GetRow(5).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Access_further_study_UA",        sheet2.GetRow(6).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Access_further_study_EN",        sheet2.GetRow(7).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Professional_status_UA",         sheet2.GetRow(8).GetCell(1).StringCellValue);
                    command.Parameters.AddWithValue("Professional_status_EN",         sheet2.GetRow(9).GetCell(1).StringCellValue);

                    command.ExecuteNonQuery();
                    processPb.Value += 1;
                
                    StringMultiLanguage programSpecification = new StringMultiLanguage();
                    StringMultiLanguage knowledgeUnderstanding = new StringMultiLanguage();
                    StringMultiLanguage applyingKnowledge = new StringMultiLanguage();
                    StringMultiLanguage MakingJudgments = new StringMultiLanguage();
                    for (int row = 1; row < sheet3.LastRowNum; row++)
                    {

                        if (sheet3.GetRow(row).GetCell(1) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(1).StringCellValue))
                            {
                                programSpecification.UA = programSpecification.UA + (sheet3.GetRow(row).GetCell(1).StringCellValue + ";_");
                                programSpecification.EN = programSpecification.EN + (sheet3.GetRow(row).GetCell(2).StringCellValue +";_");

             
                            }
                        }


                        if (sheet3.GetRow(row).GetCell(3) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(3).StringCellValue))
                            {
                                knowledgeUnderstanding.UA = knowledgeUnderstanding.UA + (sheet3.GetRow(row).GetCell(3).StringCellValue +";_");
                                knowledgeUnderstanding.EN = knowledgeUnderstanding.EN + (sheet3.GetRow(row).GetCell(4).StringCellValue +";_");
                            }
                        }
                        if (sheet3.GetRow(row).GetCell(5) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(5).StringCellValue))
                            {
                                applyingKnowledge.UA = applyingKnowledge.UA + (sheet3.GetRow(row).GetCell(5).StringCellValue + ";_");
                                applyingKnowledge.EN = applyingKnowledge.EN + (sheet3.GetRow(row).GetCell(6).StringCellValue + ";_");
                            }
                        }

                        if (sheet3.GetRow(row).GetCell(7) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(7).StringCellValue))
                            {
                            MakingJudgments.UA = MakingJudgments.UA + (sheet3.GetRow(row).GetCell(7).StringCellValue +";_");
                            MakingJudgments.EN = MakingJudgments.EN + (sheet3.GetRow(row).GetCell(8).StringCellValue +";_");
                            }
                        }

                    }
                    processPb.Value += 1;

                    upDate = "UPDATE `contents_and_results` SET Form_study_UA=@Form_study_UA," +
                    "`Form_study_EN`=@Form_study_EN," +
                    "`Program_Specification_UA`=@Program_Specification_UA," +
                    "`Program_Specification_EN`=@Program_Specification_EN," +
                    "`Knowledge_undestanding_UA`=@Knowledge_undestanding_UA" +
                    ",`Knowledge_undestanding_EN`=@Knowledge_undestanding_EN " +
                    ",`Application_knowledge_understanding_UA`=@Application_knowledge_understanding_UA," +
                    "`Application_knowledge_understanding_EN`=@Application_knowledge_understanding_EN," +
                    "`Making_judgments_UA`=@Making_judgments_UA," +
                    "`Making_judgments_EN`=@Making_judgments_EN" +
                    "  WHERE contents_and_results.Qualification_ID=@Qualification_ID";
                    command = new MySqlCommand(upDate, connection1);

                    string Form_study = sheet3.GetRow(1).GetCell(0).StringCellValue;





                // int last = Form_study. ;
                
                    command.Parameters.AddWithValue("Qualification_ID", IdQ.ToString());
                    command.Parameters.AddWithValue("Form_study_UA", Form_study.Substring(0, Form_study.IndexOf('/')));
                    command.Parameters.AddWithValue("Form_study_EN", Form_study.Substring((Form_study.IndexOf('/')+1),(Form_study.Length-Form_study.IndexOf('/')-1)));
                    command.Parameters.AddWithValue("Program_Specification_EN", programSpecification.EN.Replace(";_","; "));
                    command.Parameters.AddWithValue("Program_Specification_UA", programSpecification.UA.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Knowledge_undestanding_UA", knowledgeUnderstanding.UA.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Knowledge_undestanding_EN", knowledgeUnderstanding.EN.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Application_knowledge_understanding_UA", applyingKnowledge.UA.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Application_knowledge_understanding_EN", applyingKnowledge.EN.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Making_judgments_UA", MakingJudgments.UA.Replace(";_", "; "));
                    command.Parameters.AddWithValue("Making_judgments_EN", MakingJudgments.EN.Replace(";_", "; "));

                    command.ExecuteNonQuery();
                    processPb.Value += 1;
                /////////////////////////

                Dictionary<int, int> countries = new Dictionary<int, int>();
                string ComandSQ = "SELECT MAX(discipline.Discipline_ID) AS expr1 FROM discipline " +
                            "WHERE discipline.Qualification_ID =" + IdQ.ToString();
                upDate = "INSERT INTO Discipline (Qualification_ID, Course_title_UA, Course_title_EN, Loans, Hours, Teaching, Differential)" +
                    " VALUES (@Qualification_ID, @Course_title_UA, @Course_title_EN, @Loans, @Hours, @Teaching, @Differential)";

                for (int row = 1; row <= sheet5.LastRowNum; row++)
                {
                    try
                    {
                        if (sheet5.GetRow(row) != null) //null is when the row only contains empty cells 
                        {
                            command = new MySqlCommand(upDate, connection1);
                            // Создание обьекта студент
                            command.Parameters.AddWithValue("Qualification_ID", IdQ.ToString());
                            command.Parameters.AddWithValue("Course_title_UA", sheet5.GetRow(row).GetCell(0).StringCellValue);
                            command.Parameters.AddWithValue("Course_title_EN", sheet5.GetRow(row).GetCell(1).StringCellValue);
                            command.Parameters.AddWithValue("Loans", (sheet5.GetRow(row).GetCell(2).NumericCellValue));
                            command.Parameters.AddWithValue("Hours", (sheet5.GetRow(row).GetCell(3).NumericCellValue));
                            command.Parameters.AddWithValue("Teaching", sheet5.GetRow(row).GetCell(4).NumericCellValue);
                            command.Parameters.AddWithValue("Differential", (sheet5.GetRow(row).GetCell(5).NumericCellValue == 0) ? "Оцінка" : "Зарах");

                            command.ExecuteNonQuery();


                            command = new MySqlCommand(ComandSQ, connection1);
                            MySqlDataReader reader3 = command.ExecuteReader();
                            reader3.Read();
                            countries.Add(row, reader3.GetInt32(0));
                            reader3.Close();
                            //rbStatus.Text += sheet5.GetRow(row).GetCell(0).StringCellValue + '\n';
                        }
                    }
                    catch {}
                }
                
                processPb.Value += 1;
                studentFunc(hssfwb, countries, connection1,IdQ);
                
                connection1.Close();
                //processPb.Value += 1;
                SEARCH Search = new SEARCH();
                Search.ID = IdQ;
                Search.StringConnection = connectionString;
                Search.NewOrOld = false;
                this.Visible = false;
                Search.ShowDialog();
                this.Visible = true;

                }
                catch (Exception exc)
                {
                    try
                    {
                        MessageBox.Show(exc.ToString());
                        SEARCH Search = new SEARCH();
                        Search.ID = IdQ;
                        Search.StringConnection = connectionString;
                        Search.NewOrOld = true;
                        this.Visible = false;
                        Search.ShowDialog();
                    }
                    catch (Exception exce) { MessageBox.Show(exce.ToString()); }
                }
            }
        }

        private void processPb_Click(object sender, EventArgs e)
        {

        }
    }
}
