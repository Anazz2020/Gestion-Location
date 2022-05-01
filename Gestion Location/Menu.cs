using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Location
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Location F1 = new Location();
            F1.Show();
        }

        private void logementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logements L2 = new Logements();
            L2.Show();
        }

        private void individusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rechercher1 R1 = new Rechercher1();
            R1.Show();
        }

        private void parDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rechercher2 R2 = new Rechercher2();
            R2.Show();
        }

        private void afficheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Afficher A = new Afficher();
            //A.Show();
        }

        private void parNLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Location N = new Report_Location();
            N.Show();
        }

        private void parCommunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Individus I1 = new Report_Individus();
            I1.Show();
        }

        private void parLogementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type T = new Type();
            T.Show();
        }

        private void exportImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afficher A = new Afficher();
            A.Show();
        }
    }
}
