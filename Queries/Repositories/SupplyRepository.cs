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
using Queries.Interfaces;

namespace Queries.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private DBConnection dbc;

        public SupplyRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public void Dispose()
        {

        }

        public List<Supply> ShowSupplyTable()
        {
            List<Supply> supplyList = new List<Supply>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Supply\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Supply supply = new Supply();

                        supply.supplySet(Convert.ToInt32(dbDataRecord["station_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fuelsupplytype"].ToString(), Convert.ToInt32(dbDataRecord["fuelsupplyamount"]),
                            Convert.ToDateTime(dbDataRecord["supplydate"].ToString()));
                        supplyList.Add(supply);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return supplyList;
        }

        public void AddToSupplyTable(Supply sup)
        {
            NpgsqlCommand queryCommand;
            try
            {
                dbc.openConnection();
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Supply\"(Station_ID, Staff_ID, FuelSupplyType, FuelSupplyAmount, SupplyDate)" +
                        "VALUES(@Station_id, @Staff_id, @FuelSupplyType, @FuelSupplyAmount, @SupplyDate)", dbc.getConnection());
                    queryCommand.Parameters.AddWithValue("@Station_id", sup.GetStationID());
                    queryCommand.Parameters.AddWithValue("@Staff_id", sup.GetStaffID());
                    queryCommand.Parameters.AddWithValue("@FuelSupplyType", sup.GetFuelSupplyType());
                    queryCommand.Parameters.AddWithValue("@FuelSupplyAmount", sup.GetFuelSupplyAmount());
                    queryCommand.Parameters.AddWithValue("@SupplyDate", sup.GetSupplyDate());

                queryCommand.ExecuteNonQuery();
                dbc.closeConnection(); 
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

        }

        public List<Supply> ShowSupplyTableByID(int ID)
        {
            List<Supply> supplyList = new List<Supply>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Supply\" WHERE station_id = @Station_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Station_id", ID);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Supply supply = new Supply();

                        supply.supplySet(Convert.ToInt32(dbDataRecord["station_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fuelsupplytype"].ToString(), Convert.ToInt32(dbDataRecord["fuelsupplyamount"]),
                            Convert.ToDateTime(dbDataRecord["supplydate"].ToString()));
                        supplyList.Add(supply);
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return supplyList;
        }
    }
}
