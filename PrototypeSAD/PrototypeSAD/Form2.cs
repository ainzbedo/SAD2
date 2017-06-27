using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PrototypeSAD
{
    public partial class Form2 : Form
    {
        public MySqlConnection conn;
        public string type;
        public Form1 reftofrm1 { get; set; }
        public Form2()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("MM / dd / yyyy");
            label2.Text = date;
            type = reftofrm1.type;
            //MessageBox.Show(type);
            if (type == "Admin")
            {
                button1.Enabled = false;
                button4.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = false;
                button2.Enabled = true;
            }
            displayEvents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            casestudy study = new casestudy();
            study.Show();
            study.ref_to_main = this;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBE dbe = new DBE();
            dbe.Show();
            dbe.ref_to_main = this;
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            event_add ea = new event_add();
            ea.reftofrm2 = this;
            ea.Show();
            this.Hide();
        }
        public void displayEvents()
        {

            int evyear;
            string remindTime, timeNow, remindDate, dateNow, evname = "", evmonth, evday = "", evTime;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE status = 'Approved'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string monthtoday = DateTime.Now.ToString("MM");
                int yeartoday = int.Parse(DateTime.Now.ToString("yyyy"));
                if (dt.Rows.Count >= 1)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        evTime = dt.Rows[i]["evTime"].ToString();
                        evmonth = dt.Rows[i]["evMonth"].ToString();
                        evyear = int.Parse(dt.Rows[i]["evYear"].ToString());
                        if (evmonth == monthtoday && evyear >= yeartoday)
                        {

                            evday = dt.Rows[i]["evDay"].ToString();
                            evname = dt.Rows[i]["evName"].ToString();

                            ListViewItem itm = new ListViewItem(evday);
                            itm.SubItems.Add(evname);
                            listView1.Items.Add(itm);
                        }
                        remindDate = dt.Rows[i]["reminderDate"].ToString();
                        dateNow = DateTime.Now.ToString("MM/dd/yyyy");
                        remindTime = dt.Rows[i]["reminderTime"].ToString();
                        timeNow = DateTime.Now.ToString("HH : mm");
                        //MessageBox.Show("("+ remindTime +") ("+ timeNow +")");
                        if (remindDate == dateNow && remindTime == timeNow)
                        {
                            MessageBox.Show("Testing lng Po---- (Event: " + evname + " Date: " + evmonth + "/" + evday + "/" + evyear + " Time : " + evTime +")");
                        }
                    }
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            reftofrm1.Show();
        }
    }
}
