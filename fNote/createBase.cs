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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fNote
{
    public partial class createBase : Form
    {
        string filename = "";
        SQLiteConnection m_dbConnection;
        private mainForm mainForm;
        Regex regex = new Regex(@"^.*?(?=[\^#%&$\*:<>\?/\{\|\}]).*$");
        public createBase(mainForm mainForm)
        {
            TopMost = true;
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void baseName_Click(object sender, EventArgs e)
        {
            baseName.Text = "";
        }

        public void create_Click(object sender, EventArgs e)
        {
            if (regex.IsMatch(baseName.Text, 0) == true)
            {
                MessageBox.Show("Название должно быть без спец-символов");
            } 
            else if (System.IO.File.Exists("bases\\" + baseName.Text + ".db"))
            {
                MessageBox.Show("База с таким названием уже существует");
            }
            else if (baseName.Text == "")
            {
                MessageBox.Show("Введите название");
            }
            else
            {
                filename = "bases\\" + baseName.Text + ".db";            
                m_dbConnection = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
                m_dbConnection.Open();
                string sql3 = "CREATE TABLE notes (id integer primary key, name varchar(30), note varchar(1000), notification int, date varchar(10), time varchar(5))";
                SQLiteCommand command3 = new SQLiteCommand(sql3, m_dbConnection);
                command3.ExecuteNonQuery();

                string sql4 = "INSERT INTO notes (id, name, note, notification, date, time) VALUES (NULL, 'Имя', 'Пример заметки', 0, '01-01-1970', '00:00')";
                SQLiteCommand command4 = new SQLiteCommand(sql4, m_dbConnection);
                command4.ExecuteNonQuery();            
                DialogResult dialogResult = MessageBox.Show("Выбрать эту базу?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (mainForm.connectionOpened == true)
                    {
                        mainForm.m_dbConnection.Close();
                        System.Data.SQLite.SQLiteConnection.ClearAllPools();
                        GC.Collect();
                    }
                    mainForm.m_dbConnection = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
                    mainForm.m_dbConnection.Open();
                    mainForm.refresh();
                    ConfigurationManager.AppSettings["lastBase"] = filename;
                    mainForm.connectionOpened = true;
                }

                Close();
            }
        }
    }
}
