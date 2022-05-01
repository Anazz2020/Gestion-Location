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
    public partial class Rechercher1 : Form
    {
        public Rechercher1()
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

        public void RemplirGrid()
        {
            if (ds.Tables["Location"] != null)
            {
                ds.Tables["Location"].Clear();
            }
            cmd = new SqlCommand("select * from Location ", con);
            dap = new SqlDataAdapter(cmd);
            dap.Fill(ds, "Location ");
            dataGridView1.DataSource = ds.Tables["Location "];

        }
        public void RemplirCom()
        {

            dap = new SqlDataAdapter("select N_identite,Nom +'  '+ Prenom As [N] from Individus", con);
            dap.Fill(ds, "Individus");
            comboBox1.DataSource = ds.Tables["Individus"];
            comboBox1.DisplayMember = "N";
            comboBox1.ValueMember = "N_identite";

        }

        private void Rechercher1_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            RemplirCom();
            RemplirGrid();
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dap = new SqlDataAdapter("select * from Location where N_Location = '" + comboBox1.SelectedValue + "'", con);
            dap.Fill(ds, "Location");
            dataGridView1.DataSource = ds.Tables["Location"];
        }
    }
}
