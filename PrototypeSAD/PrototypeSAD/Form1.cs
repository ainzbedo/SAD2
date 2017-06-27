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
    public partial class Form1 : Form
    {
        public bool pass = true;
        public MySqlConnection conn;
        public string type; 
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" && textBox1.Text == "  username" || textBox2.Text == "  password")
            {
                MessageBox.Show("Please enter necessary fields!");
            }
            else
            {
                try
                {

                    conn.Open();

                    MySqlCommand comm = new MySqlCommand("SELECT * FROM tbl_accounts WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("This user does not exist");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        type = dt.Rows[0]["account_type"].ToString();
                        //MessageBox.Show(dt.Rows[0]["fullname"].ToString());
                        Form2 frm2 = new Form2();
                        frm2.reftofrm1 = this;
                        frm2.Show();
                        this.Hide();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pass)
            {
                textBox2.PasswordChar = '\0';
                pass = false;
            }
            else
            {
                textBox2.PasswordChar = '*';
                pass = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
