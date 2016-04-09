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
    public partial class addItem : Form
    {
        

        private mainForm mainForm;
        //SQLiteConnection m_dbConnection;
        public addItem(mainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            if(bEName.Text == "")
            {
                MessageBox.Show("Введите название");
            }
            else if(bENote.Text == "")
            {
                MessageBox.Show("Введите запись");
            }
            else if(mainForm.connectionOpened == false)
            {
                MessageBox.Show("Выберите базу");
            }
            else
            {
                //string baseName = "mybase";
                //string filename = "bases\\" + baseName + ".db";
                
                //m_dbConnection = new SQLiteConnection("Data Source=" + ConfigurationManager.AppSettings["lastBase"] + "; Version=3;");
                //m_dbConnection.Open();
                string sql = "INSERT INTO notes (id, name, note) VALUES (NULL, " + bEName.Text + ", " + bENote.Text + ")";
                SQLiteCommand command = new SQLiteCommand(sql, mainForm.m_dbConnection);
                command.ExecuteNonQuery();
                mainForm.refresh();
                MessageBox.Show("Запись создана");
                Close();
            }
        }
    }
}
