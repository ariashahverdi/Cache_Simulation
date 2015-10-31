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
            il1cache_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = 0; i < Simulator.my_il1cache.get_block_num(); i++)
            {
                string[] data = new string[5] { num.ToString(), bank1.ToString(), bank2.ToString(), bank3.ToString(), bank4.ToString() };
                data = new string[] { i.ToString(), Simulator.my_il1cache.get_block(i, 0).get_tag_payload(), Simulator.my_il1cache.get_block(i, 1).get_tag_payload(), Simulator.my_il1cache.get_block(i, 2).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 3).get_tag_payload() };
                il1cache_show.Rows.Add(data);
                il1cache_show.FirstDisplayedScrollingRowIndex = il1cache_show.RowCount - 1;

            }
            for (int i = 0; i < il1cache_show.RowCount; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (Simulator.my_il1cache.get_block(i, j - 1).get_dirty() == true) il1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightPink;
                    else if (Simulator.my_il1cache.get_block(i, j - 1).get_valid() == false) il1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_il1cache.get_block(i, j - 1).get_valid() == true) il1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void il1cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                    if (il1cache_show.CurrentCell != null && il1cache_show.CurrentCell.Value != null && il1cache_show.CurrentCell.ColumnIndex != 0)
            {
                int a = il1cache_show.CurrentCell.RowIndex;
                int b = il1cache_show.CurrentCell.ColumnIndex;
                cache_block form_cache_block = new cache_block(Simulator.my_il1cache, il1cache_show.CurrentCell.RowIndex, il1cache_show.CurrentCell.ColumnIndex - 1);
                form_cache_block.ShowDialog();
            }
        }

    }
}
