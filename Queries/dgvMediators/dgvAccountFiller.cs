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
using Queries.dgvMediators;
using Queries.combBoxFillers;
using Queries.TableRepositories;

namespace Queries.dgvMediators
{
    public class dgvAccountFiller
    {
        DataGridView dgv;
        AccountRepository accountQuery;
        List<Account> dgvElements;
        NpgsqlConnection conn;

        public dgvAccountFiller(DataGridView dgv, NpgsqlConnection conn)
        {
            dgvElements = new List<Account>();
            this.conn = conn;
            this.dgv = dgv;
            accountQuery = new AccountRepository(conn);
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
