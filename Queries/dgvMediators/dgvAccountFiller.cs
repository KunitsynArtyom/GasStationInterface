using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Queries.Entities;

namespace Queries.dgvMediators
{
    public class dgvAccountFiller
    {
        DataGridView dgv;
        AdminQuery adminQuery;
        List<Account> dgvElements;

        public dgvAccountFiller(DataGridView dgv, AdminQuery adminQuery)
        {
            dgvElements = new List<Account>();
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = adminQuery.GetAccounting();
            dgv.Rows.Clear();
            foreach (Account account in dgvElements)
            {
                dgv.Rows.Add(account.GetStationAdres(), account.GetFuelAccountType(), 
                    account.GetFuelAccountAmount(), account.GetAccountDate());
            }
        }
    }
}
