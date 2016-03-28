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
        DataSet ds;
        SQLiteConnection m_dbConnection;
        bool textDirty = false;
        long lastId = -1;
        bool doingRefresh = false;
        bool click1 = false;
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
                bool databaseExists = System.IO.File.Exists(filename);
                m_dbConnection = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
                m_dbConnection.Open();

                if (!databaseExists)
                {
                    string sql3 = "CREATE TABLE notes (id integer primary key, name varchar(30), note varchar(1000))";
                    SQLiteCommand command3 = new SQLiteCommand(sql3, m_dbConnection);
                    command3.ExecuteNonQuery();

                    string sql4 = "INSERT INTO notes (id, name, note) VALUES (NULL, 'a', 'abc'), (NULL, 'b', 'abcd')";
                    SQLiteCommand command4 = new SQLiteCommand(sql4, m_dbConnection);
                    command4.ExecuteNonQuery();
                }

                refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void refresh()
        {
            doingRefresh = true;
            ds = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM notes", m_dbConnection);
            adapter.Fill(ds);
            this.listBox1.DataSource = ds.Tables[0];
            this.listBox1.DisplayMember = "name";
            doingRefresh = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doingRefresh)
                return;
            try
            {
                if (textDirty && click1 == false)
                {
                    DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SQLiteCommand command = new SQLiteCommand();
                        command.CommandText = "UPDATE notes SET name='" + textBox2.Text + "', note='" + textBox1.Text + "' WHERE id=" + lastId;
                        command.Connection = m_dbConnection;
                        command.ExecuteNonQuery();

                        refresh();     

                        MessageBox.Show("Сохранено");
                    }
                }
            
                textBox1.Text = ds.Tables[0].Rows[listBox1.SelectedIndex].Field<string>("note");
                textBox2.Text = ds.Tables[0].Rows[listBox1.SelectedIndex].Field<string>("name");
                label1.Text = ds.Tables[0].Rows[listBox1.SelectedIndex].Field<long>("id").ToString();
                click1 = false;
                textDirty = false;
                lastId = ds.Tables[0].Rows[listBox1.SelectedIndex].Field<long>("id");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "UPDATE notes SET name='" + textBox2.Text + "', note='" + textBox1.Text + "' WHERE id=" + ds.Tables[0].Rows[listBox1.SelectedIndex].Field<long>("id");
                command.Connection = m_dbConnection;
                command.ExecuteNonQuery();
                click1 = true;
                refresh();
                
                MessageBox.Show("Сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textDirty = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textDirty = true;
        }
    }
}
