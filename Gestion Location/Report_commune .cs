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
using Microsoft.Reporting.WinForms;
using System.Configuration;

namespace Gestion_Location
{
    public partial class Report_Individus : Form
    {
        public Report_Individus()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        private void Report_Individus_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Quartiers' table. You can move, or remove it, as needed.
            this.QuartiersTableAdapter.Fill(this.DataSet1.Quartiers);
            // TODO: This line of code loads data into the 'DataSet1.Quartiers' table. You can move, or remove it, as needed.
            this.QuartiersTableAdapter.Fill(this.DataSet1.Quartiers);

            this.reportViewer1.RefreshReport();
            NewMethod();
        }
        private void NewMethod()
        {
            dap = new SqlDataAdapter("select * From  Communes", con);
            dap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nom_communes";
            comboBox1.ValueMember = "ID_communes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.QuartiersTableAdapter.FillBy(this.DataSet1.Quartiers,Convert.ToInt32(comboBox1.SelectedValue));
            this.reportViewer1.RefreshReport();
        }
    }
}
