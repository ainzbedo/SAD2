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

    public partial class casestudy : Form
    {
        public Form2 ref_to_main { get; set; }
        public MySqlConnection conn;

        private void btnAnnual_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifteen;
            resetColor();
            btnAnnual.BackColor = Color.Gray;
        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourteen;
            resetColor();
            btnSS.BackColor = Color.Gray;
        }

        private void btnProg_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = thirteen;
            resetColor();
            btnProg.BackColor = Color.Gray;
        }

        private void btnCloseCase_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = twelfth;
            resetColor();
            btnCloseCase.BackColor = Color.Gray;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = eleventh;
            resetColor();
            btnUpdate.BackColor = Color.Gray;
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tenth;
            resetColor();
            btnInc.BackColor = Color.Gray;
        }

        private void btnServ_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ninth;
            resetColor();
            btnServ.BackColor = Color.Gray;
        }

        private void btnEdu_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = eighth;
            resetColor();
            btnEdu.BackColor = Color.Gray;
        }

        private void btnHealth_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = seventh;
            resetColor();
            btnHealth.BackColor = Color.Gray;
        }

        private void btnProb_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixth;
            resetColor();
            btnProb.BackColor = Color.Gray;
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifth;
            resetColor();
            btnCon.BackColor = Color.Gray;
        }

        private void btnFam_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourth;
            resetColor();
            btnFam.BackColor = Color.Gray;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = third;
            resetColor();
            btnAdd.BackColor = Color.Gray;




        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = second;
            resetColor();
            btnSearch.BackColor = Color.Gray;


        }

        private void btnCaseStudy_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = first;
            resetColor();
            btnCaseStudy.BackColor = Color.Gray;


        }

        private void casestudy_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT id, name FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                dtgcs.DataSource = dt;

                dtgcs.Columns[0].Visible = false;

                conn.Close();
            }




            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }

            tabControl.SelectedTab = first;
            resetColor();
            btnCaseStudy.BackColor = Color.Gray;

            btnDropIn.BackColor = Color.Gray;
        }

        public void resetColor()
        {
            btnCaseStudy.BackColor = Color.Transparent; btnAdd.BackColor = Color.Transparent; btnAnnual.BackColor = Color.Transparent; btnCloseCase.BackColor = Color.Transparent; btnCon.BackColor = Color.Transparent; btnDropIn.BackColor = Color.Transparent;
            btnEdu.BackColor = Color.Transparent; btnFam.BackColor = Color.Transparent; btnHealth.BackColor = Color.Transparent; btnInc.BackColor = Color.Transparent; btnProb.BackColor = Color.Transparent; btnProg.BackColor = Color.Transparent;
            btnResidential.BackColor = Color.Transparent; btnSearch.BackColor = Color.Transparent; btnServ.BackColor = Color.Transparent; btnSS.BackColor = Color.Transparent; btnUpdate.BackColor = Color.Transparent;
            btnDropIn.BackColor = Color.Gray;
        }

        public void resetColor2()
        {
            btnCaseStudy2.BackColor = Color.Transparent; btnAddRes.BackColor = Color.Transparent; btnSearch2.BackColor = Color.Transparent; button52.BackColor = Color.Transparent;
            button51.BackColor = Color.Transparent; button50.BackColor = Color.Transparent; button49.BackColor = Color.Transparent; button48.BackColor = Color.Transparent;
            button47.BackColor = Color.Transparent; button46.BackColor = Color.Transparent; button45.BackColor = Color.Transparent; button44.BackColor = Color.Transparent;
            button43.BackColor = Color.Transparent; button42.BackColor = Color.Transparent; button41.BackColor = Color.Transparent;
        }

        public casestudy()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMem_Click(object sender, EventArgs e)
        {
            Member addmem = new PrototypeSAD.Member();
            addmem.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
            resetColor();
            btnCaseStudy.BackColor = Color.Gray;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = first;
        }

        private void tenth_MouseHover(object sender, EventArgs e)
        {
            rbAM.PerformClick();
        }

        private void btnDropIn_Click(object sender, EventArgs e)
        {
            resetColor();
            btnResidential.BackColor = Color.Transparent;
            btnMain.BackColor = Color.Transparent;
            btnDropIn.BackColor = Color.Gray;
            secondTaskbar.SelectedTab = dropin;
        }

        private void btnResidential_Click(object sender, EventArgs e)
        {
            resetColor();
            btnDropIn.BackColor = Color.Transparent;
            btnMain.BackColor = Color.Transparent;
            btnResidential.BackColor = Color.Gray;
            secondTaskbar.SelectedTab = residential;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            resetColor();
            btnDropIn.BackColor = Color.Transparent;
            btnResidential.BackColor = Color.Transparent;
            btnMain.BackColor = Color.Gray;

            this.Close();
        }

        private void casestudy_FormClosing(object sender, FormClosingEventArgs e)
        {
            ref_to_main.Show();
        }

        private void btnAddRes_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = third;
            resetColor2();
            btnAdd.BackColor = Color.Gray;
        }

        private void btnaddcase_Click(object sender, EventArgs e)
        {
            string name = txtname.Text, status = cbxstatus.Text, address = txtaddress.Text, lvl = txtlvl.Text, school = txtschool.Text, blood = cbxblood.Text, type = cbxtype.Text;
            int height = int.Parse(txtheight.Text), weight = int.Parse(txtweight.Text);

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("INSERT INTO casestudyprofile(name, birthdate, status, address, edtype, edlvl, school, blood_type, height, weight) VALUES('" + name + "','" + dt2.Value.Date.ToString("yyyyMMdd") + "','" + status + "','" + address + "','" + type + "','" + lvl + "','" + school + "','" + blood + "','" + height + "','" + weight + "')", conn);
                comm.ExecuteNonQuery();

                MessageBox.Show("QUERY INSERTED HAR HAR!!");

                conn.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void dtgcs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dtgcs.Rows[e.RowIndex].Cells[0].Value.ToString());

            tabControl.SelectedTab = sixteen;

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT name, birthdate, status, edtype, edlvl, blood_type, height, weight FROM casestudyprofile WHERE id = " + id, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    lblname.Text = dt.Rows[0]["name"].ToString();
                    lblstatus.Text = dt.Rows[0]["status"].ToString();
                    lbldate.Text = Convert.ToDateTime(dt.Rows[0]["birthdate"].ToString()).ToString("mm/dd/yyy");
                    lblblood.Text = dt.Rows[0]["blood_type"].ToString();
                    lblheight.Text = dt.Rows[0]["height"].ToString();
                    lblweight.Text = dt.Rows[0]["weight"].ToString();
                    lbledtype.Text = dt.Rows[0]["edtype"].ToString();
                    lbledlvl.Text = dt.Rows[0]["edlvl"].ToString();
                }

                conn.Close();
            }




            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }
    }
}
