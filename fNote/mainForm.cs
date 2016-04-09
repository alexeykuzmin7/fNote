using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;

namespace fNote
{ 
    public partial class mainForm: Form
    {
        //string baseName = "mybase";
        DataSet ds;
        public SQLiteConnection m_dbConnection;
        bool textDirty = false;
        long lastId = -1;
        bool doingRefresh = false;
        bool doingFilter = false;
        int checkSelect = -1;
        public bool connectionOpened = false;
        System.IO.StreamReader sr;
        int checkStatus = 0;
        string date = "";
        string time = "";
        
        public mainForm()
        {
            InitializeComponent();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void baseCreate_Click(object sender, EventArgs e)
        {
            new createBase(this).Show();
        }
        //public bool IsDirectoryEmpty(string path)
        //{
        //    return !Directory.EnumerateFileSystemEntries(path).Any();
        //}

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["firstLaunch"] == "true")
            {
                MessageBox.Show("Вы запустили программу в первый раз. Создайте файл(базу) для хранения заметок");
                new createBase(this).Show();
                ConfigurationManager.AppSettings["firstLaunch"] = "false";
            }
            //try
            //{
            //    string filename = "E:\\_Programing\\Projects\\fNote\\fNote\\bin\\Debug\\bases\\" + baseName + ".db";
            //    bool databaseExists = System.IO.File.Exists(filename);
            //    m_dbConnection = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
            //    m_dbConnection.Open();

            //    if (!databaseExists)
            //    {
            //        string sql3 = "CREATE TABLE notes (id integer primary key, name varchar(30), note varchar(1000))";
            //        SQLiteCommand command3 = new SQLiteCommand(sql3, m_dbConnection);
            //        command3.ExecuteNonQuery();

            //        string sql4 = "INSERT INTO notes (id, name, note) VALUES (NULL, 'a', 'abc'), (NULL, 'b', 'abcd')";
            //        SQLiteCommand command4 = new SQLiteCommand(sql4, m_dbConnection);
            //        command4.ExecuteNonQuery();
            //    }

                

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error" + ex);
            //}
            refresh();
        }

        public void refresh()
        {
            doingRefresh = true;
            ds = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM notes", m_dbConnection);
            adapter.Fill(ds);
            adapter.Dispose();
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
                if (textDirty && !doingFilter)
                {
                    DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        save();
                    }
                }
                if (!doingFilter)
                {
                    bENote.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("note");
                    bEName.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("name");
                    bEId.Text = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<long>("id").ToString();
                    lastId = ds.Tables[0].Rows[baseElements.SelectedIndex].Field<long>("id");
                    if (ds.Tables[0].Rows[baseElements.SelectedIndex].Field<int>("notification") == 1)
                    {
                        reminderActivator.Checked = true;
                    }
                    else
                    {
                        reminderActivator.Checked = false;
                    }
                }
                textDirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void save()
        {
            if(bEId.Text == "")
            {
                MessageBox.Show("Выберите запись из списка или создайте новую");
            }
            else if(bEName.Text == "")
            {
                MessageBox.Show("Введите имя записи");
            }
            else if(bENote.Text == "")
            {
                MessageBox.Show("Введите запись");
            }
            else if (bEName.Text != "" && bENote.Text != "")
            {
                if(reminderActivator.Checked == true)
                {
                    checkStatus = 1;
                    date = dateTimePicker.Value.Day.ToString() + "-" + dateTimePicker.Value.Month.ToString() + "-" + dateTimePicker.Value.Year.ToString();
                    time = dateTimePicker.Value.Hour.ToString() + ":" + dateTimePicker.Value.Minute.ToString();
                }
                else
                {
                    checkStatus = 0;
                    date = dateTimePicker.Value.Day.ToString() + "-" + dateTimePicker.Value.Month.ToString() + "-" + dateTimePicker.Value.Year.ToString();
                    time = dateTimePicker.Value.Hour.ToString() + ":" + dateTimePicker.Value.Minute.ToString();
                }
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "UPDATE notes SET name='" + bEName.Text + "', note='" + bENote.Text + "', notification='" + checkStatus + "', date='"+ date +"', time='"+ time +"' WHERE id=" + lastId;
                command.Connection = m_dbConnection;
                command.ExecuteNonQuery();

                refresh();

                MessageBox.Show("Сохранено");
            }
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
            checkSelect = baseElements.SelectedIndex;
            if (checkSelect >= 0)
            {
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "DELETE FROM notes WHERE id=" + ds.Tables[0].Rows[baseElements.SelectedIndex].Field<long>("id");
                command.Connection = m_dbConnection;
                command.ExecuteNonQuery();

                refresh();

                MessageBox.Show("Удалено");
            }
            else
            {
                MessageBox.Show("Выберите запись из списка");
            }
        }
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            doingFilter = true;
            ds.Tables[0].DefaultView.RowFilter = "name LIKE '%" + filterBox.Text + "%'";
            doingFilter = false;
        }

        public void baseSelect_Click(object sender, EventArgs e)
        {
            openBase.Filter = "Data Base (.db)|*.db";
            openBase.FilterIndex = 1;
            openBase.Multiselect = false;
            if (openBase.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (connectionOpened == true)
                {
                    m_dbConnection.Close();
                    System.Data.SQLite.SQLiteConnection.ClearAllPools();
                    GC.Collect();
                }
                sr = new System.IO.StreamReader(openBase.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                sr.Close();
                m_dbConnection = new SQLiteConnection("Data Source=" + openBase.FileName + "; Version=3;");
                m_dbConnection.Open();
                refresh();
                ConfigurationManager.AppSettings["lastBase"] = openBase.FileName;
                connectionOpened = true;
            }
        }
    }
}
