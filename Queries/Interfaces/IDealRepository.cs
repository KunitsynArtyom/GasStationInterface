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
    public interface IDealRepository
    {
        List<Deal> ShowDealTable();

        List<Deal> GetDeals(Car car);

        void UpdateDealTabele(Deal dealToUpdate, Deal deal);

        List<Deal> ShowBuyerDealTable();

    }
}
