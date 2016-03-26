using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fNote
{ 
    public partial class mainForm: Form
    {

        string baseName = "mybase";
        public mainForm()
        {
            InitializeComponent();
        }

        private void baseCreate_Click(object sender, EventArgs e)
        {
            new createBaseform().Show();
            //string databaseName = "newbase.db";
            //SQLiteConnection.CreateFile(databaseName);
            //Console.WriteLine(File.Exists(databaseName) ? "База данных создана" : "Возникла ошиюка при создании базы данных");
            //Console.ReadKey(true);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string filename = "E:\\_Programing\\Projects\\fNote\\fNote\\bin\\Debug\\bases\\" + baseName + ".db";
                if (!System.IO.File.Exists(filename))
                {
                    SQLiteConnection m_dbConnection2;
                    m_dbConnection2 = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
                    m_dbConnection2.Open();
                    string sql3 = "CREATE TABLE notes (id int, name varchar(30), note varchar(1000))";
                    SQLiteCommand command3 = new SQLiteCommand(sql3, m_dbConnection2);
                    command3.ExecuteNonQuery();

                    string sql4 = "INSERT INTO notes (id, name, note) VALUES (1, 'a', 'abc')";
                    SQLiteCommand command4 = new SQLiteCommand(sql4, m_dbConnection2);
                    command4.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("База с таким названием уже ссуществует");
                }
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source="+filename+"; Version=3;");
                m_dbConnection.Open();

                DataSet ds = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT name FROM notes", m_dbConnection);
                adapter.Fill(ds);
                this.listBox1.DataSource = ds.Tables[0];
                this.listBox1.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
