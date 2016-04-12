using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Queries
{
    public class comboBoxStaffFiller
    {
        ComboBox cb;       
        ArrayList comboBoxElements;
        UserQuery userQuery;
        public comboBoxStaffFiller(ComboBox cb, UserQuery userQuery)
        {
            this.cb = cb;
            this.userQuery = userQuery; ;
        }

        public ArrayList cb_stationFill()
        {
            comboBoxElements = userQuery.showAZSTable();
            return comboBoxElements;
        }
    }
}
