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

namespace Queries
{
    interface IAdminQuery
    {
        ArrayList showStaffTable();
        void addToStaffTable(Worker wk);
        void updateStaffTabele(string oldSurname, string oldName, string oldGender, string oldFunction, Worker wk);
    }
}
