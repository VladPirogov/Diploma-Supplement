using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class і : Form
    {
        public string StringConnection { get; set; }
        public string Name { get; set; }
        public string Dif { get; set; }
        public int ID { get; set; }
        public int IDq { get; set; }
        public bool Can = true;
        public MySqlConnection connection1;
        public і()
        {
            InitializeComponent();
            
        }

        private    void EstimatesForDicip_Load  (object sender, EventArgs e)
        {
            this.Text = Name;
            connection1 = new MySqlConnection(StringConnection);
               connection1.Open  ();
            string charsetQuerySEr = "character_set_server = utf8";
            MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

            string charsetQuery = "SET NAMES utf8";
            MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);

            //string ShowEstimates = "SELECT   estimates.Estimat_NUM,  estimates.Estimat_CHAR,  estimates.Estimat_UA," +
            //    "  estimates.Estimat_ID,   graduates.Lastname_UA,  graduates.Graduat_ID" +
            //    " FROM estimates INNER JOIN graduates ON estimates.Graduat_ID = graduates.Graduat_ID" +
            //    " INNER JOIN discipline ON estimates.Disciptine_ID = discipline.Discipline_ID" +
            //    " WHERE discipline.Discipline_ID =" + ID.ToString();
            //MySqlCommand commandList1 = new MySqlCommand(ShowEstimates, connection1);
            //MySqlDataReader reader =commandList1.ExecuteReader();


            //while (   reader.Read())
            //{

            //    dataGridView1.Rows.Add(reader["Graduat_ID"].ToString(), reader["Lastname_UA"].ToString(),
            //        reader["Estimat_NUM"].ToString(), reader["Estimat_CHAR"].ToString(), 
            //        reader["Estimat_UA"].ToString(), reader["Estimat_ID"].ToString());

            //}

            //reader.Close();
            string ShowEstimates = "SELECT graduates.Lastname_UA,  graduates.Graduat_ID FROM  graduates  WHERE graduates.Qualification_ID =" + IDq.ToString();
            MySqlCommand commandList1 = new MySqlCommand(ShowEstimates, connection1);
            MySqlDataReader reader = commandList1.ExecuteReader();


            while (reader.Read())
            {

                dataGridView1.Rows.Add(reader["Graduat_ID"].ToString(), reader["Lastname_UA"].ToString());

            }

            reader.Close();

           
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //try
                //{
                    ShowEstimates = "SELECT Estimates.Estimat_ID,Estimates.Estimat_NUM, Estimates.Estimat_UA, Estimates.Estimat_CHAR  FROM  Estimates  WHERE  Estimates.Graduat_ID = " 
                        + Convert.ToString(dataGridView1["Graduat_ID", i].Value) 
                        + " AND Estimates.Disciptine_ID = " + ID.ToString();
                    MySqlCommand commandList = new MySqlCommand(ShowEstimates, connection1);
                    MySqlDataReader reader2 =    commandList.ExecuteReader  ();
                       reader2.Read  ();
                try
                {
                    dataGridView1["Estimat_ID", i].Value = reader2["Estimat_ID"].ToString();
                        dataGridView1["Estimat_NUM", i].Value = reader2["Estimat_NUM"].ToString();
                        dataGridView1["Estimat_UA", i].Value = reader2["Estimat_UA"].ToString();
                        dataGridView1["Estimat_CHAR", i].Value = reader2["Estimat_CHAR"].ToString();

                }
                catch
                {
                    dataGridView1["Estimat_ID", i].Value = "";
                    dataGridView1["Estimat_NUM", i].Value = "0";
                    dataGridView1["Estimat_CHAR", i].Value = "F";
                    if (Dif == "Оцінка")
                    {
                        dataGridView1["Estimat_UA", i].Value = "Незадовільно / Fail";
                    }
                    else
                    {
                        dataGridView1["Estimat_UA", i].Value = "Не зараховано / Fail";
                    }
                }
                reader2.Close();
                

            }
            dataGridView1.AllowUserToAddRows = false;

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.NewRowIndex != e.RowIndex)
            {
                try
                {
                    // Получаем название заказа текущей строки из dataGridView3
                    int val = Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value);

                    // Если название заказа не пустое, значит валидация прошла успешно
                    if ((val >= 0) && (val <= 100))
                    {
                        // Меняем дизайн текущей строки из dataGridView2 на стандартный
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
                        e.Cancel = false;
                        dataGridView1.Rows[e.RowIndex].ErrorText = "";
                    }
                    else
                    {
                        // Меняем дизайн текущей строки из dataGridView2 на красный
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                        // Текущая ячейка теперь в колонке "order"
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Estimat_NUM"];

                        // Включаем редактирование ячейки
                        dataGridView1.BeginEdit(true);

                        // Валидация строки прошла неудачей
                        e.Cancel = true;
                        if (val < 0) dataGridView1.Rows[e.RowIndex].ErrorText = "Число повино бути не менше нуля";
                        else dataGridView1.Rows[e.RowIndex].ErrorText = "Число повино бути не більше ста";

                    }

                }
                catch
                {
                    // Меняем дизайн текущей строки из dataGridView2 на красный
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;

                    // Текущая ячейка теперь в колонке "order"
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Estimat_NUM"];

                    // Включаем редактирование ячейки
                    dataGridView1.BeginEdit(true);

                    // Валидация строки прошла неудачей
                    e.Cancel = true;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Введіть число";
                }
            }
        }

        private    void dataGridView1_CellValidated  (object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

                int x = Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value);
                if (x > 0)
                {
                    string TiPAint = Dif;
                    string String_UA = " ";
                    string String_CHAR = " ";
                    if (x <= 100 && x >= 90)
                    {
                        if (TiPAint == "Оцінка") String_UA = "Відмінно / Excellent";
                        else String_UA = "Зараховано / Passed";
                        String_CHAR = "A";
                    }
                    else if (x <= 89 && x >= 71)
                    {
                        if (TiPAint == "Оцінка") String_UA = "Добре / Good";
                        else String_UA = "Зараховано / Passed";
                        if (x <= 89 && x >= 80) String_CHAR = "B";
                        if (x <= 79 && x >= 71) String_CHAR = "C";
                    }
                    else if (x <= 70 && x >= 50)
                    {
                        if (TiPAint == "Оцінка") String_UA = "Задовільно / Satisfactory";
                        else String_UA = "Зараховано / Passed";
                        if (x <= 70 && x >= 61) String_CHAR = "D";
                        if (x <= 60 && x >= 50) String_CHAR = "E";
                    }
                    else
                    {
                        String_CHAR = "F";
                        if (TiPAint == "Оцінка") String_UA = "Незадовільно / Fail";
                        else String_UA = "Не зараховано / Fail";
                    }

                    dataGridView1["Estimat_UA", e.RowIndex].Value = String_UA;
                    dataGridView1["Estimat_CHAR", e.RowIndex].Value = String_CHAR;

                    if (dataGridView1["Estimat_ID", e.RowIndex].Value != "")
                    {

                        string upDate = "UPDATE Estimates SET Estimat_NUM=@Estimat_NUM, Estimat_CHAR=@Estimat_CHAR," +
                        "Estimat_UA=@Estimat_UA WHERE Estimat_ID=@Estimat_ID";
                        MySqlCommand command2Estimates = new MySqlCommand(upDate, connection1);

                        command2Estimates.Parameters.AddWithValue("Estimat_ID", Convert.ToInt32(dataGridView1["Estimat_ID", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_NUM", Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_CHAR", Convert.ToString(dataGridView1["Estimat_CHAR", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_UA", Convert.ToString(dataGridView1["Estimat_UA", e.RowIndex].Value));

                           command2Estimates.ExecuteNonQuery();
                        MessageBox.Show("Було змінено данні!");
                    }
                    else
                    {

                        string INSERT = "INSERT INTO Estimates (Graduat_ID,Disciptine_ID,Estimat_NUM,Estimat_CHAR,Estimat_UA) VALUES (@Graduat_ID,@Disciptine_ID,@Estimat_NUM,@Estimat_CHAR,@Estimat_UA)";
                        MySqlCommand command2Estimates = new MySqlCommand(INSERT, connection1);

                        command2Estimates.Parameters.AddWithValue("Graduat_ID", Convert.ToString(dataGridView1["Graduat_ID", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Disciptine_ID", ID);
                        command2Estimates.Parameters.AddWithValue("Estimat_NUM", Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_CHAR", Convert.ToString(dataGridView1["Estimat_CHAR", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_UA", Convert.ToString(dataGridView1["Estimat_UA", e.RowIndex].Value));

                           command2Estimates.ExecuteNonQuery  ();

                        string StringComand2Id = "select max(Estimat_ID) from Estimates";
                        MySqlCommand command2Id = new MySqlCommand(StringComand2Id, connection1);
                        MySqlDataReader reader =    command2Id.ExecuteReader  ();
                           reader.Read  ();
                        int CUoNT = reader.GetInt32(0);

                        dataGridView1["Estimat_ID", e.RowIndex].Value = CUoNT.ToString();
                        reader.Close();


                        MessageBox.Show("Було створено запис!");
                    }
                }
            //}
            //catch(Exception exs)
            //{
            //    MessageBox.Show(exs.Message);
            //}
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Can = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Can = true;
        }

        private void і_FormClosed(object sender, FormClosedEventArgs e)
        {
           if (connection1 != null && connection1.State != System.Data.ConnectionState.Closed)
            {
                connection1.Close();
            }
        }

        private void і_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Can)
            {
                string message = "У Вас є не збережені дані, чи бажаєте ви залишитись у цьому вікні и зберегти їх?";
                string caption = "Попередження!!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes) { e.Cancel = true; }

            }
        }
    }
}
