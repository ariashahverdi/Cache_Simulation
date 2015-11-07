using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Cache_Simulation
{
    public partial class Simulator : Form
    {
        public static Random rand = new Random(10); // DO NOT TOUCH THIS LINE PLEASE! 
        public static Memory_Controller my_memctrl = new Memory_Controller();
        public static CPU my_cpu = new CPU();
        public static Memory my_memory = new Memory(Globals.MEM_SIZE);

        public static tlb my_itlb = new tlb(4, 32, 31, 24);
        public static tlb my_dtlb = new tlb(4, 16, 31, 24);
        public static tlb my_tlb = new tlb(4, 128, 29, 24);

        public static cache my_il1cache = new cache(4, 128, 23, 64);
        public static cache my_dl1cache = new cache(8, 64, 24, 64);
        public static cache my_l2cache = new cache(8, 512, 21, 64);

        public CPU_Frm form_cpu = new CPU_Frm();

        int speed_val;

        public Simulator()
        {
            InitializeComponent();
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
                    inst_type = "Add";
                    break;
                default:
                    inst_type = "Nothing";
                    break;
            }
            type.Text = inst_type;
        }


        private void start_Click(object sender, EventArgs e)
        {
            /// ANIMATION ////////
            animation my_anim = new animation(this);
            string[] buttons = {"itlb", "dtlb", "tlb", "pt", "il1cache", "dl1cache", "l2cache", "l3cache", "mem", "disk"};
            bool[] addr;
            int size;
            for (int i = 1; i < 11; i++)
            {
                if (i < 5) size = Globals.VIRTUAL_ADD_LEN;
                else size = Globals.PHYSICAL_ADD_LEN;
                addr = new bool[size];
                for (int j = 0; j < size; j++) addr[j] = Convert.ToBoolean(Simulator.rand.Next(2));
                my_anim.DrawLine(this, buttons[i-1], size, addr, Convert.ToBoolean(Simulator.rand.Next(2)));
            }
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
            /*
            int num = 64;
            bool[] tester_addr = new bool[Globals.PHYSICAL_ADD_LEN];
            byte[] tester_data_read = new byte[num];
            byte[] tester_data_write = new byte[num];
            byte[] tester_data_write_out = new byte[num];
            bool[] addr_out = new bool[Globals.PHYSICAL_ADD_LEN];
            bool dirty_out = false;

            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++) tester_addr[i] = false;// Convert.ToBoolean(rand.Next(2)); //random address
            tester_addr[0] = true ; tester_addr[1] = false; tester_addr[2] = true; tester_addr[3] = false; //A
            tester_addr[4] = true; tester_addr[5] = true; tester_addr[6] = false; tester_addr[7] = true; //D
            tester_addr[8] = true; tester_addr[9] = true; tester_addr[10] = true; tester_addr[11] = true; //F

            tester_addr[12] = true; tester_addr[13] = true; tester_addr[14] = true; tester_addr[15] = false; //E
            tester_addr[16] = false; tester_addr[17] = true; tester_addr[18] = true; tester_addr[19] = true; //7
            tester_addr[20] = true; tester_addr[21] = true; tester_addr[22] = true; tester_addr[23] = true; //F


            tester_addr[30] = true; tester_addr[31] = false; tester_addr[32] = true; //0
            tester_addr[33] = true; tester_addr[34] = true; tester_addr[35] = true; //7


            bool res;
            res = my_dl1cache.read_from_cache(tester_addr, 64, tester_data_read); //read from a location
            res = my_dl1cache.write_to_cache(tester_addr, 8, tester_data_write, true, addr_out,tester_data_write_out, ref dirty_out); //set a location to zero 
            res = my_dl1cache.write_to_cache(tester_addr, 8, tester_data_write, true, addr_out,tester_data_write_out, ref dirty_out); //set a location to zero
            res = false;
            tester_addr[0] = true; tester_addr[1] = true; tester_addr[2] = true; tester_addr[3] = true; //A
            res = my_dl1cache.write_to_cache(tester_addr, 64, tester_data_write, false, addr_out, tester_data_write_out, ref dirty_out); //set a location to zero
            */
            ////////////////////////////////////////////////////////////


            my_memory.random_initialize();


            // Initialize the Program Counter
            my_cpu.PC = Globals.PC_INIT;


            // Disply
            pc_counter.Text = my_cpu.PC.ToString();
            for (ulong i = 0; i < 8; i++) { Globals.cur_inst[i] = my_memory.main_mem[my_cpu.PC + i]; }
            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");
            inst_show();
            form_cpu.Refresh();


        }

        // Display the instruction type
        private void nxt_inst_Click(object sender, EventArgs e)
        {
            my_cpu.fetch();

            pc_counter.Text = my_cpu.PC.ToString();

            for (ulong i = 0; i < 8; i++) { Globals.cur_inst[i] = my_memory.main_mem[my_cpu.PC + i - 8]; }
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

        public void set_location(int[] loc)
        {
            loc[0] = cpu_show.Location.X; //CPU = 0
            loc[1] = cpu_show.Location.Y + cpu_show.Size.Height / 2;

            loc[2] = itlb_show.Location.X + itlb_show.Size.Width; //itlb = 1
            loc[3] = itlb_show.Location.Y + itlb_show.Size.Height / 2;

            loc[4] = dtlb_show.Location.X + dtlb_show.Size.Width; //dtlb = 2
            loc[5] = dtlb_show.Location.Y + dtlb_show.Size.Height / 2;

            loc[6] = tlb_show.Location.X + tlb_show.Size.Width; //tlb = 3
            loc[7] = tlb_show.Location.Y + tlb_show.Size.Height / 2;

            loc[8] = pt_show.Location.X + pt_show.Size.Width; //pt_show = 4
            loc[9] = pt_show.Location.Y + pt_show.Size.Height / 2;

            loc[10] = il1_cache_show.Location.X; //il1cache = 5
            loc[11] = il1_cache_show.Location.Y + il1_cache_show.Size.Height / 2;

            loc[12] = dl1_cache_show.Location.X; //dl1_cache = 6
            loc[13] = dl1_cache_show.Location.Y + dl1_cache_show.Size.Height / 2;

            loc[14] = l2_cache_show.Location.X; //l2_cache = 7
            loc[15] = l2_cache_show.Location.Y + l2_cache_show.Size.Height / 2;

            loc[16] = l3_cache_show.Location.X; //l3_cache = 8
            loc[17] = l3_cache_show.Location.Y + l3_cache_show.Size.Height / 2;

            loc[18] = mem_show.Location.X + mem_show.Size.Width; //mem_show = 9
            loc[19] = mem_show.Location.Y + mem_show.Size.Height / 2;

            loc[20] = disk_show.Location.X; //disk_show = 10
            loc[21] = disk_show.Location.Y + disk_show.Size.Height / 2;

            loc[22] = cpu_show.Location.X + cpu_show.Size.Width;
            loc[23] = cpu_show.Location.Y + cpu_show.Size.Height / 2;
        }

        public void hit_miss_show(bool stat)
        {
           hit_miss_stat.Visible = true;
            if (stat)
            {
                hit_miss_stat.Text = "Hit";
                hit_miss_stat.ForeColor = Color.Green;
            }
            else
            {
                hit_miss_stat.Text = "Miss";
                hit_miss_stat.ForeColor = Color.Red;
            }
            hit_miss_stat.Refresh();
         }

        public void hit_miss_hide()
        {
            hit_miss_stat.Visible = false;
            hit_miss_stat.Refresh();
        }

        public void addr_show(bool []addr)
        {
            int bytes = addr.Length / 8;
            if ((addr.Length % 8) != 0) bytes++;
            byte[] arr2 = new byte[bytes];
            int bitIndex = 0, byteIndex = 0;
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i])
                {
                    arr2[byteIndex] |= (byte)(((byte)1) << bitIndex);
                }
                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }
            addr_stat.Text = BitConverter.ToString(arr2).Replace("-", " ");
            addr_stat.Visible = true;
            addr_stat.Refresh();
        }

        public void addr_hide()
        {
            addr_stat.Visible = false;
            addr_stat.Refresh();
        }

        public int get_speed()
        {
            return Convert.ToInt32(speed.Text);
        }

    }
}
