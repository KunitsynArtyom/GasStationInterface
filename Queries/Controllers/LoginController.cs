using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.comboBoxFillers;
using Queries.TableRepositories;
using Queries.Interfaces;

namespace Queries.Controllers
{
    public class LoginController
    {
        Login login;
        DBConnection dbc;
        IRepositoryFactory factory;
        RepositoryFactory repLoginFactory;

        public LoginController(Login login, DBConnection dbc)
        {
            if (login == null)
            {
                throw new ArgumentNullException();
            }
            this.login = login;
            this.dbc = dbc;
            RepositoryFactory repLoginFactory = new RepositoryFactory(dbc);
            factory = repLoginFactory;
        }

        public string tryLogin()
        {
            //LoginRepository lp = new LoginRepository(dbc);
            return factory.GetLoginRepository().LoginToTable(login);
        }    
    }
}
