namespace Worker
{
    partial class WorkerForm
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
            this.tabDealTable = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnTableView = new System.Windows.Forms.Button();
            this.dgvVievDeal = new System.Windows.Forms.DataGridView();
            this.sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fueltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSupplyTable = new System.Windows.Forms.TabPage();
            this.btnAddSupply = new System.Windows.Forms.Button();
            this.dgvViewSupply = new System.Windows.Forms.DataGridView();
            this.stationadres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplystaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelsupplytype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelsupplyamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelsupplydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAdmin.SuspendLayout();
            this.tabDealTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievDeal)).BeginInit();
            this.tabSupplyTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSupply)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabDealTable);
            this.tabAdmin.Controls.Add(this.tabSupplyTable);
            this.tabAdmin.Location = new System.Drawing.Point(12, 12);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(742, 398);
            this.tabAdmin.TabIndex = 1;
            // 
            // tabDealTable
            // 
            this.tabDealTable.Controls.Add(this.btnAdd);
            this.tabDealTable.Controls.Add(this.btnTableView);
            this.tabDealTable.Controls.Add(this.dgvVievDeal);
            this.tabDealTable.Location = new System.Drawing.Point(4, 22);
            this.tabDealTable.Name = "tabDealTable";
            this.tabDealTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabDealTable.Size = new System.Drawing.Size(734, 372);
            this.tabDealTable.TabIndex = 0;
            this.tabDealTable.Text = "Список сделок";
            this.tabDealTable.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(612, 224);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnTableView
            // 
            this.btnTableView.Location = new System.Drawing.Point(590, 139);
            this.btnTableView.Name = "btnTableView";
            this.btnTableView.Size = new System.Drawing.Size(126, 23);
            this.btnTableView.TabIndex = 1;
            this.btnTableView.Text = "Обноваить таблицу";
            this.btnTableView.UseVisualStyleBackColor = true;
            // 
            // dgvVievDeal
            // 
            this.dgvVievDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievDeal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sname,
            this.fueltype,
            this.fuelamount,
            this.dealprice,
            this.cardnum,
            this.dealdate});
            this.dgvVievDeal.Location = new System.Drawing.Point(3, 3);
            this.dgvVievDeal.Name = "dgvVievDeal";
            this.dgvVievDeal.Size = new System.Drawing.Size(568, 366);
            this.dgvVievDeal.TabIndex = 0;
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
            this.fuelamount.Width = 50;
            // 
            // dealprice
            // 
            this.dealprice.HeaderText = "Сумма сделки";
            this.dealprice.Name = "dealprice";
            this.dealprice.Width = 50;
            // 
            // cardnum
            // 
            this.cardnum.HeaderText = "Покупатель";
            this.cardnum.Name = "cardnum";
            // 
            // dealdate
            // 
            this.dealdate.HeaderText = "Дата сделки";
            this.dealdate.Name = "dealdate";
            this.dealdate.Width = 150;
            // 
            // tabSupplyTable
            // 
            this.tabSupplyTable.Controls.Add(this.btnAddSupply);
            this.tabSupplyTable.Controls.Add(this.dgvViewSupply);
            this.tabSupplyTable.Location = new System.Drawing.Point(4, 22);
            this.tabSupplyTable.Name = "tabSupplyTable";
            this.tabSupplyTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabSupplyTable.Size = new System.Drawing.Size(734, 372);
            this.tabSupplyTable.TabIndex = 1;
            this.tabSupplyTable.Text = "Таблица подвоза";
            this.tabSupplyTable.UseVisualStyleBackColor = true;
            // 
            // btnAddSupply
            // 
            this.btnAddSupply.Location = new System.Drawing.Point(617, 161);
            this.btnAddSupply.Name = "btnAddSupply";
            this.btnAddSupply.Size = new System.Drawing.Size(85, 50);
            this.btnAddSupply.TabIndex = 1;
            this.btnAddSupply.Text = "Добавить";
            this.btnAddSupply.UseVisualStyleBackColor = true;
            // 
            // dgvViewSupply
            // 
            this.dgvViewSupply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewSupply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stationadres,
            this.supplystaff,
            this.fuelsupplytype,
            this.fuelsupplyamount,
            this.fuelsupplydate});
            this.dgvViewSupply.Location = new System.Drawing.Point(3, 3);
            this.dgvViewSupply.Name = "dgvViewSupply";
            this.dgvViewSupply.Size = new System.Drawing.Size(586, 366);
            this.dgvViewSupply.TabIndex = 0;
            // 
            // stationadres
            // 
            this.stationadres.HeaderText = "Станция";
            this.stationadres.Name = "stationadres";
            this.stationadres.Width = 120;
            // 
            // supplystaff
            // 
            this.supplystaff.HeaderText = "Сотрудник-оператор";
            this.supplystaff.Name = "supplystaff";
            this.supplystaff.Width = 120;
            // 
            // fuelsupplytype
            // 
            this.fuelsupplytype.HeaderText = "Тип топлива";
            this.fuelsupplytype.Name = "fuelsupplytype";
            // 
            // fuelsupplyamount
            // 
            this.fuelsupplyamount.HeaderText = "Количество топлива";
            this.fuelsupplyamount.Name = "fuelsupplyamount";
            // 
            // fuelsupplydate
            // 
            this.fuelsupplydate.HeaderText = "Дата подвоза";
            this.fuelsupplydate.Name = "fuelsupplydate";
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 422);
            this.Controls.Add(this.tabAdmin);
            this.Name = "WorkerForm";
            this.Text = "Раздел работника";
            this.Load += new System.EventHandler(this.WorkerForm_Load);
            this.tabAdmin.ResumeLayout(false);
            this.tabDealTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievDeal)).EndInit();
            this.tabSupplyTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSupply)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabDealTable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnTableView;
        private System.Windows.Forms.DataGridView dgvVievDeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fueltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealdate;
        private System.Windows.Forms.TabPage tabSupplyTable;
        private System.Windows.Forms.Button btnAddSupply;
        private System.Windows.Forms.DataGridView dgvViewSupply;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationadres;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelsupplydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelsupplyamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelsupplytype;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplystaff;
    }
}

