namespace Admin
{
    partial class AdminForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStaffTable = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTableView = new System.Windows.Forms.Button();
            this.dgvVievStaff = new System.Windows.Forms.DataGridView();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabStaffTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStaffTable);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStaffTable
            // 
            this.tabStaffTable.Controls.Add(this.btnAdd);
            this.tabStaffTable.Controls.Add(this.btnUpdate);
            this.tabStaffTable.Controls.Add(this.btnTableView);
            this.tabStaffTable.Controls.Add(this.dgvVievStaff);
            this.tabStaffTable.Location = new System.Drawing.Point(4, 22);
            this.tabStaffTable.Name = "tabStaffTable";
            this.tabStaffTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabStaffTable.Size = new System.Drawing.Size(644, 331);
            this.tabStaffTable.TabIndex = 0;
            this.tabStaffTable.Text = "Таблица сотрудников";
            this.tabStaffTable.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(514, 196);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Заменить Иванова";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnTableView
            // 
            this.btnTableView.Location = new System.Drawing.Point(488, 75);
            this.btnTableView.Name = "btnTableView";
            this.btnTableView.Size = new System.Drawing.Size(126, 23);
            this.btnTableView.TabIndex = 1;
            this.btnTableView.Text = "Обноваить таблицу";
            this.btnTableView.UseVisualStyleBackColor = true;
            this.btnTableView.Click += new System.EventHandler(this.btnTableView_Click);
            // 
            // dgvVievStaff
            // 
            this.dgvVievStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.surname,
            this.name,
            this.gender,
            this.function});
            this.dgvVievStaff.Location = new System.Drawing.Point(6, 3);
            this.dgvVievStaff.Name = "dgvVievStaff";
            this.dgvVievStaff.Size = new System.Drawing.Size(446, 325);
            this.dgvVievStaff.TabIndex = 0;
            // 
            // surname
            // 
            this.surname.HeaderText = "Фамилия";
            this.surname.Name = "surname";
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            // 
            // gender
            // 
            this.gender.HeaderText = "Пол";
            this.gender.Name = "gender";
            // 
            // function
            // 
            this.function.HeaderText = "Профессия";
            this.function.Name = "function";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(644, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(514, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 381);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "Раздел администратора";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStaffTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStaffTable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvVievStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.Button btnTableView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
    }
}

