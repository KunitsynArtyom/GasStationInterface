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

namespace Queries.combBoxFillers
{
    public class comboBoxStaffFiller
    {
        ComboBox cb;
        //ArrayList comboBoxElements;
        List<string> comboBoxElements;
        StaffRepository staffQuery;
        StationRepository stationQuery;
        NpgsqlConnection conn;

        public comboBoxStaffFiller(ComboBox cb, NpgsqlConnection conn)
        {
            this.cb = cb;
            this.conn = conn;
            staffQuery = new StaffRepository(conn);
            stationQuery = new StationRepository(conn);

        }

        public void cb_orgFill()
        {
            comboBoxElements = stationQuery.GetOrganisations();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void cb_stationFill(string Orgname)
        {
            comboBoxElements = stationQuery.GetStationsAdres(Orgname);
            foreach (string st in comboBoxElements)
            {
                string cbString = RemoveSpaces(st);
                cb.Items.Add(cbString);
            }
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
