using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class CPU
    {
        public ulong R0;
        public ulong R1;
        public ulong R2;
        public ulong R3;

        public byte[] IR1;
        public byte[] IR2;

        public ulong PC;


        public CPU()
        {
            R0 = 0;
            R1 = 0;
            R2 = 0;
            R3 = 0;
            IR1 = new byte[8];
            IR2 = new byte[8];
            PC = 0;

        }

        public void fetch()
        {
            Simulator.my_memctrl.fetch_instructions(PC, IR1, IR2);
            PC += 8;
            execute();
        }

        public void execute()
        {
            int opcode;
            opcode = (IR1[0] & (3 << 6));
            switch (opcode)
            {

                case 0: // load instruction
                    int dest_register = (IR1[1] & (12));
                    dest_register = dest_register >> 2;
                    ulong load_address = 0;
                    ulong in_data = 0;
                    for(int i=2; i<8; i++)
                    {
                        ulong temp = Convert.ToUInt64(IR1[i]);
                        load_address |= temp << (8 * (7-i));
                    }
                    Simulator.my_memctrl.read_operand(load_address, ref in_data);
                    switch (dest_register)
                    {
                        case 0:
                            R0 = in_data;
                            break;
                        case 1:
                            R1 = in_data;
                            break;
                        case 2:
                            R2 = in_data;
                            break;
                        case 3:
                            R3 = in_data;
                            break;
                    }
                    break;
               case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:

                    break;
            }
        }
    }
}
