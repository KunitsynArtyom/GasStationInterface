using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Queries.Entities;
using Queries.Controllers;
using Queries.Interfaces;
using Queries.TableRepositories;

namespace Admin
{
    public partial class AddNewAdminForm : Form
    {
        IRepositoryFactory factory;

        public AddNewAdminForm(IRepositoryFactory factory)
        {
            InitializeComponent();
            this.factory = factory;        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string login = String.Empty, pass = String.Empty;
            try
            {
                login = tbLogin.Text;
                pass = tbPass.Text;
                DBUser nAdmin = new DBUser();
                nAdmin.setNewUser(login, pass, "admin");
                DBUserController adminController = new DBUserController();
                if (adminController.checkAddition(nAdmin))
                {
                    LoginController lc = new LoginController(factory);
                    lc.addToLoginTable(nAdmin);
                    MessageBox.Show("Операция успешно завершена!");
                    //factory.GetLoginRepository().AddNewDBUser(nAdmin);
                }
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неверно!"); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
