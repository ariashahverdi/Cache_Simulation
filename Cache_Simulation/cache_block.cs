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
    public partial class cache_block : Form
    {
        public cache_block(cache my_cache, int row, int col)
        {
            InitializeComponent();

            textBox1.Text = Convert.ToString(my_cache.get_block(row, col).get_valid());
            textBox2.Text = Convert.ToString(my_cache.get_block(row, col).get_dirty());
            textBox3.Text = (my_cache.get_block(row, col).get_tag());

            string payload = my_cache.get_block(row, col).get_payload();
            textBox4.Text = (payload.Substring(0,16));
            textBox5.Text = (payload.Substring(16, 16));
            textBox6.Text = (payload.Substring(32, 16));
            textBox7.Text = (payload.Substring(48, 16));

            textBox8.Text = (payload.Substring(64, 16));
            textBox9.Text = (payload.Substring(80, 16));
            textBox10.Text = (payload.Substring(96, 16));
            textBox11.Text = (payload.Substring(112, 16));
        }


    }
}
