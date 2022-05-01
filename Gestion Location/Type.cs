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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();


        private void Type_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Logements' table. You can move, or remove it, as needed.
            this.LogementsTableAdapter.Fill(this.DataSet1.Logements);

            this.reportViewer1.RefreshReport();
        }
        
    }
}
