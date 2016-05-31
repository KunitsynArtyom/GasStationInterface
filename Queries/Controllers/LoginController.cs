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
using Queries.TableRepositories;
using Queries.Interfaces;

namespace Queries.Validators
{
    public class LoginController
    {
        Login login;
        IRepositoryFactory factory;
        DBUserValidator dbUserValidator;
        List<string> errorList;
        string error;

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

        public string tryLogin()
        {
            return factory.GetLoginRepository().LoginToTable(login);
        }

        public void addToLoginTable(DBUser dbUser)
        {
            try
            {
                if (dbUserValidator.checkAddition(dbUser, out errorList))
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
            catch (Exception ex) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }
    }
}
