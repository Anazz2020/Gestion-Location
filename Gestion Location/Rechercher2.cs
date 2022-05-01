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
    public partial class Rechercher2 : Form
    {
        public Rechercher2()
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
            if (ds.Tables["Location "] != null)
            {
                ds.Tables["Location "].Clear();
            }
            cmd = new SqlCommand("select * from Location ", con);
            dap = new SqlDataAdapter(cmd);
            dap.Fill(ds, "Location ");
            dataGridView1.DataSource = ds.Tables["Location "];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT  Individus.N_identite, Individus.Nom, Individus.Prenom, Individus.DateNaissance, Individus.N_Telephone, Location.N_Location FROM  Individus INNER JOIN Location ON Individus.N_identite = Location.N_identite  Where Location.Date_debut between @Date1 and @Date2", con);
            cmd.Parameters.AddWithValue("@Date1", SqlDbType.Date).Value = dateTimePicker1.Value;
            cmd.Parameters.AddWithValue("@Date2", SqlDbType.Date).Value = dateTimePicker2.Value;
            dap = new SqlDataAdapter(cmd);
            dap.Fill(ds, "Location");
            dataGridView1.DataSource = ds.Tables["Location"];
        }

        private void Rechercher2_Load(object sender, EventArgs e)
        {
            RemplirGrid();
        }
    }
}
