﻿using System;
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
        public string[] tMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

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
            int yearnow = int.Parse(DateTime.Now.ToString("yyyy"));
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
                        if (yearnow == evyear)
                        {
                            if (mnow == evmonth)
                            {
                                if (dnow == evday)
                                {
                                    prog = "Ongoing";
                                }
                                else if (dnow < evday)
                                {
                                    prog = "Upcoming";
                                }
                                else if (dnow > evday)
                                {
                                    prog = "Finished";
                                }

                            }
                            else if (mnow < evmonth)
                            {
                                prog = "Upcoming";
                            }
                            else if (mnow > evmonth)
                            {
                                prog = "Finished";
                            }
                        }
                        else if (yearnow < evyear)
                        {
                            prog = "Upcoming";

                        }
                        else if (yearnow > evyear)
                        {
                            prog = "Finished";
                        }
                        //MessageBox.Show(prog + " " + id);
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
            //dateTimePicker2.MinDate = DateTime.Now;
            displayEvents();
            displayEventApproval();
            button10.Enabled = false;
            button11.Enabled = false;
            button8.Enabled = false;
            button22.Enabled = false;
            button9.Enabled = false;
            //maskedTextBox2.Enabled = false;
            //dateTimePicker2.Enabled = false;
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            string m = tMonths[mnow - 1];
            monthLabel.Text = m;

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

            string month = dialogMonth;
            string day = dialogDay;
            string year = dialogYear;
            string eventtime = dialogHour + ":" + dialogMin + " " + dialogtt;
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, attendance, status, requestedBy) VALUES('" + eventName.Text + "','" + eventDes.Text + "','" + month + "','" + day + "','" + year + "','" + eventtime + "','" + eventVenue.Text + "','" + "Pending" + "','" + eventType.Text + "', 'False' , 'Pending' " + ",'" + reqBy.Text + "');", conn);
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

            string month = dialogMonth;
            string day = dialogDay;
            string year = dialogYear;
            string eventtime = dialogHour + ":" + dialogMin + " " + dialogtt;
            string reminddate = dialogMonthR + "/" + dialogDayR + "/" + dialogYearR;
            string remindtime = dialogHourR + ":" + dialogMinR + " " + dialogttR;
            //string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, reminderDate, reminderTime, attendance, requestedBy, budget, reminder) VALUES('" + eventName.Text + "','" + eventDes.Text + "','" + month + "','" + day + "','" + year + "','" + eventtime + "','" + eventVenue.Text + "', 'Pending' , '" + eventType.Text + "' , 'Pending' ,'" + reminddate + "','" + remindtime + "', 'False' ,'" + reqBy.Text + "', 'True', 'True');", conn);
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

            string month = dialogMonth;
            string day = dialogDay;
            string year = dialogYear;
            string eventtime = dialogHour + ":" + dialogMin + " " + dialogtt;
            string reminddate = dialogMonthR + "/" + dialogDayR + "/" + dialogYearR;
            string remindtime = dialogHourR + ":" + dialogMinR + " " + dialogttR;
            //string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, reminderDate, reminderTime, attendance, requestedBy, reminder) VALUES('" + eventName.Text + "','" + eventDes.Text + "','" + month + "','" + day + "','" + year + "','" + eventtime + "','" + eventVenue.Text + "','" + "Pending" + "','" + eventType.Text + "','" + "Pending" + "','" + reminddate + "','" + remindtime + "', 'False' ,'" + reqBy.Text + "','True');", conn);
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

            string month = dialogMonth;
            string day = dialogDay;
            string year = dialogYear;
            string eventtime = dialogHour + ":" + dialogMin + " " + dialogtt;
            //string remindDate = dateTimePicker2.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO event(evName, evDesc, evMonth, evDay, evYear, evTime , evVenue, evProgress, evType, status, attendance, requestedBy, budget) VALUES('" + eventName.Text + "','" + eventDes.Text + "','" + month + "','" + day + "','" + year + "','" + eventtime + "','" + eventVenue.Text + "','" + "Pending" + "','" + eventType.Text + "', 'Pending' , 'False' ,'" + reqBy.Text + "', 'True');", conn);
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
        
        private void button9_Click_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && checkBox1.Checked == true)
            {
                if (eventName.Text == "" || eventDes.Text == "" || eventVenue.Text == "" || reqBy.Text == "" || eventType.Text == "")
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
                if (eventName.Text == "" || eventDes.Text == "" || eventVenue.Text == "" || reqBy.Text == "" || eventType.Text == "")
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
                if (eventName.Text == "" || eventDes.Text == "" || eventVenue.Text == "" || reqBy.Text == "" || eventType.Text == "")
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
                if (eventName.Text == "" || eventDes.Text == "" || eventVenue.Text == "" ||  reqBy.Text == "" || eventType.Text == "")
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
            clear();
        }

        public void clear()
        {
            eventName.Text = "";
            eventDes.Text = "";
            eventVenue.Text = "";
            reqBy.Text = "";
            eventType.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button9.Enabled = true;
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
                    eNameR.Text = evn;
                    eDesR.Text = desc;
                    eTypeR.Text = type;
                    eDateR.Text = month + "/" + day + "/" + year;
                    eTimeR.Text = time;

                    if (budget == "True")
                    {
                        eBudgetR.Checked = true;
                    }
                    else
                    {
                        eBudgetR.Checked = false;
                    }
                    if (remind == "True")
                    {
                        eRemindR.Checked = true;
                    }
                    else
                    {
                        eRemindR.Checked = false;
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

       

        private void button17_Click(object sender, EventArgs e)
        {
            approveEvent();

            clearListview5();
            displayEventApproval();
            clearListview1();

            displayEvents();
            MessageBox.Show("The event has been approved.");
            clearItemsApproved();
        }
        public void clearItemsApproved()
        {
            eNameR.Text = "";
            eDesR.Text = "";
            eDateR.Text = "";
            eTypeR.Text = "";
            eTimeR.Text = "";
            eRemindR.Checked = false;
            eBudgetR.Checked = false;
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

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                button22.Enabled = true;
            }else
            {
                button22.Enabled = false;
            }
        }
        public void monthDEA(string m)
        {
            //monthDEA = month Display Event Approved
            //MessageBox.Show(m);
            clearListview1();
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            int dnow = int.Parse(DateTime.Now.ToString("dd"));
            int yearnow = int.Parse(DateTime.Now.ToString("yyyy"));
            int evyear;
            string evname, day, prog = "", id;
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE status = 'Approved' AND evMonth = '" + m + "' AND evYear ='" + yearFilter.Value.ToString("yyyy") + "'", conn);
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
                        evday = int.Parse(dt.Rows[i]["evDay"].ToString());
                        evname = dt.Rows[i]["evName"].ToString();
                        //MessageBox.Show(" "+evday + " " + evmonth);
                        day = evday.ToString();
                        ListViewItem itm = new ListViewItem(day);
                        itm.SubItems.Add(evname);
                        //MessageBox.Show(" " + evday + " " + evname);
                        listView1.Items.Add(itm);


                        id = dt.Rows[i]["eventID"].ToString();
                        if (yearnow == evyear)
                        {
                            if (mnow == evmonth)
                            {
                                if (dnow == evday)
                                {
                                    prog = "Ongoing";
                                }
                                else if (dnow < evday)
                                {
                                    prog = "Upcoming";
                                }
                                else if (dnow > evday)
                                {
                                    prog = "Finished";
                                }

                            }
                            else if (mnow < evmonth)
                            {
                                prog = "Upcoming";
                            }
                            else if (mnow > evmonth)
                            {
                                prog = "Finished";
                            }
                        }
                        else if (yearnow < evyear)
                        {
                            prog = "Upcoming";

                        }
                        else if (yearnow > evyear)
                        {
                            prog = "Finished";
                        }
                        //MessageBox.Show(prog + " " + id);
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
        private void upb_Click(object sender, EventArgs e)
        {
            //up filter for month mo.1
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            string m = tMonths[mnow - 1];
            if (monthLabel.Text == "December")
            {
                monthLabel.Text = tMonths[0];
                monthDEA("01");
            }
            else
            {
                int num = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (tMonths[i] == monthLabel.Text)
                    {
                        m = tMonths[i + 1];
                        num = i + 2;
                    }
                }
                string n = num.ToString("00");
                monthLabel.Text = m;
                monthDEA(n);
            }
        }

        private void downb_Click(object sender, EventArgs e)
        {
            //down filter for month mo.2
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            string m = tMonths[mnow - 1];
            if (monthLabel.Text == "January")
            {
                monthLabel.Text = tMonths[11];
                monthDEA("12");
            }
            else
            {
                int num = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (tMonths[i] == monthLabel.Text)
                    {
                        m = tMonths[i - 1];
                        num = i;
                    }
                }
                string n = num.ToString("00");
                monthLabel.Text = m;
                monthDEA(n);
            }
        }

        private void yearFilter_ValueChanged(object sender, EventArgs e)
        {
            //year filter for the events yr.
            clearListview1();
            int mnow = int.Parse(DateTime.Now.ToString("MM"));
            int dnow = int.Parse(DateTime.Now.ToString("dd"));
            int yearnow = int.Parse(DateTime.Now.ToString("yyyy"));
            int evyear;
            string evname, day, prog = "", id;
            int num = 0;
            for (int i = 0; i < 12; i++)
            {
                if (tMonths[i] == monthLabel.Text)
                {
                    num = i + 1;
                }
            }
            string n = num.ToString("00");
            //MessageBox.Show(n);
            try
            {

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM event WHERE status = 'Approved' AND evYear = '" + yearFilter.Value.ToString("yyyy") + "' AND evMonth = '" + n + "'", conn);
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
                        evmonth = int.Parse(dt.Rows[i]["evMonth"].ToString());
                        evyear = int.Parse(dt.Rows[i]["evYear"].ToString());
                        evday = int.Parse(dt.Rows[i]["evDay"].ToString());
                        evname = dt.Rows[i]["evName"].ToString();
                        //MessageBox.Show(" "+evday + " " + evmonth);
                        day = evday.ToString();
                        ListViewItem itm = new ListViewItem(day);
                        itm.SubItems.Add(evname);
                        //MessageBox.Show(" " + evday + " " + evname);
                        listView1.Items.Add(itm);


                        id = dt.Rows[i]["eventID"].ToString();
                        if (yearnow == evyear)
                        {
                            if (mnow == evmonth)
                            {
                                if (dnow == evday)
                                {
                                    prog = "Ongoing";
                                }
                                else if (dnow < evday)
                                {
                                    prog = "Upcoming";
                                }
                                else if (dnow > evday)
                                {
                                    prog = "Finished";
                                }

                            }
                            else if (mnow < evmonth)
                            {
                                prog = "Upcoming";
                            }
                            else if (mnow > evmonth)
                            {
                                prog = "Finished";
                            }
                        }
                        else if (yearnow < evyear)
                        {
                            prog = "Upcoming";

                        }
                        else if (yearnow > evyear)
                        {
                            prog = "Finished";
                        }
                        //MessageBox.Show(prog + " " + id);
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
        public string whichDialog = "";
        public string dialogDay { get; set; }
        public string dialogMonth { get; set; }
        public string dialogYear { get; set; }
        public string dialogHour { get; set; }
        public string dialogMin { get; set; }
        public string dialogtt { get; set; }
        private void button21_Click(object sender, EventArgs e)
        {
            whichDialog = "eventdetail";
            eventDateDialog datedialog = new eventDateDialog();
            datedialog.reftoevent_add = this;
            DialogResult rest = datedialog.ShowDialog();
            if (rest == DialogResult.OK)
            {
                button9.Enabled = true;
                //MessageBox.Show(dialogDay + " " + dialogMonth + " " + dialogYear + " " + dialogHour + " " + dialogMin + " " + dialogtt);
                label5.Text = tMonths[int.Parse(dialogMonth) - 1] + "/" + dialogDay + "/" + dialogYear + " " + dialogHour + ":" + dialogMin + " " + dialogtt;
            }
        }
        public string dialogDayR { get; set; }
        public string dialogMonthR { get; set; }
        public string dialogYearR { get; set; }
        public string dialogHourR { get; set; }
        public string dialogMinR { get; set; }
        public string dialogttR { get; set; }
        private void button22_Click(object sender, EventArgs e)
        {
            whichDialog = "eventRemind";
            eventDateDialog datedialog = new eventDateDialog();
            datedialog.reftoevent_add = this;
            DialogResult rest = datedialog.ShowDialog();
            if (rest == DialogResult.OK)
            {

                //MessageBox.Show(dialogDay + " " + dialogMonth + " " + dialogYear + " " + dialogHour + " " + dialogMin + " " + dialogtt);
                label8.Text = tMonths[int.Parse(dialogMonthR) - 1] + "/" + dialogDayR + "/" + dialogYearR + " " + dialogHourR + ":" + dialogMinR + " " + dialogttR;
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
            int evYear = int.Parse(DateTime.Now.ToString("yyyy"));
            int evmonth = int.Parse(DateTime.Now.ToString("MM"));
            int evday = int.Parse(DateTime.Now.ToString("dd"));
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
                        if (checkIf2Events(attendees[i], evmonth, evday, evYear))
                        {
                            ListViewItem itm = new ListViewItem(attendees[i]);
                            listView2.Items.Add(itm);
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

        public bool checkIf2Events(string attend, int month, int day, int year)
        {
            bool real = true;
            try
            {
                //conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM attendance JOIN event ON attendance.eventID = event.eventID WHERE attendance.status = 'Present' AND attendee = '" + attend + "' AND (evMonth = '" + month +"' AND evDay = '"+ day +"' AND evYear = '"+ year +"')", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //MessageBox.Show("" + dt.Rows.Count);
                if (dt.Rows.Count >= 1)
                {
                    real = false;
                    MessageBox.Show("Meron");
                } else {

                    real = true;
                    MessageBox.Show("wala");
                }

            }
            catch(Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
            return real;
        }
    }
}
