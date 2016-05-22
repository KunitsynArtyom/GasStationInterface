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
using Queries.Interfaces;

namespace Queries.dgvControllers
{
    public class dgvDealController
    {
        DataGridView dgv;
        List<Deal> dgvElements;
        IRepositoryFactory factory;


        public dgvDealController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Deal>();
            this.factory = factory;
            this.dgv = dgv;
        }

        public int showDeals(int id)
        {
            var foundDealList = new List<Deal>();
            var dealList = factory.GetDealRepository().ShowBuyerDealTable(id);
            //var carDeal = factory.GetCarRepository().GetCars();
            //Car foundCar = carDeal[number];
            // foundDealList = factory.GetDealRepository().GetDeals(foundCar);
            if (dealList.Count != 0)
            {
                foreach (Deal deal in dealList)
                {
                    dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
                }
            }
            else MessageBox.Show("Сделок с данным покупателем не найдено!");

            return dealList.Count;
        }

        public void showTable()
        {
            dgvElements = factory.GetDealRepository().ShowDealTable();
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetDeal_id(), factory.GetStaffRepository().FindStaffByID(deal.GetStaff_id()), deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
            }
        }

        public void showWorkerTable(int ID)
        {
            dgvElements = factory.GetDealRepository().ShowWorkerDealTable(ID);
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
            }
        }

        public void showUserTable(string cardnum)
        {
            dgvElements = factory.GetDealRepository().ShowUserDealTable(cardnum);
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
            }
        }

        public void updateTable(int id, Deal deal)
        {
            factory.GetDealRepository().UpdateDealTable(id, deal);
            //var dealList = factory.GetDealRepository().ShowDealTable();
            //Deal dealToUpdate = dealList[number];
            //factory.GetDealRepository().UpdateDealTabele(dealToUpdate, deal);
        }

        public void addToTable(Deal deal)
        {
            factory.GetDealRepository().AddToDealTable(deal);
        }
    }
}
