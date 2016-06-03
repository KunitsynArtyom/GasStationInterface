﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using Queries;
using Queries.dgvControllers;
using Queries.Repositories;
using Queries.Validators;
using Queries.Interfaces;
using Queries.Entities;

namespace Admin
{
    public partial class AddWorkerToLoginTableForm : Form
    {
        private DataGridViewRow row;
        private IRepositoryFactory factory;

        public AddWorkerToLoginTableForm(DataGridViewRow row, IRepositoryFactory factory)
        {
            InitializeComponent();
            this.row = row;
            this.factory = factory;
        }

        private void AddToLoginTableForm_Load(object sender, EventArgs e)
        {
            if (!factory.GetLoginRepository().CheckLoginExistence(row.Cells["staff_id"].Value.ToString().Trim().Replace(" ", string.Empty)))
            {
                try
                {
                    tbPass.UseSystemPasswordChar = true;
                    lbName.Text = factory.GetStaffRepository().FindStaffByID(Convert.ToInt32(row.Cells["staff_id"].Value));
                }
                catch (Exception) { }
            }
            else
            {
                MessageBox.Show("Этому работнику уже был выдан пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string passWord = String.Empty;
            try
            {
                passWord = tbPass.Text.ToString();
                DBUser nWorker = new DBUser();
                nWorker.setNewUser(row.Cells["staff_id"].Value.ToString(), passWord.ToString(), "worker");
                LoginController loginController = new LoginController(factory);
                if (loginController.AddToLoginTable(nWorker))
                {
                    MessageBox.Show("Операция выполнена успешно!");
                    Close();
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
