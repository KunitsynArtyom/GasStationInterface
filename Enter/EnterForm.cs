using System;
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
using Queries.Controllers;
using Queries.Entities;
using System.Data.Common;
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
        }

        private void btnUserLog_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS");
            //DBConnection dbc = new DBConnection(conn);
            //RepositoryFactory repFactory = new RepositoryFactory(dbc);
            //IRepositoryFactory factory = (IRepositoryFactory)repFactory;
            //UserForm userForm = new UserForm(factory);
            //Hide();
            //userForm.ShowDialog();
            //Show();
        }

        private void btnAdminLog_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS"); // якобы заходим под админом
            DBConnection dbc = new DBConnection(conn);
            RepositoryFactory repFactory = new RepositoryFactory(dbc);
            IRepositoryFactory factory = (IRepositoryFactory)repFactory;
            AdminForm adminForm = new AdminForm(factory);
            Hide();
            adminForm.ShowDialog();
            Show();
        }

        private void btnManagerLog_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS"); // якобы заходим под работником
            //DBConnection dbc = new DBConnection(conn);
            //RepositoryFactory repFactory = new RepositoryFactory(dbc);
            //IRepositoryFactory factory = (IRepositoryFactory)repFactory;
            //WorkerForm workerForm = new WorkerForm(factory);
            //Hide();
            //workerForm.ShowDialog();
            //Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //RepositoryFactory repFactory = null;
            DBConnection dbc = null;
            string Login = String.Empty, Password = String.Empty, role = String.Empty;
            Login login = null;
            try
            {
                Login = tbLogin.Text.ToString();
                Password = tbPassword.Text.ToString();
                login = new Login();
                login.setLogin(Login, Password);
            }
            catch (Exception ex) { MessageBox.Show("Данные для входа введены некорректно!"); }

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS");
                dbc = new DBConnection(conn);
                //dbc.openConnection();
                RepositoryFactory repLoginFactory = new RepositoryFactory(dbc);

                LoginController lc = new LoginController(login, dbc);
                role = lc.tryLogin();
                if (role != String.Empty)
                    MessageBox.Show("Добро пожаловать, " + role);
                else
                    MessageBox.Show("Пользователь не найден!");
            }
            catch (Exception ex) { MessageBox.Show("Данные были введены неверно!"); }

            //RepositoryFactory repFactory = new RepositoryFactory(dbc);
            //IRepositoryFactory factory = (IRepositoryFactory)repFactory;

            role= role.Trim().Replace(" ", string.Empty);

            switch (role)
            {
                case "worker":
                    RepositoryFactory repWorkerFactory = new RepositoryFactory(dbc);
                    IRepositoryFactory workerFactory = (IRepositoryFactory)repWorkerFactory;
                    WorkerForm workerForm = new WorkerForm(Convert.ToInt32(Login), workerFactory);
                    Hide();
                    workerForm.ShowDialog();
                    Show();
                    break;
                case "admin":
                    RepositoryFactory repAdminFactory = new RepositoryFactory(dbc);
                    IRepositoryFactory adminFactory = (IRepositoryFactory)repAdminFactory;
                    AdminForm adminForm = new AdminForm(adminFactory);
                    Hide();
                    adminForm.ShowDialog();
                    Show();
                    break;
                case "user":
                    RepositoryFactory repUserFactory = new RepositoryFactory(dbc);
                    IRepositoryFactory userFactory = (IRepositoryFactory)repUserFactory;
                    UserForm userForm = new UserForm(Login, userFactory);
                    Hide();
                    userForm.ShowDialog();
                    Show();
                    break;
            }
        }
    }
}
