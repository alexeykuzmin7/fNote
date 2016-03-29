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
    public partial class addItem : Form
    {
        

        private mainForm mainForm;
        public addItem(mainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string baseName = "mybase";
            string filename = "E:\\_Programing\\Projects\\fNote\\fNote\\bin\\Debug\\bases\\" + baseName + ".db";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + filename + "; Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO notes (id, name, note) VALUES (NULL, " + bEName.Text + ", " + bENote.Text + ")";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Сохранено");
            //mainForm.NewItem(bEName.Text, bENote.Text);
            Close();
        }
    }
}
