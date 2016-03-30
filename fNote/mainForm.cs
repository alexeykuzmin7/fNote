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
        
        public mainForm()
        {
            InitializeComponent();
            
        }

        private void baseCreate_Click(object sender, EventArgs e)
        {
            new createBaseform().Show();
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

        public void refresh()
        {
            doingRefresh = true;
            ds = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM notes", m_dbConnection);
            adapter.Fill(ds);
            this.baseElements.DataSource = ds.Tables[0];
            this.baseElements.DisplayMember = "name";
            doingRefresh = false;
        }

        private void baseElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doingRefresh)
                return;
            try
            {
                if (textDirty)
                {
                    DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        save();
                    }
                }
            
                bENote.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("note");
                bEName.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("name");
                bEId.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<long>("id").ToString();
                textDirty = false;
                lastId = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<long>("id");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void save()
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "UPDATE notes SET name='" + bEName.Text + "', note='" + bENote.Text + "' WHERE id=" + lastId;
            command.Connection = m_dbConnection;
            command.ExecuteNonQuery();

            refresh();     

            MessageBox.Show("Сохранено");
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            save();
        }

        private void bENote_TextChanged(object sender, EventArgs e)
        {
            textDirty = true;
        }

        private void bEName_TextChanged(object sender, EventArgs e)
        {
            textDirty = true;
        }

        private void addElement_Click(object sender, EventArgs e)
        {
            new addItem(this).Show();
        }

        private void deleteElement_Click(object sender, EventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "DELETE FROM notes WHERE name=" + ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("name");
            command.Connection = m_dbConnection;
            command.ExecuteNonQuery();

            refresh();

            MessageBox.Show("Удалено");
        }
    }
}
