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
    public partial class L2Cache_FRM : Form
    {
        public L2Cache_FRM()
        {
            InitializeComponent();
            l2cache_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = 0; i < Simulator.my_l2cache.get_block_num(); i++)
            {
                string[] data = new string[9] { num.ToString(), bank1.ToString(), bank2.ToString(), bank3.ToString(), bank4.ToString(), bank5.ToString(), bank6.ToString(), bank7.ToString(), bank8.ToString() };
                data = new string[] { i.ToString(), Simulator.my_l2cache.get_block(i, 0).get_tag_payload(), Simulator.my_l2cache.get_block(i, 1).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 2).get_tag_payload(), Simulator.my_l2cache.get_block(i, 3).get_tag_payload(), Simulator.my_l2cache.get_block(i, 4).get_tag_payload(), Simulator.my_l2cache.get_block(i, 5).get_tag_payload(), Simulator.my_l2cache.get_block(i, 6).get_tag_payload(), Simulator.my_l2cache.get_block(i, 7).get_tag_payload() };
                l2cache_show.Rows.Add(data);
                l2cache_show.FirstDisplayedScrollingRowIndex = l2cache_show.RowCount - 1;
            }
            for (int i = 0; i < l2cache_show.RowCount; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (Simulator.my_l2cache.get_block(i, j - 1).get_dirty() == true) l2cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightPink;
                    else if (Simulator.my_l2cache.get_block(i, j - 1).get_valid() == false) l2cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_l2cache.get_block(i, j - 1).get_valid() == true) l2cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void l2cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (l2cache_show.CurrentCell != null && l2cache_show.CurrentCell.Value != null && l2cache_show.CurrentCell.ColumnIndex != 0)
            {
                cache_block form_cache_block = new cache_block(Simulator.my_l2cache, l2cache_show.CurrentCell.RowIndex, l2cache_show.CurrentCell.ColumnIndex - 1);
                form_cache_block.ShowDialog();
            }
        }
    }
}
