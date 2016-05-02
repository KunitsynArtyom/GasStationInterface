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
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabStaffTable = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTableView = new System.Windows.Forms.Button();
            this.dgvVievStaff = new System.Windows.Forms.DataGridView();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCarTable = new System.Windows.Forms.TabPage();
            this.dgvVievCars = new System.Windows.Forms.DataGridView();
            this.carmark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindDeals = new System.Windows.Forms.Button();
            this.tabAdmin.SuspendLayout();
            this.tabStaffTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).BeginInit();
            this.tabCarTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievCars)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabStaffTable);
            this.tabAdmin.Controls.Add(this.tabCarTable);
            this.tabAdmin.Location = new System.Drawing.Point(12, 12);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(652, 357);
            this.tabAdmin.TabIndex = 0;
            // 
            // tabStaffTable
            // 
            this.tabStaffTable.Controls.Add(this.btnDelete);
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(514, 248);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(514, 196);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Заменить ";
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
            // tabCarTable
            // 
            this.tabCarTable.Controls.Add(this.btnFindDeals);
            this.tabCarTable.Controls.Add(this.dgvVievCars);
            this.tabCarTable.Location = new System.Drawing.Point(4, 22);
            this.tabCarTable.Name = "tabCarTable";
            this.tabCarTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabCarTable.Size = new System.Drawing.Size(644, 331);
            this.tabCarTable.TabIndex = 1;
            this.tabCarTable.Text = "Таблица покупателей";
            this.tabCarTable.UseVisualStyleBackColor = true;
            // 
            // dgvVievCars
            // 
            this.dgvVievCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carmark,
            this.cardnum});
            this.dgvVievCars.Location = new System.Drawing.Point(6, 3);
            this.dgvVievCars.Name = "dgvVievCars";
            this.dgvVievCars.Size = new System.Drawing.Size(450, 325);
            this.dgvVievCars.TabIndex = 1;
            // 
            // carmark
            // 
            this.carmark.HeaderText = "Марка автомобиля";
            this.carmark.Name = "carmark";
            this.carmark.Width = 200;
            // 
            // cardnum
            // 
            this.cardnum.HeaderText = "Номер карты";
            this.cardnum.Name = "cardnum";
            this.cardnum.Width = 200;
            // 
            // btnFindDeals
            // 
            this.btnFindDeals.Location = new System.Drawing.Point(488, 125);
            this.btnFindDeals.Name = "btnFindDeals";
            this.btnFindDeals.Size = new System.Drawing.Size(127, 34);
            this.btnFindDeals.TabIndex = 2;
            this.btnFindDeals.Text = "Показать сделки";
            this.btnFindDeals.UseVisualStyleBackColor = true;
            this.btnFindDeals.Click += new System.EventHandler(this.btnFindDeals_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 381);
            this.Controls.Add(this.tabAdmin);
            this.Name = "AdminForm";
            this.Text = "Раздел администратора";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabAdmin.ResumeLayout(false);
            this.tabStaffTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).EndInit();
            this.tabCarTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievCars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabStaffTable;
        private System.Windows.Forms.TabPage tabCarTable;
        private System.Windows.Forms.DataGridView dgvVievStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.Button btnTableView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvVievCars;
        private System.Windows.Forms.DataGridViewTextBoxColumn carmark;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardnum;
        private System.Windows.Forms.Button btnFindDeals;
    }
}

