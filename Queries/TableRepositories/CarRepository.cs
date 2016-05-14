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
    public class CarRepository
    {
        public DBConnection dbc;

        public CarRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public List<Car> GetCars()
        {
            List<Car> dgvElements = new List<Car>();
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Car\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Car buyerCar = new Car();
                        buyerCar.buyerSet(Convert.ToInt32(dbDataRecord["car_id"]), dbDataRecord["carmark"].ToString(), dbDataRecord["cardnum"].ToString());
                        dgvElements.Add(buyerCar);
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

        public List<string> GetCardNumList()
        {
            List<string> comboBoxElements = new List<string>();

            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT cardnum FROM \"AZS\".\"Car\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["cardnum"].ToString());
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public void AddToCarTable(Car car)
        {
            NpgsqlCommand queryCommand;
            try
            {
                //dbc.openConnection();

                queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Car\"(carmark, cardnum)" +
                "VALUES(@carmark, @cardnum)", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@carmark", car.GetCarMark());
                queryCommand.Parameters.AddWithValue("@cardnum", car.GetCardNum());

                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }
        }
    }
}
