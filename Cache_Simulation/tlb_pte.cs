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
    public partial class tlb_pte : Form
    {
        public tlb_pte(tlb my_tlb, int row, int col)
        {
            InitializeComponent();

            textBox1.Text = Convert.ToString(my_tlb.get_pte(row, col).get_valid());
            textBox2.Text = my_tlb.get_pte(row, col).get_prot();

            textBox3.Text = my_tlb.get_pte(row, col).get_page_addr_tag();
            textBox4.Text = my_tlb.get_pte(row, col).get_physical_addr();

        }
    }
}
