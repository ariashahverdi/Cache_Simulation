using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Hard_Disk
    {
        public int size;
        public byte[] hard_disk; // Hard_disk

        public Hard_Disk(int m_size)
        {
            size = m_size;
            hard_disk = new byte[size];
            for (int i = 0; i < size; i++)
            {
                hard_disk[i] = 0;
            }
        }

        public void add_instruction(ulong inst, ulong address)
        {
            for (int i = 0; i < 8; i++)
            {
                ulong constant = 0xFF;
                hard_disk[address + Convert.ToUInt64(i)] = Convert.ToByte((inst & (constant << (8 * (7 - i)))) >> (8 * (7 - i)));
            }
        }

        public void read_page_from_disk(ulong in_address, byte[] data)
        {
            for (int i = 0; i < (4096); i++)
            {
                data[i] = hard_disk[in_address + Convert.ToUInt64(i)];
            }
            return;
        }

        public void write_to_page_in_hard_disk(ulong in_address, byte[] data, int block_size)
        {
            for (int i = 0; i < (block_size); i++)
            {
                hard_disk[in_address + Convert.ToUInt64(i)] = data[i];
            }
            return;
        }

    }
}
