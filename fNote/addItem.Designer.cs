namespace fNote
{
    partial class addItem
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
            this.bEId = new System.Windows.Forms.Label();
            this.bEName = new System.Windows.Forms.TextBox();
            this.bENote = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.reminderActivator = new System.Windows.Forms.CheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bEId
            // 
            this.bEId.AutoSize = true;
            this.bEId.Location = new System.Drawing.Point(13, 13);
            this.bEId.Name = "bEId";
            this.bEId.Size = new System.Drawing.Size(0, 13);
            this.bEId.TabIndex = 0;
            // 
            // bEName
            // 
            this.bEName.Location = new System.Drawing.Point(44, 13);
            this.bEName.Name = "bEName";
            this.bEName.Size = new System.Drawing.Size(203, 20);
            this.bEName.TabIndex = 1;
            // 
            // bENote
            // 
            this.bENote.Location = new System.Drawing.Point(16, 39);
            this.bENote.Multiline = true;
            this.bENote.Name = "bENote";
            this.bENote.Size = new System.Drawing.Size(256, 188);
            this.bENote.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(107, 257);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // reminderActivator
            // 
            this.reminderActivator.AutoSize = true;
            this.reminderActivator.Location = new System.Drawing.Point(16, 234);
            this.reminderActivator.Name = "reminderActivator";
            this.reminderActivator.Size = new System.Drawing.Size(96, 17);
            this.reminderActivator.TabIndex = 4;
            this.reminderActivator.Text = "Напоминание";
            this.reminderActivator.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(136, 234);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(136, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // addItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 289);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.reminderActivator);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.bENote);
            this.Controls.Add(this.bEName);
            this.Controls.Add(this.bEId);
            this.Name = "addItem";
            this.Text = "Добавить элемент в базу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bEId;
        private System.Windows.Forms.TextBox bEName;
        private System.Windows.Forms.TextBox bENote;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox reminderActivator;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}