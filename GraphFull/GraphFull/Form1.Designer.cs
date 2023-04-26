namespace GraphFull
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationMI = new System.Windows.Forms.ToolStripMenuItem();
            this.aSternMI = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMI = new System.Windows.Forms.ToolStripMenuItem();
            this.newMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.printMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMI,
            this.navigationMI});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 33);
            this.menu.TabIndex = 0;
            this.menu.Text = "Menu";
            // 
            // fileMI
            // 
            this.fileMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMI,
            this.toolStripMenuItem1,
            this.openMI,
            this.saveMI,
            this.toolStripMenuItem2,
            this.printMI,
            this.toolStripMenuItem3,
            this.exitMI});
            this.fileMI.Name = "fileMI";
            this.fileMI.Size = new System.Drawing.Size(54, 29);
            this.fileMI.Text = "File";
            // 
            // navigationMI
            // 
            this.navigationMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSternMI,
            this.resetMI});
            this.navigationMI.Name = "navigationMI";
            this.navigationMI.Size = new System.Drawing.Size(114, 29);
            this.navigationMI.Text = "Navigation";
            // 
            // aSternMI
            // 
            this.aSternMI.Enabled = false;
            this.aSternMI.Name = "aSternMI";
            this.aSternMI.Size = new System.Drawing.Size(270, 34);
            this.aSternMI.Text = "AStern";
            this.aSternMI.Click += new System.EventHandler(this.aSternMI_Click);
            // 
            // resetMI
            // 
            this.resetMI.Name = "resetMI";
            this.resetMI.Size = new System.Drawing.Size(270, 34);
            this.resetMI.Text = "Reset";
            this.resetMI.Click += new System.EventHandler(this.resetMI_Click);
            // 
            // newMI
            // 
            this.newMI.Name = "newMI";
            this.newMI.Size = new System.Drawing.Size(270, 34);
            this.newMI.Text = "New";
            this.newMI.Click += new System.EventHandler(this.newMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // openMI
            // 
            this.openMI.Name = "openMI";
            this.openMI.Size = new System.Drawing.Size(270, 34);
            this.openMI.Text = "Open";
            this.openMI.Click += new System.EventHandler(this.openMI_Click);
            // 
            // saveMI
            // 
            this.saveMI.Name = "saveMI";
            this.saveMI.Size = new System.Drawing.Size(270, 34);
            this.saveMI.Text = "Save";
            this.saveMI.Click += new System.EventHandler(this.saveMI_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 6);
            // 
            // printMI
            // 
            this.printMI.Name = "printMI";
            this.printMI.Size = new System.Drawing.Size(270, 34);
            this.printMI.Text = "Print";
            this.printMI.Click += new System.EventHandler(this.printMI_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(267, 6);
            // 
            // exitMI
            // 
            this.exitMI.Name = "exitMI";
            this.exitMI.Size = new System.Drawing.Size(270, 34);
            this.exitMI.Text = "Exit";
            this.exitMI.Click += new System.EventHandler(this.exitMI_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Document = this.pd;
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "printPreview";
            this.printPreview.Visible = false;
            // 
            // pd
            // 
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMI;
        private System.Windows.Forms.ToolStripMenuItem newMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openMI;
        private System.Windows.Forms.ToolStripMenuItem saveMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem printMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitMI;
        private System.Windows.Forms.ToolStripMenuItem navigationMI;
        private System.Windows.Forms.ToolStripMenuItem aSternMI;
        private System.Windows.Forms.ToolStripMenuItem resetMI;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument pd;
    }
}

