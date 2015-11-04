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

        private void add_instruction(ulong inst, ulong address)
        {
            for (int i = 0; i < 8; i++)
            {
                ulong constant = 0xFF;
                main_mem[address+Convert.ToUInt64(i)] = Convert.ToByte((inst & (constant << (8 * (7 - i)))) >> (8 * (7 - i)));
            }
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

            // test program                                                         ops1s2dt_s1s2dtXX
            add_instruction(0xC404000000000005, 104); // R1 = R0 + 5  f2B_binary -> 11000100_00000100
            add_instruction(0xC408000000000001, 112); // R2 = R0 + 1  f2B_binary -> 11000100_00001000
            add_instruction(0xC488000000000001, 120); // R2 = R2 + 1  f2B_binary -> 11000100_10001000
            add_instruction(0x4080000000000000, 128); // Mem[0] = R2  f2B_binary -> 01000000_10000000
            add_instruction(0x000C000000000000, 136); // R3 = Mem [0] f2B_binary -> 00000000_00001100
            add_instruction(0x80D0000000000078, 144); //Beq R3,R1,120 f2B_binary -> 10000000_11010000


            return;
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
            return;
        }

        public void write_to_memory(bool[] in_address, byte[] data, int block_size)
        {
            ulong temp_address = 0;
            for (int i = 0; i < in_address.Length; i++)
            {
                if (in_address[i])
                {
                    temp_address |= Convert.ToUInt64(1 << i);
                }
            }
            for (int i = 0; i < (block_size); i++)
            {
                 main_mem[temp_address + Convert.ToUInt64(i)] = data[i];
            }
            return;
        }
    }
}
