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
using Queries;
using Queries.Interfaces;
using Queries.Validators;
using Queries.Entities;
using Queries.Security;
using User;
using Admin;
using Worker;


namespace Enter
{
    public partial class EnterForm : Form //форма логина
    {
        public EnterForm()
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
        }

        private void btnAdminLog_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = admin; Password = qwerty1; Database = AZS"); // якобы заходим под админом
            DBConnection dbc = new DBConnection(conn);
            RepositoryFactory repFactory = new RepositoryFactory(dbc);
            IRepositoryFactory factory = (IRepositoryFactory)repFactory;
            AdminForm adminForm = new AdminForm(factory);
            Hide();
            adminForm.ShowDialog();
            Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //RepositoryFactory repFactory = null;
            DBConnection dbc = null;
            string Login = String.Empty, Password = String.Empty, role = String.Empty, rolePass = String.Empty;
            Login login = null;
            try
            {
                Login = tbLogin.Text.ToString();
                Password = tbPassword.Text.ToString();
                login = new Login();
                login.setLogin(Login.Trim().Replace(" ", string.Empty), SecurityCrypt.MD5(Password).Trim().Replace(" ", string.Empty));
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = login_check; Password = 123456; Database = AZS");
                dbc = new DBConnection(conn);
                RepositoryFactory repLoginFactory = new RepositoryFactory(dbc);
                LoginController lc = new LoginController(login, repLoginFactory);
                role = lc.TryLogin();

                MessageBox.Show(Login.ToString());
                MessageBox.Show(SecurityCrypt.MD5(Password.ToString()));
                MessageBox.Show(role.ToString());


                if (role != String.Empty)
                    MessageBox.Show("Добро пожаловать, " + role);
                else
                    MessageBox.Show("Пользователь не найден!");

                role = role.Trim().Replace(" ", string.Empty);
                rolePass = SecurityCrypt.Decrypt(lc.GetDBPassWordByRole(role), SecurityConst.sha1Key);
                MessageBox.Show(rolePass);

                EnterRole(role, Login, rolePass);

                //switch (role)
                //{
                //    case "worker":
                //        NpgsqlConnection workerConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = worker; Password =" + rolePass +"; Database = AZS");
                //        DBConnection workerDbc = new DBConnection(workerConn);
                //        IRepositoryFactory repWorkerFactory = new RepositoryFactory(workerDbc);
                //        WorkerForm workerForm = new WorkerForm(Convert.ToInt32(Login), repWorkerFactory);
                //        Hide();
                //        workerForm.ShowDialog();
                //        Show();
                //        break;
                //    case "admin":
                //        NpgsqlConnection adminConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = admin; Password =" + rolePass + "; Database = AZS");
                //        DBConnection adminDbc = new DBConnection(adminConn);
                //        IRepositoryFactory repAdminFactory = new RepositoryFactory(adminDbc);
                //        AdminForm adminForm = new AdminForm(repAdminFactory);
                //        Hide();
                //        adminForm.ShowDialog();
                //        Show();
                //        break;
                //    case "user":
                //        NpgsqlConnection userConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = user; Password =" + rolePass + "; Database = AZS");
                //        DBConnection userDbc = new DBConnection(userConn);
                //        IRepositoryFactory repUserFactory = new RepositoryFactory(dbc);
                //        UserForm userForm = new UserForm(Login, repUserFactory);
                //        Hide();
                //        userForm.ShowDialog();
                //        Show();
                //        break;
                //}
            }
            catch (Exception) { MessageBox.Show("Ошибка входа!"); }
        }

        private void EnterRole(string role, string Login, string rolePass)
        {
            switch (role)
            {
                case "worker":
                    NpgsqlConnection workerConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = worker; Password =" + rolePass + "; Database = AZS");
                    DBConnection workerDbc = new DBConnection(workerConn);
                    IRepositoryFactory repWorkerFactory = new RepositoryFactory(workerDbc);
                    WorkerForm workerForm = new WorkerForm(Convert.ToInt32(Login), repWorkerFactory);
                    Hide();
                    workerForm.ShowDialog();
                    Show();
                    break;
                case "admin":
                    NpgsqlConnection adminConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = admin; Password =" + rolePass + "; Database = AZS");
                    DBConnection adminDbc = new DBConnection(adminConn);
                    IRepositoryFactory repAdminFactory = new RepositoryFactory(adminDbc);
                    AdminForm adminForm = new AdminForm(repAdminFactory);
                    Hide();
                    adminForm.ShowDialog();
                    Show();
                    break;
                case "user":
                    NpgsqlConnection userConn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = user; Password =" + rolePass + "; Database = AZS");
                    DBConnection userDbc = new DBConnection(userConn);
                    IRepositoryFactory repUserFactory = new RepositoryFactory(userDbc);
                    UserForm userForm = new UserForm(Login, repUserFactory);
                    Hide();
                    userForm.ShowDialog();
                    Show();
                    break;
            }
        }
    }
}