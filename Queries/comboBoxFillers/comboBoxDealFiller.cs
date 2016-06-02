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
using Queries.comboBoxFillers;
using Queries.Repositories;
using Queries.Interfaces;

namespace Queries.comboBoxFillers
{
    public class ComboBoxDealFiller
    {
        private ComboBox cb;
        private List<string> comboBoxElements;
        private IRepositoryFactory factory;

        public ComboBoxDealFiller(ComboBox cb, IRepositoryFactory factory)
        {
            this.cb = cb;
            this.factory = factory;
        }

        public void СbOrgFill()
        {
            comboBoxElements = factory.GetStationRepository().GetOrganisations();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void СbStationFill(string Orgname)
        {
            comboBoxElements = factory.GetStationRepository().GetStationsAdres(Orgname);
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st.Trim().Replace(" ", string.Empty));
            }
        }

        public void СbCardnumFill()
        {
            List<Car> comboBoxCarElements = factory.GetCarRepository().GetCars();
            foreach (Car car in comboBoxCarElements)
            {               
                cb.Items.Add(car.GetCardNum().Trim().Replace(" ", string.Empty));
            }
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
