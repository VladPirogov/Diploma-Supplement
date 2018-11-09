using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class IFnotOnes : Form
    {
        public string StringConnection { get; set; }
        //public string ForSEARCH { get; set; }
        MySqlConnection connection1 ;
        public IFnotOnes()
        {
            InitializeComponent();
        }
        
        private    void IFnotOnes_Load  (object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "database2DataSet.Qualification". При необходимости она может быть перемещена или удалена.
                //MessageBox.Show(this.ForSEARCH);

                //string dbLocation = System.IO.Path.GetFullPath("Database2.mdf");
                //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbLocation + ";Integrated Security=True";

                //connection1 = new MySqlConnection(connectionString);

                connection1 = new MySqlConnection(StringConnection);
                connection1.Open();
                string charsetQuerySEr = "character_set_server = utf8";
                MySqlCommand commandSESER = new MySqlCommand(charsetQuerySEr, connection1);

                string charsetQuery = "SET NAMES utf8";
                MySqlCommand commandSET = new MySqlCommand(charsetQuery, connection1);
                string ComandSQL = "SELECT Qualification.*   FROM Qualification";

                MySqlCommand command = new MySqlCommand(ComandSQL, connection1);
                MySqlDataReader reader = command.ExecuteReader();
                dataGridView1.Columns.Add("Qualification_ID", "Номер кваліфікації в базі");
                dataGridView1.Columns.Add("Date", "Дата створення");
                dataGridView1.Columns.Add("BX", "Навігація");
                dataGridView1.Columns.Add("Degree", "Ступінь");
                dataGridView1.Columns.Add("Qualification_UA", "Кваліфікація");
                dataGridView1.Columns.Add("Qualification_EN", "Qualification");
                dataGridView1.Columns.Add("Main_field_study_UA", "Основний(і) напрям(и)підготовки за кваліфікацією");
                dataGridView1.Columns.Add("Main_field_study_EN", "Main field(s) of study for the qualification");

                while (reader.Read())
                {
                    //DateTime time = Convert.ToDateTime(reader["Date"].ToString());
                    dataGridView1.Rows.Add(reader["Qualification_ID"].ToString(), reader["Date"].ToString(), reader["BX"].ToString(),
                        reader["Degree"].ToString(), reader["Qualification_UA"].ToString(), reader["Qualification_EN"].ToString(), 
                        reader["Main_field_study_UA"].ToString(), reader["Main_field_study_EN"].ToString());
                }





                reader.Close();


                connection1.Close();
            }
            catch { MessageBox.Show("Поки що не існує баз даних"); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            SEARCH Search = new SEARCH();
            int p = System.Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
            Search.ID = p;
            Search.StringConnection = StringConnection;
            this.Visible = false;
            Search.ShowDialog();
            this.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void IFnotOnes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection1 != null && connection1.State != ConnectionState.Closed)
            {
                connection1.Close();
            }
        }
    }
}
