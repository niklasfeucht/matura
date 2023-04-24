
namespace OperatorTree
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
            this.components = new System.ComponentModel.Container();
            this.cmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.operandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblValid = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.lblInfix = new System.Windows.Forms.Label();
            this.lblPostfix = new System.Windows.Forms.Label();
            this.cmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenu
            // 
            this.cmenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operandToolStripMenuItem,
            this.operatorToolStripMenuItem});
            this.cmenu.Name = "cmenu";
            this.cmenu.Size = new System.Drawing.Size(157, 68);
            // 
            // operandToolStripMenuItem
            // 
            this.operandToolStripMenuItem.Name = "operandToolStripMenuItem";
            this.operandToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.operandToolStripMenuItem.Text = "Operand";
            this.operandToolStripMenuItem.Click += new System.EventHandler(this.operandToolStripMenuItem_Click);
            // 
            // operatorToolStripMenuItem
            // 
            this.operatorToolStripMenuItem.Name = "operatorToolStripMenuItem";
            this.operatorToolStripMenuItem.Size = new System.Drawing.Size(156, 32);
            this.operatorToolStripMenuItem.Text = "Operator";
            this.operatorToolStripMenuItem.Click += new System.EventHandler(this.operatorToolStripMenuItem_Click);
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.Location = new System.Drawing.Point(12, 9);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(91, 20);
            this.lblValid.TabIndex = 1;
            this.lblValid.Text = "Valid: False";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(12, 38);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(56, 20);
            this.lblPrefix.TabIndex = 2;
            this.lblPrefix.Text = "Prefix: ";
            // 
            // lblInfix
            // 
            this.lblInfix.AutoSize = true;
            this.lblInfix.Location = new System.Drawing.Point(13, 62);
            this.lblInfix.Name = "lblInfix";
            this.lblInfix.Size = new System.Drawing.Size(42, 20);
            this.lblInfix.TabIndex = 3;
            this.lblInfix.Text = "Infix:";
            // 
            // lblPostfix
            // 
            this.lblPostfix.AutoSize = true;
            this.lblPostfix.Location = new System.Drawing.Point(13, 86);
            this.lblPostfix.Name = "lblPostfix";
            this.lblPostfix.Size = new System.Drawing.Size(64, 20);
            this.lblPostfix.TabIndex = 4;
            this.lblPostfix.Text = "Postfix: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 663);
            this.Controls.Add(this.lblPostfix);
            this.Controls.Add(this.lblInfix);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.lblValid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.cmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmenu;
        private System.Windows.Forms.ToolStripMenuItem operandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorToolStripMenuItem;
        private System.Windows.Forms.Label lblValid;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.Label lblInfix;
        private System.Windows.Forms.Label lblPostfix;
    }
}

