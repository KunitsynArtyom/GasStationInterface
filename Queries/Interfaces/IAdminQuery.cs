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
    interface IAdminQuery
    {
        List<Worker> GetStaff();

        void AddToStaffTable(Worker wk);

        void UpdateStaffTabele(Worker wkToUpdate, Worker wk);

        void DeleteFromStaffTabele(Worker wkToDelete);

        List<string> GetOrganisations();

        List<string> GetStationsAdres(string Orgname);

        int FindStationIDByLocation(string location);

        List<Car> GetCars();

        List<Deal> ShowBuyerDealTable();

        List<Deal> GetDeals(Car car);

        List<string> GetCardNumList();

        void AddToCarTable(Car car);

        List<Account> GetAccounting();

    }
}
