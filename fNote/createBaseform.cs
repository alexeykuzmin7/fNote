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
    public partial class createBaseform : Form
    {
        public createBaseform()
        {
            InitializeComponent();
        }
        

        private void createBase_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory("bases");
            if (baseName.Text == "")
            {
                MessageBox.Show("Название базы не может быть пустым");
            }
            else if (!System.IO.File.Exists("bases\\" + baseName.Text + ".sqlite"))
            {
                SQLiteConnection.CreateFile("bases\\" + baseName.Text + ".sqlite");
            }
            else
            {
                MessageBox.Show("База с таким названием уже ссуществует");
            }
            //MessageBox.Show(legalName(baseName.Text).ToString());
        }

        //private bool legalName(string name)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        try
        //        {
        //            // Careful!
        //            //    Path.GetDirectoryName("C:\Directory\SubDirectory")
        //            //    returns "C:\Directory", which may not be what you want in
        //            //    this case. You may need to explicitly add a trailing \
        //            //    if path is a directory and not a file path. As written, 
        //            //    this function just assumes path is a file path.
        //            string fileName = System.IO.Path.GetFileName(name);
        //            string fileDirectory = System.IO.Path.GetDirectoryName(name);

        //            // we don't need to do anything else,
        //            // if we got here without throwing an 
        //            // exception, then the path does not
        //            // contain invalid characters
        //        }
        //        catch (ArgumentException)
        //        {
        //            // Path functions will throw this 
        //            // if path contains invalid chars
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private void baseName_Click(object sender, EventArgs e)
        {
            baseName.Text = "";
        }
    }
}
