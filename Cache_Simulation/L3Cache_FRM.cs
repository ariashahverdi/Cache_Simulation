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
    public partial class L3Cache_FRM : Form
    {
        public L3Cache_FRM()
        {
            InitializeComponent();
            l3cache_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = 0; i < Simulator.my_l3cache.BANK_NUM; i++)
            {
                string[] data = new string[2] { num.ToString(), cache_data.ToString() };
                data = new string[] { i.ToString(), Simulator.my_l3cache.get_block(0,i).get_tag_payload()};
                l3cache_show.Rows.Add(data);
                l3cache_show.FirstDisplayedScrollingRowIndex = l3cache_show.RowCount - 1;

            }
            for (int i = 0; i < l3cache_show.RowCount; i++)
            {
                    if (Simulator.my_l3cache.get_block(0, i).get_dirty() == true) l3cache_show.Rows[i].Cells[1].Style.BackColor = Color.LightPink;
                    else if (Simulator.my_l3cache.get_block(0, i).get_valid() == false) l3cache_show.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_l3cache.get_block(0, i).get_valid() == true) l3cache_show.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
            }
        }

        private void l3cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (l3cache_show.CurrentCell != null && l3cache_show.CurrentCell.Value != null && l3cache_show.CurrentCell.ColumnIndex != 0)
            {
                cache_block form_cache_block = new cache_block(Simulator.my_l3cache, l3cache_show.CurrentCell.ColumnIndex - 1, l3cache_show.CurrentCell.RowIndex);
                form_cache_block.ShowDialog();
            }
        }
    }
}
