namespace User
{
    partial class UserForm
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
            this.tabAZSTable = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.dataTableView = new System.Windows.Forms.Button();
            this.dgvVievAZS = new System.Windows.Forms.DataGridView();
            this.orgname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDealUserTable = new System.Windows.Forms.TabPage();
            this.dgvUserDeals = new System.Windows.Forms.DataGridView();
            this.fueltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabAZSTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievAZS)).BeginInit();
            this.tabDealUserTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDeals)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAZSTable);
            this.tabControl1.Controls.Add(this.tabDealUserTable);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAZSTable
            // 
            this.tabAZSTable.Controls.Add(this.label2);
            this.tabAZSTable.Controls.Add(this.label1);
            this.tabAZSTable.Controls.Add(this.btnSearch);
            this.tabAZSTable.Controls.Add(this.tbCity);
            this.tabAZSTable.Controls.Add(this.tbCountry);
            this.tabAZSTable.Controls.Add(this.dataTableView);
            this.tabAZSTable.Controls.Add(this.dgvVievAZS);
            this.tabAZSTable.Location = new System.Drawing.Point(4, 22);
            this.tabAZSTable.Name = "tabAZSTable";
            this.tabAZSTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabAZSTable.Size = new System.Drawing.Size(644, 331);
            this.tabAZSTable.TabIndex = 0;
            this.tabAZSTable.Text = "Таблица АЗС";
            this.tabAZSTable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Страна";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(550, 302);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(525, 267);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(100, 20);
            this.tbCity.TabIndex = 3;
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(525, 228);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(100, 20);
            this.tbCountry.TabIndex = 2;
            // 
            // dataTableView
            // 
            this.dataTableView.Location = new System.Drawing.Point(485, 63);
            this.dataTableView.Name = "dataTableView";
            this.dataTableView.Size = new System.Drawing.Size(123, 23);
            this.dataTableView.TabIndex = 1;
            this.dataTableView.Text = "Обновить таблицу";
            this.dataTableView.UseVisualStyleBackColor = true;
            this.dataTableView.Click += new System.EventHandler(this.dataView1_Click);
            // 
            // dgvVievAZS
            // 
            this.dgvVievAZS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVievAZS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orgname,
            this.country,
            this.city,
            this.street});
            this.dgvVievAZS.Location = new System.Drawing.Point(6, 3);
            this.dgvVievAZS.Name = "dgvVievAZS";
            this.dgvVievAZS.Size = new System.Drawing.Size(446, 325);
            this.dgvVievAZS.TabIndex = 0;
            // 
            // orgname
            // 
            this.orgname.HeaderText = "Организация";
            this.orgname.Name = "orgname";
            // 
            // country
            // 
            this.country.HeaderText = "Страна";
            this.country.Name = "country";
            // 
            // city
            // 
            this.city.HeaderText = "Город";
            this.city.Name = "city";
            // 
            // street
            // 
            this.street.HeaderText = "Улица";
            this.street.Name = "street";
            // 
            // tabDealUserTable
            // 
            this.tabDealUserTable.Controls.Add(this.dgvUserDeals);
            this.tabDealUserTable.Location = new System.Drawing.Point(4, 22);
            this.tabDealUserTable.Name = "tabDealUserTable";
            this.tabDealUserTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabDealUserTable.Size = new System.Drawing.Size(644, 331);
            this.tabDealUserTable.TabIndex = 1;
            this.tabDealUserTable.Text = "Список сделок";
            this.tabDealUserTable.UseVisualStyleBackColor = true;
            // 
            // dgvUserDeals
            // 
            this.dgvUserDeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserDeals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fueltype,
            this.fuelamount,
            this.dealprice,
            this.dealdate});
            this.dgvUserDeals.Location = new System.Drawing.Point(6, 6);
            this.dgvUserDeals.Name = "dgvUserDeals";
            this.dgvUserDeals.Size = new System.Drawing.Size(632, 319);
            this.dgvUserDeals.TabIndex = 0;
            // 
            // fueltype
            // 
            this.fueltype.HeaderText = "Тип топлива";
            this.fueltype.Name = "fueltype";
            this.fueltype.Width = 150;
            // 
            // fuelamount
            // 
            this.fuelamount.HeaderText = "Количество топлива";
            this.fuelamount.Name = "fuelamount";
            this.fuelamount.Width = 150;
            // 
            // dealprice
            // 
            this.dealprice.HeaderText = "Сумма сделки";
            this.dealprice.Name = "dealprice";
            this.dealprice.Width = 150;
            // 
            // dealdate
            // 
            this.dealdate.HeaderText = "Дата сделки";
            this.dealdate.Name = "dealdate";
            this.dealdate.Width = 150;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 381);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserForm";
            this.Text = "Раздел пользователя";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAZSTable.ResumeLayout(false);
            this.tabAZSTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVievAZS)).EndInit();
            this.tabDealUserTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDeals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAZSTable;
        private System.Windows.Forms.TabPage tabDealUserTable;
        private System.Windows.Forms.DataGridView dgvVievAZS;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgname;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn street;
        private System.Windows.Forms.Button dataTableView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUserDeals;
        private System.Windows.Forms.DataGridViewTextBoxColumn fueltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealdate;
    }
}

