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

namespace PrototypeSAD
{

    public partial class casestudy : Form
    {
        public Form2 ref_to_main { get; set; }
        public MySqlConnection conn;

        public int id;
        public string filename;

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

            lbladdeditprofile.Text = "New Profile";
            btnaddeditcase.Text = "Add Profile";

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid, lastname, firstname FROM casestudyprofile", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtgcs.DataSource = dt;
                    dtgcs.Columns[0].Visible = false;
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

                MySqlCommand comm = new MySqlCommand("SELECT caseid, lastname, firstname FROM casestudyprofile", conn);
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
            /*var celladded = new DataGridViewCell();
            var cellcadded = new DataGridViewCellCollection
            {
                DataGridViewCell = celladded
            };
            var cellradded = new DataGridViewRow
            {
                DataGridViewCellCollection = cellcadded
            };
            DataGridView1.Rows.add(cellradded);

            dtfamOverview.Rows.Add(tae);*/
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

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = fourth;
            resetColor();
            btnCaseStudy.BackColor = Color.Gray;

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
            for (int m = 0; m <= dtgcs.ColumnCount - 1; m++)
                dtgcs.Columns[m].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            for (int m = 0; m <= dtgcon.ColumnCount - 1; m++)
                dtgcon.Columns[m].SortMode = DataGridViewColumnSortMode.NotSortable;

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
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString() + "reloadmem");

                
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

        public void existsfam(int id)
        {

            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT caseid FROM family WHERE caseid = " + id, conn);

                int UserExist = (int)comm.ExecuteScalar();

                btned.Text = (UserExist > 0) ? "Edit Info" : "Add Info"; //put add info on catch



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

            dtbirth.Value = DateTime.Now;
            dtjoin.Value = DateTime.Now;

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
           
        }

        public void reset4()
        {
            condate.Value = DateTime.Now;
            txtintname.Clear();
            richconbox.Clear();

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

            lblnamehealth.Text = lblname.Text;

            if (btnhealth.Text == "Add Info")
            {
                tabControl.SelectedTab = eleventh;
            }

            //iput pa dis

        }

        private void btncancelhealth_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = sixteen;
        }

        private void btnaddhealth_Click(object sender, EventArgs e)
        {
            string blood = cbxbloodtype.Text;
            int height, weight;

            if (string.IsNullOrEmpty(blood) || string.IsNullOrEmpty(txtheight.Text) || string.IsNullOrEmpty(txtweight.Text))
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


                        MySqlCommand comm = new MySqlCommand("INSERT INTO health(caseid, height, weight, bloodtype) VALUES('" + id + "', '" + height + "', '" + weight + "','" + blood + "')", conn);

                        comm.ExecuteNonQuery();

                        MessageBox.Show("New Info Added!");

                        conn.Close();

                        existshealth(id);

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

                MySqlCommand comm = new MySqlCommand("SELECT condes FROM consultation WHERE cid = " + cid, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();

                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    richboxrecords.Text = dt.Rows[0]["condes"].ToString();

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
