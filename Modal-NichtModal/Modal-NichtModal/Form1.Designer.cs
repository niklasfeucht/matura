namespace Modal_NichtModal
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnModal = new System.Windows.Forms.Button();
            this.btnNichtModal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(151, 115);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(90, 20);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Hello World";
            // 
            // btnModal
            // 
            this.btnModal.Location = new System.Drawing.Point(44, 226);
            this.btnModal.Name = "btnModal";
            this.btnModal.Size = new System.Drawing.Size(125, 65);
            this.btnModal.TabIndex = 1;
            this.btnModal.Text = "Modal";
            this.btnModal.UseVisualStyleBackColor = true;
            this.btnModal.Click += new System.EventHandler(this.btnModal_Click);
            // 
            // btnNichtModal
            // 
            this.btnNichtModal.Location = new System.Drawing.Point(232, 226);
            this.btnNichtModal.Name = "btnNichtModal";
            this.btnNichtModal.Size = new System.Drawing.Size(125, 65);
            this.btnNichtModal.TabIndex = 2;
            this.btnNichtModal.Text = "Nicht Modal";
            this.btnNichtModal.UseVisualStyleBackColor = true;
            this.btnNichtModal.Click += new System.EventHandler(this.btnNichtModal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNichtModal);
            this.Controls.Add(this.btnModal);
            this.Controls.Add(this.lblResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnModal;
        private System.Windows.Forms.Button btnNichtModal;
    }
}

