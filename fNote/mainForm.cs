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
        DataSet ds;
        DataTable dt;
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
        DateTime theMoment;
        
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

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["firstLaunch"] == "true")
            {
                MessageBox.Show("Вы запустили программу в первый раз. Создайте файл(базу) для хранения заметок");
                new createBase(this).Show();
                ConfigurationManager.AppSettings["firstLaunch"] = "false";
            }
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
                    dateTimePicker.Value = DateTime.Parse(ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("date")+ " " + ds.Tables[0].Rows[baseElements.SelectedIndex].Field<string>("time"));
                    //theMoment = dateTimePicker.Value;
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
                date = dateTimePicker.Value.Day.ToString() + "-" + dateTimePicker.Value.Month.ToString() + "-" + dateTimePicker.Value.Year.ToString();
                time = dateTimePicker.Value.Hour.ToString() + ":" + dateTimePicker.Value.Minute.ToString();
                if(reminderActivator.Checked == true)
                {
                    checkStatus = 1;
                }
                else
                {
                    checkStatus = 0;
                }
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "UPDATE notes SET name='" + bEName.Text + "', note='" + bENote.Text + "', notification='" + checkStatus + "', date='" + date + "', time='" + time + "' WHERE id=" + lastId;
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
                sr.Close();
                m_dbConnection = new SQLiteConnection("Data Source=" + openBase.FileName + "; Version=3;");
                m_dbConnection.Open();
                refresh();
                ConfigurationManager.AppSettings["lastBase"] = openBase.FileName;
                connectionOpened = true;
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (connectionOpened == true)
            {
                dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT id, name, notification, date, time FROM notes WHERE notification=1", m_dbConnection);
                adapter.Fill(dt);
                adapter.Dispose();
                if (baseElements.SelectedIndex > -1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        theMoment = DateTime.Parse(dr["date"].ToString() + " " + dr["time"].ToString());
                        if (DateTime.Now.CompareTo(theMoment) > 0)
                        {
                            timer.Enabled = false;
                            SQLiteCommand command = new SQLiteCommand();
                            command.CommandText = "UPDATE notes SET notification=0 WHERE id=" + dr["id"];
                            command.Connection = m_dbConnection;
                            command.ExecuteNonQuery();
                            theMoment = DateTime.MaxValue;
                            DialogResult dialogResult = MessageBox.Show(dr["name"].ToString(), "", MessageBoxButtons.OK);
                            if (dialogResult == DialogResult.OK)
                            {
                                timer.Enabled = true;
                            }
                            refresh();
                        }
                    }
                }
            }
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipTitle = "Minimize to Tray App";
            notifyIcon.BalloonTipText = "You have successfully minimized your form.";

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
