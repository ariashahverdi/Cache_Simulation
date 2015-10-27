﻿using System;
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
    public partial class L2Cache : Form
    {
        public L2Cache()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Simulator.my_l2cache.get_block_num(); i++)
            {
                string[] data = new string[17] { num.ToString(), tag1.ToString(), payload1.ToString(), tag2.ToString(), payload2.ToString(), tag3.ToString(), payload3.ToString(), tag4.ToString(), payload4.ToString(), tag5.ToString(), payload5.ToString(), tag6.ToString(), payload6.ToString(), tag7.ToString(), payload7.ToString(), tag8.ToString(), payload8.ToString() };
                data = new string[] { i.ToString(), Simulator.my_l2cache.get_block(i, 0).get_tag(), Simulator.my_l2cache.get_block(i, 0).get_payload(), Simulator.my_l2cache.get_block(i, 1).get_tag(), Simulator.my_l2cache.get_block(i, 1).get_payload(), Simulator.my_l2cache.get_block(i, 2).get_tag(), Simulator.my_l2cache.get_block(i, 2).get_payload(), Simulator.my_l2cache.get_block(i, 3).get_tag(), Simulator.my_l2cache.get_block(i, 3).get_payload(), Simulator.my_l2cache.get_block(i, 4).get_tag(), Simulator.my_l2cache.get_block(i, 4).get_payload(), Simulator.my_l2cache.get_block(i, 5).get_tag(), Simulator.my_l2cache.get_block(i, 5).get_payload(), Simulator.my_l2cache.get_block(i, 6).get_tag(), Simulator.my_l2cache.get_block(i, 6).get_payload(), Simulator.my_l2cache.get_block(i, 7).get_tag(), Simulator.my_l2cache.get_block(i, 7).get_payload() };
                l2cache_show.Rows.Add(data);
                l2cache_show.FirstDisplayedScrollingRowIndex = l2cache_show.RowCount - 1;
            }
        }

        private void l2cache_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (l2cache_show.CurrentCell != null && l2cache_show.CurrentCell.Value != null)
                MessageBox.Show(l2cache_show.CurrentCell.Value.ToString());
        }
    }
}
