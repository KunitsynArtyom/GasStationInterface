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

namespace Queries.dgvControllers
{
    public class AccountController
    {
        private DataGridView dgv;
        private List<Account> dgvElements;
        private IRepositoryFactory factory;

        public AccountController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Account>();
            this.dgv = dgv;
            this.factory = factory;
        }

        public void ShowTable()
        {
            try
            {
                dgvElements = factory.GetAccountRepository().GetAccounting();
                dgv.Rows.Clear();
                foreach (Account account in dgvElements)
                {
                    dgv.Rows.Add(account.GetStation_id(), account.GetStationAdres(), account.GetAccountRole(), account.GetFuelAccountType(),
                        account.GetFuelAccountAmount(), account.GetAccountDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void FilterBYStationID(int id)
        {
            try
            {
                dgvElements = factory.GetAccountRepository().GetAccountingBYStationID(id);
                dgv.Rows.Clear();
                foreach (Account account in dgvElements)
                {
                    dgv.Rows.Add(account.GetStation_id(), account.GetStationAdres(), account.GetAccountRole(), account.GetFuelAccountType(),
                        account.GetFuelAccountAmount(), account.GetAccountDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
