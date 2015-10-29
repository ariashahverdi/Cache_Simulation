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
    public partial class CPU_Frm : Form
    {
        public CPU_Frm()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            textBox1.Text = Simulator.my_cpu.R0.ToString();
            textBox2.Text = Simulator.my_cpu.R1.ToString();
            textBox3.Text = Simulator.my_cpu.R2.ToString();
            textBox4.Text = Simulator.my_cpu.R3.ToString();

            textBox5.Text = BitConverter.ToString(Simulator.my_cpu.IR1).Replace("-", " ");
            textBox6.Text = BitConverter.ToString(Simulator.my_cpu.IR2).Replace("-", " ");

            textBox7.Text = Simulator.my_cpu.PC.ToString();

        }

        private void CPU_Frm_Activated(object sender, EventArgs e)
        {
            textBox1.Text = Simulator.my_cpu.R0.ToString();
            textBox2.Text = Simulator.my_cpu.R1.ToString();
            textBox3.Text = Simulator.my_cpu.R2.ToString();
            textBox4.Text = Simulator.my_cpu.R3.ToString();

            textBox5.Text = BitConverter.ToString(Simulator.my_cpu.IR1).Replace("-", " ");
            textBox6.Text = BitConverter.ToString(Simulator.my_cpu.IR2).Replace("-", " ");

            textBox7.Text = Simulator.my_cpu.PC.ToString();
        }

        private void CPU_Frm_Load(object sender, EventArgs e)
        {

        }
    }
}
