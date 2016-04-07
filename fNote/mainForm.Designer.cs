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
            this.filterBox = new System.Windows.Forms.TextBox();
            this.filter = new System.Windows.Forms.Label();
            this.openBase = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.notificationLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.baseSelect.Click += new System.EventHandler(this.baseSelect_Click);
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
            this.bENote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bENote.Size = new System.Drawing.Size(341, 288);
            this.bENote.TabIndex = 3;
            this.bENote.TextChanged += new System.EventHandler(this.bENote_TextChanged);
            // 
            // baseElements
            // 
            this.baseElements.FormattingEnabled = true;
            this.baseElements.Location = new System.Drawing.Point(409, 25);
            this.baseElements.Name = "baseElements";
            this.baseElements.Size = new System.Drawing.Size(276, 329);
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
            // filterBox
            // 
            this.filterBox.Location = new System.Drawing.Point(694, 85);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(88, 20);
            this.filterBox.TabIndex = 13;
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Список записей:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(120, 338);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Location = new System.Drawing.Point(13, 340);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(80, 13);
            this.notificationLabel.TabIndex = 17;
            this.notificationLabel.Text = "Напоминание:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(99, 340);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 370);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.notificationLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.filterBox);
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
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label filter;
        private System.Windows.Forms.OpenFileDialog openBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label notificationLabel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

