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

namespace Queries.dgvControllers
{
    public class dgvDealController
    {
        DataGridView dgv;
        DealRepository dealQuery;
        CarRepository carQuery;
        StaffRepository staffQuery;
        List<Deal> dgvElements;


        public dgvDealController(DataGridView dgv, DBConnection dbc)
        {
            dgvElements = new List<Deal>();
            dealQuery = new DealRepository(dbc);
            carQuery = new CarRepository(dbc);
            staffQuery = new StaffRepository(dbc);
            this.dgv = dgv;
        }

        public int showDeals(int number)
        {
            var foundDealList = new List<Deal>();
            var dealList = dealQuery.ShowBuyerDealTable();
            var carDeal = carQuery.GetCars();
            Car foundCar = carDeal[number];
            //Deal foundDeal = (Deal)dealList[number];
             foundDealList = dealQuery.GetDeals(foundCar);
            if (foundDealList.Count != 0)
            {
                foreach (Deal deal in foundDealList)
                {
                    dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
                }
            }
            else MessageBox.Show("Сделок с данным покупателем не найдено!");

            return foundDealList.Count;
        }

        public void showTable()
        {
            dgvElements = dealQuery.ShowDealTable();
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(staffQuery.FindStaffByID(deal.GetStaff_id()), deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
            }
        }

        public void updateTable(int number, Deal deal)
        {
            var dealList = dealQuery.ShowDealTable();
            Deal dealToUpdate = dealList[number];
            dealQuery.UpdateDealTabele(dealToUpdate, deal);
        }
    }
}
