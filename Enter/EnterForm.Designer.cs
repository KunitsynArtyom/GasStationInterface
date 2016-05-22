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
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
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
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(327, 28);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(152, 20);
            this.tbLogin.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(327, 57);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(152, 20);
            this.tbPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(404, 96);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Логин";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(404, 125);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 169);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btnManagerLog);
            this.Controls.Add(this.btnAdminLog);
            this.Controls.Add(this.btnUserLog);
            this.Name = "EnterForm";
            this.Text = "Окно логина";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUserLog;
        private System.Windows.Forms.Button btnAdminLog;
        private System.Windows.Forms.Button btnManagerLog;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
    }
}

