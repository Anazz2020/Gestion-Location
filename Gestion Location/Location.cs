using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Gestion_Location
{
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataRow ligne;
        public SqlCommandBuilder cmd_b;

        public void Grid()
        {
            if (ds.Tables["Location"] != null)
            {
                ds.Tables["Location"].Clear();
            }
            dap = new SqlDataAdapter("select * from Location", con);
            dap.Fill(ds, "Location");
            dataGridView1.DataSource = ds.Tables["Location"];
        }
        public void Combox1()
        {
            dap = new SqlDataAdapter("select N_identite,Nom +'  '+ Prenom As [N] from Individus", con);
            dap.Fill(ds, "Individus");
            comboBox1.DataSource = ds.Tables["Individus"];
            comboBox1.DisplayMember = "N";
            comboBox1.ValueMember = "N_identite";
        }

        //remplier Combox2
        public void Combox2()
        {
            dap = new SqlDataAdapter("select N_Logements,+'N°'+cast(N_Logements as varchar(10)) +' _ '+ Adresse As [N] from Logements", con);
            dap.Fill(ds, "Logements");
            comboBox2.DataSource = ds.Tables["Logements"];
            comboBox2.DisplayMember = "N";
            comboBox2.ValueMember = "N_Logements";
        }

        private void Location_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
            Grid();
            Combox1();
            Combox2();
            if (ds.Tables["Location"].Rows.Count > 0)
            {
                Afficher(RowNumber);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.CustomFormat = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show(" Merci de rempler tour les champs");
                    return;
                }

                ligne = ds.Tables["Location"].NewRow();
                ligne[0] = textBox1.Text;
                ligne[1] = dateTimePicker1.Value.ToShortTimeString();
                ligne[2] = dateTimePicker2.Value.ToShortTimeString();
                ligne[3] = comboBox1.SelectedValue;
                ligne[4] = comboBox2.SelectedValue;

                for (int i = 0; i < ds.Tables["Location"].Rows.Count; i++)
                {
                    if (textBox1.Text == ds.Tables["Location"].Rows[i][0].ToString())
                    {
                        MessageBox.Show("Ce Location existe deja");
                        return;
                    }

                }

                ds.Tables["Location"].Rows.Add(ligne);
                MessageBox.Show("Location est Ajouter Succes");
                dataGridView1.DataSource = ds.Tables["Location"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show(" Merci de rempler tour les champs");
                    return;
                }

                bool action = false;
                for (int i = 0; i < ds.Tables["Location"].Rows.Count; i++)
                {
                    if (textBox1.Text == ds.Tables["Location"].Rows[i][0].ToString())
                    {
                        action = true;
                        ds.Tables["Location"].Rows[i][0] = Convert.ToInt32(textBox1.Text) ;
                        ds.Tables["Location"].Rows[i][1] = dateTimePicker1.Value;
                        ds.Tables["Location"].Rows[i][2] = dateTimePicker2.Value;
                        ds.Tables["Location"].Rows[i][3] = comboBox1.SelectedValue;
                        ds.Tables["Location"].Rows[i][4] = comboBox2.SelectedValue;
                        MessageBox.Show("Ce Location modifier avec succes");
                        dataGridView1.DataSource = ds.Tables["Location"];
                        break;
                    }

                }
                if (action == false)
                {
                    MessageBox.Show(" Ce Location existe deja");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" Merci de rempler tour les champs");
                    return;
                }
                bool action = false;
                for (int i = 0; i < ds.Tables["Location"].Rows.Count; i++)
                {
                    if (textBox1.Text == ds.Tables["Location"].Rows[i][0].ToString())
                    {
                        action = true;
                        ds.Tables["Location"].Rows[i].Delete();
                        MessageBox.Show("Location est supprimer avec succes");
                        dataGridView1.DataSource = ds.Tables["Location"];
                        break;
                    }

                }
                if (action == false)
                {
                    MessageBox.Show(" Ce Location existe deja");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        // Void Eng
        public void ENRG()
        {
            cmd_b = new SqlCommandBuilder(dap);
            dap.Update(ds, "Location");
            dt.Clear();
            dap.Fill(dt);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd_b = new SqlCommandBuilder();
            dap.Update(ds, "Location");
            MessageBox.Show("Donnees enregister avec succes");
        }
        public void Recherche(string R)
        {

            string query = "select  * from Location where N_Location = '" + R + "'";
            dap = new SqlDataAdapter(query, con);
            dap.Fill(ds, "Location");
            dataGridView1.DataSource = ds.Tables["Location"];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Location"] != null)
            {
                ds.Tables["Location"].Clear();
            }
            string R = textBox2.Text;
            Recherche(R);
        }

        int RowNumber = 0;
        public void Afficher(int RowNumber)
        {
            this.textBox1.Text = ds.Tables["Location"].Rows[RowNumber].ItemArray[0].ToString();
            this.dateTimePicker1.CustomFormat = ds.Tables["Location"].Rows[RowNumber].ItemArray[1].ToString();
            this.dateTimePicker2.CustomFormat = ds.Tables["Location"].Rows[RowNumber].ItemArray[2].ToString();
            this.comboBox1.SelectedValue = ds.Tables["Location"].Rows[RowNumber].ItemArray[3].ToString();
            this.comboBox2.SelectedValue = ds.Tables["Location"].Rows[RowNumber].ItemArray[4].ToString();       
            this.dataGridView1.Rows[RowNumber].Selected = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //P
            if (RowNumber == 0)
            {
                RowNumber = ds.Tables["Location"].Rows.Count - 1;
            }
            else
            {
                RowNumber--;
            }
            Afficher(RowNumber);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RowNumber = 0;
            Afficher(RowNumber);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Suivant :
            if (RowNumber == ds.Tables["Location"].Rows.Count - 1)
            {
                RowNumber = 0;
            }
            else
            {
                RowNumber++;
            }
            Afficher(RowNumber);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Dernier :
            RowNumber = ds.Tables["Location"].Rows.Count - 1;
            Afficher(RowNumber);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                RowNumber = e.RowIndex;
                Afficher(RowNumber);
                this.dataGridView1.Rows[RowNumber].Selected = true;

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
