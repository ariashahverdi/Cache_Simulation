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
    public partial class dL1Cache_FRM : Form
    {
        public dL1Cache_FRM()
        {
            InitializeComponent();
            dl1cache_show.AllowUserToAddRows = false; //Disable The last Row
            int a = Simulator.my_dl1cache.get_block_num();
            for (int i = 0; i < Simulator.my_dl1cache.get_block_num(); i++)
            {
                string[] data = new string[9] { num.ToString(), bank1.ToString(), bank2.ToString(), bank3.ToString(), bank4.ToString(), bank5.ToString(), bank6.ToString(), bank7.ToString(), bank8.ToString() };
                data = new string[] { i.ToString(), Simulator.my_dl1cache.get_block(i, 0).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 1).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 2).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 3).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 4).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 5).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 6).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 7).get_tag_payload() };
                dl1cache_show.Rows.Add(data);
                dl1cache_show.FirstDisplayedScrollingRowIndex = dl1cache_show.RowCount - 1;
            }
            for (int i = 0; i < dl1cache_show.RowCount; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (Simulator.my_dl1cache.get_block(i, j - 1).get_dirty() == true) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightPink;
                    else if (Simulator.my_dl1cache.get_block(i, j - 1).get_valid() == false) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_dl1cache.get_block(i, j - 1).get_valid() == true) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Simulator.my_dl1cache.get_block_num(); i++)
            {
                string[] data = new string[9] { num.ToString(), bank1.ToString(), bank2.ToString(), bank3.ToString(), bank4.ToString(), bank5.ToString(), bank6.ToString(), bank7.ToString(), bank8.ToString() };
                data = new string[] { i.ToString(), Simulator.my_dl1cache.get_block(i, 0).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 1).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 2).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 3).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 4).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 5).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 6).get_tag_payload(), Simulator.my_dl1cache.get_block(i, 7).get_tag_payload() };
                dl1cache_show.Rows.Add(data);
                dl1cache_show.FirstDisplayedScrollingRowIndex = dl1cache_show.RowCount - 1;
            }
            for (int i = 0; i < dl1cache_show.RowCount - 1; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (Simulator.my_il1cache.get_block(i, j-1).get_dirty() == true) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightPink;
                    else if (Simulator.my_dl1cache.get_block(i, j-1).get_valid() == false) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_dl1cache.get_block(i, j-1).get_valid() == true) dl1cache_show.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }
        */

        private void dl1cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dl1cache_show.CurrentCell != null && dl1cache_show.CurrentCell.Value != null && dl1cache_show.CurrentCell.ColumnIndex != 0)
            {
                int a = dl1cache_show.CurrentCell.RowIndex;
                int b = dl1cache_show.CurrentCell.ColumnIndex;
                cache_block form_cache_block = new cache_block(Simulator.my_dl1cache, dl1cache_show.CurrentCell.RowIndex, dl1cache_show.CurrentCell.ColumnIndex-1);
                form_cache_block.ShowDialog();
            }
            //MessageBox.Show(dl1cache_show.CurrentCell.Value.ToString());
        }
    }
}
