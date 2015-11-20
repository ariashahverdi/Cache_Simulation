using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Memory_Controller
    {
        public Memory_Controller()
        {
        }
        public ulong address_translator(ulong virtual_address)
        {
            ulong physical_address = 0;
            bool[] vaddress = new bool[Globals.VIRTUAL_ADD_LEN];
            for (int i = 0; i < Globals.VIRTUAL_ADD_LEN; i++)
            {
                vaddress[Globals.VIRTUAL_ADD_LEN - i - 1] = (((virtual_address >> i) & 1) == 1);
            }
            bool[] temp_protection = new bool[4];
            bool[] paddress = new bool[Globals.PHYSICAL_ADD_LEN];
            // check for ITLB
            if(!(Simulator.my_itlb.read_from_tlb(vaddress, paddress, temp_protection)))
            {
                Globals.itlb_miss++;
                Program.my_sim.DrawLine("itlb", Globals.VIRTUAL_ADD_LEN, vaddress, false, "read");
                // check for TLB
                if (!(Simulator.my_tlb.read_from_tlb(vaddress, paddress, temp_protection)))
                {
                    Globals.tlb_miss++;
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, false, "read");

                    // check for Page Table
                    if (!(Simulator.my_page_table.search_pt(virtual_address, ref physical_address)))
                    {
                        //page fault occurred
                        Globals.pt_miss++;
                        Program.my_sim.DrawLine("pt", Globals.VIRTUAL_ADD_LEN, vaddress, false, "read");

                        // handle page fault
                        ulong virtual_replaced_address = 0;
                        if(!(Simulator.my_page_table.is_mem_available(physical_address, ref virtual_replaced_address)))
                        {
                            // write page back to hard disk
                            byte[] data2 = new byte[4096];
                            bool[] bool_phys_page_address2 = new bool[Globals.PHYSICAL_ADD_LEN];
                            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                            {
                                bool_phys_page_address2[Globals.PHYSICAL_ADD_LEN - i - 1] = (((physical_address >> i) & 1) == 1);
                            }

                            Simulator.my_memory.read_from_memory(bool_phys_page_address2, data2, 4096);
                            Globals.mem_access++;
                            Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, bool_phys_page_address2, true, "read");

                            Simulator.my_hard_disk.write_to_page_in_hard_disk(virtual_replaced_address, data2, 4096);

                            bool[] bool_virtual_page_address2 = new bool[Globals.VIRTUAL_ADD_LEN];
                            for (int i = 0; i < Globals.VIRTUAL_ADD_LEN; i++)
                            {
                                bool_virtual_page_address2[Globals.VIRTUAL_ADD_LEN - i - 1] = (((virtual_replaced_address >> i) & 1) == 1);
                            }
                            Globals.disk_access++;
                            Program.my_sim.DrawLine("disk", Globals.VIRTUAL_ADD_LEN, bool_virtual_page_address2, true, "write");

                        }

                        ulong virtual_page_address = (virtual_address & 0xFFFFFFFFFFFFF000);
                        byte[] data = new byte[4096];
                        Simulator.my_hard_disk.read_page_from_disk(virtual_page_address, data);

                        bool[] bool_virtual_page_address = new bool[Globals.VIRTUAL_ADD_LEN];
                        for (int i = 0; i < Globals.VIRTUAL_ADD_LEN; i++)
                        {
                            bool_virtual_page_address[Globals.VIRTUAL_ADD_LEN - i - 1] = (((virtual_page_address >> i) & 1) == 1);
                        }
                        Globals.disk_access++;
                        Program.my_sim.DrawLine("disk", Globals.VIRTUAL_ADD_LEN, bool_virtual_page_address, true, "read");


                        bool[] bool_phys_page_address = new bool[Globals.PHYSICAL_ADD_LEN];
                        for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                        {
                            bool_phys_page_address[Globals.PHYSICAL_ADD_LEN - i - 1] = (((physical_address >> i) & 1) == 1);
                        }
                        for(int i=0; i<12; i++)
                        {
                            bool_phys_page_address[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                        }

                        Simulator.my_memory.write_to_memory(bool_phys_page_address, data, 4096);
                        Globals.mem_access++;
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, bool_phys_page_address, true, "write");

                        Simulator.my_page_table.set_valid(virtual_address, physical_address);
                    }
                    else
                    {
                        // no page fault
                        Globals.pt_hit++;
                        Program.my_sim.DrawLine("pt", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
                    }

                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        ulong one = 1;
                        if ((physical_address & Convert.ToUInt64(one << i)) == 0)
                        {
                            paddress[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                        }
                        else
                        {
                            paddress[Globals.PHYSICAL_ADD_LEN - i - 1] = true;
                        }
                    }

                    // write to tlb and itlb
                    Simulator.my_tlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                    Simulator.my_itlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("itlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                    return physical_address;
                }
                else
                {
                    Globals.tlb_hit++;
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
                    // write to ITLB
                    Simulator.my_itlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("itlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                }
            }
            else
            {
                Globals.itlb_hit++;
                Program.my_sim.DrawLine("itlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
            }

            for(int i=0; i<Globals.PHYSICAL_ADD_LEN; i++)
            {
                if(paddress[Globals.PHYSICAL_ADD_LEN-i-1])
                {
                    ulong one = 1;
                    physical_address |= (one << i);
                }
            }

            return physical_address;
        }
        public ulong data_address_translator(ulong virtual_address)
        {
            ulong physical_address = 0;
            bool[] vaddress = new bool[Globals.VIRTUAL_ADD_LEN];
            for (int i = 0; i < Globals.VIRTUAL_ADD_LEN; i++)
            {
                vaddress[Globals.VIRTUAL_ADD_LEN - i - 1] = (((virtual_address >> i) & 1) == 1);
            }
            bool[] temp_protection = new bool[4];
            bool[] paddress = new bool[Globals.PHYSICAL_ADD_LEN];
            // check for DTLB
            if (!(Simulator.my_dtlb.read_from_tlb(vaddress, paddress, temp_protection)))
            {
                Globals.dtlb_miss++;
                Program.my_sim.DrawLine("dtlb", Globals.VIRTUAL_ADD_LEN, vaddress, false, "read");
                // check for TLB
                if (!(Simulator.my_tlb.read_from_tlb(vaddress, paddress, temp_protection)))
                {
                    Globals.tlb_miss++;
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, false, "read");

                    // check for Page Table
                    Simulator.my_page_table.search_pt(virtual_address, ref physical_address);
                    Globals.pt_hit++;
                    Program.my_sim.DrawLine("pt", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
                    for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                    {
                        ulong one = 1;
                        if ((physical_address & Convert.ToUInt64(one << i)) == 0)
                        {
                            paddress[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                        }
                        else
                        {
                            paddress[Globals.PHYSICAL_ADD_LEN - i - 1] = true;
                        }
                    }

                    // write to tlb and dtlb
                    Simulator.my_tlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                    Simulator.my_dtlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("dtlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                    return physical_address;
                }
                else
                {
                    Globals.tlb_hit++;
                    Program.my_sim.DrawLine("tlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
                    // write to DTLB
                    Simulator.my_dtlb.write_to_tlb(vaddress, paddress, temp_protection);
                    Program.my_sim.DrawLine("dtlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "write");
                }
            }
            else
            {
                Globals.dtlb_hit++;
                Program.my_sim.DrawLine("dtlb", Globals.VIRTUAL_ADD_LEN, vaddress, true, "read");
            }

            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                if (paddress[Globals.PHYSICAL_ADD_LEN - i - 1])
                {
                    ulong one = 1;
                    physical_address |= (one << i);
                }
            }

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
                Globals.il1cache_miss++;
                Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 8, ir1)))
                {
                    // L2 is missed
                    Globals.l2cache_miss++;
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");

                    //check for l3 cache
                    if (!(Simulator.my_l3cache.read_from_cache(address, 8, ir1)))
                    {
                        // L3 is missed
                        Globals.l3cache_miss++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");

                        //check for memory
                        Simulator.my_memory.read_from_memory(address, ir1, 8);
                        Globals.mem_access++;
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

                        //////// write a block to L3 cache
                        bool drt_in = false;
                        bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                        byte[] dt_out = new byte[Simulator.my_l3cache.PAYLOAD_SIZE];
                        bool drt_out = false;
                        Simulator.my_l3cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        //////// write a block to L2 cache
                        drt_in = false;
                        drt_out = false;
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
                        // L3 is hit
                        Globals.l3cache_hit++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                        // read the block from L3 cache and write the value to iL1 and L2
                        // read 64 bytes from L3 Cache
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
                        Simulator.my_l3cache.read_from_cache(temp_block_address, 64, temp_block);
 
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
                }
                else
                {
                    // L2 is hit
                    Globals.l2cache_hit++;
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
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_il1cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_il1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("il1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }

            }
            else
            {
                Globals.il1cache_hit++;
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
            ulong physical_pc = data_address_translator(cpu_address);
            byte[] temp_data = new byte[8];
            bool[] address = new bool[Globals.PHYSICAL_ADD_LEN];

            for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
            {
                address[Globals.PHYSICAL_ADD_LEN - i - 1] = (((physical_pc >> i) & 1) == 1);
            }

            //check for dl1 cache
            if (!(Simulator.my_dl1cache.read_from_cache(address, 8, temp_data)))
            {
                Globals.dl1cache_miss++;
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 8, temp_data)))
                {
                    // L2 is missed
                    Globals.l2cache_miss++;
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");

                    //check for l3 cache
                    if (!(Simulator.my_l3cache.read_from_cache(address, 8, temp_data)))
                    {
                        // L3 is missed
                        Globals.l3cache_miss++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, false, "read");

                        //check for memory
                        Simulator.my_memory.read_from_memory(address, temp_data, 8);
                        Globals.mem_access++;
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

                        //////// write a block to L3 cache
                        bool drt_in = false;
                        bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                        byte[] dt_out = new byte[Simulator.my_l3cache.PAYLOAD_SIZE];
                        bool drt_out = false;
                        Simulator.my_l3cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        //////// write a block to L2 cache
                        drt_in = false;
                        drt_out = false;
                        Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        // write a block to dL1 cache 
                        drt_in = false;
                        drt_out = false;
                        Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                    else
                    {
                        // L3 is hit
                        Globals.l3cache_hit++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                        // read the block from L3 cache and write the value to iL1 and L2
                        // read 64 bytes from L3 Cache
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
                        Simulator.my_l3cache.read_from_cache(temp_block_address, 64, temp_block);

                        //////// write a block to L2 cache
                        bool drt_in = false;
                        bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                        byte[] dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                        bool drt_out = false;
                        Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        // write a block to dL1 cache
                        drt_in = false;
                        drt_out = false;
                        Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                }
                else
                {
                    // L2 is hit
                    Globals.l2cache_hit++;
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
                    // write a block to dL1 cache
                    bool drt_in = false;
                    bool[] ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                    byte[] dt_out = new byte[Simulator.my_il1cache.PAYLOAD_SIZE];
                    bool drt_out = false;
                    Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                }

            }
            else
            {
                Globals.dl1cache_hit++;
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
            ulong physical_pc = data_address_translator(cpu_address);
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
                Globals.dl1cache_miss++;
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");
                //now let's write to l2 cache
                drt_in = false; // write-through
                drt_out = false;
                if (!(Simulator.my_l2cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                {
                    //write to l2 has not been successful
                    Globals.l2cache_miss++;
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");

                    //now let's write to l3 cache
                    drt_in = false; // write-through
                    drt_out = false;
                    if (!(Simulator.my_l3cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                    {
                        //write to l3 has not been successful
                        Globals.l3cache_miss++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");

                        //now let's write to memory
                        Simulator.my_memory.write_to_memory(address, temp_data, 8);
                        Globals.mem_access++;
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
                        //////// write a block to L1 & L2 cache & L3 cache
                        drt_in = false;
                        drt_out = false;
                        Simulator.my_l3cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                    else
                    {
                        //write to l3 has been successful
                        Globals.l3cache_hit++;
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        
                        // now lets write 64 bytes to dl2 and dl1
                        // read 64 bytes from l3
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
                        Simulator.my_l3cache.read_from_cache(temp_block_address, 64, temp_block);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                        
                        //////// write a block to L1 and L2 cache
                        drt_in = false;
                        drt_out = false;
                        Simulator.my_dl1cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        Simulator.my_l2cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        //now let's write to memory
                        Simulator.my_memory.write_to_memory(address, temp_data, 8);
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                    }
                }
                else
                {
                    //write to l2 has been successful
                    Globals.l2cache_hit++;
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
                    //now let's write to L3 cache and memory
                    Simulator.my_l3cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                    Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    Simulator.my_memory.write_to_memory(address, temp_data, 8);
                    Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                }
            }
            ///////////////////////////////write to dl1 has been successful
            else
            {
                //write to dl1 has been successful
                Globals.dl1cache_hit ++;
                Program.my_sim.DrawLine("dl1cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                //now let's write to l2 cache
                drt_in = false; // write-through
                drt_out = false;
                if (!(Simulator.my_l2cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                {
                    //write to l2 has not been successful
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");

                    //now let's write to L3 cache
                    if (!(Simulator.my_l3cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                    {
                        // write to l3 has not been successful
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");
                        //now let's write to memory
                        Simulator.my_memory.write_to_memory(address, temp_data, 8);
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        // read 64 bytes from memory
                        byte[] temp_block2 = new byte[64];
                        bool[] temp_block_address2 = new bool[Globals.PHYSICAL_ADD_LEN];
                        for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                        {
                            temp_block_address2[i] = address[i];
                        }
                        for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                        {
                            temp_block_address2[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                        }
                        Simulator.my_memory.read_from_memory(temp_block_address2, temp_block2, 64);
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "read");
                        //write 64 bytes to dl3 caches and dl2
                        drt_in = false; //write-through
                        ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                        dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                        drt_out = false;
                        Simulator.my_l3cache.write_to_cache(temp_block_address2, 64, temp_block2, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        Simulator.my_l2cache.write_to_cache(temp_block_address2, 64, temp_block2, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                    else
                    {
                        // write to l3 has been successful
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                        // read 64 bytes from l3
                        byte[] temp_block3 = new byte[64];
                        bool[] temp_block_address3 = new bool[Globals.PHYSICAL_ADD_LEN];
                        for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                        {
                            temp_block_address3[i] = address[i];
                        }
                        for (int i = 0; i < Globals.BYTE_OFF_LEN; i++)
                        {
                            temp_block_address3[Globals.PHYSICAL_ADD_LEN - i - 1] = false;
                        }
                        Simulator.my_l3cache.read_from_cache(temp_block_address3, 64, temp_block3);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "read");

                        //now let's write to l2 cache
                        drt_in = false; // write-through
                        drt_out = false;
                        Simulator.my_l2cache.write_to_cache(temp_block_address3, 64, temp_block3, drt_in, ad_out, dt_out, ref drt_out) ;

                        //now let's write to memory
                        Simulator.my_memory.write_to_memory(address, temp_data, 8);
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                }
                else
                {
                    //write to l2 has been successful
                    Program.my_sim.DrawLine("l2cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");

                    //now let's write to L3 cache
                    if (!(Simulator.my_l3cache.write_to_cache(address, 8, temp_data, drt_in, ad_out, dt_out, ref drt_out)))
                    {
                        // write to l3 has not been successful
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, false, "write");
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
                        //write 64 bytes to dl3 caches
                        drt_in = false; //write-through
                        ad_out = new bool[Globals.PHYSICAL_ADD_LEN];
                        dt_out = new byte[Simulator.my_l2cache.PAYLOAD_SIZE];
                        drt_out = false;
                        Simulator.my_l3cache.write_to_cache(temp_block_address, 64, temp_block, drt_in, ad_out, dt_out, ref drt_out);
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                    else
                    {
                        // write to l3 has been successful
                        Program.my_sim.DrawLine("l3cache", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                        //now let's write to memory
                        Simulator.my_memory.write_to_memory(address, temp_data, 8);
                        Program.my_sim.DrawLine("mem", Globals.PHYSICAL_ADD_LEN, address, true, "write");
                    }
                }
            }
        }
    }
}
