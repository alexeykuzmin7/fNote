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
        int checkStatus = 0;
        string date = "";
        string time = "";
        public addItem(mainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
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
                date = dateTimePicker.Value.Day.ToString() + "-" + dateTimePicker.Value.Month.ToString() + "-" + dateTimePicker.Value.Year.ToString();
                time = dateTimePicker.Value.Hour.ToString() + ":" + dateTimePicker.Value.Minute.ToString();
                if (reminderActivator.Checked == true)
                {
                    checkStatus = 1;
                }
                else
                {
                    checkStatus = 0;
                }
                string sql = "INSERT INTO notes (id, name, note, notification, date, time) VALUES (NULL, " + bEName.Text + ", " + bENote.Text + ", '" + checkStatus + "', '" + date + "', '" + time + "')";
                SQLiteCommand command = new SQLiteCommand(sql, mainForm.m_dbConnection);
                command.ExecuteNonQuery();
                mainForm.refresh();
                MessageBox.Show("Запись создана");
                Close();
            }
        }
    }
}
