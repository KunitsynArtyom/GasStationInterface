using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;
using Queries.TableRepositories;
using Queries.dgvControllers;

namespace Queries.dgvControllers
{
    public class dgvStaffController
    {
        DataGridView dgv;
        StaffRepository staffQuery;
        List<Worker> dgvElements;
        DBConnection dbc;

        public dgvStaffController(DataGridView dgv, DBConnection dbc)
        {
            dgvElements = new List<Worker>();
            this.dbc = dbc;
            this.dgv = dgv;
            staffQuery = new StaffRepository(dbc);
        }

        public void showTable()
        {
            dgvElements = staffQuery.GetStaff();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction(), wk.GetSalary());
            }
        }

        public void addToTable(Worker wk)
        {
            staffQuery.AddToStaffTable(wk);
        }

        public void updateTable(int number, Worker wk)
        {
            var workerList = staffQuery.GetStaff();
            Worker wkToUpdate = workerList[number];
            staffQuery.UpdateStaffTable(wkToUpdate, wk);
        }

        public void deleteFromTable(int number)
        {
            var workerList = staffQuery.GetStaff();
            Worker wkToDelete = workerList[number];
            staffQuery.DeleteFromStaffTabele(wkToDelete);
        }
    }
}
