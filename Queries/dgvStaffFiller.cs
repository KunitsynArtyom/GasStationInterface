using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Queries
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

        public void updateTable(DataGridViewRow updateRow, Worker wk)
        {
            //int oldStaff_id = Convert.ToInt32(updateRow.Cells["staff_id"].Value);
            string oldSurname = Convert.ToString(updateRow.Cells["surname"].Value);
            string oldName = Convert.ToString(updateRow.Cells["name"].Value);
            string oldGender = Convert.ToString(updateRow.Cells["gender"].Value);
            string oldFunction = Convert.ToString(updateRow.Cells["function"].Value);
            adminQuery.updateStaffTabele(oldSurname, oldName, oldGender, oldFunction, wk);
        }
    }
}
