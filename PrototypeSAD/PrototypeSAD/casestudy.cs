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
using System.IO;
using System.Globalization;

namespace PrototypeSAD
{

    public partial class casestudy : Form
    {
        public Form2 ref_to_main { get; set; }
        public MySqlConnection conn;

        public int id, hid, fammode, famid;
        public string filename;
        public DataTable tblfam = new DataTable();

        public casestudy()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=prototype_sad;Uid=root;Pwd=root;");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            rbam.PerformClick();
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
            shit.BackColor = Color.Gray;
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
            shit2.BackColor = Color.Gray;
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

            lbladdeditprofile.Text = "New Profile";
            btnaddeditcase.Text = "Add Profile";


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

        public void resetColor()
        {
            btnCaseStudy.BackColor = Color.Transparent; btnAdd.BackColor = Color.Transparent; btnAnnual.BackColor = Color.Transparent; btnCloseCase.BackColor = Color.Transparent; shit2.BackColor = Color.Transparent; btnDropIn.BackColor = Color.Transparent;
            btnEdu.BackColor = Color.Transparent; btnFam.BackColor = Color.Transparent; shit.BackColor = Color.Transparent; btnInc.BackColor = Color.Transparent; btnProb.BackColor = Color.Transparent; btnProg.BackColor = Color.Transparent;
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

        private void casestudy_Load(object sender, EventArgs e)
        {

           
            lbladdeditprofile.Text = "New Profile";
            btnaddeditcase.Text = "Add Profile";

            dtbirth.MaxDate = DateTime.Now;
            dtjoin.MaxDate = DateTime.Now;
            condate.MaxDate = DateTime.Now;
            dtpcheck.MaxDate = DateTime.Now;
            dateincid.MaxDate = DateTime.Now;

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid, lastname, firstname, program FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtgcs.DataSource = dt;
                    dtgcs.Columns[0].Visible = false;

                    getdrop();
                    getresidential();
                    getcount();
                }

                else
                {
                    MessageBox.Show("There are no case studies currently profiled.");
                }
              
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

        public void refresh()
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid, lastname, firstname, program FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                dtgcs.DataSource = dt;
               
                dtgcs.Columns[0].Visible = false;

                getdrop();
                getresidential();
                getcount();

                conn.Close();
            }




            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }

            //tabControl.SelectedTab = first;
            resetColor();
            btnCaseStudy.BackColor = Color.Gray;

            btnDropIn.BackColor = Color.Gray;
        }

        public void getdrop()
        {
            MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM casestudyprofile WHERE program = 'Drop-In'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            lbldrop.Text = dt.Rows[0]["count(*)"].ToString();
        }

        public void getresidential()
        {
            MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM casestudyprofile WHERE program = 'Residential'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            lblresidential.Text = dt.Rows[0]["count(*)"].ToString();
        }

        public void getcount()
        {
            MySqlCommand comm = new MySqlCommand("SELECT COUNT(caseid) FROM casestudyprofile", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            lbltotalcase.Text = dt.Rows[0]["count(caseid)"].ToString();
        }

       private void btnAddMem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = twenty;
        }

        
        private void dtgcs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dtgcs.Rows[e.RowIndex].Cells[0].Value.ToString());

                tabControl.SelectedTab = sixteen;

                reload(id);

                existsed(id);

                existshealth(id);

            }

            catch (Exception ee)
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (btnaddeditcase.Text == "Add Profile")
            {
                addprofile();
            }

            else
            {
                
                editprofile();
            }
           
        }

        public void reloadeditinfo(int id)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT lastname, firstname, birthdate, caseAge, program, status, address, datejoined, picture FROM casestudyprofile WHERE caseid = " + id, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    txtlname.Text = dt.Rows[0]["lastname"].ToString();
                    txtfname.Text = dt.Rows[0]["firstname"].ToString();
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    txtage.Text = dt.Rows[0]["caseAge"].ToString();
                    cbxprogram.Text = dt.Rows[0]["program"].ToString();
                    cbxstatus.Text = dt.Rows[0]["status"].ToString();

                    dtbirth.Value = Convert.ToDateTime(dt.Rows[0]["birthdate"]);
                    dtjoin.Value = Convert.ToDateTime(dt.Rows[0]["datejoined"]);


                    pbox1.ImageLocation = dt.Rows[0]["picture"].ToString();

                    filename = dt.Rows[0]["picture"].ToString().Replace(@"\", @"\\");

                }

                conn.Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                conn.Close();
            }


        }

        public void addprofile()
        {
            string lname = txtlname.Text, fname = txtfname.Text, status = cbxstatus.Text, program = cbxprogram.Text, address = txtaddress.Text;
            int age;

            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(txtage.Text) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(program) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else if (pbox1.Image == null)
            {
                MessageBox.Show("Please insert a proper picture.");
            }

            else
            {

                if (Int32.TryParse(txtage.Text, out age))
                {
                    age = int.Parse(txtage.Text);

                    try
                    {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("INSERT INTO casestudyprofile(lastname, firstname, birthdate, status, caseage, program, dateJoined, picture, address) VALUES('" + lname + "', '" + fname + "', '" + dtbirth.Value.Date.ToString("yyyyMMdd") + "','" + status + "','" + age + "','" + program + "','" + dtjoin.Value.Date.ToString("yyyy/MM/dd") + "', '" + filename + "', '" + address + "')", conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("New Profile Added!");

                        conn.Close();

                        tabControl.SelectedTab = first;

                        reset();
                        refresh();

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                        conn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Age input is invalid! Please input a proper input!");
                }

            }
        }

        public void editprofile()
        {
            string lname = txtlname.Text, fname = txtfname.Text, status = cbxstatus.Text, program = cbxprogram.Text, address = txtaddress.Text;
            int age;

            
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(txtage.Text) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(program) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else if (pbox1.Image == null)
            {
                MessageBox.Show("Please insert a proper picture.");
            }

            else
            {

                if (Int32.TryParse(txtage.Text, out age))
                {
                    age = int.Parse(txtage.Text);

                    try
                    {
                        MessageBox.Show(filename);
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("UPDATE casestudyprofile SET lastname = '" + lname + "', firstname = " +
                                            "'" + fname + "', birthdate = " + dtbirth.Value.Date.ToString("yyyyMMdd") + ", status = '" + status + "', " +
                                            "caseage = " + age + ", program = '" + program + "', datejoined = " + dtjoin.Value.Date.ToString("yyyyMMdd") + ", " +
                                            "picture = '" + filename + "', address = '" + address + "' WHERE caseid = " + id, conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("Profile Edited!");

                        conn.Close();

                        tabControl.SelectedTab = sixteen;

                        reset();
                        refresh();

                        reload(id);

                        existsed(id);

                        existshealth(id);

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                        conn.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Age input is invalid! Please input a proper input!");
                }

            }
        }

        public void reloadedithealth(int id)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT height, weight, bloodtype, allergies, hecondition FROM health WHERE caseid = " + id, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    lblvheight.Text = dt.Rows[0]["height"].ToString();
                    lblvweight.Text = dt.Rows[0]["weight"].ToString();
                    lblvblood.Text = dt.Rows[0]["bloodtype"].ToString();
                    rviewall.Text = dt.Rows[0]["allergies"].ToString();
                    rviewcondition.Text = dt.Rows[0]["hecondition"].ToString();

                }

                conn.Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                conn.Close();
            }


        }

        public void addhealth()
        {
            string blood = cbxbloodtype.Text, allergy = rtxtall.Text, condition = rtxtcondition.Text;
            int height, weight;

            if (string.IsNullOrEmpty(blood) || string.IsNullOrEmpty(txtheight.Text) || string.IsNullOrEmpty(txtweight.Text) || string.IsNullOrEmpty(allergy) || string.IsNullOrEmpty(condition))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {

                if (Int32.TryParse(txtheight.Text, out height) && Int32.TryParse(txtweight.Text, out weight))
                {
                    height = int.Parse(txtheight.Text); weight = int.Parse(txtweight.Text);

                    try
                    {

                        conn.Open();


                        MySqlCommand comm = new MySqlCommand("INSERT INTO health(caseid, height, weight, bloodtype, allergies, hecondition) VALUES('" + id + "', '" + height + "', '" + weight + "','" + blood + "','" + allergy + "','" + condition + "')", conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("New Info Added!");

                        conn.Close();

                        existshealth(id);

                        reloadedithealth(id);

                        lblblood.Text = blood;
                        lblheight.Text = height.ToString();
                        lblweight.Text = weight.ToString();

                        tabControl.SelectedTab = sixteen;

                        reset3();

                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                        conn.Close();
                    }

                }

                else
                {
                    if (Int32.TryParse(txtheight.Text, out height) == false && Int32.TryParse(txtweight.Text, out weight) == false)
                    {
                        MessageBox.Show("Height and Weight inputs are invalid! Use numbers!");
                    }

                    else if (Int32.TryParse(txtheight.Text, out height) == false)
                    {
                        MessageBox.Show("Height input is invalid! Use numbers!");
                    }

                    else
                    {
                        MessageBox.Show("Weight input is invalid! Use numbers!");
                    }
                }
            }
        }

        public void edithealth()
        {
            string blood = cbxbloodtype.Text, allergy = rtxtall.Text, condition = rtxtcondition.Text;
            int height, weight;

            if (string.IsNullOrEmpty(blood) || string.IsNullOrEmpty(txtheight.Text) || string.IsNullOrEmpty(txtweight.Text) || string.IsNullOrEmpty(allergy) || string.IsNullOrEmpty(condition))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {

                if (Int32.TryParse(txtheight.Text, out height) && Int32.TryParse(txtweight.Text, out weight))
                {
                    height = int.Parse(txtheight.Text); weight = int.Parse(txtweight.Text);

                    try
                    {

                        conn.Open();


                        MySqlCommand comm = new MySqlCommand("UPDATE health SET height = '" + height + "', weight = '" + weight + "', bloodtype = '" + blood + "', allergies = '" + allergy + "', hecondition = '" + condition + "' WHERE caseid = " + id, conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("New Info Added!");

                        conn.Close();

                        existshealth(id);

                        reloadedithealth(id);

                        lblblood.Text = blood;
                        lblheight.Text = height.ToString();
                        lblweight.Text = weight.ToString();

                        tabControl.SelectedTab = seventeen;

                        reset3();

                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                        conn.Close();
                    }

                }

                else
                {
                    if (Int32.TryParse(txtheight.Text, out height) == false && Int32.TryParse(txtweight.Text, out weight) == false)
                    {
                        MessageBox.Show("Height and Weight inputs are invalid! Use numbers!");
                    }

                    else if (Int32.TryParse(txtheight.Text, out height) == false)
                    {
                        MessageBox.Show("Height input is invalid! Use numbers!");
                    }

                    else
                    {
                        MessageBox.Show("Weight input is invalid! Use numbers!");
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourth;

            existsfam(id);

            reloadfam(id);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            reset();

        }

        private void pbox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog rest = new OpenFileDialog();

            rest.Filter = "images| *.JPG; *.PNG; *.GIF"; // you can add any other image type 

            if (rest.ShowDialog() == DialogResult.OK)
            {
                pbox1.Image = Image.FromFile(rest.FileName);

                filename = Path.GetFullPath(rest.FileName).Replace(@"\", @"\\");

            }

            

        }

        public void reload(int id)
        {
            //for (int m = 0; m <= dtgcs.ColumnCount - 1; m++)
                //dtgcs.Columns[m].SortMode = DataGridViewColumnSortMode.NotSortable;

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT lastname, firstname, birthdate, caseAge, program, status, address, datejoined, picture FROM casestudyprofile WHERE caseid = " + id, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    lblname.Text = dt.Rows[0]["firstname"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                    lbladdress.Text = dt.Rows[0]["address"].ToString();
                    lblage.Text = dt.Rows[0]["caseAge"].ToString() + " years old";
                    lblprogram.Text = dt.Rows[0]["program"].ToString();
                    lblstatus.Text = dt.Rows[0]["status"].ToString();

                    lbldate.Text = Convert.ToDateTime(dt.Rows[0]["birthdate"]).ToString("MMMM dd, yyyy");
                    lbljoined.Text = Convert.ToDateTime(dt.Rows[0]["datejoined"]).ToString("MMMM dd, yyyy");


                    pbox2.ImageLocation = dt.Rows[0]["picture"].ToString();

                }

                comm = new MySqlCommand("SELECT school, edutype, level FROM education WHERE caseid = " + id, conn);
                adp = new MySqlDataAdapter(comm);
                dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    lbledlvl.Text = dt.Rows[0]["level"].ToString();
                    lbledtype.Text = dt.Rows[0]["edutype"].ToString();
                    lbledschool.Text = dt.Rows[0]["school"].ToString();

                }

                conn.Close();
            }




            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void reloadcon(int id)
        {
            //MessageBox.Show(id.ToString());

            //for (int m = 0; m <= dtgcon.ColumnCount - 1; m++)
              //  dtgcon.Columns[m].SortMode = DataGridViewColumnSortMode.NotSortable;

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT cid, interviewdate, interviewer FROM consultation WHERE caseid = " + id + " ORDER BY interviewdate", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There are no current consultation records for this case study.");
                }

                else

                {
                    dtgcon.DataSource = dt;

                }
               

                dtgcon.Columns[0].Visible = false;

                conn.Close();

            }


            catch (Exception ee)
            {
                                
                //MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void reloadincid(int id)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT incidid, type, incdate FROM incident WHERE caseid = " + id + " ORDER BY incdate", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There are no current incident records for this case study.");
                }

                else

                {
                    dtincid.DataSource = dt;

                }


                dtincid.Columns[0].Visible = false;

                conn.Close();

            }


            catch (Exception ee)
            {

                //MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void reloadhealth(int id)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT checkid, checkupdate, checkuplocation FROM checkup JOIN health ON health.hid = checkup.hid WHERE health.caseid = " + id + " ORDER BY checkupdate", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There are no current incident records for this case study.");
                }

                else

                {
                    dtghealth.DataSource = dt;
                    dtghealth.Columns[0].Visible = false;
                    //dtincid.Columns[1].Visible = false;

                    //hid = int.Parse(dt.Rows[0]["health.hid"].ToString());
                    //MessageBox.Show(hid.ToString());
                }


                

                conn.Close();

            }


            catch (Exception ee)
            {

                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void reloadfam(int id)
        {

            int famid;

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT familyid, famtype FROM family WHERE caseid = " + id, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    famid = int.Parse(dt.Rows[0]["familyid"].ToString());

                    lblfamtype.Text = dt.Rows[0]["famtype"].ToString();

                    reloadmem(famid);
                    
                }

                else
                {
                    MessageBox.Show("There are no current family records for this case study.");
                }

               
                conn.Close();

            }


            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString() + "reloadfam");

                conn.Close();
            }

        }

      
        public void reloadmem(int famid)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand("SELECT memberid, type, gender, birthdate, relationship, dependency FROM member WHERE familyid = " + famid, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtfamOverview.DataSource = dt;
                    dtfamOverview.Columns[0].Visible = false;

                    fammode = 1;
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("There are no current member records for this case study.");

                fammode = 0;
            }
        }

        public void existsed(int id)
        {

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid FROM education WHERE caseid = " + id, conn);

                int UserExist = (int)comm.ExecuteScalar();

                btned.Text = (UserExist > 0) ? "View Info" : "Add Info"; //put add info on catch

              
                
                conn.Close();

            }

           
            catch (Exception ee)
            {
                btned.Text = "Add Info";

                lbledlvl.Text = "";
                lbledtype.Text = "";
                lbledschool.Text = "";

                conn.Close();
            }

         
        }

        public void existsinvolve(int incidid)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT involveid FROM involvement WHERE caseid = " + id, conn);

                

                int UserExist = (int)comm.ExecuteScalar();

                btnaddinvolve.Text = (UserExist > 0) ? "View Info" : "Add Info"; //put add info on catch
                
                conn.Close();

            }


            catch (Exception ee)
            {
                btnaddinvolve.Text = "Add Info";

                conn.Close();
            }

        }

        public void existsfam(int id)
        {

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid FROM family WHERE caseid = " + id, conn);

                int UserExist = (int)comm.ExecuteScalar();

                btned.Text = (UserExist > 0) ? "Edit Info" : "Add Info"; //put add info on catch

                comm = new MySqlCommand("SELECT familyid FROM family WHERE caseid = " + id, conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                DataTable dt = new DataTable();

                adp.Fill(dt);

                famid = int.Parse(dt.Rows[0]["familyid"].ToString());

                conn.Close();

            }


            catch (Exception ee)
            {
                btned.Text = "Add Info";

                lblfamtype.Text = "";
                
                conn.Close();
            }


        }

        public void existshealth(int id)
        {

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid FROM health WHERE caseid = " + id, conn);

                int UserExist = (int)comm.ExecuteScalar();

                btnhealth.Text = (UserExist > 0) ? "View Info" : "Add Info"; //put add info on catch

            

                conn.Close();

            }


            catch (Exception ee)
            {
                btnhealth.Text = "Add Info";

                lblblood.Text = "";
                lblheight.Text = "";
                lblweight.Text = "";

                conn.Close();
            }


        }

        public void reset()
        {
            pbox1.Image = null;

            txtlname.Clear();
            txtfname.Clear();
            txtage.Clear();
            txtaddress.Clear();

            cbxprogram.SelectedIndex = -1;
            cbxstatus.SelectedIndex = -1;

            dtbirth.Value = DateTime.Now.Date;
            dtjoin.Value = DateTime.Now.Date;

            if (btnaddeditcase.Text == "Add Profile")
            {
                tabControl.SelectedTab = first;
            }

            else
            {
                tabControl.SelectedTab = sixteen;
            }
            
            resetColor();
        }

        public void reset2()
        {
            txtedname.Clear();
            cbxlevel.SelectedIndex = -1;
            cbxtype.SelectedIndex = -1;
        }

        public void reset3()
        {
            txtheight.Clear();
            txtweight.Clear();
            cbxbloodtype.SelectedIndex = -1;

            rtxtcondition.Clear();
            rtxtall.Clear();
           
        }

        public void reset4()
        {
            condate.Value = DateTime.Now.Date;
            txtintname.Clear();
            richconbox.Clear();

        }

        public void reset5()
        {
            txttypeincid.Clear();
            txtincidlocation.Clear();
            rtxtactiontaken.Clear();
            rtxtinciddesc.Clear();

            rbam.Checked = false;
            rbpm.Checked = false;

            cbxhour.SelectedIndex = -1;
            cbxmin.SelectedIndex = -1;

            dateincid.Value = DateTime.Now.Date;
        }

        public void reset6()
        {
            dtpcheck.Value = DateTime.Now.Date;
            txtlocationcheck.Clear();
            rcheckdetails.Clear();
        }

        public void reset7()
        {
            dtfamOverview.DataSource = null;
        }

        private void btned_Click(object sender, EventArgs e)
        {
            lblnamed.Text = lblnamedrpt.Text = lblname.Text;

            if (btned.Text == "Add Info")
            {
                tabControl.SelectedTab = seventh;
            }

            else
            {
                tabControl.SelectedTab = eighth;

                try
                {
                    conn.Open();

                    string[] data = lblnamedrpt.Text.Split(' ');

                    MySqlCommand comm = new MySqlCommand("SELECT school, edutype, level FROM education WHERE caseid = " + id, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();

                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        lblschool.Text = dt.Rows[0]["school"].ToString();
                        lbltype.Text = dt.Rows[0]["edutype"].ToString();
                        lbllevel.Text = dt.Rows[0]["level"].ToString();

                        lbledlvl.Text = dt.Rows[0]["level"].ToString();
                        lbledtype.Text = dt.Rows[0]["edutype"].ToString();
                        lbledschool.Text = dt.Rows[0]["school"].ToString();

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

        private void btnedback_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;

        }

        private void btnadded_Click(object sender, EventArgs e)
        {

            string edname = txtedname.Text, type = cbxtype.Text, level = cbxlevel.Text;

            if (string.IsNullOrEmpty(edname) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(level))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {

                try
                    {

                    conn.Open();


                        MySqlCommand comm = new MySqlCommand("INSERT INTO education(caseid, school, eduType, level) VALUES('" + id + "', '" + edname + "', '" + type + "','" + level + "')", conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("New Info Added!");
                      

                        conn.Close();

                    existsed(id);

                    lbltype.Text = lbledtype.Text = type;
                    lblschool.Text = lbledschool.Text = edname;
                    lbllevel.Text = lbledlvl.Text = level;

                    tabControl.SelectedTab = eighth;

                    reset2();

                }
                
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                        conn.Close();
                    }
                }

            }
        

        private void btncanceled_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
            reset2();
        }

        private void btnhealth_Click_1(object sender, EventArgs e)
        {

            if (btnhealth.Text == "Add Info")
            {
                tabControl.SelectedTab = eleventh;

                btnaddhealth.Text = "Add Info";
            }

            else
            {
                tabControl.SelectedTab = seventeen;
                reloadedithealth(id);
            }
            

  

            lblnamehealth.Text = lblname.Text;
            //reloadhealth(id);
        }

        private void btncancelhealth_Click(object sender, EventArgs e)
        {
            if (btnaddhealth.Text == "Add Info")
            {

                tabControl.SelectedTab = sixteen;

            }

            else
            {
                tabControl.SelectedTab = seventeen;
            }

            reset3();
        }

        private void btnaddhealth_Click(object sender, EventArgs e)
        {

            if (btnaddhealth.Text == "Add Info")
            {
                addhealth();
            }

            else
            {
                edithealth();
            }

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ninth;
            tabconrecords.SelectedTab = tabrecords;

            reloadcon(id);
        }

        private void btnaddconrec_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixth;
        }

        private void btncancon_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ninth;


        }

        private void btncancelcon_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
        }

        private void btncancelviewrec_Click(object sender, EventArgs e)
        {
            tabconrecords.SelectedTab = tabrecords;
            richboxrecords.Clear();
        }

        private void dtgcon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                conn.Open();

                int cid = int.Parse(dtgcon.Rows[e.RowIndex].Cells[0].Value.ToString());

                MySqlCommand comm = new MySqlCommand("SELECT condes, interviewdate, interviewer FROM consultation WHERE cid = " + cid, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    richboxrecords.Text = dt.Rows[0]["condes"].ToString();

                    lbldatecon.Text = Convert.ToDateTime(dt.Rows[0]["interviewdate"]).ToString("MMMM dd, yyyy");
              
                    lblintcon.Text = dt.Rows[0]["interviewer"].ToString();

                }

                tabconrecords.SelectedTab = document;

                conn.Close();

            }

            catch (Exception ee)
            {
                //MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void btnaddcon_Click(object sender, EventArgs e)
        {
            string interviewer = txtintname.Text, condes = richconbox.Text;

            if (string.IsNullOrEmpty(interviewer) || string.IsNullOrEmpty(condes))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {
                try
                {

                    conn.Open();


                    MySqlCommand comm = new MySqlCommand("INSERT INTO consultation(caseid, condes, interviewdate, interviewer) VALUES('" + id + "', '" + condes + "', '" + condate.Value.Date.ToString("yyyyMMdd") + "','" + interviewer + "')", conn);

                    comm.ExecuteNonQuery();

                    MessageBox.Show("Consultation Record Added!");

                    conn.Close();

                    reloadcon(id);

                    tabControl.SelectedTab = ninth;

                    reset4();
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                    conn.Close();
                }
            }
        }

        private void btneditprofile_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = third;

            btnaddeditcase.Text = "Add Changes";
            lbladdeditprofile.Text = "Edit Profile";

            reloadeditinfo(id);
        }

        private void btnbackcasestud_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = first;
        }

        private void btncanfamtype_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourth;

        }

        private void btnfamtype_Click(object sender, EventArgs e)
        {
            if (btnfamtype.Text == "add")
            {
                tabControl.SelectedTab = fifth;
            }
        }

        private void btnbackfam_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;

            reset7();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = twelfth;

            reloadincid(id);

        }

        private void dtincid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int incid = int.Parse(dtincid.Rows[e.RowIndex].Cells[0].Value.ToString());

                tabControl.SelectedTab = thirteen;

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT type, incdate, venue, description, action FROM incident WHERE incidid = " + incid, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    inctype.Text = dt.Rows[0]["type"].ToString();
                    incidlocation.Text = dt.Rows[0]["venue"].ToString();
                    repinciddesc.Text = dt.Rows[0]["description"].ToString();
                    repincidaction.Text = dt.Rows[0]["action"].ToString();

                    lbldateincid.Text = dt.Rows[0]["incdate"].ToString();


                }

                tabControl.SelectedTab = thirteen;

                conn.Close();

            }

            catch (Exception ee)
            {
                //MessageBox.Show("" + ee);
                conn.Close();
            }

            //existshealth(id);

        }

          

        private void btnaddincid_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourteen;
        }

        private void btnbackmainincid_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
        }

        private void btnbackincidrec_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = twelfth;

            reset5();
        }

        private void btnaddincidrecord_Click(object sender, EventArgs e)
        {
            string type = txttypeincid.Text, hour = cbxhour.Text, minute = cbxmin.Text, zone, location = txtincidlocation.Text, desc = rtxtinciddesc.Text, action = rtxtactiontaken.Text;
            
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(minute) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(action) || (rbam.Checked == false && rbpm.Checked == false))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {
                if (rbam.Checked == true)
                {
                    zone = "AM";
                }

                else
                {
                    zone = "PM";
                }
                
                DateTime dt = DateTime.Parse(hour + ":" + minute + " " + zone);

                //dt.ToString("hh:mm tt");

                //DateTime wut = DateTime.ParseExact(dateincid.Value.Date.ToString("yyyy-MM-dd") + " " + dt.ToString(), "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture);
                MessageBox.Show(dateincid.Value.Date.ToString("yyyy-MM-dd"));

                try
                {
                    conn.Open();


                    MySqlCommand comm = new MySqlCommand("INSERT INTO incident(caseid, type, incdate, venue, description, action, dateadded) VALUES('" + id + "', '" + type + "', '" + dateincid.Value.Date.ToString("yyyy-MM-dd ") + dt.ToString("hh:mm tt") + "','" + location + "', '" + desc + "', '" + action + "', '" + DateTime.Now.ToString("yyyy-MM-dd") +"')", conn);

                    comm.ExecuteNonQuery();

                    MessageBox.Show("Incident Record Added!");

                    conn.Close();

                    reloadincid(id);

                    tabControl.SelectedTab = twelfth;
                   
                    reset5();
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                    conn.Close();
                    
                }

            }

            
        }

        private void btnbackmainincid_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
        }

        private void btnaddincid_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tenth;
        }

        private void btnbackfrominc_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = twelfth;
        }

        private void btnbackfrominvolve_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tenth;
        }

        private void btnbackfromhealth_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = seventeen;
        }

        private void btngotohealth_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = eighteen;
           
        }

        private void btnbackfromhealthview_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
        }

        private void btnedithealth_Click(object sender, EventArgs e)
        {
            btnaddhealth.Text = "Add Changes";

            txtheight.Text = lblvheight.Text;
            txtweight.Text = lblvweight.Text;
            cbxbloodtype.Text = lblvblood.Text;
            rtxtall.Text = rviewall.Text;
            rtxtcondition.Text = rviewcondition.Text;

            tabControl.SelectedTab = eleventh;
        }

        private void btngotocheckup_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifteen;

            reloadhealth(id);

        }

        private void btnbackfromcheck_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifteen;

            reset6();
        }

        private void dtghealth_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int checkid = int.Parse(dtghealth.Rows[e.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show(checkid.ToString());
                tabControl.SelectedTab = nineteen;

                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT checkupdetails, checkupdate, checkuplocation FROM checkup WHERE checkid = " + checkid, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    rvcheckdetails.Text = dt.Rows[0]["checkupdetails"].ToString();

                    lblcheckdate.Text = Convert.ToDateTime(dt.Rows[0]["checkupdate"]).ToString("MMMM dd, yyyy");
                    lbllocationcheck.Text = dt.Rows[0]["checkuplocation"].ToString();


                }

                conn.Close();

            }

            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        public void gethid(int id)
        {
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT hid FROM health WHERE caseid = " + id, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                hid = int.Parse(dt.Rows[0]["hid"].ToString());

                conn.Close();

            }


            catch (Exception ee)
            {

                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtfamOverview.EndEdit();

            try
            {
                conn.Open();

                for (int i = 0; i < dtfamOverview.Rows.Count; i++)
                {
                    //MySqlCommand comm = new MySqlCommand("INSERT INTO member(familyid, firstname, lastname, type, gender, birthdate, relationship, action, dateadded) VALUES('" + id + "', '" + type + "', '" + dateincid.Value.Date.ToString("yyyy-MM-dd ") + dt.ToString("hh:mm tt") + "','" + location + "', '" + desc + "', '" + action + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')", conn);

                    //comm.ExecuteNonQuery();
                }

            }


            catch (Exception ee)
            {

                MessageBox.Show("" + ee);
                conn.Close();
            }
        }

        private void bttnbackfromcheckrec_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fifteen;
        }

        private void btnaddcheckuprec_Click(object sender, EventArgs e)
        {
            string location = txtlocationcheck.Text, details = rcheckdetails.Text;

            gethid(id);

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(details))
            {
                MessageBox.Show("Please fill out empty fields.");
            }

            else
            {
                try
                {

                    conn.Open();


                    MySqlCommand comm = new MySqlCommand("INSERT INTO checkup(hid, checkupdetails, checkupdate, checkuplocation) VALUES('" + hid + "', '" + details + "', '" + dtpcheck.Value.Date.ToString("yyyyMMdd") + "', '" + location + "')", conn);
                    MessageBox.Show(hid.ToString());
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Checkup Record Added!");

                    conn.Close();

                    reloadhealth(id);

                    tabControl.SelectedTab = fifteen;

                    reset6();
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                    conn.Close();
                }
            }
        }

        private void btnaddfamtype_Click(object sender, EventArgs e)
        {
            string famtype = cbxfamtype.Text;

            if (string.IsNullOrEmpty(famtype))
            {
                MessageBox.Show("Fill in the empty fields.");
            }

            else
            {
                try
                {
                    conn.Open();


                    MySqlCommand comm = new MySqlCommand("INSERT INTO family(caseid, famtype) VALUES('" + id + "', '" + famtype + "')", conn);

                    comm.ExecuteNonQuery();

                    MessageBox.Show("Family Type Added!");

                    conn.Close();

                    existsfam(id);

                    reloadfam(id);

                    tabControl.SelectedTab = ninth;

                    cbxfamtype.SelectedIndex = -1;
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                    conn.Close();
                }
            }
        }
    }
}
