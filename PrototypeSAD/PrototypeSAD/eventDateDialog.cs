using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeSAD
{
    public partial class eventDateDialog : Form
    {
        public eventDateDialog()
        {
            InitializeComponent();
        }
        public string[] tMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public int evYear = int.Parse(DateTime.Now.ToString("yyyy"));
        public int evmonth = int.Parse(DateTime.Now.ToString("MM"));
        public int evday = int.Parse(DateTime.Now.ToString("dd"));
        public int evhour = int.Parse(DateTime.Now.ToString("hh"));
        public int evmin = int.Parse(DateTime.Now.ToString("mm"));
        public string evtt = DateTime.Now.ToString("hh:mm tt");
        private void eventDateDialog_Load(object sender, EventArgs e)
        {
            dayUpdate(evYear, evmonth);
            for (int j = evYear; j <= evYear + 100; j++)
            {
                comboBox3.Items.Add(""+ j +"");
            }
            for (int i = 0; i < 60; i++)
            {
                comboBox5.Items.Add(i.ToString("00"));
            }
            comboBox1.SelectedIndex = evday - 1;
            comboBox2.SelectedIndex = evmonth - 1;
            comboBox3.SelectedItem = evYear.ToString();
            comboBox4.SelectedIndex = evhour - 1;
            comboBox5.SelectedIndex = evmin - 1;
            comboBox6.SelectedItem = evtt.Substring(6, 2);

            //MessageBox.Show(evtt.Substring(6, 2));
        }
        public void dayUpdate(int year, int month)
        {
            comboBox1.Items.Clear();
            if (year % 4 != 0)
            {
                //common year
                if (month == 2)
                {
                    //february
                    for(int i = 1; i <= 28; i++)
                    {
                        comboBox1.Items.Add(""+i+"");
                    }

                }
                else if (month % 2 == 0)
                {
                    //day 30
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
                else
                {
                    //day 31
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
            }
            else if (year % 100 != 0)
            {
                //leap year
                if (month == 2)
                {
                    //february
                    for (int i = 1; i <= 29; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }

                }
                else if (month % 2 == 0)
                {
                    //day 30
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
                else
                {
                    //day 31
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
            }
            else if (year % 400 != 0)
            {
                //common year
                if (month == 2)
                {
                    //february
                    for (int i = 1; i <= 28; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }

                }
                else if (month % 2 == 0)
                {
                    //day 30
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
                else
                {
                    //day 31
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
            }
            else
            {
                //leap year
                if (month == 2)
                {
                    //february
                    for (int i = 1; i <= 29; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }

                }
                else if (month % 2 == 0)
                {
                    //day 30
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
                else
                {
                    //day 31
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBox1.Items.Add("" + i + "");
                    }
                }
            }
        }

        

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int num = 0;
            string m;
            for (int i = 0; i < 12; i++)
            {
                if (tMonths[i] == comboBox2.Text)
                {
                    //m = tMonths[i + 1];
                    num = i + 1;
                }
            }
            //MessageBox.Show(comboBox3.Text);
            dayUpdate(int.Parse(comboBox3.Text), num);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int num = 0;
            string m;
            for (int i = 0; i < 12; i++)
            {
                if (tMonths[i] == comboBox2.Text)
                {
                    //m = tMonths[i + 1];
                    num = i + 1;
                }
            }
            //MessageBox.Show(comboBox3.Text);
            dayUpdate(int.Parse(comboBox3.Text), num);
        }
    }
}
