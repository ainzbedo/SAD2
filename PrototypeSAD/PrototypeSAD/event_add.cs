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

    public partial class event_add : Form
    {
        public bool reminder = false;
        public MySqlConnection conn;
        public string type;
        public string time, desc, evn, evprog, evtype;
        public int month, day, year;
        
        public int evid, caseid;
        public int attendaceID;
        public string casename;
        public string[] casename2 = new string[100];
        public string attendance, attend;
        public int evmonth, evday;
        public Form2 reftofrm2 { get; set; }
        public event_add()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            if (type == "Admin")
            {
                this.tabControl2.SelectedTab = tabPage4;

            }
            else
            {
                this.tabControl2.SelectedTab = tabPage3;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void event_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            reftofrm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            clearlsitview2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage4;
        }

        public void displayEvents()
        {
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            int dnow = int.Parse(DateTime.Now.ToString("dd"));
            int evyear;
            string evname, day, prog = "", id;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE status = 'Approved'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                int monthtoday = int.Parse(DateTime.Now.ToString("MM"));
                int yeartoday = int.Parse(DateTime.Now.ToString("yyyy"));
                if (dt.Rows.Count >= 1)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //MessageBox.Show(dt.Rows.Count + "");
                        evmonth = int.Parse(dt.Rows[i]["evMonth"].ToString());
                        evyear = int.Parse(dt.Rows[i]["evYear"].ToString());
                        //MessageBox.Show(" " + evyear + " " + evmonth + " " + monthtoday);
                        if (evmonth == monthtoday && evyear >= yeartoday)
                        {

                            evday = int.Parse(dt.Rows[i]["evDay"].ToString());
                            evname = dt.Rows[i]["evName"].ToString();
                            //MessageBox.Show(" "+evday + " " + evmonth);
                            day = evday.ToString();
                            ListViewItem itm = new ListViewItem(day);
                            itm.SubItems.Add(evname);
                            //MessageBox.Show(" " + evday + " " + evname);
                            listView1.Items.Add(itm);

                        }
                        id = dt.Rows[i]["eventID"].ToString();
                        if (mnow == evmonth)
                        {
                            if(dnow == evday)
                            {
                                prog = "Ongoing";
                            }else if (dnow > evday)
                            {
                                prog = "Finished";
                            }else if (dnow < evday)
                            {
                                prog = "Upcoming";
                            }
                            
                        }
                        updateEventProgress(prog, id);
                    }
                }

                
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }
        public void clearListview1()
        {
            listView1.Items.Clear();
        }
        public void clearListview5()
        {
            listView5.Items.Clear();
        }
        public void displayEventApproval()
        {
            string evname, request;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE status='Pending'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //conn.Close();
                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        request = dt.Rows[i]["requestedBy"].ToString();
                        evname = dt.Rows[i]["evName"].ToString();
                        //MessageBox.Show(evname+" "+request);
                        ListViewItem itm = new ListViewItem(evname);
                        itm.SubItems.Add(request);

                        listView5.Items.Add(itm);

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
        private void event_add_Load(object sender, EventArgs e)
        {
            
            type = reftofrm2.type;
            //MessageBox.Show(type);
            if (type == "Admin")
            {

                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {
                button7.Enabled = false;
            }
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now;
            displayEvents();
            displayEventApproval();
            button10.Enabled = false;
            button11.Enabled = false;
            button8.Enabled = false;
            maskedTextBox2.Enabled = false;
            dateTimePicker2.Enabled = false;
            
        }
        public void updateEventProgress(string p, string id)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE event SET evProgress ='"+ p +"' WHERE eventID = '"+ id +"';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Module is Not Ready");
        }


        public void insert()
        {

            string month = dateTimePicker1.Value.Date.ToString("MM");
            string day = dateTimePicker1.Value.Date.ToString("dd");
            string year = dateTimePicker1.Value.Date.ToString("yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, attendance, status, requestedBy) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + month + "','" + day + "','" + year + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + "Pending" + "','" + comboBox1.Text + "', 'False' , 'Pending' " + ",'" + textBox7.Text + "');", conn);
                comm.ExecuteNonQuery();

                conn.Close();
                //displayEvents();


            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void insertWithboth()
        {

            string month = dateTimePicker1.Value.Date.ToString("MM");
            string day = dateTimePicker1.Value.Date.ToString("dd");
            string year = dateTimePicker1.Value.Date.ToString("yyyy");
            string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, reminderDate, reminderTime, attendance, requestedBy, budget, reminder) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + month + "','" + day + "','" + year + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "', 'Pending' , '" + comboBox1.Text + "' , 'Pending' ,'" + remindDate + "','" + maskedTextBox2.Text + "', 'False' ,'" + textBox7.Text + "', 'True', 'True');", conn);
                comm.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void insertWithRemind()
        {

            string month = dateTimePicker1.Value.Date.ToString("MM");
            string day = dateTimePicker1.Value.Date.ToString("dd");
            string year = dateTimePicker1.Value.Date.ToString("yyyy");
            string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, reminderDate, reminderTime, attendance, requestedBy, reminder) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + month + "','" + day + "','" + year + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + "Pending" + "','" + comboBox1.Text + "','" + "Pending" + "','" + remindDate + "','" + maskedTextBox2.Text + "', 'False' ,'" + textBox7.Text + "','True');", conn);
                comm.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void insertWithbudget()
        {

            string month = dateTimePicker1.Value.Date.ToString("MM");
            string day = dateTimePicker1.Value.Date.ToString("dd");
            string year = dateTimePicker1.Value.Date.ToString("yyyy");
            string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, attendance, requestedBy, budget) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + month + "','" + day + "','" + year + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + "Pending" + "','" + comboBox1.Text + "', 'Pending' , 'False' ,'" + textBox7.Text + "', 'True');", conn);
                comm.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }


        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            evn = listView1.SelectedItems[0].SubItems[1].Text;
            button10.Enabled = true;
            button11.Enabled = true;
            eventdetails(evn);
        }
        public void eventdetails(string evn)
        {
            string venue;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE evName='" + evn + "'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    evid = int.Parse(dt.Rows[0]["eventID"].ToString());
                    time = dt.Rows[0]["evTime"].ToString();
                    venue = dt.Rows[0]["evVenue"].ToString();
                    desc = dt.Rows[0]["evDesc"].ToString();
                    evprog = dt.Rows[0]["evProgress"].ToString();
                    evtype = dt.Rows[0]["evType"].ToString();
                    attendance = dt.Rows[0]["attendance"].ToString();


                    label9.Text = time;
                    label10.Text = venue;
                    label11.Text = desc;
                    label3.Text = evtype;
                    label14.Text = evprog;
                }


                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Module is Not ready");
            button10.Enabled = false;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            //insertCaseAttendanceA();
            updateCaseA();
            clearlistview3();
            showAttendanceAP();


            clearlsitview2();
            ViewCaseAttendance();

        }
        public string ref_attend { get; set; }
        public string ref_stat { get; set; }
        public string ref_role { get; set; }
        private void button12_Click(object sender, EventArgs e)
        {
            string name, status, role;
            attendee attend = new attendee();
            attend.ea = this;
            DialogResult rest = attend.ShowDialog();
            if (rest == DialogResult.OK)
            {
                name = ref_attend;
                status = ref_stat;
                role = ref_role;
                //MessageBox.Show(role);
                insertAttendance(name, status, role);
                //updateEvent();
            }

            clearlistview4();
            showAttendanceCase();
        }
        public void clearlistview4()
        {
            listView4.Items.Clear();
        }
        public void insertAttendance(string n, string s, string r)
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO attendance(eventID, attendee, status , role) VALUES('" + evid + "','" + n + "','" + s + "','" + r + "')", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void showAttendance()
        {
            string attendee, role, status;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM attendance WHERE eventID='" + evid + "'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        attendaceID = int.Parse(dt.Rows[i]["attendanceID"].ToString());
                        attendee = dt.Rows[i]["attendee"].ToString();
                        role = dt.Rows[i]["role"].ToString();
                        status = dt.Rows[i]["status"].ToString();

                        ListViewItem itm = new ListViewItem(attendee);
                        itm.SubItems.Add(role);
                        itm.SubItems.Add(status);
                        listView4.Items.Add(itm);
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
        /*
        public void updateEvent()
        {
            //tanungin si sam kasi usually may another table for the segregation of attendance being a case study and others as an attendee
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE event SET status ='Approve';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        */


        private void button9_Click_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && checkBox1.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || maskedTextBox2.Text == "")
                {
                    MessageBox.Show("Please enter necessary fields!");
                }
                else
                {
                    insertWithboth();
                    clearListview1();
                    clearListview5();
                    displayEvents();
                    displayEventApproval();
                    MessageBox.Show("Your request has been sent.");
                }
            } else if (checkBox2.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter necessary fields!");
                }
                else
                {
                    insertWithbudget();
                    clearListview1();
                    clearListview5();
                    displayEvents();
                    displayEventApproval();
                    MessageBox.Show("Your request has been sent.");
                }
            }
            else if (checkBox1.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || maskedTextBox2.Text == "")
                {
                    MessageBox.Show("Please enter necessary fields!");
                }
                else
                {
                    insertWithRemind();
                    clearListview1();
                    clearListview5();
                    displayEvents();
                    displayEventApproval();
                    MessageBox.Show("Your request has been sent.");
                }
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter necessary fields!");
                }
                else
                {
                    insert();
                    clearListview1();
                    clearListview5();
                    displayEvents();
                    displayEventApproval();
                    MessageBox.Show("Your request has been sent.");
                }
            }
            button9.Enabled = false;
        }



        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button8.Enabled = true;
            }
            else
            {
                button8.Enabled = false;
            }
        }


        private void listView5_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Arial Rounded MT", 10, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
        }



        private void listView5_MouseClick(object sender, MouseEventArgs e)
        {
            evn = listView5.SelectedItems[0].SubItems[0].Text;
            approveEventDetails(evn);
        }
        public void approveEventDetails(string evn)
        {
            string venue, type, budget, remind;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE evName='" + evn + "'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    evid = int.Parse(dt.Rows[0]["eventID"].ToString());
                    time = dt.Rows[0]["evTime"].ToString();
                    venue = dt.Rows[0]["evVenue"].ToString();
                    desc = dt.Rows[0]["evDesc"].ToString();
                    evprog = dt.Rows[0]["evProgress"].ToString();
                    evtype = dt.Rows[0]["evType"].ToString();
                    month = int.Parse(dt.Rows[0]["evMonth"].ToString());
                    day = int.Parse(dt.Rows[0]["evDay"].ToString());
                    year = int.Parse(dt.Rows[0]["evYear"].ToString());
                    type = dt.Rows[0]["evType"].ToString();
                    budget = dt.Rows[0]["budget"].ToString();
                    remind = dt.Rows[0]["reminder"].ToString();
                    textBox5.Text = evn;
                    textBox8.Text = desc;
                    textBox11.Text = type;
                    textBox9.Text = month + "/" + day + "/" + year;
                    textBox10.Text = time;

                    if (budget == "True")
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }
                    if (remind == "True")
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
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

        private void button18_Click(object sender, EventArgs e)
        {
            disApproveEvent();
            clearListview5();
            displayEventApproval();
            clearListview1();

            displayEvents();
            MessageBox.Show("The event has been disapproved.");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button9.Enabled = true;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            approveEvent();

            clearListview5();
            displayEventApproval();
            clearListview1();

            displayEvents();
            MessageBox.Show("The event has been approved.");
        }

        public void approveEvent()
        {
            string s = "";
            int monthtoday = int.Parse(DateTime.Now.ToString("MM"));
            int daytoday = int.Parse(DateTime.Now.ToString("dd"));
            int yeartoday = int.Parse(DateTime.Now.ToString("yyyy"));
            if (year == yeartoday)
            {
                if (month == monthtoday)
                {
                    if (day > daytoday)
                    {
                        s = "Upcoming";
                    } else if (day == daytoday)
                    {
                        s = "Ongoing";
                    }
                } else if (month > monthtoday)
                {
                    s = "Upcoming";
                }
            } else if (year > yeartoday)
            {
                s = "Upcoming";
            }
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE event SET status='Approved' , evProgress = '" + s + "' WHERE eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void disApproveEvent()
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE event SET status='Disapproved' , evProgress = 'Disapproved' WHERE eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            casename = listView2.SelectedItems[0].SubItems[0].Text;
            getcaseid(casename);
            button15.Enabled = true;
            button13.Enabled = true;
        }
        public void getcaseid(string n)
        {
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM casestudyprofile WHERE caseName='" + n + "'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    caseid = int.Parse(dt.Rows[0]["caseID"].ToString());
                }


                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            //insertCaseAttendanceP();
            updateCaseP();
            clearlistview3();
            showAttendanceAP();

            clearlsitview2();
            ViewCaseAttendance();
            button15.Enabled = false;
            button13.Enabled = false;


        }
        public void updateCaseP()
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE attendance SET status ='Present' WHERE attendee = '" + casename + "' AND eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void updateCaseA()
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE attendance SET status ='Absent' WHERE attendee = '" + casename + "' AND eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void updateCaseToNone()
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE attendance SET status ='none' WHERE attendee = '" + casename + "' AND eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //updateToNoneC(casename);
            getcaseid(casename);
            updateCaseToNone();
            //updateToNoneA();
            clearlistview3();
            showAttendanceAP();

            clearlsitview2();
            ViewCaseAttendance();
            //viewCaseProfile();
            button14.Enabled = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            updateOtherA();
            clearlistview4();
            showAttendanceCase();
            button20.Enabled = false;
        }
        public void updateOtherA()
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE attendance SET status='none' WHERE eventID = '" + evid + "' AND attendee ='" + casename + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            casename = listView3.SelectedItems[0].SubItems[0].Text;
            button14.Enabled = true;
        }

        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            casename = listView4.SelectedItems[0].SubItems[0].Text;
            button20.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            label32.Text = evn;
            label33.Text = time;
            label34.Text = desc;
            button11.Enabled = false;
            //clearlsitview2();
            //viewCaseProfile();
            clearlistview4();
            showAttendanceCase();
            clearlistview3();
            showAttendanceAP();
            if (attendance == "False")
            {
                /*
                for(int i = 0; i < selectAllCase(); i++)
                {
                    updateToNoneCase(i); // to update each case to none
                }*/

                CaseProfile();

                mayAttendancepo();
                clearlsitview2();
                ViewCaseAttendance();
                //viewCaseProfile();
            }
            else
            {
                clearlsitview2();
                ViewCaseAttendance();
                ///viewCaseProfile();
            }

        }



        public void showAttendanceCase()
        {
            string attendee, role, status;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM attendance WHERE (role ='Guest' OR role = 'Social Worker' OR role = 'Staff') AND eventID='" + evid + "' AND (status = 'Absent' OR status = 'Present')", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        attendaceID = int.Parse(dt.Rows[i]["attendanceID"].ToString());
                        attendee = dt.Rows[i]["attendee"].ToString();
                        role = dt.Rows[i]["role"].ToString();
                        status = dt.Rows[i]["status"].ToString();
                        //MessageBox.Show(attendee + " " + status);
                        ListViewItem itm = new ListViewItem(attendee);
                        itm.SubItems.Add(role);
                        itm.SubItems.Add(status);
                        listView4.Items.Add(itm);
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
        public void clearlistview3()
        {
            listView3.Items.Clear();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            maskedTextBox1.BeepOnError = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                dateTimePicker2.Enabled = true;
                maskedTextBox2.Enabled = true;
            }else
            {
                dateTimePicker2.Enabled = false;
                maskedTextBox2.Enabled = false;
            }
        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {

            string s = maskedTextBox1.Text;
            string[] check = s.Split(':');
            if (int.Parse(check[0]) > 24 || int.Parse(check[1]) > 59)
            {
                MessageBox.Show("Please folow the 24 hour format");
                button9.Enabled = false;
            }
            else
            {
                //MessageBox.Show("Correct");
                button9.Enabled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_Validated(object sender, EventArgs e)
        {

            string s = maskedTextBox2.Text;
            string[] check = s.Split(':');
            if (int.Parse(check[0]) > 24 || int.Parse(check[1]) > 59)
            {
                MessageBox.Show("Please folow the 24 hour format");
                button9.Enabled = false;
            }
            else
            {
                //MessageBox.Show("Correct");
                button9.Enabled = true;
            }
        }

        public void showAttendanceAP()
        {
            string role, status;

            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM attendance WHERE eventID='" + evid + "' AND status != 'none' AND role = 'child' ", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        attendaceID = int.Parse(dt.Rows[i]["attendanceID"].ToString());
                        attend = dt.Rows[i]["attendee"].ToString();
                        role = dt.Rows[i]["role"].ToString();
                        status = dt.Rows[i]["status"].ToString();

                        ListViewItem itm = new ListViewItem(attend);
                        itm.SubItems.Add(status);
                        listView3.Items.Add(itm);
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

        public int selectAllCase()
        {
            int num = 0;
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                num = dt.Rows.Count;


                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
            return num;
        }
        public void updateToNoneCase( int c)
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE casestudyprofile SET Astatus ='none' WHERE caseID = '"+ c +"';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void mayAttendancepo()
        {

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("UPDATE event SET attendance='True' WHERE eventID = '" + evid + "';", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void clearlsitview2()
        {
            listView2.Items.Clear();
        }
        public void CaseProfile()
        {
            int cid;
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        casename2[i] = dt.Rows[i]["caseName"].ToString();
                        cid = int.Parse(dt.Rows[i]["caseID"].ToString());
                        insertCaseView(casename2[i] , cid);
                    }

                }


                
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }
        public void insertCaseView(string c , int cid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO attendance(eventID, caseID, attendee, status, role) VALUES('" + evid + "','" + cid + "','" + c + "', 'none', 'child')", conn);
                comm.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
        public void ViewCaseAttendance()
        {
            string[] attendees = new string[100];
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM attendance WHERE eventID = '"+ evid +"' AND status = 'none'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                
                if (dt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        attendees[i] = dt.Rows[i]["attendee"].ToString();
                        ListViewItem itm = new ListViewItem(attendees[i]);
                        listView2.Items.Add(itm);
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
    }
}
