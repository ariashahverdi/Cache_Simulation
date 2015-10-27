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
    public partial class iL1Cache : Form
    {
        public iL1Cache()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Simulator.my_il1cache.get_block_num(); i++)
            {
                string[] data = new string[9] { num.ToString(), tag1.ToString(), payload1.ToString(), tag2.ToString(), payload2.ToString(), tag3.ToString(), payload3.ToString(), tag4.ToString(), payload4.ToString() };
                data = new string[] { i.ToString(), Simulator.my_il1cache.get_block(i, 0).get_tag(), Simulator.my_il1cache.get_block(i, 0).get_payload(), Simulator.my_il1cache.get_block(i, 1).get_tag(), Simulator.my_il1cache.get_block(i, 1).get_payload(), Simulator.my_il1cache.get_block(i, 2).get_tag(), Simulator.my_il1cache.get_block(i, 2).get_payload(), Simulator.my_dl1cache.get_block(i, 3).get_tag(), Simulator.my_il1cache.get_block(i, 3).get_payload() };
                il1cache_show.Rows.Add(data);
                il1cache_show.FirstDisplayedScrollingRowIndex = il1cache_show.RowCount - 1;
            }
        }

        private void dl1cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
