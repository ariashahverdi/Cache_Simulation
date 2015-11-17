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
    public partial class STAT_FRM : Form
    {
        public STAT_FRM()
        {
            InitializeComponent();
            progressBar1.Value = 30;
            progressBar1.ForeColor = Color.Red;
            progressBar1.Refresh();
        }

        public void Refresh()
        {
            progressBar1.Value += 1;
        }
    }
}
