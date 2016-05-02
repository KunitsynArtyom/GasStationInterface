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
    public class dgvStaffFiller
    {
        DataGridView dgv;
        AdminQuery adminQuery;
        ArrayList dgvElements;

        public dgvStaffFiller(DataGridView dgv, AdminQuery adminQuery)
        {
            dgvElements = new ArrayList();
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = adminQuery.showStaffTable();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction());
            }
        }

        public void addToTable(Worker wk)
        {
            adminQuery.addToStaffTable(wk);
        }

        public void updateTable(/*DataGridViewRow updateRow*/int number, Worker wk)
        {
            var workerList = adminQuery.showStaffTable();
            Worker wkToUpdate = (Worker)workerList[number];
            adminQuery.updateStaffTabele(wkToUpdate, wk);
        }

        public void deleteFromTable(int number)
        {
            var workerList = adminQuery.showStaffTable();
            Worker wkToDelete = (Worker)workerList[number];
            adminQuery.deleteFromStaffTabele(wkToDelete);
        }
    }
}
