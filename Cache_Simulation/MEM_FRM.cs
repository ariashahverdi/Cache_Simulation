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
    public partial class MEM_FRM : Form
    {
        public MEM_FRM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int page_num = Convert.ToInt32(speed.Text);
            int page_size = 1 << 12;
            mem_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = (page_num-1)*page_size; i <page_num*page_size; i++)
            {
                string[] data = new string[2] { num.ToString(), val.ToString() };
                data = new string[] { i.ToString(), Simulator.my_memory.main_mem[i].ToString("X") };
                mem_show.Rows.Add(data);
                mem_show.FirstDisplayedScrollingRowIndex = mem_show.RowCount - 1;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mem_show.Rows.Clear();
            mem_show.Refresh();
        }
    }
}
