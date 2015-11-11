using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Memory_Controller
    {
        int status;
        public Memory_Controller()
        {
            status = 0;
        }
        public ulong address_translator(ulong virtual_address)
        {
            ulong physical_address = 0;
            Simulator.my_page_table.search_pt(virtual_address, ref physical_address);
            return physical_address;
        }
        public void fetch_instructions(ulong cpu_pc, byte[] ir1, byte[] ir2)
        {
            ulong physical_pc = address_translator(cpu_pc);
            bool[] address = new bool[Globals.PHYSICAL_ADD_LEN];
            bool[] next_address = new bool[Globals.PHYSICAL_ADD_LEN];
            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                address[Globals.PHYSICAL_ADD_LEN-i-1] = (((physical_pc >> i) & 1) == 1);
            }
            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                next_address[Globals.PHYSICAL_ADD_LEN - i - 1] = (((physical_pc + 8) >> i) & 1) == 1;
            }

            //check for il1 cache
            if (!(Simulator.my_il1cache.read_from_cache(address, 8, ir1)))
            {
                Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 8, ir1)))
                {
                    // L2 is missed
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                    //check for memory
                    Simulator.my_memory.read_from_memory(address, ir1, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "read");

                    // read 64 bytes from main memory
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_memory.read_from_memory(temp_block_address, temp_block, 64);
                    //////// write a block to L2 cache
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    // write a block to IL1 cache 
                    drt_in = false;
                    drt_out = false;
                    Simulator.my_il1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
                else
                {
                    // L2 is hit
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                    // read the block from L2 cache and write the value to iL1
                    // read 64 bytes from L2 Cache
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_l2cache.read_from_cache(temp_block_address, 64, temp_block);
                    // write a block to IL1 cache 
                    //////// write a block to L2 cache
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_il1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }

            }
            else
            {
                Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
            }
            /*
            if (!(Simulator.my_il1cache.read_from_cache(next_address, 8, ir2)))
            {
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(next_address, 8, ir2)))
                {
                    //check for memory
                    Simulator.my_memory.read_from_memory(next_address, ir2, 8);
                    // read 64 bytes from main memory
                    // write a block to L2 cache
                    // write a block to IL1 cache 
                }
            }
            */
        }

        public void read_operand(ulong cpu_address, ref ulong data)
        {
            ulong physical_pc = address_translator(cpu_address);
            byte[] temp_data = new byte[8];
            bool[] address = new bool[Globals.PHYSICAL_ADD_LEN];

            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                address[Globals.PHYSICAL_ADD_LEN - i - 1] = (((physical_pc >> i) & 1) == 1);
            }

            //check for dl1 cache
            if (!(Simulator.my_dl1cache.read_from_cache(address, 8, temp_data)))
            {
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 8, temp_data)))
                {
                    // L2 is missed
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                    //check for memory
                    Simulator.my_memory.read_from_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "read");

                    // read 64 bytes from main memory
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_memory.read_from_memory(temp_block_address, temp_block, 64);
                    //////// write a block to L2 cache
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    // write a block to DL1 cache 
                    drt_in = false;
                    drt_out = false;
                    Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
                else
                {
                    // L2 is hit
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                    // read the block from L2 cache and write the value to dL1
                    // read 64 bytes from L2 Cache
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_l2cache.read_from_cache(temp_block_address, 64, temp_block);
                    // write a block to DL1 cache 
                    //////// write a block to L2 cache
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }

            }
            else
            {
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
            }

            data = 0;
            for(int i=0; i<8; i++)
            {
                data |= (Convert.ToUInt64(temp_data[i]) << (8 * (7-i))); 
            }
        }

        public void write_operand(ulong cpu_address, ulong data)
        {
            ulong physical_pc = address_translator(cpu_address);
            byte[] temp_data = new byte[8];
            bool[] address = new bool[Globals.PHYSICAL_ADD_LEN];
            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                address[Globals.PHYSICAL_ADD_LEN-i-1] = (((physical_pc >> i) & 1) == 1);
            }
            for (int i = 0; i < 8; i++)
            {
                ulong constant = 0xFF;
                temp_data[i] = Convert.ToByte((data & (constant << (8 * (7 - i)))) >> (8 * (7 - i)));
            }

            //write to dl1 cache
            bool drt_in = false; // write-through
            bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
            byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
            bool drt_out = false;
            if (!(Simulator.my_dl1cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
            {
                //write to dl1 has not been successful
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");
                //now let's write to l2 cache
                drt_in = false; // write-through
                drt_out = false;
                if (!(Simulator.my_l2cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                {
                    //write to l2 has not been successful
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");
                    //now let's write to memory
                    Simulator.my_memory.write_to_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    // now lets read 64 bytes from memory
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_memory.read_from_memory(temp_block_address, temp_block, 64);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                    //////// write a block to L1 & L2 cache
                    drt_in = false;
                    drt_out = false;
                    Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
                else
                {
                    //write to l2 has been successful
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    // now lets write 64 bytes to dl1
                    // read 64 bytes from l2
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_l2cache.read_from_cache(temp_block_address, 64, temp_block);
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                    //////// write a block to L1 cache
                    drt_in = false;
                    drt_out = false;
                    Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    //now let's write to memory
                    Simulator.my_memory.write_to_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            else
            {
                //write to dl1 has been successful
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                //now let's write to l2 cache
                drt_in = false; // write-through
                drt_out = false;
                if (!(Simulator.my_l2cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                {
                    //write to l2 has not been successful
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, false, "write");
                    //now let's write to memory
                    Simulator.my_memory.write_to_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    // read 64 bytes from memory
                    byte[] temp_block = new byte[64];
                    bool[] temp_block_address = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        temp_block_address[i] = address[i];
                    }
                    for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                    {
                        temp_block_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                    }
                    Simulator.my_memory.read_from_memory(temp_block_address, temp_block, 64);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                    //write 64 bytes to dl1 and l2 caches
                    drt_in = false; //write-through
                    ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                    drt_out = false;
                    Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
                else
                {
                    //write to l2 has been successful
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    //now let's write to memory
                    Simulator.my_memory.write_to_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }
            }
        }
    }
}
