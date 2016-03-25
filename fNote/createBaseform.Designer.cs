namespace fNote
{
    partial class createBaseform
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
            this.createBase = new System.Windows.Forms.Button();
            this.baseName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createBase
            // 
            this.createBase.Location = new System.Drawing.Point(65, 63);
            this.createBase.Name = "createBase";
            this.createBase.Size = new System.Drawing.Size(75, 23);
            this.createBase.TabIndex = 0;
            this.createBase.Text = "Создать";
            this.createBase.UseVisualStyleBackColor = true;
            this.createBase.Click += new System.EventHandler(this.createBase_Click);
            // 
            // baseName
            // 
            this.baseName.Location = new System.Drawing.Point(12, 22);
            this.baseName.Name = "baseName";
            this.baseName.Size = new System.Drawing.Size(187, 20);
            this.baseName.TabIndex = 1;
            this.baseName.Text = "hghg";
            this.baseName.Click += new System.EventHandler(this.baseName_Click);
            // 
            // createBaseform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 107);
            this.Controls.Add(this.baseName);
            this.Controls.Add(this.createBase);
            this.Name = "createBaseform";
            this.Text = "Создать базу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBase;
        public System.Windows.Forms.TextBox baseName;
    }
}