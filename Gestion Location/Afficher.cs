using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Gestion_Location
{
    public partial class Afficher : Form
    {
        public Afficher()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["str"].ConnectionString);
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        DateTime Today = DateTime.Now;
        public void Data()
        {
            dap = new SqlDataAdapter("select * from Communes ", con);
            dap.Fill(ds, "Communes");
            dataGridView1.DataSource = ds.Tables["Communes"];
        }
        //void ExpExl()
        //{
        //    Microsoft.Office.Interop.Excel._Application Exlapp = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel._Workbook workbook = Exlapp.Workbooks.Add(Type.Missing);



        //    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
        //    {
        //        Exlapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
        //    }

        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        //        {
        //            Exlapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
        //        }
        //    }
        //    saveFileDialog1.Filter = "Excel Files |.*xlsx";
        //    saveFileDialog1.FileName = "Excel " + Today.ToString("MM-dd-yyyy hh.mm.ss") + ".xlsx";
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        workbook.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        MessageBox.Show("Economiser avec Succes");
        //    }

        //    Exlapp.Quit();
        //}

        void ExpCsv()
        {


            //string filename = "";
            //saveFileDialog1.Filter = "CSV (*.csv)|*.csv";
            //saveFileDialog1.FileName = "Excel " + Today.ToString("MM-dd-yyyy hh.mm.ss") + ".csv";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show("Data will be exported and you will be notified when it is ready.");
            //    if (File.Exists(filename))
            //    {
            //        try
            //        {
            //            File.Delete(filename);
            //        }
            //        catch (IOException ex)
            //        {
            //            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
            //        }
            //    }
                
            //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //    {
            //        dataGridView1.Columns.Count += dataGridView1.Columns[i].HeaderText + ",";
            //    }
            //    for (int i = 1; i < dataGridView1.RowCount; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.RowCount; j++)
            //        {
            //            output.[i + 2, j + 1] += dataGridView1.Rows[i].Cells[j].Value.ToString() + ",";
            //        }
            //    }
            //    System.IO.File.WriteAllLines(saveFileDialog1.FileName, output, System.Text.Encoding.UTF8);
            //    MessageBox.Show("Your file was generated and its ready for use.");
            //}

        }

        void ExpText()
        {
            string exptxt = null;
            saveFileDialog1.Filter = "Text Files |.*txt";
            saveFileDialog1.FileName = "Text " + Today.ToString("MM-dd-yyyy hh.mm.ss") + ".txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exptxt = saveFileDialog1.FileName;
            }
            StreamWriter str = new StreamWriter((string)null);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                str.WriteLine(ds.Tables["communes "].Rows[i][0].ToString() + "   " + ds.Tables["communes "].Rows[i][1].ToString() + "   " + ds.Tables["Produit"].Rows[i][2].ToString() + "   " + ds.Tables["communes "].Rows[i][3].ToString());
            }
            str.Close();
            MessageBox.Show("Economiser avec Succes");
        }
        void ExpHtml()
        {
            Data();
            string exphtml = null;
            saveFileDialog1.Filter = "HTML5 Files |.*html";
            saveFileDialog1.FileName = "Html " + Today.ToString("MM-dd-yyyy hh.mm.ss") + ".html";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exphtml = saveFileDialog1.FileName;
            }
            using (StreamWriter str = new StreamWriter(exphtml))
            {
                FileInfo info = new FileInfo(exphtml);
                StringBuilder StB = new StringBuilder();
                StB.AppendFormat("<!DOCKTYPE>");
                StB.AppendFormat("<html>");
                StB.AppendFormat("<head>");
                StB.AppendFormat("<meta charset='utf-8'/>");
                StB.AppendFormat("<title> Gestio Produit </title>");
                StB.AppendFormat("</head>");
                StB.AppendFormat("<body>");
                StB.AppendFormat("<table border=1 cellspacing = 10 cellspadding = 10 style='border-collapse:collapse';");
                StB.AppendFormat("<tr>");
                foreach (DataColumn c in ds.Tables["Communes"].Columns)
                {
                    StB.AppendFormat("<th>" + c.ColumnName.ToString() + "</th>");
                }
                StB.AppendFormat("</tr>");
                foreach (DataRow r in ds.Tables["Communes"].Rows)
                {
                    StB.AppendFormat("<tr>");
                    for (int i = 0; i < ds.Tables["Communes"].Columns.Count; i++)
                    {
                        StB.AppendFormat("<td>" + r[i].ToString() + "</td>");
                    }
                    StB.AppendFormat("</tr>");
                }
                StB.AppendFormat("</table>");
                StB.AppendFormat("</body>");
                StB.AppendFormat("</html>");
                str.WriteLine(StB.ToString());
                MessageBox.Show("Economiser avec Succes");
            }

        }


        public void ExpXml()
        {
            string expxml = null;
            saveFileDialog1.Filter = "Xml Files |.*xml";
            saveFileDialog1.FileName = "Xml " + Today.ToString("MM-dd-yyyy hh.mm.ss") + ".xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                expxml = saveFileDialog1.FileName;

            }
            ds.WriteXml(expxml);
            MessageBox.Show("Economiser avec Succes");

        }


        private void Afficher_Load(object sender, EventArgs e)
        {
            Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show(" Merci Checked Button ");
                return;
            }
            if (radioButton1.Checked)
            {
                //ExpExl();
            }
            if (radioButton2.Checked)
            {
                ExpXml();
            }
            if (radioButton3.Checked)
            {
                ExpHtml();
            }
            if (radioButton4.Checked)
            {
                ExpCsv();
            }
        }
    }
}
