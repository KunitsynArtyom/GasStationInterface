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

namespace Queries.dgvControllers
{
    public class dgvAccountController
    {
        DataGridView dgv;
        AccountRepository accountQuery;
        List<Account> dgvElements;

        public dgvAccountController(DataGridView dgv, DBConnection dbc)
        {
            dgvElements = new List<Account>();
            this.dgv = dgv;
            accountQuery = new AccountRepository(dbc);
        }

        public void showTable()
        {
            dgvElements = accountQuery.GetAccounting();
            dgv.Rows.Clear();
            foreach (Account account in dgvElements)
            {
                dgv.Rows.Add(account.GetStationAdres(), account.GetFuelAccountType(), 
                    account.GetFuelAccountAmount(), account.GetAccountDate());
            }
        }
    }
}
