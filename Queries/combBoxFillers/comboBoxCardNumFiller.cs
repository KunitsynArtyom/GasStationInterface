using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Queries.combBoxFillers
{
    public class comboBoxCardNumFiller
    {
        ComboBox cb;
        List<string> comboBoxElements;
        AdminQuery adminQuery;
        public comboBoxCardNumFiller(ComboBox cb, AdminQuery adminQuery)
        {
            this.cb = cb;
            this.adminQuery = adminQuery; ;
        }

        public void cb_CardNumFill()
        {
            comboBoxElements = adminQuery.GetCardNumList();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }
    }
}
