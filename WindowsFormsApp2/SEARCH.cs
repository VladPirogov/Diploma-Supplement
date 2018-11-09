using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace WindowsFormsApp2
{
    public partial class SEARCH : Form
    {
        public string ForSEARCH { get; set; }
        public string StringConnection { get; set; }
        public int ID { get; set; }
        public bool NewOrOld { get; set; }
        private DateTimePicker dtp = new DateTimePicker();
        //private MaskedTextBox maskedTextBox = new MaskedTextBox();
        private Rectangle rect;

        private bool TextChanged_15_16_17_18 = false;

        private Dictionary<int, string> filesPath = new Dictionary<int, string>();
        private Dictionary<int, Student> students = new Dictionary<int, Student>();
        private Dictionary<string, string> serviceValues = new Dictionary<string, string>();
        private StringMultiLanguage programSpecification = new StringMultiLanguage();
        private StringMultiLanguage knowledgeUnderstanding = new StringMultiLanguage();
        private StringMultiLanguage applyingKnowledge = new StringMultiLanguage();
        private StringMultiLanguage MakingJudgments = new StringMultiLanguage();
        private string Degree = "";
        private StringMultiLanguage qualification = new StringMultiLanguage();
        private StringMultiLanguage studyQualification = new StringMultiLanguage();
        private StringMultiLanguage levelQualification = new StringMultiLanguage();
        private StringMultiLanguage FieldStudy = new StringMultiLanguage();
        private StringMultiLanguage FirstSpecialty = new StringMultiLanguage();
        private StringMultiLanguage SecondSpecialty = new StringMultiLanguage();
        private StringMultiLanguage Specialization = new StringMultiLanguage();
        private StringMultiLanguage durationProgram = new StringMultiLanguage();
        private StringMultiLanguage accessRequiments = new StringMultiLanguage();
        private StringMultiLanguage Access_to_further = new StringMultiLanguage();
        private StringMultiLanguage Professional_status = new StringMultiLanguage();
        private string modeStudy = "";
        public MySqlConnection connection1;
        public string pathTodir = "./output";
        //Словари для проверок 
        public SEARCH()
        {
            InitializeComponent();
        }

        private void SEARCH_Load(object sender, EventArgs e)
        {
            connection1 = new MySqlConnection(StringConnection);

            connection1.Open();
            string charsetQuerySEr = "character_set_server = utf8";
            MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

            string charsetQuery = "SET NAMES utf8";
            MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);




            string ComandSQLgetQualification = "SELECT   Qualification.* FROM   Qualification  WHERE  Qualification. Qualification_ID=" + ID.ToString();
            MySqlCommand commandList1 = new MySqlCommand(ComandSQLgetQualification, connection1);
            MySqlDataReader readerList1 = commandList1.ExecuteReader();
            readerList1.Read();
            label2.Text = readerList1["Degree"].ToString();
            textBox1.Text = readerList1["Qualification_UA"].ToString();
            textBox2.Text = readerList1["Qualification_EN"].ToString();
            if (readerList1["FieldStudy_UA"] != "")
                textBox28.Text = readerList1["FieldStudy_UA"].ToString();
            if (readerList1["FieldStudy_EN"] != "")
                textBox27.Text = readerList1["FieldStudy_EN"].ToString();
            if (readerList1["FirstSpecialty_UA"] != "")
                textBox35.Text = readerList1["FirstSpecialty_UA"].ToString();
            if (readerList1["FirstSpecialty_EN"] != "")
                textBox34.Text = readerList1["FirstSpecialty_EN"].ToString();
            if (readerList1["SecondSpecialty_UA"] != "")
                textBox30.Text = readerList1["SecondSpecialty_UA"].ToString();
            if (readerList1["SecondSpecialty_EN"] != "")
                textBox29.Text = readerList1["SecondSpecialty_EN"].ToString();
            if (readerList1["Specialization_UA"] != "")
                textBox32.Text = readerList1["Specialization_UA"].ToString();
            if (readerList1["Specialization_EN"] != "")
                textBox31.Text = readerList1["Specialization_EN"].ToString();
            if (readerList1["Main_field_study_UA"] != "")
                textBox3.Text = readerList1["Main_field_study_UA"].ToString();
            if (readerList1["Main_field_study_EN"] != "")
                textBox4.Text = readerList1["Main_field_study_EN"].ToString();
            if (readerList1["BX"] != "")
                textBox25.Text = readerList1["BX"].ToString();
            readerList1.Close();

            
            //maskedTextBox.Visible = false;
            //dataGridView2.Controls.Add(maskedTextBox);
            ////dataGridView2.CellBeginEdit +=new DataGridViewCellCancelEventHandler(dataGridView2_CellBeginEdit);
            ////dataGridView2.CellEndEdit +=new DataGridViewCellEventHandler(dataGridView2_CellEndEdit);
            //maskedTextBox.Mask = "99.99.9999";
            //maskedTextBox.ValidatingType = typeof(System.DateTime);
            //maskedTextBox.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);



            //dataGridView2.Controls.Add(dtp);
            //dtp.Visible = false;
            //dtp.Format = DateTimePickerFormat.Custom;
            //dtp.TextChanged += new EventHandler(dtp_TextChange);

            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            cell.Items.Add("Оцінка");
            cell.Items.Add("Зарах");
            cell.Value = "Зарах";
            dataGridView3.Columns["Differential"].CellTemplate = cell;

            DataGridViewComboBoxCell cell2 = new DataGridViewComboBoxCell();
            cell2.Items.Add("1");
            cell2.Items.Add("2");
            cell2.Items.Add("3");
            cell2.Items.Add("4");
            cell2.Value = "1";
            dataGridView3.Columns["Teaching"].CellTemplate = cell2;



            button1.Enabled = false;
            button13.Enabled = false;
            button2.Enabled = false;

            if (!NewOrOld)
            {
                try
                {
                    //
                    ShowNational_framework();
                    //
                    ShowContents_and_results();
                    //
                    ShowDiscipline();
                    //
                    ShowGraduates();
                }
                catch { }
            }
            else
            {
                button5.Enabled = false;
                button22.Enabled = false;
                button9.Enabled = false;
                button12.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button16.Enabled = false;
            }
            //button28.Enabled = false;

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void второйЛистToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            string upDate = "UPDATE `Contents_and_results` SET `Form_study_UA`=@Form_study_UA, `Form_study_EN`=@Form_study_EN,`Program_Specification_UA`=@Program_Specification_UA, `Program_Specification_EN`=@Program_Specification_EN " +
            "WHERE `Contents_and_results`.`Qualification_ID`=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Form_study_UA", textBox15.Text);
            command.Parameters.AddWithValue("Form_study_EN", textBox16.Text);
            command.Parameters.AddWithValue("Program_Specification_UA", textBox17.Text);
            command.Parameters.AddWithValue("Program_Specification_EN", textBox18.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Данні було змінено");
            button5.Enabled = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string upDate = "UPDATE Contents_and_results SET Knowledge_undestanding_UA=@Form_study_UA, Knowledge_undestanding_EN=@Form_study_EN " +
                "WHERE Contents_and_results.Qualification_ID=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Form_study_UA", textBox20.Text);
            command.Parameters.AddWithValue("Form_study_EN", textBox19.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Данні було змінено");
            button22.Enabled = false;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string upDate = "UPDATE Contents_and_results SET Application_knowledge_understanding_UA=@Form_study_UA, Application_knowledge_understanding_EN=@Form_study_EN " +
                "WHERE Contents_and_results.Qualification_ID=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Form_study_UA", textBox22.Text);
            command.Parameters.AddWithValue("Form_study_EN", textBox21.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Данні було змінено");
            button9.Enabled = false;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string upDate = "UPDATE Contents_and_results SET Making_judgments_UA=@Form_study_UA, Making_judgments_EN=@Form_study_EN " +
                "WHERE Contents_and_results.Qualification_ID=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Form_study_UA", textBox24.Text);
            command.Parameters.AddWithValue("Form_study_EN", textBox23.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Данні було змінено");
            button12.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string upDate = "UPDATE Qualification SET " +
                "Qualification_UA=@Qualification_UA," +
                "Qualification_EN=@Qualification_EN," +
                "FieldStudy_UA=@FieldStudy_UA,"+
                "FieldStudy_EN=@FieldStudy_EN," +
                "Main_field_study_UA=@Main_field_study_UA," +
                "Main_field_study_EN=@Main_field_study_EN," +
                "BX=@BX" +
                "  WHERE Qualification.Qualification_ID=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Qualification_UA", textBox1.Text);
            command.Parameters.AddWithValue("Qualification_EN", textBox2.Text);
            command.Parameters.AddWithValue("FieldStudy_UA", textBox28.Text);
            command.Parameters.AddWithValue("FieldStudy_EN", textBox27.Text);
            command.Parameters.AddWithValue("Main_field_study_UA", textBox3.Text);
            command.Parameters.AddWithValue("Main_field_study_EN", textBox4.Text);
           
            command.Parameters.AddWithValue("BX", textBox25.Text);
          
            command.ExecuteNonQuery();
            MessageBox.Show("Було змінено данні!");
            button1.Enabled = false;

        }

        private void button16_Click(object sender, EventArgs e)
        {
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
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("Level_qualification_UA", textBox5.Text);
            command.Parameters.AddWithValue("Level_qualification_EN", textBox6.Text);
            command.Parameters.AddWithValue("Official_duration_programme_UA", textBox7.Text);
            command.Parameters.AddWithValue("Official_duration_programme_EN", textBox8.Text);
            command.Parameters.AddWithValue("Access_requirements_UA", textBox9.Text);
            command.Parameters.AddWithValue("Access_requirements_EN", textBox10.Text);
            command.Parameters.AddWithValue("Access_further_study_UA", textBox11.Text);
            command.Parameters.AddWithValue("Access_further_study_EN", textBox12.Text);
            command.Parameters.AddWithValue("Professional_status_UA", textBox13.Text);
            command.Parameters.AddWithValue("Professional_status_EN", textBox14.Text);


            command.ExecuteNonQuery();
            MessageBox.Show("Було змінено данні!");
            button16.Enabled = false;

        }

#pragma warning disable IDE1006 // Стили именования
        private void label4_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        //Генерация док
        private void button28_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count <= 1)
            {
                MessageBox.Show("Введіть всі десципліни");
                return;
            }

            int C = 0;
            string Cgraduates = "SELECT  COUNT(Graduat_ID) AS COUNT_ID  FROM graduates WHERE graduates.Qualification_ID=" + ID;
            MySqlCommand cgraduates = new MySqlCommand(Cgraduates, connection1);
            MySqlDataReader rCgraduates = cgraduates.ExecuteReader();
            rCgraduates.Read();
            C = rCgraduates.GetInt32(0);
            rCgraduates.Close();
            if (C == 0)
            {
                MessageBox.Show("Введіть всіх студентів");
                return;
            }

            try
            {
                string FileName = Path.GetFullPath("Bachelor's Template.doc");
                //docLoadStatusPb.Image = Issu.Properties.Resources.On;
                DateTime localDate = DateTime.Now;
                filesPath = new Dictionary<int, string>();
                filesPath.Add(1, FileName); // Добавление файлового пути
                rbStatus.Text += String.Format("{0}:{1}:{2}: Файл даних \"Word\" успішно завантажено.\n", localDate.Hour, localDate.Minute, localDate.Second);

            }
            catch (Exception exc)
            {
                //docLoadStatusPb.Image = Issu.Properties.Resources.Off;
                DateTime localDate = DateTime.Now;
                rbStatus.Text += String.Format("{0}:{1}:{2}: Помилка: \n{3}\n", localDate.Hour, localDate.Minute, localDate.Second, exc.Message);
                MessageBox.Show(exc.Message);
                return;
            }
            //if (!Directory.Exists("./output"))
            //{
            //    Directory.CreateDirectory("output");
            //}

            var path_dialog = new FolderBrowserDialog();
            if (path_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Путь к директории
                pathTodir = path_dialog.SelectedPath;
            }
            string pattern = @"[\s|\.|,]+";//шаблон
            Regex rgx = new Regex(pattern);
            string directory;

            string ComandSQLgetQualification = "SELECT  Qualification.* FROM  Qualification  WHERE Qualification.Qualification_ID=" + ID;
            MySqlCommand commandList1 = new MySqlCommand(ComandSQLgetQualification, connection1);
            MySqlDataReader readerList1 = commandList1.ExecuteReader();
            readerList1.Read();

            string serviceValues = readerList1["Qualification_UA"].ToString();

            if ((serviceValues.Length) > 150)
            {
                string buf = serviceValues.Substring(0, (serviceValues.IndexOf(".")));
                directory = rgx.Replace(buf, "_");
            }
            else { directory = rgx.Replace(serviceValues, "_"); }

            if (!Directory.Exists(String.Format((pathTodir + "/{0}"), directory)))
            {

                DateTime localDate = DateTime.Now;
                rbStatus.Text += String.Format("{0}:{1}:{2}: Було створено папку \"{3}\".\n", localDate.Hour, localDate.Minute, localDate.Second, directory);
                Directory.CreateDirectory(String.Format((pathTodir + "/{0}"), directory));
            }

            readerList1.Close();
            
            int i = 0;
            string ComandSQL2graduates = "SELECT graduates.*  FROM graduates WHERE graduates.Qualification_ID=" + ID;
            MySqlCommand command2graduates = new MySqlCommand(ComandSQL2graduates, connection1);
            MySqlDataReader reader2graduates = command2graduates.ExecuteReader();
            students = new Dictionary<int, Student>();
            while (reader2graduates.Read())
            {
                DateTime DecisionDate;
                string date2DecisionDate = null;
                DateTime date;
                string date2birthday = null;
                DateTime dateStart=new DateTime();
                string dateStart2 = null;
                DateTime dateEnd=new DateTime();
                string dateEnd2 = null;
                if (!String.IsNullOrEmpty(reader2graduates["DecisionDate"].ToString()))
                {

                    DecisionDate = Convert.ToDateTime(reader2graduates["DecisionDate"]);
                    date2DecisionDate = String.Format("{0}.{1}.{2}", DecisionDate.Day, DecisionDate.Month, DecisionDate.Year);
                }
                if (!String.IsNullOrEmpty(reader2graduates["TrainingStar"].ToString()))
                {

                    dateStart = Convert.ToDateTime(reader2graduates["TrainingStar"]);
                    dateStart2 = String.Format("{0}.{1}.{2}", dateStart.Day, dateStart.Month, dateStart.Year);
                }
                if (!String.IsNullOrEmpty(reader2graduates["TrainingEnd"].ToString()))
                {

                    dateEnd = Convert.ToDateTime(reader2graduates["TrainingEnd"]);
                    dateEnd2 = String.Format("{0}.{1}.{2}", dateEnd.Day, dateEnd.Month, dateEnd.Year);
                }
                if (!String.IsNullOrEmpty(reader2graduates["birthday"].ToString()))
                {

                    date = Convert.ToDateTime(reader2graduates["birthday"]);
                    date2birthday = String.Format("{0}.{1}.{2}", date.Day, date.Month, date.Year);
                }
                
                Student student = new Student();
                student.ID = Convert.ToInt16(reader2graduates["Graduat_ID"]);
                student.ProtNum = Convert.ToInt32(reader2graduates["ProtNum"]);
                student.Lastname.UA = reader2graduates["Lastname_UA"].ToString();
                student.Lastname.EN = reader2graduates["Lastname_EN"].ToString();
                student.Firstname.UA = reader2graduates["Firstname_UA"].ToString();
                student.Firstname.EN = reader2graduates["Firstname_EN"].ToString();
                student.Birthday = Convert.ToDateTime(date2birthday);
                student.dateStart = Convert.ToDateTime(dateStart);
                student.dateEnd = Convert.ToDateTime(dateEnd);
                student.DecisionDate= Convert.ToDateTime(date2DecisionDate);
                student.SerialDiploma = reader2graduates["SerialDiploma"].ToString();
                student.NumberDiploma = reader2graduates["NumberDiploma"].ToString();
                student.IssuedBy = reader2graduates["IssuedBy"].ToString();
                student.NumberAddition = reader2graduates["NumberAddition"].ToString();
                student.PrevDocument.UA = reader2graduates["PrevDocument_UA"].ToString();
                student.PrevDocument.EN = reader2graduates["PrevDocument_EN"].ToString();
                student.PrevSerialNumberAddition = reader2graduates["prevSerialNumberAddition"].ToString();
                student.DurationOfTraining.UA = reader2graduates["DurationOfTraining_UA"].ToString();
                student.DurationOfTraining.EN = reader2graduates["DurationOfTraining_EN"].ToString();
                student.QualificationAwarded.UA= reader2graduates["QualificationAwardedUA"].ToString();
                student.QualificationAwarded.EN = reader2graduates["QualificationAwardedEN"].ToString();

                students.Add(i, student);
                i++;
            }

            reader2graduates.Close();
            progressBar1.Value = 0;
            progressBar1.Maximum = i;

            string ComandSQLgetQualification2 = "SELECT  Qualification.* FROM  Qualification  WHERE Qualification.Qualification_ID=" + ID;
            MySqlCommand commandList12 = new MySqlCommand(ComandSQLgetQualification2, connection1);
            MySqlDataReader readerList12 = commandList12.ExecuteReader();
            readerList12.Read();

            ////////////
            Degree = readerList12["Degree"].ToString();
            qualification.UA = readerList12["Qualification_UA"].ToString();
            qualification.EN = readerList12["Qualification_EN"].ToString();
            FieldStudy.UA = readerList12["FieldStudy_UA"].ToString();
            FieldStudy.EN = readerList12["FieldStudy_EN"].ToString();
            FirstSpecialty.UA = readerList12["FirstSpecialty_UA"].ToString();
            FirstSpecialty.EN = readerList12["FirstSpecialty_EN"].ToString();
            SecondSpecialty.UA = readerList12["SecondSpecialty_UA"].ToString();
            SecondSpecialty.EN = readerList12["SecondSpecialty_EN"].ToString();
            Specialization.UA = readerList12["Specialization_UA"].ToString();
            Specialization.EN = readerList12["Specialization_EN"].ToString();
            studyQualification.UA = Regex.Replace(readerList12["Main_field_study_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            studyQualification.EN = Regex.Replace(readerList12["Main_field_study_EN"].ToString()
                , Encoding.ASCII.GetString(new byte[] { 10 }), "");

            readerList12.Close();
            


            string ComandSQLgetNational_framework = "SELECT  National_framework.* FROM  National_framework" +
                "  WHERE National_framework.Qualification_ID=" + ID;
            MySqlCommand commandList2 = new MySqlCommand(ComandSQLgetNational_framework, connection1);
            MySqlDataReader readerList2 = commandList2.ExecuteReader();
            readerList2.Read();
            if (readerList2 != null)
            {
                levelQualification.UA = Regex.Replace(readerList2["Level_qualification_UA"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");
                levelQualification.EN = Regex.Replace(readerList2["Level_qualification_EN"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");

                durationProgram.UA = Regex.Replace(readerList2["Official_duration_programme_UA"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");
                durationProgram.EN = Regex.Replace(readerList2["Official_duration_programme_EN"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");
                accessRequiments.UA = Regex.Replace(readerList2["Access_requirements_UA"].ToString(),
                    Encoding.ASCII.GetString(new byte[] { 10 }), "");
                accessRequiments.EN = Regex.Replace(readerList2["Access_requirements_EN"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");

                Access_to_further.UA = Regex.Replace(readerList2["Access_further_study_UA"].ToString()
                     , Encoding.ASCII.GetString(new byte[] { 10 }), "");
                Access_to_further.EN = Regex.Replace(readerList2["Access_further_study_EN"].ToString(),
                    Encoding.ASCII.GetString(new byte[] { 10 }), "");
                Professional_status.UA = Regex.Replace(readerList2["Professional_status_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
                Professional_status.EN = Regex.Replace(readerList2["Professional_status_EN"].ToString(),
                    Encoding.ASCII.GetString(new byte[] { 10 }), "");
            }

            readerList2.Close();
            
            string ComandSQLgetContents_and_results = "SELECT  Contents_and_results.* FROM  Contents_and_results  WHERE Contents_and_results.Qualification_ID=" + ID;
            MySqlCommand commandList3 = new MySqlCommand(ComandSQLgetContents_and_results, connection1);
            MySqlDataReader readerList3 = commandList3.ExecuteReader();
            readerList3.Read();
            modeStudy =  Regex.Replace(readerList3["Form_study_UA"].ToString().Trim(), @"\s+", " ") + "/" + Regex.Replace(readerList3["Form_study_EN"].ToString().Trim(), @"\s+", " ");

            if (readerList3["Program_Specification_UA"].ToString() != null)
                programSpecification.UA = Regex.Replace(readerList3["Program_Specification_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Program_Specification_EN"].ToString() != null)
                programSpecification.EN = Regex.Replace(readerList3["Program_Specification_EN"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Knowledge_undestanding_EN"].ToString() != null)
                knowledgeUnderstanding.EN = Regex.Replace(readerList3["Knowledge_undestanding_EN"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Knowledge_undestanding_UA"].ToString() != null)
                knowledgeUnderstanding.UA = Regex.Replace(readerList3["Knowledge_undestanding_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Application_knowledge_understanding_EN"].ToString() != null)
                applyingKnowledge.EN = Regex.Replace(readerList3["Application_knowledge_understanding_EN"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Application_knowledge_understanding_UA"].ToString() != null)
                applyingKnowledge.UA = Regex.Replace(readerList3["Application_knowledge_understanding_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Making_judgments_EN"].ToString() != null)
                MakingJudgments.EN = Regex.Replace(readerList3["Making_judgments_EN"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");
            if (readerList3["Making_judgments_UA"].ToString() != null)
                MakingJudgments.UA = Regex.Replace(readerList3["Making_judgments_UA"].ToString()
                    , Encoding.ASCII.GetString(new byte[] { 10 }), "");

            readerList3.Close();
            

           
            generateEuroAddEuroSupplement(directory, 0, students);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        //void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        //{
        //    if (e.IsValidInput)
        //    {

        //        if (maskedTextBox.Visible)

        //        {
        //            DateTime Date;

        //            if (DateTime.TryParse(maskedTextBox.Text, out Date))
        //            {
        //                if (!String.IsNullOrEmpty(dataGridView2.CurrentCell.Value.ToString()))
        //                { dataGridView2.CurrentCell.Value = ""; }
        //                //maskedTextBox.Text = String.Format("{0}.{1}.{2}", Date.Day, Date.Month, Date.Year);
        //                dataGridView2.CurrentCell.Value = Date.ToString("d.M.yyyy", CultureInfo.InvariantCulture);
        //            }
        //            else
        //            {
        //                //dataGridView2.CurrentCell.Value = maskedTextBox.Text;
        //                MessageBox.Show("Дані не вдалося конвертувати в дату");
        //            }
        //            maskedTextBox.Visible = false;
        //        }
        //    }
            //else
            //{
            //    //Now that the type has passed basic type validation, enforce more specific type rules.
            //    DateTime userDate = (DateTime)e.ReturnValue;
            //    if (userDate < DateTime.Now)
            //    {
            //        toolTip1.ToolTipTitle = "Invalid Date";
            //        toolTip1.Show("The date in this field must be greater than today's date.", maskedTextBox1, 0, -20, 5000);
            //        e.Cancel = true;
            //    }
            //}
        //}


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                

                case "buton":
                    if (!String.IsNullOrEmpty(dataGridView2["ID_graduates", e.RowIndex].Value.ToString()))
                    {
                        
                        string deletStart = "DELETE FROM Estimates WHERE Graduat_ID=" + dataGridView2["ID_graduates", e.RowIndex].Value.ToString();
                        MySqlCommand command = new MySqlCommand(deletStart, connection1);
                        command.ExecuteNonQuery();

                        deletStart = "DELETE FROM graduates WHERE Graduat_ID=" + dataGridView2["ID_graduates", e.RowIndex].Value.ToString();
                        command = new MySqlCommand(deletStart, connection1);
                        command.ExecuteNonQuery();

                        dataGridView2.Rows.Clear();
                        ShowGraduates();
                        MessageBox.Show("Було змінено данні!");
                    }
                    else { dataGridView2.Rows.RemoveAt(e.RowIndex); }

                    break;

                case "Estimates":
                    if (dataGridView3.RowCount > 0)
                    {
                        if (!String.IsNullOrEmpty(dataGridView2["ID_graduates", e.RowIndex].Value.ToString()))
                        {
                            Estimates estimates = new Estimates();
                            estimates.ID = Convert.ToInt32(dataGridView2["ID_graduates", e.RowIndex].Value);
                            estimates.IDq = ID;
                            estimates.StringConnection = StringConnection;
                            estimates.ShowDialog();
                        }
                        else { MessageBox.Show("Спочатку закінчіть ввід даних"); }

                    }
                    else { MessageBox.Show("Спочатку створіть дисципліни"); }

                    break;
                

            }


        }

        private void button26_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name== "Baton")
            {
                if (!String.IsNullOrEmpty(dataGridView3["Discipline_ID", e.RowIndex].Value.ToString()))
                    {
                        string deletStart = "DELETE FROM Estimates WHERE Disciptine_ID=" + dataGridView3["Discipline_ID", e.RowIndex].Value.ToString();
                        MySqlCommand command = new MySqlCommand(deletStart, connection1);
                        command.ExecuteNonQuery();

                        deletStart = "DELETE FROM Discipline WHERE Discipline_ID=" + dataGridView3["Discipline_ID", e.RowIndex].Value.ToString();
                        command = new MySqlCommand(deletStart, connection1);
                        command.ExecuteNonQuery();


                        int ind = Convert.ToInt32(e.RowIndex);

                        dataGridView3.Rows.Clear();
                        ShowDiscipline();
                        MessageBox.Show("Було змінено данні!");
                }
                else { dataGridView3.Rows.RemoveAt(e.RowIndex); }

                 
            }
        }
        private void ShowDiscipline()
        {
            MySqlDataReader reader = null;
            try
            {
                string ComandSQL2Discipline = "SELECT Discipline.*  FROM Discipline WHERE Discipline.Qualification_ID=" + ID;
                MySqlCommand command = new MySqlCommand(ComandSQL2Discipline, connection1);
                reader = command.ExecuteReader();

                float SumHours =0 ;
                float SumLoans = 0;
                if (reader != null)
                    while (reader.Read())
                    {
                        
                        dataGridView3.Rows.Add(reader["Course_title_UA"].ToString(), reader["Course_title_EN"].ToString(), 
                            reader["Loans"].ToString(),
                            reader["Hours"].ToString(), reader["Teaching"].ToString(),
                            reader["Differential"].ToString(), reader["Discipline_ID"].ToString());
                        float valh= float.Parse(reader["Hours"].ToString());
                        SumHours += valh;
                        float val = float.Parse(reader["Loans"].ToString());
                        SumLoans += val;
                    }
                reader.Close();
                label26.Text = SumLoans.ToString();
                label27.Text = SumHours.ToString();
                ShowEstimatea();
            }
            catch (Exception help)
            {
                reader.Close();
                MessageBox.Show(help.Message);
                //this.Close();
            }
        }
        private void ShowGraduates()
        {
            string ComandSQL2graduates = "SELECT *  FROM graduates WHERE graduates.Qualification_ID=" + ID;
            MySqlCommand command2graduates = new MySqlCommand(ComandSQL2graduates, connection1);
            MySqlDataReader reader2graduates = command2graduates.ExecuteReader();

            if (reader2graduates != null)
            {
                while (reader2graduates.Read())
                {
                    DateTime date;
                    string date2birthday = null;
                    DateTime dateStart;
                    string dateStart2 = null;
                    DateTime dateEnd;
                    string dateEnd2 = null;
                    DateTime DecisionDate;
                    string DecisionDate2 = null;

                    if (!String.IsNullOrEmpty(reader2graduates["TrainingStar"].ToString()))
                    {

                        dateStart = Convert.ToDateTime(reader2graduates["TrainingStar"]);
                        dateStart2 = String.Format("{0}.{1}.{2}", dateStart.Day, dateStart.Month, dateStart.Year);
                    }
                    if (!String.IsNullOrEmpty(reader2graduates["TrainingEnd"].ToString()))
                    {

                        dateEnd = Convert.ToDateTime(reader2graduates["TrainingEnd"]);
                        dateEnd2 = String.Format("{0}.{1}.{2}", dateEnd.Day, dateEnd.Month, dateEnd.Year);
                    }
                    if (!String.IsNullOrEmpty(reader2graduates["birthday"].ToString()))
                    {

                        date = Convert.ToDateTime(reader2graduates["birthday"]);
                        date2birthday = String.Format("{0}.{1}.{2}", date.Day, date.Month, date.Year);
                    }
                    if (!String.IsNullOrEmpty(reader2graduates["DecisionDate"].ToString()))
                    {
                        DecisionDate = Convert.ToDateTime(reader2graduates["DecisionDate"]);
                        DecisionDate2 = String.Format("{0}.{1}.{2}", DecisionDate.Day, DecisionDate.Month, DecisionDate.Year);
                    }


                    dataGridView2.Rows.Add(reader2graduates["Lastname_UA"].ToString(), reader2graduates["Lastname_EN"].ToString(), reader2graduates["Firstname_UA"].ToString(), reader2graduates["Firstname_EN"].ToString(),
                        date2birthday, reader2graduates["SerialDiploma"].ToString(),
                        reader2graduates["NumberDiploma"].ToString(), reader2graduates["NumberAddition"].ToString(),
                        DecisionDate2, reader2graduates["ProtNum"].ToString(), reader2graduates["QualificationAwardedUA"].ToString(), reader2graduates["QualificationAwardedEN"].ToString(),
                        reader2graduates["PrevDocument_UA"].ToString(), reader2graduates["PrevDocument_EN"].ToString(),
                        reader2graduates["prevSerialNumberAddition"].ToString(), reader2graduates["IssuedBy"].ToString(), 
                        dateStart2, dateEnd2, reader2graduates["DurationOfTraining_UA"].ToString(), reader2graduates["DurationOfTraining_EN"].ToString(),
                         reader2graduates["Graduat_ID"].ToString());

                }

                reader2graduates.Close();
            }

        }
        private void ShowContents_and_results()
        {
            try
            {
                string ComandSQLgetContents_and_results = "SELECT  Contents_and_results.* FROM  Contents_and_results  WHERE Contents_and_results.Qualification_ID=" + ID;
                MySqlCommand commandList3 = new MySqlCommand(ComandSQLgetContents_and_results, connection1);
                MySqlDataReader readerList3 = commandList3.ExecuteReader();
                readerList3.Read();
                if (readerList3["Form_study_UA"].ToString() != null)
                    textBox15.Text = readerList3["Form_study_UA"].ToString();
                if (readerList3["Form_study_EN"].ToString() != null)
                    textBox16.Text = readerList3["Form_study_EN"].ToString();
                if (readerList3["Program_Specification_UA"].ToString() != null)
                    textBox17.Text = readerList3["Program_Specification_UA"].ToString();
                if (readerList3["Program_Specification_EN"].ToString() != null)
                    textBox18.Text = readerList3["Program_Specification_EN"].ToString();
                if (readerList3["Knowledge_undestanding_EN"].ToString() != null)
                    textBox19.Text = readerList3["Knowledge_undestanding_EN"].ToString();
                if (readerList3["Knowledge_undestanding_UA"].ToString() != null)
                    textBox20.Text = readerList3["Knowledge_undestanding_UA"].ToString();
                if (readerList3["Application_knowledge_understanding_EN"].ToString() != null)
                    textBox21.Text = readerList3["Application_knowledge_understanding_EN"].ToString();
                if (readerList3["Application_knowledge_understanding_UA"].ToString() != null)
                    textBox22.Text = readerList3["Application_knowledge_understanding_UA"].ToString();
                if (readerList3["Making_judgments_EN"].ToString() != null)
                    textBox23.Text = readerList3["Making_judgments_EN"].ToString();
                if (readerList3["Making_judgments_UA"].ToString() != null)
                    textBox24.Text = readerList3["Making_judgments_UA"].ToString();
                if (readerList3 != null)
                    readerList3.Close();
                button5.Enabled = false;
                button22.Enabled = false;
                button9.Enabled = false;
                button12.Enabled = false;
            }
            catch (Exception help)
            {
                MessageBox.Show(help.Message);
                //this.Close();
            }
        }
        private void ShowNational_framework()
        {
            try
            {

                string ComandSQLgetNational_framework = "SELECT  National_framework.* FROM  National_framework  WHERE National_framework.Qualification_ID=" + ID;
                MySqlCommand commandList2 = new MySqlCommand(ComandSQLgetNational_framework, connection1);
                MySqlDataReader readerList2 = commandList2.ExecuteReader();
                readerList2.Read();
                if (readerList2 != null)
                {
                    if (readerList2["Level_qualification_UA"] != "")
                        textBox5.Text = readerList2["Level_qualification_UA"].ToString();
                    if (readerList2["Level_qualification_EN"] != "")
                        textBox6.Text = readerList2["Level_qualification_EN"].ToString();
                    if (readerList2["Official_duration_programme_UA"] != "")
                        textBox7.Text = readerList2["Official_duration_programme_UA"].ToString();
                    if (readerList2["Official_duration_programme_EN"] != "")
                        textBox8.Text = readerList2["Official_duration_programme_EN"].ToString();
                    if (readerList2["Access_requirements_UA"].ToString() != "")
                        textBox9.Text = readerList2["Access_requirements_UA"].ToString();
                    if (readerList2["Access_requirements_EN"].ToString() != "")
                        textBox10.Text = readerList2["Access_requirements_EN"].ToString();
                    if (readerList2["Access_further_study_UA"].ToString() != "")
                        textBox11.Text = readerList2["Access_further_study_UA"].ToString();
                    if (readerList2["Access_further_study_EN"].ToString() != "")
                        textBox12.Text = readerList2["Access_further_study_EN"].ToString();
                    if (readerList2["Professional_status_UA"].ToString() != "")
                        textBox13.Text = readerList2["Professional_status_UA"].ToString();
                    if (readerList2["Professional_status_EN"].ToString() != "")
                        textBox14.Text = readerList2["Professional_status_EN"].ToString();
                }
                if (readerList2 != null || readerList2.IsClosed)
                    readerList2.Close();
                button16.Enabled = false;
            }
            catch (Exception help)
            {
                MessageBox.Show(help.Message);
                //this.Close();
            }
        }
        private void ShowEstimatea()
        {
            dataGridView1.Rows.Clear();
            if(dataGridView2.RowCount>0)
            try
            {
                string ComandSQL2Discipline = "SELECT *  FROM Discipline WHERE Discipline.Qualification_ID=" + ID;
                MySqlCommand command = new MySqlCommand(ComandSQL2Discipline, connection1);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["Course_title_UA"].ToString(), reader["Differential"].ToString(), reader["Discipline_ID"].ToString());
                    }
                reader.Close();
                dataGridView1.Visible = true;
                label31.Visible = false;

            }
            catch (Exception help)
            {
                //reader.Close();
                MessageBox.Show(help.Message);
                //this.Close();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Estimat":
                    if (dataGridView3.RowCount > 1)
                    {
                        і estimates = new і();
                        estimates.ID = Convert.ToInt32(dataGridView1["Estimates_ID", e.RowIndex].Value);
                        estimates.IDq = ID;
                        estimates.Name = dataGridView1["Discipline", e.RowIndex].Value.ToString();
                        estimates.Dif = dataGridView1["Dif", e.RowIndex].Value.ToString();
                        estimates.StringConnection = StringConnection;
                        estimates.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Спочатку додайте дані про студентів");
                    }


                    break;
            }
        }


        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = dtp.Text.ToString();
            int i = dataGridView2.CurrentCell.RowIndex;
            string upDate = "UPDATE graduates SET birthday=@birthday,TrainingStar=@TrainingStar,TrainingEnd=@TrainingEnd WHERE Graduat_ID=@Graduat_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);
            command.Parameters.AddWithValue("Graduat_ID", Convert.ToInt32(dataGridView2["ID_graduates", i].Value));
            DateTime date;
            if (dataGridView2["birthday", i].Value != null)
            {
                date = Convert.ToDateTime(dataGridView2["birthday", i].Value);
            }
            else
            {
                date = DateTime.Now;
            }
            command.Parameters.AddWithValue("birthday", date);
            DateTime dateStart;
            if (dataGridView2["TrainingStar", i].Value != null)
            {
                dateStart = Convert.ToDateTime(dataGridView2["TrainingStar", i].Value);
            }
            else
            {
                dateStart = DateTime.Now;
            }

            DateTime dateEnd;
            if (dataGridView2["TrainingEnd", i].Value != null)
            {
                dateEnd = Convert.ToDateTime(dataGridView2["TrainingEnd", i].Value);
            }
            else
            {
                dateEnd = DateTime.Now;
            }
            command.Parameters.AddWithValue("TrainingStar", dateStart);
            command.Parameters.AddWithValue("TrainingEnd", dateEnd);
            command.ExecuteNonQuery();
            MessageBox.Show("Було змінено данні!");


        }
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dtp.Visible = false;

        }
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //if (maskedTextBox.Visible)

            //{
            //    //we have to adjust the location for the MaskedTextBox while scrolling

            //    Rectangle rect = dataGridView2.GetCellDisplayRectangle(

            //        dataGridView2.CurrentCell.ColumnIndex,

            //        dataGridView2.CurrentCell.RowIndex, true);

            //   maskedTextBox.Location = rect.Location;

            //}
            //maskedTextBox.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            button1.Enabled = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
        //Національна рамка
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }
        ///Навчальний план
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }
        //Знання і розуміння
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            button22.Enabled = true;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            button22.Enabled = true;
        }
        //Застосування знань
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            button9.Enabled = true;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            button9.Enabled = true;
        }
        //Формування суджень
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = true;
        }
        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = true;
        }

        //Загрузка шаблона
        //private void button27_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Word Microsoft Office 1998-2003 (*.doc)|*.doc";
        //    Stream myStream = null;
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            //docLoadStatusPb.Image = Issu.Properties.Resources.On;
        //            DateTime localDate = DateTime.Now;
        //            filesPath.Add(1, ofd.FileName); // Добавление файлового пути
        //            rbStatus.Text += String.Format("{0}:{1}:{2}: Файл даних \"Word\" успішно завантажено.\n", localDate.Hour, localDate.Minute, localDate.Second);
        //            button28.Enabled = true;
        //        }
        //        catch (Exception exc)
        //        {
        //            //docLoadStatusPb.Image = Issu.Properties.Resources.Off;
        //            DateTime localDate = DateTime.Now;
        //            rbStatus.Text += String.Format("{0}:{1}:{2}: Помилка: \n{3}\n", localDate.Hour, localDate.Minute, localDate.Second, exc.Message);
        //            MessageBox.Show(exc.Message);
        //        }
        //    }

        //}
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////generateEuroAddEuroSupplement//////////////
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="increment"></param>
        /// <param name="students"></param>
        private void generateEuroAddEuroSupplement(string directory, int increment, Dictionary<int, Student> students)
        {


            if (students.Count > increment)
            {

                DateTime localDate = DateTime.Now;
                Word.Application MSWord = new Word.Application();
                try
                {
                    //if (!Directory.Exists(String.Format(pathTodir + "/{0}/{1}", directory, students[increment])))
                    //{
                    //    rbStatus.Text += String.Format("{0}:{1}:{2}: Було створено папку \"{3}\".\n", localDate.Hour, localDate.Minute, localDate.Second, students[increment]);
                    //}

                    //Directory.CreateDirectory(String.Format(pathTodir + "/{0}/{1}", directory, students[increment].Lastname.UA));
                    string CopyFilePaTh = null;
                    try
                    {
                        File.Copy(filesPath[1], String.Format(pathTodir + "/{0}/{1}.doc", directory, students[increment].Lastname.UA), true);
                        CopyFilePaTh = String.Format(pathTodir + "/{0}/{1}.doc", directory, students[increment].Lastname.UA);
                    }
                    catch (Exception exc)
                    {

                        MessageBox.Show(exc.Message);
                        return;
                    }


                    rbStatus.Text += String.Format(pathTodir + "/\nI{0}I\n/\nI{1}I\n.doc", directory, students[increment].Lastname.UA);
                    //FileInfo targetDir = new FileInfo(pathTodir);
                    //string name = targetDir.FullName;

                    Word.Document doc = MSWord.Documents.Open(Path.Combine(CopyFilePaTh), ReadOnly: false, Visible: true);
                    doc.Activate();


               


                    FindAndReplace(MSWord, "{{serialDiploma}}", students[increment].SerialDiploma);
                    FindAndReplace(MSWord, "{{numberDiploma}}", students[increment].NumberDiploma);
                    FindAndReplace(MSWord, "{{numberAddition}}", students[increment].NumberAddition);
                    FindAndReplace(MSWord, "{{lastname_UA}}", students[increment].Lastname.UA);
                    FindAndReplace(MSWord, "{{lastname_EN}}", students[increment].Lastname.EN);
                    FindAndReplace(MSWord, "{{firstname_UA}}", students[increment].Firstname.UA);
                    FindAndReplace(MSWord, "{{firstname_EN}}", students[increment].Firstname.EN);
                    FindAndReplace(MSWord, "{{birthday}}",
                    students[increment].Birthday.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
                    FindAndReplace(MSWord, "{{qualification_UA}}", qualification.UA);
                    FindAndReplace(MSWord, "{{qualification_EN}}", qualification.EN);

                    FindAndReplace(MSWord, "{{FieldStudyUA}}", FieldStudy.UA);
                    FindAndReplace(MSWord, "{{FieldStudyEN}}", FieldStudy.EN);
                    FindAndReplace(MSWord, "{{FirstSpecialtyUA}}", FirstSpecialty.UA);
                    FindAndReplace(MSWord, "{{FirstSpecialtyEN}}", FirstSpecialty.EN);
                    FindAndReplace(MSWord, "{{SecondSpecialtyUA}}", SecondSpecialty.UA);
                    FindAndReplace(MSWord, "{{SecondSpecialtyEN}}", SecondSpecialty.EN);
                    FindAndReplace(MSWord, "{{SpecializationUA}}", Specialization.UA);
                    FindAndReplace(MSWord, "{{SpecializationEN}}", Specialization.EN);


                    FindAndReplace(MSWord, "{{studyQualification_UA}}", studyQualification.UA);
                    FindAndReplace(MSWord, "{{studyQualification_EN}}", studyQualification.EN);

                    
                    FindAndReplace(MSWord, "{{levelQualification_UA}}", levelQualification.UA);
                    FindAndReplace(MSWord, "{{levelQualification_EN}}", levelQualification.EN);
                    FindAndReplace(MSWord, "{{durationProgram_UA}}", durationProgram.UA);
                    FindAndReplace(MSWord, "{{durationProgram_EN}}", durationProgram.EN);
                    FindAndReplace(MSWord, "{{accessRequiments_UA}}", accessRequiments.UA);
                    FindAndReplace(MSWord, "{{accessRequiments_EN}}", accessRequiments.EN);
                    FindAndReplace(MSWord, "{{Access_to_further_UA}}", Access_to_further.UA);
                    FindAndReplace(MSWord, "{{Access_to_further_EN}}", Access_to_further.EN);
                    FindAndReplace(MSWord, "{{Professional_status_UA}}", Professional_status.UA);
                    FindAndReplace(MSWord, "{{Professional_status_EN}}", Professional_status.EN);
                    FindAndReplace(MSWord, "{{DurationOfTraining_UA}}", students[increment].DurationOfTraining.UA);
                    FindAndReplace(MSWord, "{{DurationOfTraining_EN}}", students[increment].DurationOfTraining.EN);
                    FindAndReplace(MSWord, "{{TrainingStar}}",
                        students[increment].dateStart.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
                    FindAndReplace(MSWord, "{{TrainingEnd}}",
                        students[increment].dateEnd.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
                    FindAndReplace(MSWord, "{{modeStudy}}", modeStudy);
                    FindAndReplace(MSWord, "{{prevDocument_UA}}", students[increment].PrevDocument.UA);
                    FindAndReplace(MSWord, "{{prevDocument_EN}}", students[increment].PrevDocument.EN);
                    FindAndReplace(MSWord, "{{PrevSerialNumberAddition}}", students[increment].PrevSerialNumberAddition);
                    FindAndReplace(MSWord, "{{programSpecification_UA}}", programSpecification.UA);
                    FindAndReplace(MSWord, "{{programSpecification_EN}}", programSpecification.EN);
                    FindAndReplace(MSWord, "{{knowledgeUnderstanding_UA}}", knowledgeUnderstanding.UA);
                    FindAndReplace(MSWord, "{{knowledgeUnderstanding_EN}}", knowledgeUnderstanding.EN);
                    FindAndReplace(MSWord, "{{applyingKnowledge_UA}}", applyingKnowledge.UA);
                    FindAndReplace(MSWord, "{{applyingKnowledge_EN}}", applyingKnowledge.EN);
                    FindAndReplace(MSWord, "{{MakingJudgments_UA}}", MakingJudgments.UA);
                    FindAndReplace(MSWord, "{{MakingJudgments_EN}}", MakingJudgments.EN);

                    FindAndReplace(MSWord, "{{DecisionDate}}", students[increment].DecisionDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
                    FindAndReplace(MSWord, "{{ProtNum}}", students[increment].ProtNum.ToString());
                    FindAndReplace(MSWord, "{{QualificationAwardedUA}}", students[increment].QualificationAwarded.UA);
                    FindAndReplace(MSWord, "{{QualificationAwardedEN}}", students[increment].QualificationAwarded.EN);
                    FindAndReplace(MSWord, "{{IssuedBy}}", students[increment].IssuedBy);

                    //MakingJudgments

                    //////////////
                    //Анти-баг
                    Object missingObj = System.Reflection.Missing.Value;
                    //Что 
                    object strToFindObj = "{{Student_Evaluation_Table}}";

                    // диапазон документа Word
                    Word.Range wordRange = null;
                    bool rangeFound;
                    object replaceTypeObj = Word.WdReplace.wdReplaceAll;
                    for (int i = 1; i <= doc.Sections.Count; i++)
                    {
                        wordRange = doc.Sections[i].Range;
                        Word.Find wordFindObj = wordRange.Find;

                        object[] wordFindParameters = new object[15] { strToFindObj,
                                missingObj, missingObj, missingObj, missingObj, missingObj,
                                missingObj, missingObj, missingObj, missingObj, missingObj,
                                missingObj, missingObj, missingObj, missingObj };

                        rangeFound = (bool)wordFindObj.GetType().InvokeMember("Execute",
                            System.Reflection.BindingFlags.InvokeMethod, null, wordFindObj,
                            wordFindParameters);

                        if (rangeFound)
                        {

                            break;
                        }
                        wordFindObj = null;
                    }

                    //Создали таблицу//THER////////////////////////////////////////////////////////
                    //List<string> numbers = new List<string>{};
                    var t1 = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                    var t2 = Word.WdAutoFitBehavior.wdAutoFitContent;
                    object oMissing = System.Reflection.Missing.Value;
                    string ComandSQL = "SELECT COUNT(Discipline_ID) AS COUNT_ID  FROM Discipline WHERE Discipline.Qualification_ID=" + ID;
                    MySqlCommand command = new MySqlCommand(ComandSQL, connection1);
                    MySqlDataReader reader = command.ExecuteReader();///////////
                    reader.Read();
                    int ForRow = reader.GetInt32(0);
                    reader.Close();
                    int t = 0;
               

                ////                    
                Word.Table table = doc.Tables.Add(wordRange, (3 + ForRow), 7, t1,t2);
                //MessageBox.Show("1");
                //table.Columns[1].SetWidth(, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("2");
                //table.Columns[2].SetWidth(90, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("3");
                //table.Columns[3].SetWidth(9, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("4");

                //table.Columns[4].SetWidth(19, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("5");
                //table.Columns[5].SetWidth(9, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("6");
                //table.Columns[6].SetWidth(24, Word.WdRulerStyle.wdAdjustSameWidth);
                //MessageBox.Show("7");
                //table.Columns[7].SetWidth(9, Word.WdRulerStyle.wdAdjustSameWidth);
                table.Columns.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPoints;
                table.Columns[1].SetWidth(15f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[2].SetWidth(350f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[3].SetWidth(15f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[4].SetWidth(28f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[5].SetWidth(28f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[6].SetWidth(85f, Word.WdRulerStyle.wdAdjustNone);
                table.Columns[7].SetWidth(28f, Word.WdRulerStyle.wdAdjustNone);
                table.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                table.Cell(1, 1).Range.Text = "Номер за порядком" +
                        '\n' +
                        "/Course unit code";
                    table.Cell(1, 2).Range.Text = "Назва дисципліни/Course title";
                    table.Cell(1, 3).Range.Text = "Кредити" +
                        '\n' +
                        "ЄКТС" +
                        '\n' +
                        "/ECTS" +
                        '\n' +
                        "credits";
                    table.Cell(1, 4).Range.Text = "Години/\nHours";
                    table.Cell(1, 5).Range.Text = "Бали/\nMarks";
                    table.Cell(1, 6).Range.Text = "Оцінка за національною шкалою/National grade";
                    table.Cell(1, 7).Range.Text = "Рейтинг ЄКТС/\nECTS grade";

                    table.Cell(1, 1).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 2).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 3).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 4).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 5).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 6).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 7).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 1).Range.Bold = 2;
                    table.Cell(1, 2).Range.Bold = 2;
                    table.Cell(1, 3).Range.Bold = 2;
                    table.Cell(1, 4).Range.Bold = 2;
                    table.Cell(1, 5).Range.Bold = 2;
                    table.Cell(1, 6).Range.Bold = 2;
                    table.Cell(1, 7).Range.Bold = 2;
                    table.Borders.Enable = 1;
                    table.Range.Font.Size = 8;

                    
                    table.Cell(1, 2).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 3).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 4).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 5).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 6).Range.Font.Name = "Times New Roman";
                    table.Cell(1, 7).Range.Font.Name = "Times New Roman";
                

                int j = 2;
                    float forH = 0;
                    float forL = 0;
                    string ComandSQLforDiscipline = "SELECT  Discipline.Course_title_UA,Discipline.Course_title_EN, " +
                    " Discipline.Loans,  Discipline.Hours,  Discipline.Teaching,  Discipline.Differential, " +
                    " Estimates.Estimat_NUM, Estimates.Estimat_CHAR,  Estimates.Estimat_UA" +
                    " FROM Estimates INNER JOIN Discipline ON Estimates.Disciptine_ID = Discipline.Discipline_ID" +
                    " WHERE Discipline.Qualification_ID=" + ID +
                    " AND Discipline.Teaching=1 " +
                    "AND Estimates.Graduat_ID =" + students[increment].ID.ToString()+
                    " ORDER BY Discipline.Course_title_UA COLLATE utf8_unicode_ci";
                    MySqlCommand commandforDiscipline = new MySqlCommand(ComandSQLforDiscipline, connection1);
                    MySqlDataReader readerforDiscipline1 = commandforDiscipline.ExecuteReader();
                
                while (readerforDiscipline1.Read())
                    {
                        table.Cell(j, 1).Range.Text = (j - 1).ToString();
                        table.Cell(j, 2).Range.Text = (readerforDiscipline1["Course_title_UA"].ToString() + "/" + readerforDiscipline1["Course_title_EN"].ToString());
                        table.Cell(j, 3).Range.Text = readerforDiscipline1["Loans"].ToString();
                        table.Cell(j, 4).Range.Text = readerforDiscipline1["Hours"].ToString();
                        forH += float.Parse(readerforDiscipline1["Hours"].ToString());
                        forL += float.Parse(readerforDiscipline1["Loans"].ToString());
                        //numbers.Add(Convert.ToString(readerforDiscipline1["Discipline_ID"]));
                        //string ShowEstimates = "SELECT [Estimates].[Estimat_ID],[Estimates].[Estimat_NUM], [Estimates].[Estimat_UA], [Estimates].[Estimat_CHAR]  FROM  [Estimates]  WHERE  [Estimates].[Graduat_ID] = " + students[increment].ID.ToString() + " AND [Estimates].[Disciptine_ID] = " + );
                        //MySqlCommand commandList = new MySqlCommand(ShowEstimates, connection1);
                        //MySqlDataReader reader2 =   commandList.ExecuteReader();
                        //  reader2.Read();
                        try
                        {
                            table.Cell(j, 5).Range.Text = readerforDiscipline1["Estimat_NUM"].ToString();
                            table.Cell(j, 6).Range.Text = readerforDiscipline1["Estimat_UA"].ToString();
                            table.Cell(j, 7).Range.Text = readerforDiscipline1["Estimat_CHAR"].ToString();

                        }
                        catch
                        {
                            if (Convert.ToString(readerforDiscipline1["Differential"]) == "Зарах")
                            {
                                table.Cell(j, 6).Range.Text = "не складав(ла)";
                            }
                            else
                            {
                                table.Cell(j, 6).Range.Text = "Незадовільно / Fail";
                            }
                        }
                        //reader2.Close();
                        j++;

                    }
                    readerforDiscipline1.Close();
                
                int CUoNT = 0;
                    string ComandCOUNT = "";
                    MySqlDataReader readerComandCOUNT2 = null;
                    try
                    {
                        ComandCOUNT = "SELECT COUNT(Discipline_ID) AS COUNT_ID  FROM  Discipline WHERE" +
                           " Discipline.Qualification_ID=" + ID + " AND Discipline.Teaching=2";
                        MySqlCommand commandCOUNT = new MySqlCommand(ComandCOUNT, connection1);
                        readerComandCOUNT2 = commandCOUNT.ExecuteReader();
                        readerComandCOUNT2.Read();

                        CUoNT = readerComandCOUNT2.GetInt32(0);
                        if (readerComandCOUNT2 != null)
                            readerComandCOUNT2.Close();
                    }
                    catch { CUoNT = 0; readerComandCOUNT2.Close(); }
                    if (CUoNT > 0)
                    {
                        string ComandSQLforDiscipline2 = "SELECT  Discipline.Course_title_UA,Discipline.Course_title_EN, " +
                        " Discipline.Loans,  Discipline.Hours,  Discipline.Teaching,  Discipline.Differential, " +
                        " Estimates.Estimat_NUM, Estimates.Estimat_CHAR,  Estimates.Estimat_UA" +
                        " FROM Estimates INNER JOIN Discipline ON Estimates.Disciptine_ID = Discipline.Discipline_ID" +
                        " WHERE Discipline.Qualification_ID=" + ID +
                        " AND Discipline.Teaching=2 " +
                        "AND Estimates.Graduat_ID =" + students[increment].ID.ToString() +
                        " ORDER BY Discipline.Course_title_UA COLLATE utf8_unicode_ci";
                        MySqlCommand commandforDiscipline2 = new MySqlCommand(ComandSQLforDiscipline2, connection1);
                        MySqlDataReader readerforDiscipline2 = commandforDiscipline2.ExecuteReader();
                        if (readerforDiscipline2 != null)
                        {
                            table.Rows.Add(ref oMissing);
                            table.Cell(j, 2).Range.Text = "Практики / Practical training";
                            table.Cell(j, 2).Range.Bold = 2;
                            j++;
                            t = j;
                            while (readerforDiscipline2.Read())
                            {
                            

                                table.Cell(j, 1).Range.Text = (j - 1).ToString();
                                table.Cell(j, 2).Range.Text = (readerforDiscipline2["Course_title_UA"].ToString() + "/" 
                                + readerforDiscipline2["Course_title_EN"].ToString());
                            
                            table.Cell(j, 3).Range.Text = readerforDiscipline2["Loans"].ToString();
                                table.Cell(j, 4).Range.Text = readerforDiscipline2["Hours"].ToString();
                            
                                forH +=readerforDiscipline2.GetFloat(3);
                                forL +=readerforDiscipline2.GetFloat(2);
                           


                            try
                                {
                                    table.Cell(j, 5).Range.Text = readerforDiscipline2["Estimat_NUM"].ToString();
                                    table.Cell(j, 6).Range.Text = readerforDiscipline2["Estimat_UA"].ToString();
                                    table.Cell(j, 7).Range.Text = readerforDiscipline2["Estimat_CHAR"].ToString();

                                }
                                catch
                                {
                                    if (Convert.ToString(readerforDiscipline2["Differential"]) == "Зарах")
                                    {
                                        table.Cell(j, 6).Range.Text = "не складав(ла)";
                                    }
                                    else
                                    {
                                        table.Cell(j, 6).Range.Text = "Незадовільно / Fail";
                                    }

                                }

                                j++;


                            }
                            readerforDiscipline2.Close();
                        }
                    }
                    CUoNT = 0;
                //MessageBox.Show("1");
                //MySqlDataReader readerComandCOUNT3 = null;
                MySqlDataReader readerComandCOUNT3 = null;
                try
                {
                    ComandCOUNT = "SELECT COUNT(Discipline_ID) AS COUNT_ID  FROM  Discipline WHERE" +
                            " Discipline.Qualification_ID=" + ID + " AND Discipline.Teaching=3";
                        MySqlCommand commandCOUN3 = new MySqlCommand(ComandCOUNT, connection1);
                        readerComandCOUNT3 = commandCOUN3.ExecuteReader();
                        if (readerComandCOUNT3.Read())
                            if(readerComandCOUNT3[0]!= DBNull.Value)
                            {
                            CUoNT = readerComandCOUNT3.GetInt32(0);
                            readerComandCOUNT3.Close();
                             }
                }
                catch { CUoNT = 0; readerComandCOUNT3.Close(); }
                readerComandCOUNT3.Close();
                    if (CUoNT > 0)
                        {
                        string ComandSQLforDiscipline3 = "SELECT  Discipline.Course_title_UA,Discipline.Course_title_EN, " +
                        " Discipline.Loans,  Discipline.Hours,  Discipline.Teaching,  Discipline.Differential, " +
                        " Estimates.Estimat_NUM, Estimates.Estimat_CHAR,  Estimates.Estimat_UA" +
                        " FROM Estimates INNER JOIN Discipline ON Estimates.Disciptine_ID = Discipline.Discipline_ID" +
                        " WHERE Discipline.Qualification_ID=" + ID +
                        " AND Discipline.Teaching=3 " +
                        "AND Estimates.Graduat_ID =" + students[increment].ID.ToString() +
                    " ORDER BY Discipline.Course_title_UA COLLATE utf8_unicode_ci";
                        MySqlCommand commandforDiscipline3 = new MySqlCommand(ComandSQLforDiscipline3, connection1);
                        MySqlDataReader readerforDiscipline3 = commandforDiscipline3.ExecuteReader();
                        if (readerforDiscipline3 != null)
                        {
                            table.Rows.Add(ref oMissing);
                            table.Cell(j, 2).Range.Text = "Курсові / Coursework";
                            table.Cell(j, 2).Range.Bold = 2;
                            j++;

                            while (readerforDiscipline3.Read())
                            {
                                table.Cell(j, 1).Range.Text = (j - 1).ToString();
                                table.Cell(j, 2).Range.Text = (readerforDiscipline3["Course_title_UA"].ToString() + "/"
                                + readerforDiscipline3["Course_title_EN"].ToString());
                                table.Cell(j, 3).Range.Text = readerforDiscipline3["Loans"].ToString();
                                table.Cell(j, 4).Range.Text = readerforDiscipline3["Hours"].ToString();
                                forH += float.Parse(readerforDiscipline3["Hours"].ToString());
                                forL += float.Parse(readerforDiscipline3["Loans"].ToString());

                                try
                                {
                                    table.Cell(j, 5).Range.Text = readerforDiscipline3["Estimat_NUM"].ToString();
                                    table.Cell(j, 6).Range.Text = readerforDiscipline3["Estimat_UA"].ToString();
                                    table.Cell(j, 7).Range.Text = readerforDiscipline3["Estimat_CHAR"].ToString();

                                }
                                catch
                                {
                                    if (Convert.ToString(readerforDiscipline3["Differential"]) == "Зарах")
                                    {
                                        table.Cell(j, 6).Range.Text = "не складав(ла)";
                                    }
                                    else
                                    {
                                        table.Cell(j, 6).Range.Text = "Незадовільно / Fail";
                                    }
                                }

                                j++;

                            }
                            readerforDiscipline3.Close();
                        }
                    }
                    CUoNT = 0;
                    MySqlDataReader ComandCOUNT4=null;
                    try
                    {
                        ComandCOUNT = "SELECT COUNT(Discipline_ID) AS COUNT_ID  FROM  Discipline WHERE" +
                            " Discipline.Qualification_ID=" + ID + " AND Discipline.Teaching=4";

                        MySqlCommand commandCOUN4 = new MySqlCommand(ComandCOUNT, connection1);

                        ComandCOUNT4 = commandCOUN4.ExecuteReader();
                        ComandCOUNT4.Read();

                        CUoNT = ComandCOUNT4.GetInt32(0);

                        ComandCOUNT4.Close();
                    }
                    catch { CUoNT = 0;ComandCOUNT4.Close(); }
                    if (CUoNT > 0)
                    {
                        string ComandSQLforDiscipline4 = "SELECT  Discipline.Course_title_UA,Discipline.Course_title_EN, " +
                        " Discipline.Loans,  Discipline.Hours,  Discipline.Teaching,  Discipline.Differential, " +
                        " Estimates.Estimat_NUM, Estimates.Estimat_CHAR,  Estimates.Estimat_UA" +
                        " FROM Estimates INNER JOIN Discipline ON Estimates.Disciptine_ID = Discipline.Discipline_ID" +
                        " WHERE Discipline.Qualification_ID=" + ID +
                        " AND Discipline.Teaching=4 " +
                        "AND Estimates.Graduat_ID =" + students[increment].ID.ToString() +
                        " ORDER BY Discipline.Course_title_UA COLLATE utf8_unicode_ci";
                        MySqlCommand commandforDiscipline4 = new MySqlCommand(ComandSQLforDiscipline4, connection1);
                        MySqlDataReader readerforDiscipline4 = commandforDiscipline4.ExecuteReader();
                        if (readerforDiscipline4 != null)
                        {
                            table.Rows.Add(ref oMissing);
                            table.Cell(j, 2).Range.Text = "Атестація / Сertification";
                            table.Cell(j, 2).Range.Bold = 2;
                            j++;
                            while (readerforDiscipline4.Read())
                            {
                                table.Cell(j, 1).Range.Text = (j - 1).ToString();
                                table.Cell(j, 2).Range.Text = (readerforDiscipline4["Course_title_UA"].ToString() + "/" + readerforDiscipline4["Course_title_EN"].ToString());
                                table.Cell(j, 3).Range.Text = readerforDiscipline4["Loans"].ToString();
                                table.Cell(j, 4).Range.Text = readerforDiscipline4["Hours"].ToString();
                                forH += float.Parse(readerforDiscipline4["Hours"].ToString());
                                forL += float.Parse(readerforDiscipline4["Loans"].ToString());

                                try
                                {
                                    table.Cell(j, 5).Range.Text = readerforDiscipline4["Estimat_NUM"].ToString();
                                    table.Cell(j, 6).Range.Text = readerforDiscipline4["Estimat_UA"].ToString();
                                    table.Cell(j, 7).Range.Text = readerforDiscipline4["Estimat_CHAR"].ToString();

                                }
                                catch
                                {
                                    if (Convert.ToString(readerforDiscipline4["Differential"]) == "Зарах")
                                    {
                                        table.Cell(j, 6).Range.Text = "не складав(ла)";
                                    }
                                    else
                                    {
                                        table.Cell(j, 6).Range.Text = "Незадовільно / Fail";
                                    }

                                }

                                j++;

                            }
                            
                        }
                        readerforDiscipline4.Close();
                    }
                    
                    table.Cell(j, 2).Range.Text = "Всього кредитів ЄКТС/Total credits ECTS";
                    table.Cell(j + 1, 2).Range.Text = "Підсумкова оцінка/Total mark and rank";
                    table.Cell(j, 2).Range.Font.Name = "Times New Roman";
                    table.Cell(j + 1, 2).Range.Font.Name = "Times New Roman";
                    table.Cell(j, 2).Range.Bold = 2;
                    table.Cell(j, 3).Range.Bold = 2;
                    table.Cell(j, 4).Range.Bold = 2;
                    table.Cell(j + 1, 2).Range.Bold = 2;
                    table.Cell(j, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(j + 1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(j, 3).Range.Text = forL.ToString();
                    table.Cell(j, 4).Range.Text = forH.ToString();
                    doc.Save();
                    MSWord.Quit();
                    progressBar1.Value = increment + 1;
                    rbStatus.Text += Path.Combine(pathTodir + "/{0}/{1}/{1}.doc", directory, students[increment].Lastname.UA);
                    rbStatus.Text += Path.Combine(Environment.CurrentDirectory, directory, students[increment].Lastname.UA, students[increment] + ".doc");

                    //percentStatusLbl.Text = String.Format("{0}/{1}", increment, students.Count);

                    replaceTypeObj = null;
                    rangeFound = false;
                    table = null;




                    increment++;

                    generateEuroAddEuroSupplement(directory, increment, students);
                }
                catch (Exception exc)
                {
                    //doc.Save();
                    MSWord.Quit();
                    MessageBox.Show(exc.Message);
                }

            }
            else
            {
                MessageBox.Show("Гoтовo");
                
                filesPath = null;
                students = null;
            }

        }


        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, string findText, string replaceWithText)
        {
            if (replaceWithText.Length > 255)
            {
                FindAndReplace(doc, findText, findText + replaceWithText.Substring(255));
                replaceWithText = replaceWithText.Substring(0, 255);
            }

            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            //execute find and replace
            doc.Selection.Find.Execute(findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
        //Заполнение переменых для временого хранение 

        /// <summary>
        /// /////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView3_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

           

            if (dataGridView3.NewRowIndex != e.RowIndex)
            {
                try
                {
                    
                    if (!string.IsNullOrEmpty(dataGridView3["Loans", e.RowIndex].Value.ToString()))
                    {
                        float val = float.Parse(dataGridView3["Loans", e.RowIndex].Value.ToString());



                        if (val < 0 && val > 10000)
                        {
                            dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            dataGridView3.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                            // Текущая ячейка теперь в колонке "order"
                            dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Loans"];

                            // Включаем редактирование ячейки
                            dataGridView3.BeginEdit(true);

                            // Валидация строки прошла неудачей
                            e.Cancel = true;
                            dataGridView3.Rows[e.RowIndex].ErrorText = "Введіть додатне число,не більше за 10000";
                            tabControl1.SelectedIndex = 6;
                        }
                        else if (!string.IsNullOrEmpty(dataGridView3["Hours", e.RowIndex].Value.ToString()))
                        {
                            float valh = float.Parse(dataGridView3["Hours", e.RowIndex].Value.ToString());
                            if (valh < 0 && valh > 10000)
                            {

                                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                                // Текущая ячейка теперь в колонке "order"
                                dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Hours"];

                                // Включаем редактирование ячейки
                                dataGridView3.BeginEdit(true);

                                // Валидация строки прошла неудачей
                                e.Cancel = true;
                                dataGridView3.Rows[e.RowIndex].ErrorText = "Введіть додатне число,не більше за 10000";
                                tabControl1.SelectedIndex = 6;
                            }
                        }
                    }
                    if (IsUkr(Convert.ToString(dataGridView3["Course_titel_UA", e.RowIndex].Value))
                        && IsEng(Convert.ToString(dataGridView3["Course_titel_EN", e.RowIndex].Value)))
                    {

                        dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dataGridView3.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
                        e.Cancel = false;
                        dataGridView3.Rows[e.RowIndex].ErrorText = "";
                    }
                    else
                    {
                        dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        dataGridView3.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                        if (!IsUkr(Convert.ToString(dataGridView3["Course_titel_UA", e.RowIndex].Value)))
                        {
                            dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Course_titel_UA"];
                            dataGridView3.BeginEdit(true);
                            e.Cancel = true;
                            dataGridView3.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView3.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки українського алфавіту";
                        }
                        else if (!IsEng(Convert.ToString(dataGridView3["Course_titel_EN", e.RowIndex].Value)))
                        {
                            dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Course_titel_EN"];
                            dataGridView3.BeginEdit(true);
                            e.Cancel = true;
                            dataGridView3.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView3.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки англійського алфавіту";
                        }
                        tabControl1.SelectedIndex = 6;
                    }

                }
                catch (Exception exs)
                {
                    tabControl1.SelectedIndex = 6;
                    // Меняем дизайн текущей строки из dataGridView2 на красный
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                    // Текущая ячейка теперь в колонке "order"
                    try
                    {
                        double val = Convert.ToDouble(dataGridView3["Hours", e.RowIndex].Value);
                        dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Hours"];
                    }
                    catch
                    {
                        double val = Convert.ToDouble(dataGridView3["Loans", e.RowIndex].Value);
                        dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells["Loans"];

                    }

                    // Включаем редактирование ячейки
                    dataGridView3.BeginEdit(true);

                    // Валидация строки прошла неудачей
                    e.Cancel = true;
                    dataGridView3.Rows[e.RowIndex].ErrorText = dataGridView2.CurrentCell.OwningColumn.HeaderText + "-Введіть додатне число";
                }
            }
        }

        private void dataGridView2_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView2.NewRowIndex != e.RowIndex)
            {
                try
                {
                    if (!String.IsNullOrEmpty(dataGridView2["birthday", e.RowIndex].Value.ToString()))
                {
                    try
                    {
                        DateTime dateValue = new DateTime();
                        DateTime.TryParse(dataGridView2["birthday", e.RowIndex].Value.ToString(), out dateValue);
                        dataGridView2["birthday", e.RowIndex].Value = dateValue.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

                    }
                    catch
                    {
                        tabControl1.SelectedIndex = 8;
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["birthday"];
                        dataGridView2.Rows[e.RowIndex].ErrorText = "Введіть  дату в форматі 00.00.0000";
                        e.Cancel = true;
                        tabControl1.SelectedIndex = 8;
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                        return;
                    }
                    
                }
                
                    if (!String.IsNullOrEmpty(dataGridView2["TrainingStar", e.RowIndex].Value.ToString()))
                    {
                        try
                        {
                            DateTime dateValue = new DateTime();
                            DateTime.TryParse(dataGridView2["TrainingStar", e.RowIndex].Value.ToString(), out dateValue);
                            dataGridView2["TrainingStar", e.RowIndex].Value = dateValue.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

                        }
                        catch
                        {
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["TrainingStar"];
                            dataGridView2.Rows[e.RowIndex].ErrorText = "Введіть  дату в форматі 00.00.0000";
                            e.Cancel = true;
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                            return;
                        }
                    }

                    if (!String.IsNullOrEmpty(dataGridView2["TrainingEnd", e.RowIndex].Value.ToString()))
                    {
                        try
                        {
                            DateTime dateValue = new DateTime();
                            DateTime.TryParse(dataGridView2["TrainingEnd", e.RowIndex].Value.ToString(), out dateValue);
                            dataGridView2["TrainingEnd", e.RowIndex].Value = dateValue.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

                        }
                        catch
                        {
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["TrainingEnd"];
                            dataGridView2.Rows[e.RowIndex].ErrorText = "Введіть  дату в форматі 00.00.0000";
                            e.Cancel = true;
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                            return;
                        }
                    }
                    if (!String.IsNullOrEmpty(dataGridView2["DecisionDate", e.RowIndex].Value.ToString()))
                    {
                        try
                        {
                            DateTime dateValue = new DateTime();
                            DateTime.TryParse(dataGridView2["DecisionDate", e.RowIndex].Value.ToString(), out dateValue);
                            dataGridView2["DecisionDate", e.RowIndex].Value = dateValue.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);

                        }
                        catch
                        {
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["DecisionDate"];
                            dataGridView2.Rows[e.RowIndex].ErrorText = "Введіть  дату в форматі 00.00.0000";
                            e.Cancel = true;
                            tabControl1.SelectedIndex = 8;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                            return;
                        }
                    }

                }
                catch { }
                // Если название заказа не пустое, значит валидация прошла успешно
                if (IsUkr(Convert.ToString(dataGridView2["Lastname_UA", e.RowIndex].Value)) &&
                    IsEng(Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value)) &&
                    IsUkr(Convert.ToString(dataGridView2["Firstname_UA", e.RowIndex].Value)) &&
                    IsEng(Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value)))
                {
                    // Меняем дизайн текущей строки из dataGridView2 на стандартный
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
                    e.Cancel = false;
                    dataGridView2.Rows[e.RowIndex].ErrorText = "";
                }
                else
                {
                    // Меняем дизайн текущей строки из dataGridView2 на красный
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                    // Текущая ячейка теперь в колонке "order"
                    if (!IsUkr(Convert.ToString(dataGridView2["Lastname_UA", e.RowIndex].Value)))
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["Lastname_UA"];
                        dataGridView2.BeginEdit(true);

                        dataGridView2.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView2.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки українського алфавіту";
                    }
                    else if (!IsEng(Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value)))
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["Lastname_EN"];
                        dataGridView2.BeginEdit(true);

                        dataGridView2.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView2.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки англійського алфавіту";
                    }
                    else if (!IsUkr(Convert.ToString(dataGridView2["Firstname_UA", e.RowIndex].Value)))
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["Firstname_UA"];
                        dataGridView2.BeginEdit(true);

                        dataGridView2.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView2.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки українського алфавіту";
                    }
                    else if (!IsEng(Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value)))
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells["Firstname_EN"];
                        dataGridView2.BeginEdit(true);
                        dataGridView2.Rows[e.RowIndex].ErrorText = "Комірка " + dataGridView2.CurrentCell.OwningColumn.HeaderText + " сприймає букви тільки англійського алфавіту";
                    }
                    e.Cancel = true;
                    tabControl1.SelectedIndex = 7;
                }
            }
        }

        static bool IsUkr(string text)
        {
            var newText = Regex.Replace(text, "[-.?!)(,:]", "");
            bool isUkr = true;
            Regex regex = new Regex("[^А-Яа-яёЁЇїІіЄєҐґ ]+$");
            if (regex.IsMatch(newText))
            {
                isUkr = false;
            }
            return isUkr;
        }

        static bool IsEng(string text)
        {
            var newText = Regex.Replace(text, "[-.?!)(,:]", "");
            bool isEn = true;
            Regex regex = new Regex("[^a-zA-Z ]+$");
            if (regex.IsMatch(newText))
            {
                isEn = false;
            }
            return isEn;
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToInt32(dataGridView2["ID_graduates", e.RowIndex].Value) > 0)
            {
                //try
                //{
                
                string upDate = "UPDATE graduates SET Lastname_UA=@Lastname_UA, Lastname_EN=@Lastname_EN,Firstname_UA=@Firstname_UA," +
                    " Firstname_EN=@Firstname_EN,birthday=@birthday, SerialDiploma=@SerialDiploma," +
                        "NumberDiploma=@NumberDiploma, NumberAddition=@NumberAddition,PrevDocument_UA=@PrevDocument_UA," +
                        " PrevDocument_EN=@PrevDocument_EN,prevSerialNumberAddition=@prevSerialNumberAddition," +
                        "TrainingStar=@TrainingStar,TrainingEnd=@TrainingEnd ,DurationOfTraining_UA=@DurationOfTraining_UA," +
                        "DurationOfTraining_EN=@DurationOfTraining_EN," +
                        "DecisionDate = DEFAULT, ProtNum = @ProtNum, QualificationAwardedUA = @QualificationAwardedUA," +
                        " QualificationAwardedEN = @QualificationAwardedUA, IssuedBy = @QualificationAwardedUA" +
                        " WHERE Graduat_ID=@Graduat_ID";
                    MySqlCommand command = new MySqlCommand(upDate, connection1);

                    command.Parameters.AddWithValue("Graduat_ID", Convert.ToInt32(dataGridView2["ID_graduates", e.RowIndex].Value));
                    command.Parameters.AddWithValue("Lastname_UA", Convert.ToString(dataGridView2["Lastname_UA", e.RowIndex].Value));
                    command.Parameters.AddWithValue("Lastname_EN", Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value));
                    command.Parameters.AddWithValue("Firstname_UA", Convert.ToString(dataGridView2[columnName: "Firstname_UA", rowIndex: e.RowIndex].Value));
                    command.Parameters.AddWithValue("Firstname_EN", Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value));
                    DateTime date;
                    if (dataGridView2["birthday", e.RowIndex].Value != null)
                    {
                        date = Convert.ToDateTime(dataGridView2["birthday", e.RowIndex].Value);
                    }
                    else
                    {
                        date = DateTime.Now;
                    }
                    command.Parameters.AddWithValue("birthday", date);
                    DateTime dateStart;
                    if (dataGridView2["TrainingStar", e.RowIndex].Value != null)
                    {
                        dateStart = Convert.ToDateTime(dataGridView2["TrainingStar", e.RowIndex].Value);
                    }
                    else
                    {
                        dateStart = DateTime.Now;
                    }

                    DateTime dateEnd;
                    if (dataGridView2["TrainingEnd", e.RowIndex].Value != null)
                    {
                        dateEnd = Convert.ToDateTime(dataGridView2["TrainingEnd", e.RowIndex].Value);
                    }
                    else
                    {
                        dateEnd = DateTime.Now;
                    }
                    DateTime DecisionDate;

                    if (dataGridView2["DecisionDate", e.RowIndex].Value != null)
                    {
                        DecisionDate = Convert.ToDateTime(dataGridView2["DecisionDate", e.RowIndex].Value);
                    }
                    else
                    {
                        DecisionDate = DateTime.Now;
                    }
                    command.Parameters.AddWithValue("DecisionDate", dateStart);
                    command.Parameters.AddWithValue("ProtNum", Convert.ToString(dataGridView2["ProtNum", e.RowIndex].Value));
                    command.Parameters.AddWithValue("QualificationAwardedUA", Convert.ToString(dataGridView2["QualificationAwardedUA", e.RowIndex].Value));
                    command.Parameters.AddWithValue("QualificationAwardedEN", Convert.ToString(dataGridView2["QualificationAwardedEN", e.RowIndex].Value));
                    command.Parameters.AddWithValue("IssuedBy", Convert.ToString(dataGridView2["IssuedBy", e.RowIndex].Value));
                    command.Parameters.AddWithValue("TrainingStar", dateStart);
                    command.Parameters.AddWithValue("TrainingEnd", dateEnd);
                    command.Parameters.AddWithValue("SerialDiploma", Convert.ToString(dataGridView2["SerialDiploma", e.RowIndex].Value));
                    command.Parameters.AddWithValue("NumberDiploma", Convert.ToString(dataGridView2["NumberDiploma", e.RowIndex].Value));
                    command.Parameters.AddWithValue("NumberAddition", Convert.ToString(dataGridView2["NumberAddition", e.RowIndex].Value));
                    command.Parameters.AddWithValue("PrevDocument_UA", Convert.ToString(dataGridView2["PrevDocument_UA", e.RowIndex].Value));
                    command.Parameters.AddWithValue("PrevDocument_EN", Convert.ToString(dataGridView2["PrevDocument_EN", e.RowIndex].Value));
                    command.Parameters.AddWithValue("prevSerialNumberAddition", Convert.ToString(dataGridView2["prevSerialNumberAddition", e.RowIndex].Value));
                    command.Parameters.AddWithValue("DurationOfTraining_UA", Convert.ToString(dataGridView2["DurationOfTraining_UA", e.RowIndex].Value));
                    command.Parameters.AddWithValue("DurationOfTraining_EN", Convert.ToString(dataGridView2["DurationOfTraining_EN", e.RowIndex].Value));


                    command.ExecuteNonQuery();
                    MessageBox.Show("Було змінено данні!");
                //}
                //catch (Exception help)
                //{
                //    MessageBox.Show(help.Message);
                //    //this.Close();
                //}

            }
            else
            {
               
                if ((!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Lastname_UA", e.RowIndex].Value)))
                    && (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value)))
                    && (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Firstname_UA", e.RowIndex].Value)))
                    && (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value)))
                    && (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["birthday", e.RowIndex].Value)))
                    )
                {
                    //try
                    //{
                        string ComandString = "INSERT INTO graduates (Qualification_ID,Lastname_UA,Lastname_EN,Firstname_UA,Firstname_EN,birthday,SerialDiploma,NumberDiploma," +
                                "NumberAddition,PrevDocument_UA,PrevDocument_EN,prevSerialNumberAddition,TrainingStar,TrainingEnd,DurationOfTraining_UA,DurationOfTraining_EN, " +
                                "DecisionDate, ProtNum, QualificationAwardedUA, QualificationAwardedEN, IssuedBy)" +
                                "VALUES(@Qualification_ID,@Lastname_UA,@Lastname_EN,@Firstname_UA," +
                                "@Firstname_EN,@birthday,@SerialDiploma,@NumberDiploma," +
                                "@NumberAddition,@PrevDocument_UA,@PrevDocument_EN,@prevSerialNumberAddition,@TrainingStar,@TrainingEnd,@DurationOfTraining_UA,@DurationOfTraining_EN," +
                                " @DecisionDate, @ProtNum, @QualificationAwardedUA, @QualificationAwardedEN, @IssuedBy)";
                    
                    MySqlCommand command = new MySqlCommand(ComandString, connection1);
                    
                    command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
                        command.Parameters.AddWithValue("Lastname_UA", Convert.ToString(dataGridView2["Lastname_UA", e.RowIndex].Value));
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("Lastname_EN", Convert.ToString(dataGridView2["Lastname_EN", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("Lastname_EN", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Firstname_UA", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("Firstname_UA", Convert.ToString(dataGridView2["Firstname_UA", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("Firstname_UA", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("Firstname_EN", Convert.ToString(dataGridView2["Firstname_EN", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("Firstname_EN", "");
                        DateTime date;
                        if (dataGridView2["birthday", e.RowIndex].Value != null)
                        {
                            date = Convert.ToDateTime(dataGridView2["birthday", e.RowIndex].Value);
                        }
                        else
                        {
                            date = DateTime.Now;
                        }

                        DateTime dateStart;
                        if (dataGridView2["TrainingStar", e.RowIndex].Value != null)
                        {
                            dateStart = Convert.ToDateTime(dataGridView2["TrainingStar", e.RowIndex].Value);
                        }
                        else
                        {
                            dateStart = DateTime.Now;
                        }

                        DateTime dateEnd;
                        if (dataGridView2["TrainingEnd", e.RowIndex].Value != null)
                        {
                            dateEnd = Convert.ToDateTime(dataGridView2["TrainingEnd", e.RowIndex].Value);
                        }
                        else
                        {
                            dateEnd = DateTime.Now;
                        }
                        command.Parameters.AddWithValue("birthday", date);//////
                        command.Parameters.AddWithValue("TrainingStar", dateStart);
                        command.Parameters.AddWithValue("TrainingEnd", dateEnd);
                        DateTime DecisionDate;

                        if (dataGridView2["DecisionDate", e.RowIndex].Value != null)
                        {
                            DecisionDate = Convert.ToDateTime(dataGridView2["DecisionDate", e.RowIndex].Value);
                        }
                        else
                        {
                            DecisionDate = DateTime.Now;
                        }
                        command.Parameters.AddWithValue("DecisionDate", dateStart);
                        if(!String.IsNullOrEmpty(Convert.ToString(dataGridView2["ProtNum", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("ProtNum", Convert.ToString(dataGridView2["ProtNum", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("ProtNum", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["QualificationAwardedUA", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("QualificationAwardedUA", Convert.ToString(dataGridView2["QualificationAwardedUA", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("QualificationAwardedUA", "");
                            if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["QualificationAwardedEN", e.RowIndex].Value)))
                                command.Parameters.AddWithValue("QualificationAwardedEN", Convert.ToString(dataGridView2["QualificationAwardedEN", e.RowIndex].Value));
                            else command.Parameters.AddWithValue("QualificationAwardedEN", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["IssuedBy", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("IssuedBy", Convert.ToString(dataGridView2["IssuedBy", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("IssuedBy", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["SerialDiploma", e.RowIndex].Value)))
                                command.Parameters.AddWithValue("SerialDiploma", Convert.ToString(dataGridView2["SerialDiploma", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("SerialDiploma", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["NumberDiploma", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("NumberDiploma", Convert.ToString(dataGridView2["NumberDiploma", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("NumberDiploma", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["NumberAddition", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("NumberAddition", Convert.ToString(dataGridView2["NumberAddition", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("NumberAddition", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["PrevDocument_UA", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("PrevDocument_UA", Convert.ToString(dataGridView2["PrevDocument_UA", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("PrevDocument_UA", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["PrevDocument_EN", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("PrevDocument_EN", Convert.ToString(dataGridView2["PrevDocument_EN", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("PrevDocument_EN", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["prevSerialNumberAddition", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("prevSerialNumberAddition", Convert.ToString(dataGridView2["prevSerialNumberAddition", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("prevSerialNumberAddition", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["prevSerialNumberAddition", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("DurationOfTraining_UA", Convert.ToString(dataGridView2["DurationOfTraining_UA", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("DurationOfTraining_UA", "");
                        if (!String.IsNullOrEmpty(Convert.ToString(dataGridView2["DurationOfTraining_EN", e.RowIndex].Value)))
                            command.Parameters.AddWithValue("DurationOfTraining_EN", Convert.ToString(dataGridView2["DurationOfTraining_EN", e.RowIndex].Value));
                        else command.Parameters.AddWithValue("DurationOfTraining_EN", "");

                        command.ExecuteNonQuery();

                        string StringComand2Id = "select max(Graduat_ID) from graduates";
                        MySqlCommand command2Id = new MySqlCommand(StringComand2Id, connection1);
                        MySqlDataReader reader = command2Id.ExecuteReader();
                        reader.Read();
                        int CUoNT = reader.GetInt32(0);
                        dataGridView2["ID_graduates", e.RowIndex].Value = CUoNT.ToString();
                        // MessageBox.Show(CUoNT.ToString());
                        if ((reader != null) || (!reader.IsClosed))
                            reader.Close();

                        MessageBox.Show("Було додано запис!");
                    //}
                    //catch (Exception help)
                    //{
                    //    MessageBox.Show(help.Message);
                    //    //this.Close();
                    //}

                }
                else
                {
                    if (dataGridView2.NewRowIndex != e.RowIndex)
                    {
                        MessageBox.Show("Введіть призвише, ім'я, ім'я по батькові та дату народження!");
                    }
                }
            }
        }


        private void dataGridView3_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dataGridView3["Discipline_ID", e.RowIndex].Value) > 0)
            {
               
                 if (String.IsNullOrEmpty(dataGridView3["Teaching", e.RowIndex].Value.ToString()))
                {
                dataGridView3["Teaching", e.RowIndex].Value = "1";
                }

                if (String.IsNullOrEmpty(dataGridView3["Differential", e.RowIndex].Value.ToString()))
                {
                dataGridView3["Differential", e.RowIndex].Value = "Оцiнка";
                }
                try
                {
                    string upDate = "UPDATE Discipline SET Course_title_UA=@Course_title_UA, Course_title_EN=@Course_title_EN, Loans=@Loans, Hours=@Hours,Teaching=@Teaching, Differential=@Differential WHERE Discipline_ID=@Discipline_ID";
                    MySqlCommand command2Discipline = new MySqlCommand(upDate, connection1);

                    command2Discipline.Parameters.AddWithValue("Discipline_ID", Convert.ToInt32(dataGridView3["Discipline_ID", e.RowIndex].Value));
                    command2Discipline.Parameters.AddWithValue("Course_title_UA", Convert.ToString(dataGridView3["Course_titel_UA", e.RowIndex].Value));
                    command2Discipline.Parameters.AddWithValue("Course_title_EN", Convert.ToString(dataGridView3["Course_titel_EN", e.RowIndex].Value));
                    command2Discipline.Parameters.AddWithValue("Loans", (
                        dataGridView3["Loans", e.RowIndex].Value.ToString().Replace(",",".")));
                    command2Discipline.Parameters.AddWithValue("Hours", (
                        dataGridView3["Hours", e.RowIndex].Value.ToString().Replace(",", ".") ));
                    command2Discipline.Parameters.AddWithValue("Teaching", Convert.ToString(dataGridView3["Teaching", e.RowIndex].Value));
                    command2Discipline.Parameters.AddWithValue("Differential", Convert.ToString(dataGridView3["Differential", e.RowIndex].Value));

                    command2Discipline.ExecuteNonQuery();
                    MessageBox.Show("Було змінено данні!");

                    float SumHours = 0;
                    float SumLoans = 0;
                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        float valh = float.Parse(dataGridView3["Hours", i].Value.ToString());
                        SumHours += valh;
                        float val = float.Parse(dataGridView3["Loans", i].Value.ToString());
                        SumLoans += val;
                    }
                    label26.Text = SumLoans.ToString();
                    label27.Text = SumHours.ToString();

                }
                catch (Exception help)
                {
                    MessageBox.Show(help.Message);
                    //this.Close();
                }

            }
            else
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dataGridView3["Course_titel_UA", e.RowIndex].Value)))
                {
                    try
                    {
                        
                        string upDate = "INSERT INTO Discipline (Qualification_ID, Course_title_UA, Course_title_EN, Loans, Hours, Teaching, Differential) VALUES (@Qualification_ID, @Course_title_UA, @Course_title_EN, @Loans, @Hours, @Teaching, @Differential)";
                        MySqlCommand command2Discipline = new MySqlCommand(upDate, connection1);

                        command2Discipline.Parameters.AddWithValue("Qualification_ID", ID);
                        command2Discipline.Parameters.AddWithValue("Course_title_UA", Convert.ToString(dataGridView3["Course_titel_UA", e.RowIndex].Value));
                        command2Discipline.Parameters.AddWithValue("Course_title_EN", Convert.ToString(dataGridView3["Course_titel_EN", e.RowIndex].Value));
                        command2Discipline.Parameters.AddWithValue("Loans", (
                        dataGridView3["Loans", e.RowIndex].Value.ToString().Replace(",", ".")));
                        command2Discipline.Parameters.AddWithValue("Hours", (
                            dataGridView3["Hours", e.RowIndex].Value.ToString().Replace(",", ".")));
                        if (String.IsNullOrEmpty(Convert.ToString(dataGridView3["Teaching", e.RowIndex].Value)))
                        {
                            dataGridView3["Teaching", e.RowIndex].Value = 1;
                        }
                        command2Discipline.Parameters.AddWithValue("Teaching", Convert.ToString(dataGridView3["Teaching", e.RowIndex].Value));
                        if (String.IsNullOrEmpty(Convert.ToString(dataGridView3["Differential", e.RowIndex].Value)))
                        {
                            dataGridView3["Differential", e.RowIndex].Value = 0;
                        }
                        command2Discipline.Parameters.AddWithValue("Differential", Convert.ToString(dataGridView3["Differential", e.RowIndex].Value
));


                        command2Discipline.ExecuteNonQuery();
                       
                        string StringComand2Id = "select max(Discipline_ID) from Discipline";
                        MySqlCommand command2Id = new MySqlCommand(StringComand2Id, connection1);
                        MySqlDataReader reader = command2Id.ExecuteReader();
                        reader.Read();
                        int CUoNT = reader.GetInt32(0);
                        dataGridView3["Discipline_ID", e.RowIndex].Value = CUoNT.ToString();

                        if ((reader != null) || (!reader.IsClosed))
                            reader.Close();

                        MessageBox.Show("Було додано запис!");
                    }
                    catch (Exception help)
                    {
                        MessageBox.Show(help.Message);
                        //this.Close();
                    }
                    float SumHours = 0;
                    float SumLoans = 0;
                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        float valh = float.Parse(dataGridView3["Hours", i].Value.ToString());
                        SumHours += valh;
                        float val = float.Parse(dataGridView3["Loans", i].Value.ToString());
                        SumLoans += val;
                    }
                    label26.Text = SumLoans.ToString();
                    label27.Text = SumHours.ToString();

                }
                else
                {
                    if (dataGridView2.NewRowIndex != e.RowIndex)
                    {
                        MessageBox.Show("Введіть назву!");
                    }
                }
            }
            ShowEstimatea();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (button1.Enabled)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Дані не було збережено");
            }
            if(button2.Enabled)
            {
                tabControl1.SelectedIndex = 1;
                MessageBox.Show("Дані не було збережено");
            }
            if (button16.Enabled)
            {
                tabControl1.SelectedIndex = 2;
                MessageBox.Show("Дані не було збережено");
            }
            if (button5.Enabled)
            {
                tabControl1.SelectedIndex = 3;
                MessageBox.Show("Дані не було збережено");
            }
            if (button22.Enabled)
            {
                tabControl1.SelectedIndex = 4;
                MessageBox.Show("Дані не було збережено");
            }
            if (button9.Enabled)
            {
                tabControl1.SelectedIndex = 5;
                MessageBox.Show("Дані не було збережено");
            }
            if (button12.Enabled)
            {
                tabControl1.SelectedIndex = 6;
                MessageBox.Show("Дані не було збережено");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            string message = "Ви бажаєте видалити дану кваліфікацію і всі зв'язані з нею записи?";
            string caption = "Видалення";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string ShowEstimates = "SELECT  Discipline.Discipline_ID FROM  Discipline  WHERE Discipline.Qualification_ID =" + ID.ToString();
                MySqlCommand commandList1 = new MySqlCommand(ShowEstimates, connection1);

                MySqlDataReader reader = commandList1.ExecuteReader();

                while (reader.Read())
                {
                    string Estimates = "DELETE*   FROM Estimates WHERE Estimates.Disciptine_ID = " + reader["Discipline_ID"].ToString();
                    MySqlCommand command = new MySqlCommand(Estimates, connection1);
                    command.ExecuteNonQuery();

                }

                reader.Close();

                string Discipline = "DELETE FROM  Discipline  WHERE Discipline.Qualification_ID =" + ID.ToString();
                MySqlCommand Disciplinecommand = new MySqlCommand(Discipline, connection1);
                Disciplinecommand.ExecuteNonQuery();

                string graduates = "DELETE FROM  graduates  WHERE graduates.Qualification_ID =" + ID.ToString();
                MySqlCommand graduatesCommand = new MySqlCommand(graduates, connection1);
                graduatesCommand.ExecuteNonQuery();

                string Contents_and_results = "DELETE FROM  Contents_and_results  WHERE Contents_and_results.Qualification_ID =" + ID.ToString();
                MySqlCommand Contents_and_resultsCommand = new MySqlCommand(Contents_and_results, connection1);
                Contents_and_resultsCommand.ExecuteNonQuery();

                string National_framework = "DELETE FROM  National_framework  WHERE National_framework.Qualification_ID =" + ID.ToString();
                MySqlCommand National_frameworkCommand = new MySqlCommand(National_framework, connection1);
                National_frameworkCommand.ExecuteNonQuery();


                string Qualification = "DELETE FROM  Qualification  WHERE Qualification.Qualification_ID =" + ID.ToString();
                MySqlCommand QualificationCommand = new MySqlCommand(Qualification, connection1);
                QualificationCommand.ExecuteNonQuery();

                MessageBox.Show("Дані було видалено!");

                //this.Close();

            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void SEARCH_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection1 != null && connection1.State != System.Data.ConnectionState.Closed)
            {
                connection1.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void dataGridView3_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Differential"].Value="Оцінка";
            e.Row.Cells["Teaching"].Value ="1";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (maskedTextBox.Visible)
            //{
               
            //            DateTime Date;

            //   if (DateTime.TryParse(maskedTextBox.Text, out Date))
            //   {
            //        if (!String.IsNullOrEmpty(dataGridView2.CurrentCell.Value.ToString()))
            //        { dataGridView2.CurrentCell.Value = ""; }
            //         dataGridView2.CurrentCell.Value = Date.ToString("d.M.yyyy", CultureInfo.InvariantCulture);

            //   }
            //            else
            //            {
            //                //dataGridView2.CurrentCell.Value = maskedTextBox.Text;
            //                MessageBox.Show("Дані не вдалося конвертувати в дату");
            //            }
                    
            //        maskedTextBox.Visible = false;
            //}
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.Text == "5606")
            {
                button13.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string upDate = "UPDATE Qualification SET " +
                "FirstSpecialty_UA=@FirstSpecialty_UA," +
                "FirstSpecialty_EN=@FirstSpecialty_EN," +
                "SecondSpecialty_UA=@SecondSpecialty_UA," +
                "SecondSpecialty_EN=@SecondSpecialty_EN," +
                "Specialization_UA=@Specialization_UA," +
                "Specialization_EN=@Specialization_EN" +
                "  WHERE Qualification.Qualification_ID=@Qualification_ID";
            MySqlCommand command = new MySqlCommand(upDate, connection1);

            command.Parameters.AddWithValue("Qualification_ID", ID.ToString());
            command.Parameters.AddWithValue("FirstSpecialty_UA", textBox35.Text);
            command.Parameters.AddWithValue("FirstSpecialty_EN", textBox34.Text);
            command.Parameters.AddWithValue("SecondSpecialty_UA", textBox30.Text);
            command.Parameters.AddWithValue("SecondSpecialty_EN", textBox29.Text);
            command.Parameters.AddWithValue("Specialization_UA", textBox32.Text);
            command.Parameters.AddWithValue("Specialization_EN", textBox31.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Було змінено данні!");
            button2.Enabled = false;
        }

        
    }

}
