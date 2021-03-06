﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries.Entities;
using Queries.Interfaces;


namespace Queries.Repositories
{
    public class DealRepository : IDealRepository
    {
        private DBConnection dbc;

        public DealRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public void Dispose()
        {

        }

        //public List<Deal> ShowDealTable()
        //{
        //    List<Deal> dealList = new List<Deal>();
        //    try
        //    {
        //        dbc.openConnection();
        //        NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
        //        NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
        //        if (AZSTableReader.HasRows)
        //        {
        //            foreach (DbDataRecord dbDataRecord in AZSTableReader)
        //            {
        //                Deal deal = new Deal();

        //                deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
        //                    dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
        //                    dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
        //                dealList.Add(deal);
        //            }
        //        }
        //        AZSTableReader.Close();
        //    }
        //    catch (PostgresException pe)
        //    {
        //        throw pe;
        //    }
        //    finally { dbc.closeConnection(); }

        //    return dealList;
        //}

        public List<Deal> ShowDealTable()
        {
            List<Deal> dealList = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();

                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dealList.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return dealList;
        }

        public List<Deal> ShowUserDealTable(int id)
        {
            List<Deal> dealList = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\" WHERE car_id = @Car_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", id);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();

                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dealList.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return dealList;
        }

        public List<Deal> ShowWorkerDealTable(int id)
        {
            List<Deal> dealList = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\" WHERE staff_id = @Staff_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Staff_id", id);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();

                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            Convert.ToDateTime(dbDataRecord["dealdate"]));
                        dealList.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return dealList;
        }

        public List<Deal> GetDeals(Car car)
        {
            List<Deal> dgvElements = new List<Deal>();

            try
            {
                NpgsqlDataReader AZSTableReader = null;
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = @Car_id", dbc.getConnection());
                //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = '" + car.GetCar_id() + "' ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", car.GetCarID());
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
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public void UpdateDealTable(int id, Deal deal)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Deal\" SET car_id = @Car_id, fueltype = @Fueltype, fuelamount = @Fuelamount, dealprice = @DealPrice," +
                    "dealdate = @DealDate WHERE deal_id = @Deal_id ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", deal.GetCarID());
                queryCommand.Parameters.AddWithValue("@Fueltype", deal.GetFuelType());
                queryCommand.Parameters.AddWithValue("@Fuelamount", deal.GetFuelAmount());
                queryCommand.Parameters.AddWithValue("@DealPrice", deal.GetDealPrice());
                queryCommand.Parameters.AddWithValue("@DealDate", deal.GetDealDate());
                queryCommand.Parameters.AddWithValue("@Deal_id", id);
                queryCommand.ExecuteNonQuery();

            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
        }

        public void AddToDealTable(Deal deal)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Deal\"(Car_ID , Staff_ID , FuelType , FuelAmount , DealPrice , DealDate)" +
                        "VALUES(@Car_id, @Staff_id, @FuelType, @FuelAmount, @DealPrice, @DealDate)", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", deal.GetCarID());
                queryCommand.Parameters.AddWithValue("@Staff_id", deal.GetStaff_id());
                queryCommand.Parameters.AddWithValue("@FuelType", deal.GetFuelType());
                queryCommand.Parameters.AddWithValue("@FuelAmount", deal.GetFuelAmount());
                queryCommand.Parameters.AddWithValue("@DealPrice", deal.GetDealPrice());
                //queryCommand.Parameters.AddWithValue("@CardNum", deal.GetCardNum());
                queryCommand.Parameters.AddWithValue("@DealDate", Convert.ToDateTime(deal.GetDealDate()));
            queryCommand.ExecuteNonQuery();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
        }

        public List<Deal> ShowBuyerDealTable(int id)
        {
            List<Deal> dgvElements = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\" WHERE car_id = @Car_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", id);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();
                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]),
                            Convert.ToInt32(dbDataRecord["staff_id"]), dbDataRecord["fueltype"].ToString(),
                            Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dgvElements.Add(deal);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }
    }
}
