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

namespace Queries
{
    public class WorkerQuery : IWorkerQuery
    {
        public DataGridView dgv;
        public DBConnection dbc;
        public WorkerQuery(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
        }

        public List<Deal> getDealList()
        {
            List<Deal> dgvElements = new List<Deal>();
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
                                dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                                dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dgvElements.Add(deal);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
            return dgvElements;
        }

        public string findStaffByID(int staff_id)
        {
            string SName = "", name, surname;
            try
            {
                NpgsqlDataReader AZSTableReader = null;
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT surname, name FROM \"AZS\".\"Staff\" WHERE staff_id = '" + staff_id + "' ", dbc.getConnection());
                AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                    {
                       foreach (DbDataRecord dbDataRecord in AZSTableReader)
                        {
                            surname = dbDataRecord["surname"].ToString().Replace(" ", string.Empty);
                            name  = dbDataRecord["name"].ToString().Replace(" ", string.Empty);
                            SName = surname + " " + name;                       
                         }
                    }
                }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return SName;
        }

        public ArrayList getOrgList()
        {
            var comboBoxElements = new ArrayList();

            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT orgname FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["orgname"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public ArrayList getStationList(string Orgname)
        {
            var comboBoxElements = new ArrayList();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT country, city, street FROM \"AZS\".\"GasStation\" WHERE orgname = '" + Orgname + "' ", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["country"].ToString() + "," + dbDataRecord["city"].ToString() + "," + dbDataRecord["street"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }
    }
}
