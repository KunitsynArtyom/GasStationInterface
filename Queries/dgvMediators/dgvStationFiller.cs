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
        List<Station> dgvElements;

        public dgvStationFiller(DataGridView dgv, UserQuery userQuery)
        {
            //dgvElements = new ArrayList();
            this.userQuery = userQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = new List<Station>();
            dgvElements = userQuery.getStations();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(),ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void findInTable(string country, string city)
        {
            dgvElements = new List<Station>();
            dgvElements = userQuery.findStation(country, city);
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }
    }
}
