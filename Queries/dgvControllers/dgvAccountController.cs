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

namespace Queries.dgvControllers
{
    public class dgvAccountController
    {
        DataGridView dgv;
        AccountRepository accountQuery;
        List<Account> dgvElements;
        IRepositoryFactory factory;

        public dgvAccountController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Account>();
            this.dgv = dgv;
            this.factory = factory;
            //accountQuery = factory.GetAccountRepository();
        }

        public void showTable()
        {
            dgvElements = factory.GetAccountRepository().GetAccounting();
            dgv.Rows.Clear();
            foreach (Account account in dgvElements)
            {
                dgv.Rows.Add(account.GetStationAdres(), account.GetFuelAccountType(), 
                    account.GetFuelAccountAmount(), account.GetAccountDate());
            }
        }
    }
}
