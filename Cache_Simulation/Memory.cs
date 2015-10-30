using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Memory
    {
        public int size;
        public byte[] main_mem; // Main Memory

        public Memory(int m_size)
        {
            size = m_size;
            main_mem = new byte[size];
        }
        public void random_initialize()
        {
            // Initialize the memory to some totally random instructions
            // Opcode can only be { 0:load | 1:store | 2:branch | 3:other }
            // We modify the first byte of each instruction to be one of these
            for (int i = 0; i<Globals.MEM_SIZE;i++)
            {
                if (i % 8 == 0) main_mem[i] = (byte)((Simulator.rand.Next(256) % 4) << 6); //opcode
                else if ((i % 8 > 1)&&(i % 8 < 6)) main_mem[i] = 0;
                else main_mem[i] = (byte)Simulator.rand.Next(256);
            }
        }
        public void read_from_memory(bool[] in_address, byte[] data, int block_size)
        {
            ulong temp_address = 0;
            for (int i = 0; i < in_address.Length; i++)
            {
                if (in_address[i])
                {
                    temp_address |= Convert.ToUInt64(1 << i);
                }
            }
            for (int i =0; i<(block_size); i++)
            {
                data[i] = main_mem[temp_address + Convert.ToUInt64(i)];
            }
        }
    }
}
