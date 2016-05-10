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

namespace Queries
{
    public class UserQuery : IUserQuery //класс, содержащий в себе методы-запросы к таблице GasStation
    {

        public DBConnection dbc;
        public UserQuery(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
            //this.dgv = dgv;
        }
        public List<Station> getStations()
        {        
            List<Station> stationList = new List<Station>();
            try
            {

                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["orgname"].ToString(), dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(), dbDataRecord["street"].ToString(), Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                }
                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                
            }
            finally { dbc.closeConnection(); }
            return stationList;
        }

        public List<Station> findStation(string fCountry, string fCity)
        {
            List<Station> stationList = new List<Station>();
            dbc.openConnection();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                    "'%" + fCountry + "%' AND city LIKE" + "'%" + fCity + "%'", dbc.getConnection());
                NpgsqlDataReader AZSTableSearcher = command.ExecuteReader();
                if (AZSTableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableSearcher)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]),
                            dbDataRecord["orgname"].ToString(),
                            dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(),
                            dbDataRecord["street"].ToString(),
                            Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                }
                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                
            }
            finally { dbc.closeConnection(); }
            return stationList;
        }
    }
}
