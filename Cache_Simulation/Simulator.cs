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
        public static cache my_l3cache = new cache(1024, 1, 30, 64);

        public static Page_Table my_page_table = new Page_Table(1024, "test.txt");

        public CPU_FRM form_cpu = new CPU_FRM();
        public STAT_FRM form_stat = new STAT_FRM();

        int speed_val;
        int [] loc = new int[24];


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
            /// 
           /*
            string[] buttons = {"itlb", "dtlb", "tlb", "pt", "il1cache", "dl1cache", "l2cache", "l3cache", "mem", "disk"};
            bool[] addr;
            int size;
            for (int i = 1; i < 11; i++)
            {
                if (i < 5) size = Globals.VIRTUAL_ADD_LEN;
                else size = Globals.PHYSICAL_ADD_LEN;
                addr = new bool[size];
                for (int j = 0; j < size; j++) addr[j] = Convert.ToBoolean(Simulator.rand.Next(2));
                DrawLine( buttons[i-1], size, addr, Convert.ToBoolean(Simulator.rand.Next(2)));
            }
            */
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

            ////////////////////////////////////////////////////////////

            // **** ATTN **** //

            /* Sample Code to Work With TLB */
            /*
            int num = 64;
            bool[] v_addr = new bool[Globals.VIRTUAL_ADD_LEN];
            bool[] p_addr = new bool[Globals.PHYSICAL_ADD_LEN];
            bool[] prot = new bool[4];
            prot[0] = true; prot[1] = true; prot[2] = false; prot[3] = false;

            for (int i = 0; i < Globals.VIRTUAL_ADD_LEN; i++) v_addr[i] = false;// Convert.ToBoolean(rand.Next(2)); //random address
            v_addr[0] = true; v_addr[1] = false; v_addr[2] = true; v_addr[3] = false; //A
            v_addr[4] = true; v_addr[5] = true; v_addr[6] = false; v_addr[7] = true; //D
            v_addr[8] = true; v_addr[9] = true; v_addr[10] = true; v_addr[11] = true; //F

            v_addr[12] = true; v_addr[13] = true; v_addr[14] = true; v_addr[15] = false; //E
            v_addr[16] = false; v_addr[17] = true; v_addr[18] = true; v_addr[19] = true; //7
            v_addr[20] = true; v_addr[21] = true; v_addr[22] = true; v_addr[23] = true; //F


            v_addr[30] = true; v_addr[31] = false; v_addr[32] = true; //0
            v_addr[33] = true; v_addr[34] = true; v_addr[35] = true; //7


            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++) p_addr[i] = Convert.ToBoolean(Simulator.rand.Next(2));

            bool res;
            res = my_itlb.read_from_tlb(v_addr, p_addr, prot); //read from a location
            res = my_itlb.write_to_tlb(v_addr, p_addr, prot); //write a location
            res = false;
            res = my_itlb.read_from_tlb(v_addr, p_addr, prot); //read from a location

            int a = 0;
            */
            ////////////////////////////////////////////////////////////
            my_memory.random_initialize();
            my_page_table.initialize();

            // Initialize the Program Counter
            my_cpu.PC = Globals.PC_INIT;


            // Disply
            pc_counter.Text = my_cpu.PC.ToString();

            ulong virtual_address = 0;
            for (ulong i = 0; i < 8; i++)
            {
                my_page_table.search_pt((my_cpu.PC + i), ref virtual_address);
                Globals.cur_inst[i] = my_memory.main_mem[virtual_address];
            }

            inst.Text = BitConverter.ToString(Globals.cur_inst).Replace("-", " ");
            inst_show();
            form_cpu.Refresh();


        }

        // Display the instruction type
        private void nxt_inst_Click(object sender, EventArgs e)
        {
            my_cpu.fetch();

            pc_counter.Text = my_cpu.PC.ToString();

            ulong virtual_address = 0;
            for (ulong i = 0; i < 8; i++)
            {
                my_page_table.search_pt((my_cpu.PC + i), ref virtual_address);
                Globals.cur_inst[i] = my_memory.main_mem[virtual_address];
            }
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
            form_cpu = new CPU_FRM();
            form_cpu.Show();
        }

        private void pt_show_Click(object sender, EventArgs e)
        {
            PT_FRM form_pt = new PT_FRM();
            form_pt.ShowDialog();
        }

        private void l3_cache_show_Click(object sender, EventArgs e)
        {
            L3Cache_FRM form_l3cache = new L3Cache_FRM();
            form_l3cache.ShowDialog();
        }

        private void mem_show_Click(object sender, EventArgs e)
        {
            MEM_FRM form_mem = new MEM_FRM();
            form_mem.ShowDialog();
        }

        private void disk_show_Click(object sender, EventArgs e)
        {
            DISK_FRM form_disk = new DISK_FRM();
            form_disk.ShowDialog();
        }

        public int get_idx(string indata)
        {
            switch (indata)
            {
                case "itlb": return 1;
                case "dtlb": return 2;
                case "tlb": return 3;
                case "pt": return 4;
                case "il1cache": return 5;
                case "dl1cache": return 6;
                case "l2cache": return 7;
                case "l3cache": return 8;
                case "mem": return 9;
                case "disk": return 10;

                default: return 0;
            }
        }

        public int get_exec_time(string indata)
        {
            switch (indata)
            {
                case "itlb": return Globals.L1_HIT;
                case "dtlb": return Globals.L1_HIT;
                case "tlb": return Globals.L2_HIT;
                case "pt": return Globals.MEM_ACCESS;
                case "il1cache": return Globals.L1_HIT;
                case "dl1cache": return Globals.L1_HIT;
                case "l2cache": return Globals.L2_HIT;
                case "l3cache": return Globals.L3_HIT;
                case "mem": return Globals.MEM_ACCESS;
                case "disk": return Globals.DISK_ACCESS;

                default: return 0;
            }
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

        public void DrawLine(string block, int size, bool[] addr, bool hit_miss, string read_write)
        {
            set_location(loc);
            int cpu_x = loc[0];
            int cpu_y = loc[1];

            int idx = get_idx(block);
            if (idx >= 5 && idx <= 9)
            {
                cpu_x = loc[22];
                cpu_y = loc[23];
            }
            else
            {
                cpu_x = loc[0];
                cpu_y = loc[1];
            }
            int dest_x = loc[2 * idx];
            int dest_y = loc[2 * idx + 1];

            int tempx;
            if (idx == 9) tempx = 40; //To Mem
            else if (idx == 10) tempx = -50;
            else tempx = 0;

            System.Drawing.Pen myPen1;
            System.Drawing.Pen myPen2;
            System.Drawing.Pen myPen3;
            myPen1 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen2 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen3 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            System.Drawing.Graphics formGraphics = CreateGraphics();

            if (read_write == "write")
            {
                //myPen1.EndCap = LineCap.RoundAnchor;
                formGraphics.DrawLine(myPen1, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y, cpu_x, cpu_y);
            }

            else
            {
                myPen1.EndCap = LineCap.ArrowAnchor;
                formGraphics.DrawLine(myPen1, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y, cpu_x, cpu_y);
            }
            
            myPen1.Dispose();

            formGraphics.DrawLine(myPen2, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y);
            myPen2.Dispose();

            if (read_write == "write")
            {
                myPen3.StartCap = LineCap.ArrowAnchor;
                formGraphics.DrawLine(myPen3, dest_x, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y);
            }
            else
            {
                //myPen3.EndCap = LineCap.RoundAnchor;
                formGraphics.DrawLine(myPen3, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y, dest_x, dest_y );
            }

            
            myPen3.Dispose();

            addr_show(addr, size);
            hit_miss_show(hit_miss);
            rw_show(read_write);

            Thread.Sleep(get_speed());

            formGraphics.Clear(BackColor);

            addr_hide();
            hit_miss_hide();
            rw_hide();

            Globals.EXEC_TIME += get_exec_time(block);
            exe_time.Text = Globals.EXEC_TIME.ToString();
            exe_time.Refresh();

            /*
            Globals.il1cache_hit = rand.Next(100); Globals.il1cache_miss = rand.Next(100); Globals.il1cache_access = Globals.il1cache_hit + Globals.il1cache_miss;
            Globals.dl1cache_hit = rand.Next(100); Globals.dl1cache_miss = rand.Next(100); Globals.dl1cache_access = Globals.dl1cache_hit + Globals.dl1cache_miss;
            Globals.l2cache_hit = rand.Next(100); Globals.l2cache_miss = rand.Next(100); Globals.l2cache_access = Globals.l2cache_hit + Globals.l2cache_miss;
            Globals.l3cache_hit = rand.Next(100); Globals.l3cache_miss = rand.Next(100); Globals.l3cache_access = Globals.l3cache_hit + Globals.l3cache_miss;

            Globals.itlb_hit = rand.Next(100); Globals.itlb_miss = rand.Next(100); Globals.itlb_access = Globals.itlb_hit + Globals.itlb_miss;
            Globals.dtlb_hit = rand.Next(100); Globals.dtlb_miss = rand.Next(100); Globals.dtlb_access = Globals.dtlb_hit + Globals.dtlb_miss;
            Globals.tlb_hit = rand.Next(100); Globals.tlb_miss = rand.Next(100); Globals.tlb_access = Globals.tlb_hit + Globals.tlb_miss;
            Globals.pt_hit = rand.Next(100); Globals.pt_miss = rand.Next(100); Globals.pt_access = Globals.pt_hit + Globals.pt_miss;

            Globals.mem_access += 1;
            Globals.disk_access += 1;
            */

        form_stat.refresh();
        }


        public void hit_miss_show(bool stat)
        {
           hit_miss_stat.Visible = true;
            if (stat)
            {
                hit_miss_stat.Text = "H";
                hit_miss_stat.ForeColor = Color.Green;
            }
            else
            {
                hit_miss_stat.Text = "M";
                hit_miss_stat.ForeColor = Color.Red;
            }
            hit_miss_stat.Refresh();
         }

        public void hit_miss_hide()
        {
            hit_miss_stat.Visible = false;
            hit_miss_stat.Refresh();
        }

        public void addr_show(bool []addr, int size)
        {
            //byte[] addr_byte = new byte[addr.Length / 8];
            ulong addr_val = 0;   
            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[addr.Length - i - 1])
                {
                    ulong one = 1;
                    addr_val |= (one << i);
                }
            }
            byte[] addr_byte = BitConverter.GetBytes(addr_val);
            byte temp;
            for(int i=0;i<addr_byte.Length/2;i++)
            {
                temp = addr_byte[i];
                addr_byte[i] = addr_byte[addr_byte.Length - i - 1];
                addr_byte[addr_byte.Length - i - 1] = temp;
            }
            if (size == Globals.VIRTUAL_ADD_LEN)
            {
                v_addr_stat.Text = BitConverter.ToString(addr_byte).Replace("-", " ").Substring(6,17);
                v_addr_stat.Visible = true;
                v_addr_stat.Refresh();
            }
            else
            {
                string test = BitConverter.ToString(addr_byte).Replace("-", " ");
                p_addr_stat.Text = BitConverter.ToString(addr_byte).Replace("-", " ").Substring(9, 14);
                p_addr_stat.Visible = true;
                p_addr_stat.Refresh();
            }
        }

        public void addr_hide()
        {
            v_addr_stat.Visible = false;
            v_addr_stat.Refresh();
            p_addr_stat.Visible = false;
            p_addr_stat.Refresh();
        }

        public void rw_show(string rw)
        {
            if (rw == "read") read_write_stat.Text = "read";
            else if (rw == "write") read_write_stat.Text = "write";
            read_write_stat.Visible = true;
            read_write_stat.Refresh();
        }

        public void rw_hide()
        {
            read_write_stat.Visible = false;
            read_write_stat.Refresh();
        }

        public int get_speed()
        {
            return Convert.ToInt32(speed.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_stat = new STAT_FRM();
            form_stat.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int instruction_counter = 0;
            ulong starting_point;

            // create the file and write it.
            System.IO.StreamWriter hex_file = new System.IO.StreamWriter("../../test.hex", false);

            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("../../test.asm");
            char[] delimiterChars = { ' ', ',' };
            byte[,] current_instruction = new byte[1024, 8];
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                for (int i = 0; i < 8; i++)
                {
                    current_instruction[instruction_counter, i] = 0;
                }

                switch (words[0])
                {
                    case "load":
                        current_instruction[instruction_counter, 0] |= 0x00;
                        break;

                    case "store":
                        current_instruction[instruction_counter, 0] |= 0x40;
                        break;

                    case "branch":
                        current_instruction[instruction_counter, 0] |= 0x80;
                        break;

                    case "add":
                        current_instruction[instruction_counter, 0] |= 0xC0;
                        break;
                    default:
                        if (instruction_counter == 0)
                        {
                            starting_point = Convert.ToUInt64(words[0]);
                            hex_file.Write(starting_point.ToString());
                            hex_file.Write(" ");
                        }
                        else
                        {
                            hex_file.Write(instruction_counter.ToString());
                            hex_file.Write(" ");
                            for (int i = 0; i < instruction_counter; i++)
                            {
                                hex_file.Write("0x");
                                for (int j = 0; j < 8; j++)
                                {
                                    hex_file.Write(current_instruction[i, j].ToString("X").PadLeft(2, '0'));
                                }
                                hex_file.Write(" ");
                            }
                            hex_file.Write(System.Environment.NewLine);

                            starting_point = Convert.ToUInt64(words[0]);
                            hex_file.Write(starting_point.ToString());
                            hex_file.Write(" ");
                        }


                        instruction_counter = 0;
                        continue;
                }

                char[] delimiter = { '(', ')' };

                /////////////////////////////////////////////////////// Destination

                if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    current_instruction[instruction_counter, 1] |= 0x00;
                }
                else
                {
                    if (words[1].StartsWith("r"))
                    {
                        string[] destination = words[1].Split(delimiter);
                        if (destination.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int dest_reg = Convert.ToInt32(destination[0][1]) - 0X30;
                            dest_reg = dest_reg << 2;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(dest_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int dest_reg = Convert.ToInt32(destination[0][1]) - 0X30;
                            dest_reg = dest_reg << 2;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(dest_reg);
                            current_instruction[instruction_counter, 0] |= 0x02;
                            int index = Convert.ToInt32(destination[1]) - 0X30;
                            current_instruction[instruction_counter, 7] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 6] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[1].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x01;
                        string[] destination = words[1].Split(delimiter);
                        ulong address = Convert.ToUInt64(destination[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x03;
                        ulong immediate = Convert.ToUInt64(words[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }

                /////////////////////////////////////////////////////// Source 1

                if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    //Address Mode 0 Register direct
                    int src1_reg = Convert.ToInt32(words[1][1]) - 0X30;
                    src1_reg = src1_reg << 6;
                    current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                }
                else
                {
                    if (words[2].StartsWith("r"))
                    {
                        string[] source1 = words[2].Split(delimiter);
                        if (source1.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int src1_reg = Convert.ToInt32(source1[0][1]) - 0X30;
                            src1_reg = src1_reg << 6;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int src1_reg = Convert.ToInt32(source1[0][1]) - 0X30;
                            src1_reg = src1_reg << 6;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                            current_instruction[instruction_counter, 0] |= 0x20;
                            int index = Convert.ToInt32(source1[1]) - 0X30;
                            current_instruction[instruction_counter, 3] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 2] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[2].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x10;
                        string[] source_1 = words[2].Split(delimiter);
                        ulong address = Convert.ToUInt64(source_1[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x30;
                        ulong immediate = Convert.ToUInt64(words[2]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }

                /////////////////////////////////////////////////////// Source 2

                if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    //Address Mode 0 Register direct
                    int src2_reg = Convert.ToInt32(words[2][1]) - 0X30;
                    src2_reg = src2_reg << 4;
                    current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                }
                else if (words[0] == "add")
                {
                    if (words[3].StartsWith("r"))
                    {
                        string[] source2 = words[1].Split(delimiter);
                        if (source2.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int src2_reg = Convert.ToInt32(source2[0][1]) - 0X30;
                            src2_reg = src2_reg << 4;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int src2_reg = Convert.ToInt32(source2[0][1]) - 0X30;
                            src2_reg = src2_reg << 4;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                            current_instruction[instruction_counter, 0] |= 0x08;
                            int index = Convert.ToInt32(source2[1]) - 0X30;
                            current_instruction[instruction_counter, 5] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 4] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[1].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x04;
                        string[] source2 = words[1].Split(delimiter);
                        ulong address = Convert.ToUInt64(source2[0]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x0C;
                        ulong immediate = Convert.ToUInt64(words[3]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }


                /////////////////////////////////////////////////////// JMP Address

                if (words[0] == "branch")
                {
                    ulong immediate = Convert.ToUInt64(words[3]);
                    current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                    current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                    current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                    current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                    current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                    current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                }
                instruction_counter++;

            }


            if (instruction_counter != 0)
            {
                hex_file.Write(instruction_counter.ToString());
                hex_file.Write(" ");
                for (int i = 0; i < instruction_counter; i++)
                {
                    hex_file.Write("0x");
                    for (int j = 0; j < 8; j++)
                    {
                        hex_file.Write(current_instruction[i, j].ToString("X").PadLeft(2,'0'));
                    }
                    hex_file.Write(" ");
                }
                hex_file.Write(System.Environment.NewLine);
            }

            file.Close();
            hex_file.Close();

        }
    }
}
