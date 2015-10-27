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
    public partial class Simulator : Form
    {
        public static Random rand = new Random();
        public static cache my_il1cache = new cache(4, 128, 23, 64);
        public static cache my_dl1cache = new cache(8, 64, 24, 64);
        public static cache my_l2cache = new cache(8, 512, 21, 64);

        public Simulator()
        {
            InitializeComponent();
        }

        public void inst_show()
        {
            // Display the instruction type
            int opcode = Globals.main_mem[Globals.pc_counter_val - Globals.PC_INIT];
            string inst_type;
            switch (opcode)
            {
                case 0:
                    inst_type = "Load";
                    break;
                case 1:
                    inst_type = "Store";
                    break;
                case 2:
                    inst_type = "Branch";
                    break;
                case 3:
                    inst_type = "Other";
                    break;
                default:
                    inst_type = "Nothing";
                    break;
            }
            type.Text = inst_type;
        }

        private void start_Click(object sender, EventArgs e)
        {

            // Initialize the memory to some totally random instructions
            // Opcode can only be { 0:load | 1:store | 2:branch | 3:other }
            // We modify the first byte of each instruction to be one of these
            for (int i=0;i<Globals.MEM_SIZE;i++)
            {
                if (i % 8 == 0) Globals.main_mem[i] = (byte)(rand.Next(256) % 4); //opcode
                else Globals.main_mem[i] = (byte)rand.Next(256);
            }

            // Initialize the Program Counter
            Globals.pc_counter_val = Globals.PC_INIT;
            pc_counter.Text = Globals.pc_counter_val.ToString();

            // Displying The First Instruction
            for (int i = 0; i < 8; i++) { Globals.cur_inst[i] = Globals.main_mem[Globals.pc_counter_val - Globals.PC_INIT + i]; }
            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");

            inst_show();

        }

        // Display the instruction type
        private void nxt_inst_Click(object sender, EventArgs e)
        {
            Globals.pc_counter_val += 8; 
            pc_counter.Text = Globals.pc_counter_val.ToString();

            for (int i = 0; i < 8; i++) { Globals.cur_inst[i] = Globals.main_mem[Globals.pc_counter_val - Globals.PC_INIT + i]; }
            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");

            inst_show();

        }

        private void Simulator_Load(object sender, EventArgs e)
        {

        }

        private void itlb_show_Click(object sender, EventArgs e)
        {
            iTLB f2 = new iTLB();
            f2.ShowDialog(); // Shows Form2
        }

        private void il1_cache_show_Click(object sender, EventArgs e)
        {
            iL1Cache form_il1cache = new iL1Cache();
            form_il1cache.ShowDialog(); // Shows Form2
        }

        private void dl1_cache_show_Click(object sender, EventArgs e)
        {
            dL1Cache form_dl1cache = new dL1Cache();
            form_dl1cache.ShowDialog(); // Shows Form2
        }

        private void l2_cache_show_Click(object sender, EventArgs e)
        {
            L2Cache form_l2cache = new L2Cache();
            form_l2cache.ShowDialog(); // Shows Form2
        }

    }
}
