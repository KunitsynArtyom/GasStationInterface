namespace Worker
{
    partial class addToDealTableForm
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
            this.cbCardList = new System.Windows.Forms.ComboBox();
            this.dealDatePick = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOrgList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStationList = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbFuelamount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbStaffList = new System.Windows.Forms.ComboBox();
            this.cbFuelType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbCardList
            // 
            this.cbCardList.FormattingEnabled = true;
            this.cbCardList.Location = new System.Drawing.Point(150, 172);
            this.cbCardList.Name = "cbCardList";
            this.cbCardList.Size = new System.Drawing.Size(167, 21);
            this.cbCardList.TabIndex = 45;
            // 
            // dealDatePick
            // 
            this.dealDatePick.Location = new System.Drawing.Point(150, 199);
            this.dealDatePick.Name = "dealDatePick";
            this.dealDatePick.Size = new System.Drawing.Size(167, 20);
            this.dealDatePick.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Адрес:";
            // 
            // cbOrgList
            // 
            this.cbOrgList.FormattingEnabled = true;
            this.cbOrgList.Location = new System.Drawing.Point(150, 12);
            this.cbOrgList.Name = "cbOrgList";
            this.cbOrgList.Size = new System.Drawing.Size(167, 21);
            this.cbOrgList.TabIndex = 42;
            this.cbOrgList.SelectedIndexChanged += new System.EventHandler(this.cbOrgList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Организация:";
            // 
            // cbStationList
            // 
            this.cbStationList.FormattingEnabled = true;
            this.cbStationList.Location = new System.Drawing.Point(150, 39);
            this.cbStationList.Name = "cbStationList";
            this.cbStationList.Size = new System.Drawing.Size(167, 21);
            this.cbStationList.TabIndex = 40;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(242, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Дата сделки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Номер карты:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Цена сделки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Количество топлива:";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(150, 146);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(167, 20);
            this.tbPrice.TabIndex = 27;
            // 
            // tbFuelamount
            // 
            this.tbFuelamount.Location = new System.Drawing.Point(150, 120);
            this.tbFuelamount.Name = "tbFuelamount";
            this.tbFuelamount.Size = new System.Drawing.Size(167, 20);
            this.tbFuelamount.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Сотрудник:";
            // 
            // cbStaffList
            // 
            this.cbStaffList.FormattingEnabled = true;
            this.cbStaffList.Location = new System.Drawing.Point(150, 66);
            this.cbStaffList.Name = "cbStaffList";
            this.cbStaffList.Size = new System.Drawing.Size(167, 21);
            this.cbStaffList.TabIndex = 47;
            // 
            // cbFuelType
            // 
            this.cbFuelType.FormattingEnabled = true;
            this.cbFuelType.Location = new System.Drawing.Point(150, 93);
            this.cbFuelType.Name = "cbFuelType";
            this.cbFuelType.Size = new System.Drawing.Size(167, 21);
            this.cbFuelType.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Тип топлива:";
            // 
            // addToDealTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 278);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbFuelType);
            this.Controls.Add(this.cbStaffList);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbCardList);
            this.Controls.Add(this.dealDatePick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbOrgList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStationList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbFuelamount);
            this.Name = "addToDealTableForm";
            this.Text = "Добавление сделки";
            this.Load += new System.EventHandler(this.addToDealTableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCardList;
        private System.Windows.Forms.DateTimePicker dealDatePick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOrgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStationList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbFuelamount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStaffList;
        private System.Windows.Forms.ComboBox cbFuelType;
        private System.Windows.Forms.Label label11;
    }
}