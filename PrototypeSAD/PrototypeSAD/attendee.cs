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
    public partial class attendee : Form
    {
        public event_add ea { get; set; }
        public attendee()
        {
            InitializeComponent();
        }

        private void attendee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                if (textBox1.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Necessary Fields");
                }
                else
                {
                    ea.ref_attend = textBox1.Text;
                    ea.ref_stat = radioButton1.Text;
                    ea.ref_role = comboBox1.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                if (textBox1.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Necessary Fields");
                }
                else
                {
                    ea.ref_attend = textBox1.Text;
                    ea.ref_stat = radioButton2.Text;
                    ea.ref_role = comboBox1.Text;
                    // MessageBox.Show(ea.ref_role);
                    this.DialogResult = DialogResult.OK;
                }
            }


        }

        
    }
}
