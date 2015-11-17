using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cache_Simulation
{
    public partial class PT_FRM : Form
    {
        public PT_FRM()
        {
            InitializeComponent();
            pt_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = 0; i < Simulator.my_page_table.size; i++)
            {
                string[] data = new string[3] { num.ToString(), virtual_addr.ToString(), physical_addr.ToString() };
                data = new string[] { i.ToString(), Simulator.my_page_table.entries[i].get_page_addr_tag(), Simulator.my_page_table.entries[i].get_physical_addr()};
                pt_show.Rows.Add(data);
                pt_show.FirstDisplayedScrollingRowIndex = pt_show.RowCount - 1;

            }
        }
    }
}
