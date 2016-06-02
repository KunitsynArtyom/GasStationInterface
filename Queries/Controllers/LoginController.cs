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
using System.Data.Common;
using System.Collections;
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.comboBoxFillers;
using Queries.Repositories;
using Queries.Interfaces;

namespace Queries.Validators
{
    public class LoginController
    {
        private Login login;
        private IRepositoryFactory factory;
        private DBUserValidator dbUserValidator;
        private List<string> errorList;
        private string error;

        public LoginController(Login login, IRepositoryFactory factory)
        {
            if (login == null)
            {
                throw new ArgumentNullException();
            }
            this.login = login;
            this.factory = factory;
            dbUserValidator = new DBUserValidator();
        }

        public LoginController(IRepositoryFactory factory)
        {
            this.factory = factory;
            dbUserValidator = new DBUserValidator();
        }

        public string TryLogin()
        {
            return factory.GetLoginRepository().LoginToTable(login);
        }

        public string GetDBPassWordByRole(string role)
        {
            string passWord = String.Empty;
            try
            {
                passWord = factory.GetLoginRepository().GetRolePass(role);
            }
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!"); }

            return passWord;
        }

        public bool AddToLoginTable(DBUser dbUser)
        {
            bool checkFlag = false;
            try
            {
                if (checkFlag = dbUserValidator.checkAddition(dbUser, out errorList))
                {
                    factory.GetLoginRepository().AddNewDBUser(dbUser);
                }
                else
                {
                    int k = 0;
                    foreach (string str in errorList)
                    {
                        k++;
                        error += "Ошибка №" + k + ": " + str + " \n";
                    }
                    MessageBox.Show(error);
                }
            }
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return checkFlag;
        }
    }
}
