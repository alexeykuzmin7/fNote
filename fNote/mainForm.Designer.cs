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
            this.bENote = new System.Windows.Forms.TextBox();
            this.baseElements = new System.Windows.Forms.ListBox();
            this.saveChanges = new System.Windows.Forms.Button();
            this.bEId = new System.Windows.Forms.Label();
            this.bEName = new System.Windows.Forms.TextBox();
            this.addElement = new System.Windows.Forms.Button();
            this.deleteElement = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baseSelect
            // 
            this.baseSelect.Location = new System.Drawing.Point(694, 335);
            this.baseSelect.Name = "baseSelect";
            this.baseSelect.Size = new System.Drawing.Size(85, 23);
            this.baseSelect.TabIndex = 1;
            this.baseSelect.Text = "Выбрать базу";
            this.baseSelect.UseVisualStyleBackColor = true;
            // 
            // baseCreate
            // 
            this.baseCreate.Location = new System.Drawing.Point(694, 306);
            this.baseCreate.Name = "baseCreate";
            this.baseCreate.Size = new System.Drawing.Size(85, 23);
            this.baseCreate.TabIndex = 2;
            this.baseCreate.Text = "Создать базу";
            this.baseCreate.UseVisualStyleBackColor = true;
            this.baseCreate.Click += new System.EventHandler(this.baseCreate_Click);
            // 
            // bENote
            // 
            this.bENote.Location = new System.Drawing.Point(12, 41);
            this.bENote.Multiline = true;
            this.bENote.Name = "bENote";
            this.bENote.Size = new System.Drawing.Size(341, 313);
            this.bENote.TabIndex = 3;
            this.bENote.TextChanged += new System.EventHandler(this.bENote_TextChanged);
            // 
            // baseElements
            // 
            this.baseElements.FormattingEnabled = true;
            this.baseElements.Location = new System.Drawing.Point(409, 12);
            this.baseElements.Name = "baseElements";
            this.baseElements.Size = new System.Drawing.Size(259, 342);
            this.baseElements.TabIndex = 4;
            this.baseElements.SelectedIndexChanged += new System.EventHandler(this.baseElements_SelectedIndexChanged);
            // 
            // saveChanges
            // 
            this.saveChanges.Location = new System.Drawing.Point(264, 12);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(89, 23);
            this.saveChanges.TabIndex = 5;
            this.saveChanges.Text = "Изменить";
            this.saveChanges.UseVisualStyleBackColor = true;
            this.saveChanges.Click += new System.EventHandler(this.saveChanges_Click);
            // 
            // bEId
            // 
            this.bEId.AutoSize = true;
            this.bEId.Location = new System.Drawing.Point(13, 13);
            this.bEId.Name = "bEId";
            this.bEId.Size = new System.Drawing.Size(0, 13);
            this.bEId.TabIndex = 6;
            // 
            // bEName
            // 
            this.bEName.Location = new System.Drawing.Point(55, 13);
            this.bEName.Name = "bEName";
            this.bEName.Size = new System.Drawing.Size(203, 20);
            this.bEName.TabIndex = 7;
            this.bEName.TextChanged += new System.EventHandler(this.bEName_TextChanged);
            // 
            // addElement
            // 
            this.addElement.Location = new System.Drawing.Point(694, 13);
            this.addElement.Name = "addElement";
            this.addElement.Size = new System.Drawing.Size(85, 23);
            this.addElement.TabIndex = 8;
            this.addElement.Text = "Добавить";
            this.addElement.UseVisualStyleBackColor = true;
            this.addElement.Click += new System.EventHandler(this.addElement_Click);
            // 
            // deleteElement
            // 
            this.deleteElement.Location = new System.Drawing.Point(694, 43);
            this.deleteElement.Name = "deleteElement";
            this.deleteElement.Size = new System.Drawing.Size(85, 23);
            this.deleteElement.TabIndex = 10;
            this.deleteElement.Text = "Удалить";
            this.deleteElement.UseVisualStyleBackColor = true;
            this.deleteElement.Click += new System.EventHandler(this.deleteElement_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(671, 13);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 341);
            this.vScrollBar1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(694, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 13;
            // 
            // filter
            // 
            this.filter.AutoSize = true;
            this.filter.Location = new System.Drawing.Point(691, 69);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(47, 13);
            this.filter.TabIndex = 14;
            this.filter.Text = "Фильтр";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 370);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.deleteElement);
            this.Controls.Add(this.addElement);
            this.Controls.Add(this.bEName);
            this.Controls.Add(this.bEId);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.baseElements);
            this.Controls.Add(this.bENote);
            this.Controls.Add(this.baseCreate);
            this.Controls.Add(this.baseSelect);
            this.Name = "mainForm";
            this.Text = "fNote";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baseSelect;
        private System.Windows.Forms.Button baseCreate;
        private System.Windows.Forms.TextBox bENote;
        private System.Windows.Forms.ListBox baseElements;
        private System.Windows.Forms.Button saveChanges;
        private System.Windows.Forms.Label bEId;
        private System.Windows.Forms.TextBox bEName;
        private System.Windows.Forms.Button addElement;
        private System.Windows.Forms.Button deleteElement;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label filter;
    }
}

