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
using Queries.TableRepositories;

namespace Queries.comboBoxFillers
{
    public class comboBoxDealFiller
    {
        ComboBox cb;
        NpgsqlConnection conn;
        List<string> comboBoxElements;
        DealRepository dealQuery;
        StationRepository stationQuery;
        CarRepository carQuery;


        public comboBoxDealFiller(ComboBox cb, DBConnection dbc)
        {
            this.cb = cb;
            dealQuery = new DealRepository(dbc);
            stationQuery = new StationRepository(dbc);
            carQuery = new CarRepository(dbc);
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

        public void cb_cardnumFill()
        {
            List<Car> comboBoxCarElements = carQuery.GetCars();
            foreach (Car car in comboBoxCarElements)
            {               
                cb.Items.Add(car.GetCardNum());
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
