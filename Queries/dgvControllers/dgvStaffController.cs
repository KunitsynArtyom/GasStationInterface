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
using Queries.Interfaces;

namespace Queries.dgvControllers
{
    public class dgvStaffController
    {
        DataGridView dgv;
        List<Worker> dgvElements;
        IRepositoryFactory factory;

        public dgvStaffController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Worker>();
            this.dgv = dgv;
            this.factory = factory;
            //staffQuery = factory.GetStaffRepository();
        }

        public void showTable()
        {
            dgvElements = factory.GetStaffRepository().GetStaff();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetStaff_id(), wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction(), wk.GetSalary());
            }
        }

        public void addToTable(Worker wk)
        {
            factory.GetStaffRepository().AddToStaffTable(wk);
        }

        public void updateTable(int id, Worker wk)
        {
            factory.GetStaffRepository().UpdateStaffTable(id, wk);
            //var workerList = factory.GetStaffRepository().GetStaff();
            //Worker wkToUpdate = workerList[number];
            //factory.GetStaffRepository().UpdateStaffTable(wkToUpdate, wk);
        }

        public void deleteFromTable(int id)
        {

            factory.GetStaffRepository().DeleteFromStaffTable(id);
            //var workerList = factory.GetStaffRepository().GetStaff();
            //Worker wkToDelete = workerList[number];
            //factory.GetStaffRepository().DeleteFromStaffTabele(wkToDelete);
        }
    }
}
