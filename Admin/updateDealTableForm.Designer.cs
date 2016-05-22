namespace Admin
{
    partial class updateDealTableForm
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
            this.dealDatePick = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_fuelamount = new System.Windows.Forms.TextBox();
            this.cbFuelType = new System.Windows.Forms.ComboBox();
            this.tb_dealprice = new System.Windows.Forms.TextBox();
            this.cbCardNum = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dealDatePick
            // 
            this.dealDatePick.CausesValidation = false;
            this.dealDatePick.CustomFormat = "";
            this.dealDatePick.Location = new System.Drawing.Point(118, 127);
            this.dealDatePick.Name = "dealDatePick";
            this.dealDatePick.Size = new System.Drawing.Size(135, 20);
            this.dealDatePick.TabIndex = 41;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(78, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(178, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Заменить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Номер карты:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Дата сделки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Цена сделки:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Количество топлива:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Тип топлива: ";
            // 
            // tb_fuelamount
            // 
            this.tb_fuelamount.Location = new System.Drawing.Point(147, 48);
            this.tb_fuelamount.Name = "tb_fuelamount";
            this.tb_fuelamount.Size = new System.Drawing.Size(106, 20);
            this.tb_fuelamount.TabIndex = 28;
            // 
            // cbFuelType
            // 
            this.cbFuelType.FormattingEnabled = true;
            this.cbFuelType.Location = new System.Drawing.Point(147, 23);
            this.cbFuelType.Name = "cbFuelType";
            this.cbFuelType.Size = new System.Drawing.Size(106, 21);
            this.cbFuelType.TabIndex = 43;
            // 
            // tb_dealprice
            // 
            this.tb_dealprice.Location = new System.Drawing.Point(147, 74);
            this.tb_dealprice.Name = "tb_dealprice";
            this.tb_dealprice.Size = new System.Drawing.Size(106, 20);
            this.tb_dealprice.TabIndex = 44;
            // 
            // cbCardNum
            // 
            this.cbCardNum.FormattingEnabled = true;
            this.cbCardNum.Location = new System.Drawing.Point(118, 100);
            this.cbCardNum.Name = "cbCardNum";
            this.cbCardNum.Size = new System.Drawing.Size(135, 21);
            this.cbCardNum.TabIndex = 45;
            // 
            // updateDealTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 206);
            this.Controls.Add(this.cbCardNum);
            this.Controls.Add(this.tb_dealprice);
            this.Controls.Add(this.cbFuelType);
            this.Controls.Add(this.dealDatePick);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_fuelamount);
            this.Name = "updateDealTableForm";
            this.Text = "Обновление данных о сделке";
            this.Load += new System.EventHandler(this.updateDealTableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dealDatePick;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_fuelamount;
        private System.Windows.Forms.ComboBox cbFuelType;
        private System.Windows.Forms.TextBox tb_dealprice;
        private System.Windows.Forms.ComboBox cbCardNum;
    }
}