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
using Queries.TableQueries;

namespace Queries
{
    public class UserQuery : IUserQuery //класс, содержащий в себе методы-запросы к таблице GasStation
    {

        public DBConnection dbc;
        public UserQuery(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
        }

        public List<Station> getStations()
        {
            StationQuery stationQuery = new StationQuery(dbc);
            List<Station> stationList = stationQuery.getStations();
            return stationList;
        }

        public List<Station> findStation(string fCountry, string fCity)
        {
            StationQuery stationQuery = new StationQuery(dbc);
            List<Station> stationList = stationQuery.findStations(fCountry, fCity);
            return stationList;
        }
    }
}
