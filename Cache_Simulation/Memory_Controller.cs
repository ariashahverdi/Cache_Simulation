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
        public void fetch_instructions(ulong cpu_pc, byte[] ir1, byte[] ir2)
        {
            ulong temp_pc = cpu_pc;
            bool[] address = new bool[64];
            bool[] next_address = new bool[64];
            for (int i = 0; i < 64; i++)
            {
                address[i] = ((temp_pc >> i) & 1) == 1;
            }
            for (int i = 0; i < 64; i++)
            {
                next_address[i] = (((temp_pc+8) >> i) & 1) == 1;
            }

            //check for il1 cache
            if (!(Simulator.my_il1cache.read_from_cache(address, 8, ir1))) 
            {
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 8, ir1)))
                {
                    //check for memory
                    Simulator.my_memory.read_from_memory(address, ir1, 8);
                    // read 64 bytes from main memory
                    // write a block to L2 cache
                    // write a block to IL1 cache 
                }
            }
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

        }

        public void read_operand(ulong cpu_address, ref ulong data)
        {
            ulong temp_address = cpu_address;
            byte[] temp_data = new byte[8];
            bool[] address = new bool[64];
            for (int i = 0; i < 64; i++)
            {
                address[i] = ((temp_address >> i) & 1) == 1;
            }

            //check for il1 cache
            if (!(Simulator.my_il1cache.read_from_cache(address, 64, temp_data)))//Amir --> Aria Modiefied this Line
            {
                //check for l2 cache
                if (!(Simulator.my_l2cache.read_from_cache(address, 64, temp_data)))//Amir --> Aria Modiefied this Line
                {
                    //check for memory
                    Simulator.my_memory.read_from_memory(address, temp_data, 8);
                    // read 64 bytes from main memory
                    // write a block to L2 cache
                    // write a block to IL1 cache 
                }
            }
            data = 0;
            for(int i=0; i<8; i++)
            {
                data |= (Convert.ToUInt64(temp_data[i]) << (8 * (7-i))); 
            }
        }

        public void write_operand(ulong cpu_address, ulong data)
        {
            byte[] temp_data = new byte[8];
            bool[] address = new bool[64];
            for (int i = 0; i < 64; i++)
            {
                address[i] = (((cpu_address >> i) & 1) == 1);
            }
            for (int i = 0; i < 8; i++)
            {
                ulong constant = 0xFF;
                temp_data[i] = Convert.ToByte((data & (constant << (8 * (7 - i)))) >> (8 * (7 - i)));
            }

            //check for il1 cache
            //if (!(Simulator.my_il1cache.read_from_cache(address, temp_data)))
            //{
            //check for l2 cache
            //if (!(Simulator.my_l2cache.read_from_cache(address, temp_data)))
            //{
            //check for memory
            Simulator.my_memory.write_to_memory(address, temp_data, 8);
            // read 64 bytes from main memory
            // write a block to L2 cache
            // write a block to IL1 cache 
            //}
            //}
        }
    }
}
