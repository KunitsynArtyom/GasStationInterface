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
using Queries;
using Queries.dgvControllers;
using Queries.TableRepositories;
using Queries.Validators;
using Queries.Interfaces;
using Queries.Entities;

namespace Admin
{
    public partial class AddWorkerToLoginTableForm : Form
    {
        DataGridViewRow row;
        IRepositoryFactory factory;

        public AddWorkerToLoginTableForm(DataGridViewRow row, IRepositoryFactory factory)
        {
            InitializeComponent();
            this.row = row;
            this.factory = factory;
        }

        private void AddToLoginTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                lbName.Text = factory.GetStaffRepository().FindStaffByID(Convert.ToInt32(row.Cells["staff_id"].Value));
            }
            catch (Exception) {  }
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
                //DBUserValidator userControl = new DBUserValidator();
                //if (userControl.checkAddition(nWorker))
                //{
                    LoginController loginController = new LoginController(factory);
                loginController.addToLoginTable(nWorker);
                    //MessageBox.Show("Операция успешно завершена!");
                //}
            }
            catch (Exception ex) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }
    }
}
