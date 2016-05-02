using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using Connection;
using System.Collections;
using Queries.Entities;

namespace Queries
{
    interface IAdminQuery
    {
        ArrayList showStaffTable();

        void addToStaffTable(Worker wk);

        void updateStaffTabele(Worker wkToUpdate, Worker wk);

        void deleteFromStaffTabele(Worker wkToDelete);

        ArrayList getOrgList();

        ArrayList getStationList(string Orgname);

        int findIDByLocation(string location);

        ArrayList showCarTable();

        ArrayList showBuyerDealTable();

        ArrayList findDealList(Car car, string searchFlag);

        ArrayList getCardNumList();

        void addToCarTable(Car car);

    }
}
