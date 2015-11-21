using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cache_Simulation
{
    public partial class CPU_FRM : Form
    {
        public CPU_FRM()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            textBox1.Text = Simulator.my_cpu.R[0].ToString("X");
            textBox2.Text = Simulator.my_cpu.R[1].ToString("X");
            textBox3.Text = Simulator.my_cpu.R[2].ToString("X");
            textBox4.Text = Simulator.my_cpu.R[3].ToString("X");

            textBox5.Text = BitConverter.ToString(Simulator.my_cpu.IR1).Replace("-", " ");
            textBox6.Text = BitConverter.ToString(Simulator.my_cpu.IR2).Replace("-", " ");

            textBox7.Text = Simulator.my_cpu.PC.ToString();

        }

        private void CPU_Frm_Activated(object sender, EventArgs e)
        {
            textBox1.Text = Simulator.my_cpu.R[0].ToString("X");
            textBox2.Text = Simulator.my_cpu.R[1].ToString("X");
            textBox3.Text = Simulator.my_cpu.R[2].ToString("X");
            textBox4.Text = Simulator.my_cpu.R[3].ToString("X");

            textBox5.Text = BitConverter.ToString(Simulator.my_cpu.IR1).Replace("-", " ");
            textBox6.Text = BitConverter.ToString(Simulator.my_cpu.IR2).Replace("-", " ");

            textBox7.Text = Simulator.my_cpu.PC.ToString();
        }

        private void CPU_Frm_Load(object sender, EventArgs e)
        {

        }
    }
}
