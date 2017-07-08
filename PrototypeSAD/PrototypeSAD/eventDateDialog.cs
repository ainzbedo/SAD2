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

        private void eventDateDialog_Load(object sender, EventArgs e)
        {
            int evYear = int.Parse(DateTime.Now.ToString("yyyy"));
            int evmonth = int.Parse(DateTime.Now.ToString("mm"));
            string[] tMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            dayUpdate(evYear, evmonth);
            for (int j = evYear; j <= evYear + 100; j++)
            {
                comboBox3.Items.Add(""+ j +"");
            }
            for (int i = 1; i <= 60; i++)
            {
                comboBox5.Items.Add(""+ i +"");
            }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                        
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
