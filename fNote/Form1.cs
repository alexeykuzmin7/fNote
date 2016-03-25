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
    public partial class mainForm : Form
    {
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
    }
}
