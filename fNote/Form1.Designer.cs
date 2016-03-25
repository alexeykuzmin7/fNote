namespace fNote
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseSelect = new System.Windows.Forms.Button();
            this.baseCreate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // baseSelect
            // 
            this.baseSelect.Location = new System.Drawing.Point(694, 41);
            this.baseSelect.Name = "baseSelect";
            this.baseSelect.Size = new System.Drawing.Size(85, 23);
            this.baseSelect.TabIndex = 1;
            this.baseSelect.Text = "Выбрать базу";
            this.baseSelect.UseVisualStyleBackColor = true;
            // 
            // baseCreate
            // 
            this.baseCreate.Location = new System.Drawing.Point(694, 12);
            this.baseCreate.Name = "baseCreate";
            this.baseCreate.Size = new System.Drawing.Size(85, 23);
            this.baseCreate.TabIndex = 2;
            this.baseCreate.Text = "Создать базу";
            this.baseCreate.UseVisualStyleBackColor = true;
            this.baseCreate.Click += new System.EventHandler(this.baseCreate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 346);
            this.textBox1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(356, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(267, 342);
            this.listBox1.TabIndex = 4;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 370);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.baseCreate);
            this.Controls.Add(this.baseSelect);
            this.Name = "mainForm";
            this.Text = "fNote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baseSelect;
        private System.Windows.Forms.Button baseCreate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

