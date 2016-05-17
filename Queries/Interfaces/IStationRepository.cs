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


namespace Queries.Interfaces
{
    public interface IStationRepository : IDisposable
    {
        int FindStationIDByLocation(string location);

        List<Station> findStations(string fCountry, string fCity);

        List<string> GetOrganisations();

        List<Station> getStations();

        List<string> GetStationsAdres(string Orgname);

        string GetStationsAdresByID(int station_id);

        void AddToStationTable(Station st);

    }
}
