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
using Microsoft.Reporting.WinForms;

namespace Gestion_Location
{
    public partial class Report_Location : Form
    {
        public Report_Location()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Individus' table. You can move, or remove it, as needed.
            this.IndividusTableAdapter.Fill(this.DataSet1.Individus);


            this.reportViewer1.RefreshReport();

            NewMethod();

        }

        private void NewMethod()
        {
            dap = new SqlDataAdapter("select N_identite From  Individus", con);
            dap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "N_identite";
            comboBox1.ValueMember = "N_identite";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Individus' table. You can move, or remove it, as needed.
            this.IndividusTableAdapter.FillBy(this.DataSet1.Individus, Convert.ToInt32(comboBox1.SelectedValue));
            this.reportViewer1.RefreshReport();
        }
    }
}
