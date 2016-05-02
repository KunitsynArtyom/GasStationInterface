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
    public class dgvStationFiller
    {
        DataGridView dgv;
        UserQuery userQuery;
        ArrayList dgvElements;

        public dgvStationFiller(DataGridView dgv, UserQuery userQuery)
        {
            //dgvElements = new ArrayList();
            this.userQuery = userQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = new ArrayList();
            dgvElements = userQuery.showAZSTable();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(),ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void findInTable(string country, string city)
        {
            dgvElements = new ArrayList();
            dgvElements = userQuery.findAZS(country, city);
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }
    }
}
