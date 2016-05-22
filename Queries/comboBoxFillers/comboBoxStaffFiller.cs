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
using Queries.dgvControllers;
using Queries.TableRepositories;
using Queries.Interfaces;

namespace Queries.comboBoxFillers
{
    public class comboBoxStaffFiller
    {
        ComboBox cb;
        List<string> comboBoxElements;
        StaffRepository staffQuery;
        StationRepository stationQuery;
        IRepositoryFactory factory;

        public comboBoxStaffFiller(ComboBox cb, IRepositoryFactory factory)
        {
            this.cb = cb;
            this.factory = factory;
            //staffQuery = factory.GetStaffRepository();
            //stationQuery = factory.GetStationRepository();

        }

        public void cb_orgFill()
        {
            comboBoxElements = factory.GetStationRepository().GetOrganisations();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void cb_stationFill(string Orgname)
        {
            comboBoxElements = factory.GetStationRepository().GetStationsAdres(Orgname);
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
