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
    public partial class Simulator : Form
    {
        public static Random rand = new Random(10);
        public static Memory_Controller my_memctrl = new Memory_Controller();
        public static CPU my_cpu = new CPU();
        public static Memory my_memory = new Memory(Globals.MEM_SIZE);

        public static tlb my_itlb = new tlb(4,32,31,24);
        public static tlb my_dtlb = new tlb(4,16,31,24);
        public static tlb my_tlb = new tlb(4,128,29,24);

        public static cache my_il1cache = new cache(4, 128, 23, 64);
        public static cache my_dl1cache = new cache(8, 64, 24, 64);
        public static cache my_l2cache = new cache(8, 512, 21, 64);

        public CPU_Frm form_cpu = new CPU_Frm();

        public Simulator()
        {
            InitializeComponent();


        }

        public void DrawLine()
        {
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(myPen, 0, 0, 200, 200);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        public void inst_show()
        {
            // Display the instruction type
            int opcode = Globals.cur_inst[0];
            opcode = (opcode >> 6);

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
            ////////////////////////////////////////////////////////////

            // **** ATTN **** //
            // Address field should be bool[]  

            // **** READ FROM CACHE **** //
            // FUNCTION: public bool read_from_cache(bool[] address, byte[] data)
            // send the address if the output is false then it was a miss, it the output is true the data you requested is in data

            // **** WRITE TO CACHE **** //
            // FUNCTION: public bool write_to_cache(bool[] address, byte[] data_in, bool dirty_in, bool[] tag_out, byte[] data_out, bool dirty_out)
            // write to cache: send address and data_in also determine the write policy (so if it's write back set dirty_in to false so that we know what to do with data)
            // then check if dirty_out == true then the tag_out and data_out is for the data dumped out of the cache. You have the address so just replace the tag
            // portion of the address with tag_out and you can write it either to higher cache or memory. 


            /* Sample Code to Work With Cache */
            int num = 64;
            bool[] tester_addr = new bool[Globals.PHYSICAL_ADD_LEN];
            byte[] tester_data_read = new byte[num];
            byte[] tester_data_write = new byte[num];
            byte[] tester_data_write_out = new byte[num];
            bool[] tag_out = new bool[24];
            bool dirty_out = false;

            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++) tester_addr[i] = false;// Convert.ToBoolean(rand.Next(2)); //random address
            tester_addr[0] =false ; tester_addr[1] = false; tester_addr[2] = false; tester_addr[3] = true;
            tester_addr[4] = true; tester_addr[5] = true; tester_addr[6] = false; tester_addr[7] = false;
            tester_addr[8] = true; tester_addr[9] = false; tester_addr[10] = true; tester_addr[11] = true;

            tester_addr[12] = true; tester_addr[13] = true; tester_addr[14] = true; tester_addr[15] = true;
            tester_addr[16] = true; tester_addr[17] = true; tester_addr[18] = false; tester_addr[19] = true;
            tester_addr[20] = true; tester_addr[21] = false; tester_addr[22] = false; tester_addr[23] = false;


            bool res;
            res = my_il1cache.read_from_cache(tester_addr, 64, tester_data_read); //read from a location
            res = my_il1cache.write_to_cache(tester_addr, 64, tester_data_write, false, tag_out,tester_data_write_out, ref dirty_out); //set a location to zero 
            res = false;
            for (int i = 0; i < Globals.DATA_BYTE_LEN; i++) tester_data_read[i] = (byte)rand.Next(256); //random address
            res = my_dl1cache.read_from_cache(tester_addr, 64, tester_data_read);
            ////////////////////////////////////////////////////////////
            

            my_memory.random_initialize();


            // Initialize the Program Counter
            my_cpu.PC = Globals.PC_INIT;


            // Disply
            pc_counter.Text = my_cpu.PC.ToString();
            for (ulong i = 0; i < 8; i++) { Globals.cur_inst[i] = my_memory.main_mem[my_cpu.PC + i]; }
            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");
            inst_show();


           
        }

        // Display the instruction type
        private void nxt_inst_Click(object sender, EventArgs e)
        {
            my_cpu.fetch();

            pc_counter.Text = my_cpu.PC.ToString();

            for (ulong i = 0; i < 8; i++) { Globals.cur_inst[i] = my_memory.main_mem[my_cpu.PC+ i-8]; }
            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");

            inst_show();
            form_cpu.Refresh();
        }

        private void Simulator_Load(object sender, EventArgs e)
        {

        }

        private void itlb_show_Click(object sender, EventArgs e)
        {
            iTLB_FRM form_itlb = new iTLB_FRM();
            form_itlb.ShowDialog(); 
        }

        private void dtlb_Click(object sender, EventArgs e)
        {
            dTLB_FRM form_dtlb = new dTLB_FRM();
            form_dtlb.ShowDialog();
        }

        private void tlb_show_Click(object sender, EventArgs e)
        {
            TLB_FRM form_tlb = new TLB_FRM();
            form_tlb.ShowDialog();
        }

        private void il1_cache_show_Click(object sender, EventArgs e)
        {
            iL1Cache_FRM form_il1cache = new iL1Cache_FRM();
            form_il1cache.ShowDialog();
        }

        private void dl1_cache_show_Click(object sender, EventArgs e)
        {
            dL1Cache_FRM form_dl1cache = new dL1Cache_FRM();
            form_dl1cache.ShowDialog(); 
        }

        private void l2_cache_show_Click(object sender, EventArgs e)
        {
            L2Cache_FRM form_l2cache = new L2Cache_FRM();
            form_l2cache.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_cpu = new CPU_Frm();
            form_cpu.Show();
        }


    }
}
