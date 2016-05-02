using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Queries.combBoxFillers
{
    public class comboBoxStaffFiller
    {
        ComboBox cb;       
        ArrayList comboBoxElements;
        AdminQuery adminQuery;
        public comboBoxStaffFiller(ComboBox cb, AdminQuery adminQuery)
        {
            this.cb = cb;
            this.adminQuery = adminQuery; ;
        }

        public void cb_orgFill()
        {
            comboBoxElements = adminQuery.getOrgList();
            //foreach (Station ps in comboBoxElements)
            foreach (String st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void cb_stationFill(string Orgname)
        {
            comboBoxElements = adminQuery.getStationList(Orgname);
            //foreach (Station ps in comboBoxElements)
            foreach (String st in comboBoxElements)
            {
                string cbString = RemoveSpaces(st);
                //st.Trim();
                cb.Items.Add(cbString);
            }
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
