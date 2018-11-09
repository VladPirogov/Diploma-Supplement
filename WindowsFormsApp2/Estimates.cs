using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Estimates : Form
    {
        public string StringConnection { get; set; }
        public int ID { get; set; }
        public int IDq { get; set; }
        public bool Can = true;
        public MySqlConnection connection1;
        public Estimates()
        {
            InitializeComponent();
        }
        
       
        private    void Estimates_Load  (object sender, EventArgs e)
        {
            connection1 = new MySqlConnection(StringConnection);
            connection1.Open();
            string charsetQuerySEr = "character_set_server = utf8";
            MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

            string charsetQuery = "SET NAMES utf8";
            MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);
            Showtoo();
            //dataGridView1.RowValidating += new DataGridViewCellCancelEventHandler (dataGridView1_RowValidating);
        }
        private void Showtoo()
        {
            string ShowEstimates = "SELECT Discipline.Course_title_UA,  " +
                "Discipline.Discipline_ID,Discipline.Differential " +
                "FROM  Discipline " +
                " WHERE Discipline.Qualification_ID =" + IDq.ToString();
            MySqlCommand commandList1 = new MySqlCommand(ShowEstimates, connection1);
            MySqlDataReader reader = commandList1.ExecuteReader();


            while (reader.Read())
            {

                dataGridView1.Rows.Add(reader["Discipline_ID"].ToString(), reader["Differential"].ToString(), reader["Course_title_UA"].ToString());
                


            }

            reader.Close();

            ////dataGridView1.Visible = true;
            //string ShowEstimates = "SELECT estimates.Estimat_NUM," +
            //    " estimates.Estimat_CHAR," +
            //    "estimates.Estimat_UA, " +
            //    "estimates.Estimat_ID, " +
            //    "discipline.Discipline_ID, " +
            //    "discipline.Course_title_UA, " +
            //    "discipline.Differential " +
            //    "FROM estimates INNER JOIN graduates ON " +
            //    " estimates.Graduat_ID = graduates.Graduat_ID " +
            //    "INNER JOIN discipline ON " +
            //    "estimates.Disciptine_ID = discipline.Discipline_ID " +
            //    "WHERE graduates.Graduat_ID=" + ID.ToString();
            //MySqlCommand commandList1 = new MySqlCommand(ShowEstimates, connection1);
            //MySqlDataReader reader =   commandList1.ExecuteReader();


            //while (  reader.Read())
            //{

            //    dataGridView1.Rows.Add(reader["Discipline_ID"].ToString(), reader["Differential"].ToString(), 
            //        reader["Course_title_UA"].ToString(), reader["Estimat_NUM"].ToString(), reader["Estimat_CHAR"].ToString(),
            //        reader["Estimat_UA"].ToString(), reader["Estimat_ID"].ToString());

            //}

            //reader.Close();

            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {

                //try
                //{
                ShowEstimates = "SELECT  estimates.*" +
                "FROM estimates WHERE  estimates.Graduat_ID = " + ID.ToString() +
                " AND estimates.Disciptine_ID = " + Convert.ToString(dataGridView1["Discipline_ID", i].Value);
                MySqlCommand commandList = new MySqlCommand(ShowEstimates, connection1);
                MySqlDataReader reader2 = commandList.ExecuteReader();
                reader2.Read();
                if (reader2 != null)
                {
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
                        if (Convert.ToString(dataGridView1["Differential", i].Value) == "Оцінка")
                        {
                            dataGridView1["Estimat_UA", i].Value = "Незадовільно / Fail";
                        }
                        else
                        {
                            dataGridView1["Estimat_UA", i].Value = "Не зараховано / Fail";
                        }
                    }


                }
                reader2.Close();
                //}


            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private    void dataGridView1_CellEndEdit  (object sender, DataGridViewCellEventArgs e)
        {

            //try
            //{
                
                int x = Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value);
                if (x > 0)
                {
                    string TiPAint = Convert.ToString(dataGridView1["Differential", e.RowIndex].Value);
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

                        string upDate = "UPDATE Estimates SET Estimat_NUM=@Estimat_NUM, Estimat_CHAR=@Estimat_CHAR,Estimat_UA=@Estimat_UA WHERE Estimat_ID=@Estimat_ID";
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

                        command2Estimates.Parameters.AddWithValue("Graduat_ID", ID);
                        command2Estimates.Parameters.AddWithValue("Disciptine_ID", Convert.ToString(dataGridView1["Discipline_ID", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_NUM", Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_CHAR", Convert.ToString(dataGridView1["Estimat_CHAR", e.RowIndex].Value));
                        command2Estimates.Parameters.AddWithValue("Estimat_UA", Convert.ToString(dataGridView1["Estimat_UA", e.RowIndex].Value));

                          command2Estimates.ExecuteNonQuery();

                        string StringComand2Id = "select max(Estimat_ID) from Estimates";
                        MySqlCommand command2Id = new MySqlCommand(StringComand2Id, connection1);
                        MySqlDataReader reader =   command2Id.ExecuteReader();
                          reader.Read();
                        int CUoNT = reader.GetInt32(0);
                    reader.Close();
                    dataGridView1["Estimat_ID", e.RowIndex].Value = CUoNT.ToString();



                        MessageBox.Show("Було створено запис!");
                    }
                }
            //}
            //catch { }
            Can = true;
        }

        private    void dataGridView1_CellContentClick  (object sender, DataGridViewCellEventArgs e)
        {
            
           string STr = null;
           try
           {
               STr = dataGridView1["Estimat_ID", e.RowIndex].Value.ToString();
           }
           catch
           {
               STr = null;
           }
           if (!String.IsNullOrEmpty(STr))
           {
               string deletStart = "DELETE FROM Estimates WHERE Estimat_ID=" + STr ;
               MySqlCommand command = new MySqlCommand(deletStart, connection1);
                 command.ExecuteNonQuery();

               dataGridView1["Estimat_NUM", e.RowIndex].Value = "0";
               dataGridView1["Estimat_CHAR", e.RowIndex].Value = "F";
               if (Convert.ToString(dataGridView1["Differential", e.RowIndex].Value) == "0")
               {
                   dataGridView1["Estimat_UA", e.RowIndex].Value = "Незадовільно / Fail";
               }
               else
               {
                     dataGridView1["Estimat_UA", e.RowIndex].Value = "Не зараховано / Fail";
               }
           }
                
        }

        


        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.NewRowIndex != e.RowIndex)
            {
                try
                {
                    // Получаем название заказа текущей строки из dataGridView3
                    int val = Convert.ToInt32(dataGridView1["Estimat_NUM", e.RowIndex].Value);

                    // Если название заказа не пустое, значит валидация прошла успешно
                    if ((val >= 0)&&(val <= 100))
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
                        if(val < 0)dataGridView1.Rows[e.RowIndex].ErrorText = "Число повино бути не менше нуля";
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

        private void Estimates_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Can = false;
        }

        private void Estimates_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection1 != null && connection1.State != System.Data.ConnectionState.Closed)
            {
                connection1.Close();
            }
        }
    }
}
