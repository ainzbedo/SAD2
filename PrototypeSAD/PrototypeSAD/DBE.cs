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
    public partial class DBE : Form
    {
        public Form ref_to_main { get; set; }
        public MySqlConnection conn;

        public DBE()
        {            
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = third;
            resetColor();
            btnAdd.BackColor = Color.Gray;
        }

        public void resetColor()
        {
            btnAdd.BackColor = Color.Transparent; btnSearch.BackColor = Color.Transparent; btnDonor.BackColor = Color.Transparent; btnUpdate.BackColor = Color.Transparent;
            btnAddB.BackColor = Color.Transparent; btnApproveBud.BackColor = Color.Transparent;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = second;
            resetColor();
            btnSearch.BackColor = Color.Gray;
        }

        private void btnDonor_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = first;
            resetColor();
            btnDonor.BackColor = Color.Gray;
        }

        public void resetMainColor()
        {
            btnDonation.BackColor = Color.Transparent; btnBudget.BackColor = Color.Transparent; btnExpense.BackColor = Color.Transparent; btnAll.BackColor = Color.Transparent; btnMain.BackColor = Color.Transparent;
        }

        private void btnDonation_Click(object sender, EventArgs e)
        {
            secondTaskbar.SelectedTab = donation;
            tabControl.SelectedTab = third;
            resetColor();
            resetMainColor();
            btnDonor.BackColor = Color.Gray;
            btnDonation.BackColor = Color.Gray;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DBE_FormClosing(object sender, FormClosingEventArgs e)
        {
            ref_to_main.Show();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            secondTaskbar.SelectedTab = budget;
            tabControl.SelectedTab = third;
            resetMainColor();
            btnBudget.BackColor = Color.Gray;
            btnAddB.BackColor = Color.Gray;
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            secondTaskbar.SelectedTab = expense;
            tabControl.SelectedTab = seventh;
            resetMainColor();
            btnExpense.BackColor = Color.Gray;
            btnAddE.BackColor = Color.Gray;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            secondTaskbar.SelectedTab = all;
            tabControl.SelectedTab = eighth;
            resetMainColor();
            btnAll.BackColor = Color.Gray;
            button52.BackColor = Color.Gray;
        }

        private void btnAddB_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifth;
            resetColor();
            btnAddB.BackColor = Color.Gray;
        }

        private void btnApproveBud_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixth;
            resetColor();
            btnApproveBud.BackColor = Color.Gray;
        }

        private void btnAddE_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = seventh;
            resetColor();
            btnAddE.BackColor = Color.Gray;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = eighth;
            resetColor();
            button52.BackColor = Color.Gray;
        }

        private void DBE_Load(object sender, EventArgs e)
        {
            resetColor();
            resetMainColor();
            btnDonation.BackColor = Color.Gray;
            secondTaskbar.SelectedTab = donation;
            tabControl.SelectedTab = third;
        }

        private void btnAddDonation_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM donation WHERE status = 'Approved'", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);



                conn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Nah!" + ee);
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
