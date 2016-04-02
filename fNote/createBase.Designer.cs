namespace fNote
{
    partial class createBase
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
            this.baseName = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // baseName
            // 
            this.baseName.Location = new System.Drawing.Point(12, 22);
            this.baseName.Name = "baseName";
            this.baseName.Size = new System.Drawing.Size(187, 20);
            this.baseName.TabIndex = 1;
            this.baseName.Text = "Название базы";
            this.baseName.Click += new System.EventHandler(this.baseName_Click);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(64, 61);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 2;
            this.create.Text = "Создать";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // createBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 107);
            this.Controls.Add(this.create);
            this.Controls.Add(this.baseName);
            this.Name = "createBase";
            this.Text = "Создать базу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        public System.Windows.Forms.TextBox baseName;
        private System.Windows.Forms.Button create;
    }
}