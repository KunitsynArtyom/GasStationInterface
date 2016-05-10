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
        //ArrayList dgvElements;
        List<Worker> dgvElements;

        public dgvStaffFiller(DataGridView dgv, AdminQuery adminQuery)
        {
            dgvElements = new List<Worker>();
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = adminQuery.GetStaff();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction(), wk.GetSalary());
            }
        }

        public void addToTable(Worker wk)
        {
            adminQuery.AddToStaffTable(wk);
        }

        public void updateTable(/*DataGridViewRow updateRow*/int number, Worker wk)
        {
            var workerList = adminQuery.GetStaff();
            Worker wkToUpdate = (Worker)workerList[number];
            adminQuery.UpdateStaffTabele(wkToUpdate, wk);
        }

        public void deleteFromTable(int number)
        {
            var workerList = adminQuery.GetStaff();
            Worker wkToDelete = (Worker)workerList[number];
            adminQuery.DeleteFromStaffTabele(wkToDelete);
        }
    }
}
