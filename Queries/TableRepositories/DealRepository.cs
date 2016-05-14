using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries.Entities;


namespace Queries.TableRepositories
{
    public class DealRepository
    {
        public DBConnection dbc;

        public DealRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public List<Deal> ShowDealTable()
        {
            List<Deal> dealList = new List<Deal>();
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();

                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dealList.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }

            return dealList;
        }

        public List<Deal> GetDeals(Car car)
        {
            List<Deal> dgvElements = new List<Deal>();

            try
            {
                NpgsqlDataReader AZSTableReader = null;
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = @Car_id", dbc.getConnection());
                //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = '" + car.GetCar_id() + "' ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", car.GetCar_id());
                AZSTableReader = queryCommand.ExecuteReader();
                //NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal foundDeal = new Deal();
                        foundDeal.dealSet(dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"].ToString()),
                            Convert.ToInt32(dbDataRecord["dealprice"]), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dgvElements.Add(foundDeal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public void UpdateDealTabele(Deal dealToUpdate, Deal deal)
        {
            try
            {
                //dbc.openConnection();
                //NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Deal\" SET fueltype = '" + deal.GetFuelType() + "', fuelamount = '" + deal.GetFuelAmount() + 
                //"', dealprice = '" + deal.GetDealPrice() + "', cardnum = '" + deal.GetCardNum() + "', dealdate = '" + deal.GetDealDate() + "'" +
                //" WHERE deal_id = " + Convert.ToInt32(dealToUpdate.GetDeal_id()) + " ", dbc.getConnection());
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Deal\" SET fueltype = @Fueltype, fuelamount = @Fuelamount, dealprice = @DealPrice," +
                    "cardnum = @Cardnum, dealdate = @DealDate WHERE deal_id = @Deal_id ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Fueltype", deal.GetFuelType());
                queryCommand.Parameters.AddWithValue("@Fuelamount", deal.GetFuelAmount());
                queryCommand.Parameters.AddWithValue("@DealPrice", deal.GetDealPrice());
                queryCommand.Parameters.AddWithValue("@Cardnum", deal.GetCardNum());
                queryCommand.Parameters.AddWithValue("@DealDate", deal.GetDealDate());
                queryCommand.Parameters.AddWithValue("@Deal_id", dealToUpdate.GetDeal_id());
                queryCommand.ExecuteNonQuery();

            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }
        }

        public List<Deal> ShowBuyerDealTable()
        {
            List<Deal> dgvElements = new List<Deal>();
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();
                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]),
                            Convert.ToInt32(dbDataRecord["staff_id"]), dbDataRecord["fueltype"].ToString(),
                            Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()).Date);
                        dgvElements.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }

            return dgvElements;
        }
    }
}
