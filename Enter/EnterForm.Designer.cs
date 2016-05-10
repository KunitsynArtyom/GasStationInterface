namespace Enter
{
    partial class EnterForm
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
            this.btnUserLog = new System.Windows.Forms.Button();
            this.btnAdminLog = new System.Windows.Forms.Button();
            this.btnManagerLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUserLog
            // 
            this.btnUserLog.Location = new System.Drawing.Point(42, 83);
            this.btnUserLog.Name = "btnUserLog";
            this.btnUserLog.Size = new System.Drawing.Size(191, 23);
            this.btnUserLog.TabIndex = 0;
            this.btnUserLog.Text = "Вход от имени пользователя";
            this.btnUserLog.UseVisualStyleBackColor = true;
            this.btnUserLog.Click += new System.EventHandler(this.btnUserLog_Click);
            // 
            // btnAdminLog
            // 
            this.btnAdminLog.Location = new System.Drawing.Point(42, 25);
            this.btnAdminLog.Name = "btnAdminLog";
            this.btnAdminLog.Size = new System.Drawing.Size(191, 23);
            this.btnAdminLog.TabIndex = 1;
            this.btnAdminLog.Text = "Вход от имени администратора";
            this.btnAdminLog.UseVisualStyleBackColor = true;
            this.btnAdminLog.Click += new System.EventHandler(this.btnAdminLog_Click);
            // 
            // btnManagerLog
            // 
            this.btnManagerLog.Location = new System.Drawing.Point(42, 54);
            this.btnManagerLog.Name = "btnManagerLog";
            this.btnManagerLog.Size = new System.Drawing.Size(191, 23);
            this.btnManagerLog.TabIndex = 2;
            this.btnManagerLog.Text = "Вход от имени работника";
            this.btnManagerLog.UseVisualStyleBackColor = true;
            this.btnManagerLog.Click += new System.EventHandler(this.btnManagerLog_Click);
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 128);
            this.Controls.Add(this.btnManagerLog);
            this.Controls.Add(this.btnAdminLog);
            this.Controls.Add(this.btnUserLog);
            this.Name = "EnterForm";
            this.Text = "Окно логина";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserLog;
        private System.Windows.Forms.Button btnAdminLog;
        private System.Windows.Forms.Button btnManagerLog;
    }
}

