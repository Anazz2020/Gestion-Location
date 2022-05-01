namespace Gestion_Location
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parNLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parCommunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parLogementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficherToolStripMenuItem,
            this.mToolStripMenuItem,
            this.rechercherToolStripMenuItem,
            this.afficheToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficherToolStripMenuItem
            // 
            this.ficherToolStripMenuItem.Name = "ficherToolStripMenuItem";
            this.ficherToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.ficherToolStripMenuItem.Text = "Ficher";
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationToolStripMenuItem,
            this.logementToolStripMenuItem});
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.mToolStripMenuItem.Text = "Mise à jour";
            // 
            // locationToolStripMenuItem
            // 
            this.locationToolStripMenuItem.Name = "locationToolStripMenuItem";
            this.locationToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.locationToolStripMenuItem.Text = "Location";
            this.locationToolStripMenuItem.Click += new System.EventHandler(this.locationToolStripMenuItem_Click);
            // 
            // logementToolStripMenuItem
            // 
            this.logementToolStripMenuItem.Name = "logementToolStripMenuItem";
            this.logementToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.logementToolStripMenuItem.Text = "Logement";
            this.logementToolStripMenuItem.Click += new System.EventHandler(this.logementToolStripMenuItem_Click);
            // 
            // rechercherToolStripMenuItem
            // 
            this.rechercherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individusToolStripMenuItem,
            this.parDateToolStripMenuItem});
            this.rechercherToolStripMenuItem.Name = "rechercherToolStripMenuItem";
            this.rechercherToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.rechercherToolStripMenuItem.Text = "Rechercher";
            // 
            // individusToolStripMenuItem
            // 
            this.individusToolStripMenuItem.Name = "individusToolStripMenuItem";
            this.individusToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.individusToolStripMenuItem.Text = "Le montant total ";
            this.individusToolStripMenuItem.Click += new System.EventHandler(this.individusToolStripMenuItem_Click);
            // 
            // parDateToolStripMenuItem
            // 
            this.parDateToolStripMenuItem.Name = "parDateToolStripMenuItem";
            this.parDateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.parDateToolStripMenuItem.Text = "Par Date";
            this.parDateToolStripMenuItem.Click += new System.EventHandler(this.parDateToolStripMenuItem_Click);
            // 
            // afficheToolStripMenuItem
            // 
            this.afficheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImportToolStripMenuItem});
            this.afficheToolStripMenuItem.Name = "afficheToolStripMenuItem";
            this.afficheToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.afficheToolStripMenuItem.Text = "Affiche ";
            this.afficheToolStripMenuItem.Click += new System.EventHandler(this.afficheToolStripMenuItem_Click);
            // 
            // exportImportToolStripMenuItem
            // 
            this.exportImportToolStripMenuItem.Name = "exportImportToolStripMenuItem";
            this.exportImportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportImportToolStripMenuItem.Text = "Export & Import";
            this.exportImportToolStripMenuItem.Click += new System.EventHandler(this.exportImportToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parNLocationToolStripMenuItem,
            this.parCommunToolStripMenuItem,
            this.parLogementsToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.reportToolStripMenuItem.Text = "L \'état d\'impression";
            // 
            // parNLocationToolStripMenuItem
            // 
            this.parNLocationToolStripMenuItem.Name = "parNLocationToolStripMenuItem";
            this.parNLocationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parNLocationToolStripMenuItem.Text = "Par N° Location";
            this.parNLocationToolStripMenuItem.Click += new System.EventHandler(this.parNLocationToolStripMenuItem_Click);
            // 
            // parCommunToolStripMenuItem
            // 
            this.parCommunToolStripMenuItem.Name = "parCommunToolStripMenuItem";
            this.parCommunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parCommunToolStripMenuItem.Text = "Par Communes";
            this.parCommunToolStripMenuItem.Click += new System.EventHandler(this.parCommunToolStripMenuItem_Click);
            // 
            // parLogementsToolStripMenuItem
            // 
            this.parLogementsToolStripMenuItem.Name = "parLogementsToolStripMenuItem";
            this.parLogementsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parLogementsToolStripMenuItem.Text = "Par Logements";
            this.parLogementsToolStripMenuItem.Click += new System.EventHandler(this.parLogementsToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechercherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parNLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parCommunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parLogementsToolStripMenuItem;
    }
}

