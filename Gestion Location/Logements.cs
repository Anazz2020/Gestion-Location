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
    public partial class Logements : Form
    {
        public Logements()
        {
            InitializeComponent();
        }
        public static String S = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        public SqlConnection con = new SqlConnection(S);
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataRow ligne;
        public SqlCommandBuilder cmd_b;

        //Remplier Grid
        public void Grid()
        {
            using (SqlConnection con = new SqlConnection(S))
            {
                if (dt.Rows != null)
                {
                    dt.Rows.Clear();
                }
                con.Open();
                cmd = new SqlCommand("select *from Logements ", con);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                this.dataGridView1.DataSource = dt;
                con.Close();


            }
        }
        //Remplier Type Logements
        public void Comb_Type()
        {
            using (SqlConnection con = new SqlConnection(S))
            {
                con.Open();
                cmd = new SqlCommand("select * from TypeLogements ", con);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Type_Logements ";
                comboBox1.ValueMember = "Type_Logements";
                dr.Close();
                con.Close();
            }
        }
        //Remplier Comb_Quartiers
        public void Comb_Quartiers()
        {
            using (SqlConnection con = new SqlConnection(S))
            {
                con.Open();
                cmd = new SqlCommand("select ID_Quartier,Nom_Quartier from Quartiers ", con);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Nom_Quartier";
                comboBox2.ValueMember = "ID_Quartier";
                dr.Close();
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            Grid();
            Comb_Type();
            Comb_Quartiers();
            if (dt.Rows.Count > 0)
            {
                Afficher(RowNumber);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(S))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("insert into Logements(N_Logements,Adresse,Superficie,Loyer,Type_Logements,ID_Quartier) values (@N_Logements,@Adresse,@Superficie,@Loyer,@Type_Logements,@ID_Quartier)", con);
                    cmd.Parameters.AddWithValue("@N_Logements", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Adresse", this.textBox3.Text);
                    cmd.Parameters.AddWithValue("@Superficie", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@Loyer", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@Type_Logements", this.comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Quartier", this.comboBox2.SelectedValue);

                    con.Open();
                    int action = cmd.ExecuteNonQuery();
                    if (action > 0)
                    {
                        MessageBox.Show("Bien ajouter");
                    }
                    else
                    {
                        MessageBox.Show("Erreur ajouter !!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(S))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("update Logements set N_Logements=@N_Logements ,Adresse=@Adresse , Superficie=@Superficie , Loyer=@Loyer , Type_Logements=@Type_Logements , ID_Quartier=@ID_Quartier Where N_Logements=@N_Logements ", con);
                    cmd.Parameters.AddWithValue("@N_Logements", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Adresse", this.textBox3.Text);
                    cmd.Parameters.AddWithValue("@Superficie", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@Loyer", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@Type_Logements", this.comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Quartier", this.comboBox2.SelectedValue);

                    con.Open();
                    int action = cmd.ExecuteNonQuery();
                    if (action > 0)
                    {
                        MessageBox.Show("Bien modifier");
                    }
                    else
                    {
                        MessageBox.Show("Erreur modifier !!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez vraiement supprimer l'Logement  ? ", "Supprimer un utilisaeur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
            {


                using (SqlConnection con = new SqlConnection(S))
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("Delete from Logements where N_Logements=@N_Logements ", con);
                        cmd.Parameters.AddWithValue("@N_Logements", this.textBox1.Text);

                        con.Open();
                        int action = cmd.ExecuteNonQuery();
                        if (action > 0)
                            if (action > 0)
                            {
                                MessageBox.Show("Bien supprimer");
                            }
                            else
                            {
                                MessageBox.Show("Erreur supprimer !!!");
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        // Methode Afficher
        int RowNumber = 0;
        public void Afficher(int RowNumber)
        {
            this.textBox1.Text = dt.Rows[RowNumber].ItemArray[0].ToString();
            this.textBox3.Text = dt.Rows[RowNumber].ItemArray[1].ToString();
            this.textBox4.Text = dt.Rows[RowNumber].ItemArray[2].ToString();
            this.textBox5.Text = dt.Rows[RowNumber].ItemArray[3].ToString();
            this.comboBox1.SelectedValue = dt.Rows[RowNumber].ItemArray[4].ToString();
            this. comboBox2.SelectedValue = dt.Rows[RowNumber].ItemArray[5].ToString();
            this.dataGridView1.Rows[RowNumber].Selected = true;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Dernier :
            RowNumber = dt.Rows.Count - 1;
            Afficher(RowNumber);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Premier :
            RowNumber = 0;
            Afficher(RowNumber);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Suivant :
            if (RowNumber == dt.Rows.Count - 1)
            {
                RowNumber = 0;
            }
            else
            {
                RowNumber += 1;
            }
            Afficher(RowNumber);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Précédent :
            if (RowNumber == 0)
            {
                RowNumber = dt.Rows.Count - 1;
            }
            else
            {
                RowNumber -= 1;
            }
            Afficher(RowNumber);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowNumber = this.dataGridView1.CurrentRow.Index;
                Afficher(RowNumber);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(S))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Logements WHERE N_Logements=@N_Logements", con);
                    cmd.Parameters.AddWithValue("@N_Logements", this.textBox2.Text);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        this.textBox1.Text = dr[0].ToString();
                        this.textBox3.Text = dr[1].ToString();
                        this.textBox4.Text = dr[2].ToString();
                        this.textBox5.Text = dr[3].ToString();
                        this.comboBox1.SelectedValue = dr[4].ToString();
                        this.comboBox2.SelectedValue = dr[5].ToString();
                    }
                                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
