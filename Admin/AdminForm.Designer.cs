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
            this.tabAccountingTable = new System.Windows.Forms.TabPage();
            this.dgvViewAccounting = new System.Windows.Forms.DataGridView();
            this.stationadres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelaccounttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelaccountamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCarTable = new System.Windows.Forms.TabPage();
            this.btnCarAdd = new System.Windows.Forms.Button();
            this.btnFindDealsByCar_id = new System.Windows.Forms.Button();
            this.dgvVievCars = new System.Windows.Forms.DataGridView();
            this.carmark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabStaffTable = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnTableView = new System.Windows.Forms.Button();
            this.dgvVievStaff = new System.Windows.Forms.DataGridView();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabDealTable = new System.Windows.Forms.TabPage();
            this.btnDealUpdate = new System.Windows.Forms.Button();
            this.dgvVievDeal = new System.Windows.Forms.DataGridView();
            this.sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fueltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAccountingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAccounting)).BeginInit();
            this.tabCarTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievCars)).BeginInit();
            this.tabStaffTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.tabDealTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievDeal)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAccountingTable
            // 
            this.tabAccountingTable.Controls.Add(this.dgvViewAccounting);
            this.tabAccountingTable.Location = new System.Drawing.Point(4, 22);
            this.tabAccountingTable.Name = "tabAccountingTable";
            this.tabAccountingTable.Size = new System.Drawing.Size(703, 458);
            this.tabAccountingTable.TabIndex = 2;
            this.tabAccountingTable.Text = "Таблица учёта";
            this.tabAccountingTable.UseVisualStyleBackColor = true;
            // 
            // dgvViewAccounting
            // 
            this.dgvViewAccounting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewAccounting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationadres,
            this.fuelaccounttype,
            this.fuelaccountamount,
            this.accountdate});
            this.dgvViewAccounting.Location = new System.Drawing.Point(3, 3);
            this.dgvViewAccounting.Name = "dgvViewAccounting";
            this.dgvViewAccounting.Size = new System.Drawing.Size(695, 452);
            this.dgvViewAccounting.TabIndex = 2;
            // 
            // stationadres
            // 
            this.stationadres.HeaderText = "Адрес станции";
            this.stationadres.Name = "stationadres";
            this.stationadres.Width = 150;
            // 
            // fuelaccounttype
            // 
            this.fuelaccounttype.HeaderText = "Тип топлива";
            this.fuelaccounttype.Name = "fuelaccounttype";
            this.fuelaccounttype.Width = 150;
            // 
            // fuelaccountamount
            // 
            this.fuelaccountamount.HeaderText = "Количество топлива";
            this.fuelaccountamount.Name = "fuelaccountamount";
            this.fuelaccountamount.Width = 150;
            // 
            // accountdate
            // 
            this.accountdate.HeaderText = "Дата проверки";
            this.accountdate.Name = "accountdate";
            this.accountdate.Width = 200;
            // 
            // tabCarTable
            // 
            this.tabCarTable.Controls.Add(this.btnCarAdd);
            this.tabCarTable.Controls.Add(this.btnFindDealsByCar_id);
            this.tabCarTable.Controls.Add(this.dgvVievCars);
            this.tabCarTable.Location = new System.Drawing.Point(4, 22);
            this.tabCarTable.Name = "tabCarTable";
            this.tabCarTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabCarTable.Size = new System.Drawing.Size(703, 458);
            this.tabCarTable.TabIndex = 1;
            this.tabCarTable.Text = "Таблица покупателей";
            this.tabCarTable.UseVisualStyleBackColor = true;
            // 
            // btnCarAdd
            // 
            this.btnCarAdd.Location = new System.Drawing.Point(547, 255);
            this.btnCarAdd.Name = "btnCarAdd";
            this.btnCarAdd.Size = new System.Drawing.Size(122, 34);
            this.btnCarAdd.TabIndex = 3;
            this.btnCarAdd.Text = "Добавить покупателя";
            this.btnCarAdd.UseVisualStyleBackColor = true;
            this.btnCarAdd.Click += new System.EventHandler(this.btnCarAdd_Click);
            // 
            // btnFindDealsByCar_id
            // 
            this.btnFindDealsByCar_id.Location = new System.Drawing.Point(547, 136);
            this.btnFindDealsByCar_id.Name = "btnFindDealsByCar_id";
            this.btnFindDealsByCar_id.Size = new System.Drawing.Size(127, 34);
            this.btnFindDealsByCar_id.TabIndex = 2;
            this.btnFindDealsByCar_id.Text = "Поиск сделок";
            this.btnFindDealsByCar_id.UseVisualStyleBackColor = true;
            this.btnFindDealsByCar_id.Click += new System.EventHandler(this.btnFindDeals_Click);
            // 
            // dgvVievCars
            // 
            this.dgvVievCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carmark,
            this.cardnum});
            this.dgvVievCars.Location = new System.Drawing.Point(6, 3);
            this.dgvVievCars.Name = "dgvVievCars";
            this.dgvVievCars.Size = new System.Drawing.Size(493, 452);
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
            this.cardnum.Width = 250;
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
            this.tabStaffTable.Size = new System.Drawing.Size(703, 458);
            this.tabStaffTable.TabIndex = 0;
            this.tabStaffTable.Text = "Таблица сотрудников";
            this.tabStaffTable.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(586, 282);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(586, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(586, 229);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Изменить ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnTableView
            // 
            this.btnTableView.Location = new System.Drawing.Point(565, 115);
            this.btnTableView.Name = "btnTableView";
            this.btnTableView.Size = new System.Drawing.Size(116, 23);
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
            this.function,
            this.salary});
            this.dgvVievStaff.Location = new System.Drawing.Point(6, 3);
            this.dgvVievStaff.Name = "dgvVievStaff";
            this.dgvVievStaff.Size = new System.Drawing.Size(525, 440);
            this.dgvVievStaff.TabIndex = 0;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabStaffTable);
            this.tabAdmin.Controls.Add(this.tabCarTable);
            this.tabAdmin.Controls.Add(this.tabAccountingTable);
            this.tabAdmin.Controls.Add(this.tabDealTable);
            this.tabAdmin.Location = new System.Drawing.Point(12, 12);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(711, 484);
            this.tabAdmin.TabIndex = 0;
            // 
            // tabDealTable
            // 
            this.tabDealTable.Controls.Add(this.btnDealUpdate);
            this.tabDealTable.Controls.Add(this.dgvVievDeal);
            this.tabDealTable.Location = new System.Drawing.Point(4, 22);
            this.tabDealTable.Name = "tabDealTable";
            this.tabDealTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabDealTable.Size = new System.Drawing.Size(703, 458);
            this.tabDealTable.TabIndex = 3;
            this.tabDealTable.Text = "Список сделок";
            this.tabDealTable.UseVisualStyleBackColor = true;
            // 
            // btnDealUpdate
            // 
            this.btnDealUpdate.Location = new System.Drawing.Point(607, 201);
            this.btnDealUpdate.Name = "btnDealUpdate";
            this.btnDealUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnDealUpdate.TabIndex = 2;
            this.btnDealUpdate.Text = "Изменить";
            this.btnDealUpdate.UseVisualStyleBackColor = true;
            this.btnDealUpdate.Click += new System.EventHandler(this.btnDealUpdate_Click);
            // 
            // dgvVievDeal
            // 
            this.dgvVievDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievDeal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sname,
            this.fueltype,
            this.fuelamount,
            this.dealprice,
            this.dataGridViewTextBoxColumn1,
            this.dealdate});
            this.dgvVievDeal.Location = new System.Drawing.Point(6, 0);
            this.dgvVievDeal.Name = "dgvVievDeal";
            this.dgvVievDeal.Size = new System.Drawing.Size(580, 455);
            this.dgvVievDeal.TabIndex = 1;
            // 
            // sname
            // 
            this.sname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sname.HeaderText = "ФИ сотрудника";
            this.sname.Name = "sname";
            this.sname.Width = 120;
            // 
            // fueltype
            // 
            this.fueltype.HeaderText = "Тип топлива";
            this.fueltype.Name = "fueltype";
            this.fueltype.Width = 50;
            // 
            // fuelamount
            // 
            this.fuelamount.HeaderText = "Количество топлива";
            this.fuelamount.Name = "fuelamount";
            this.fuelamount.Width = 60;
            // 
            // dealprice
            // 
            this.dealprice.HeaderText = "Сумма сделки";
            this.dealprice.Name = "dealprice";
            this.dealprice.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Покупатель";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dealdate
            // 
            this.dealdate.HeaderText = "Дата сделки";
            this.dealdate.Name = "dealdate";
            this.dealdate.Width = 150;
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
            this.gender.Width = 60;
            // 
            // function
            // 
            this.function.HeaderText = "Профессия";
            this.function.Name = "function";
            this.function.Width = 120;
            // 
            // salary
            // 
            this.salary.HeaderText = "Зарплата";
            this.salary.Name = "salary";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 501);
            this.Controls.Add(this.tabAdmin);
            this.Name = "AdminForm";
            this.Text = "Раздел администратора";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabAccountingTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAccounting)).EndInit();
            this.tabCarTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievCars)).EndInit();
            this.tabStaffTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievStaff)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabDealTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievDeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.DataGridView dgvVievStaff;
        private System.Windows.Forms.Button btnTableView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabStaffTable;
        private System.Windows.Forms.DataGridView dgvVievCars;
        private System.Windows.Forms.Button btnFindDealsByCar_id;
        private System.Windows.Forms.Button btnCarAdd;
        private System.Windows.Forms.TabPage tabCarTable;
        private System.Windows.Forms.DataGridView dgvViewAccounting;
        private System.Windows.Forms.TabPage tabAccountingTable;
        private System.Windows.Forms.TabPage tabDealTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvVievDeal;
        private System.Windows.Forms.Button btnDealUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fueltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn carmark;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelaccountamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelaccounttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationadres;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
    }
}

