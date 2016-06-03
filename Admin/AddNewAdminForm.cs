﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Queries.Entities;
using Queries.Validators;
using Queries.Interfaces;
using Queries.Repositories;
using Queries.Security;

namespace Admin
{
    public partial class AddNewAdminForm : Form
    {
        private IRepositoryFactory factory;

        public AddNewAdminForm(IRepositoryFactory factory)
        {
            InitializeComponent();
            this.factory = factory;
            tbPass.UseSystemPasswordChar = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string login = String.Empty, pass = String.Empty;
            try
            {
                login = tbLogin.Text.ToString();
                pass = tbPass.Text.ToString();
                DBUser nAdmin = new DBUser();
                nAdmin.setNewUser(login, pass, "admin");
                LoginController lc = new LoginController(factory);
                if (!factory.GetLoginRepository().CheckLoginExistence(login.ToString().Trim().Replace(" ", string.Empty)))
                {
                    if (lc.AddToLoginTable(nAdmin))
                    {
                        MessageBox.Show("Операция выполнена успешно!");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Администратор с таким именем уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
            {
                tbPass.UseSystemPasswordChar = false;
            }
            else tbPass.UseSystemPasswordChar = true;
        }
    }
}
