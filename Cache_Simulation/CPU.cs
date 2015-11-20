using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class CPU
    {
        public ulong[] R;

        public byte[] IR1;
        public byte[] IR2;

        public bool is_halted;

        public ulong PC;

        private int opcode;
        private int src1_add_mode;
        private int src2_add_mode;
        private int dst_add_mode;
        private int src1_reg;
        private int src2_reg;
        private int dst_reg;
        private ulong inst_addr;


        private void opcode_decoder()
        {
            opcode = IR1[0] >> 6;
            src1_add_mode = (IR1[0] & (0x30)) >> 4;
            src2_add_mode = (IR1[0] & (0x0C)) >> 2;
            dst_add_mode = (IR1[0] & (0x03));
            src1_reg = IR1[1] >> 6;
            src2_reg = (IR1[1] & (0x30)) >> 4;
            dst_reg = (IR1[1] & (0x0C)) >> 2;

            inst_addr = 0;
            for (int i = 2; i < 8; i++)
            {
                ulong temp = Convert.ToUInt64(IR1[i]);
                inst_addr |= temp << (8 * (7 - i));
            }
        }

        public CPU()
        {
            R = new ulong[4];
            R[0] = 0;
            R[1] = 0;
            R[2] = 0;
            R[3] = 0;
            IR1 = new byte[8];
            IR2 = new byte[8];
            PC = 0;
            is_halted = false;
        }

        public void fetch()
        {
            Simulator.my_memctrl.fetch_instructions(PC, IR1, IR2);
            PC += 8;
            execute();
            return;
        }

        public void execute()
        {
            opcode_decoder();
            switch (opcode)
            {
                case 0: // load instruction
                    ulong in_data = 0;
                    Simulator.my_memctrl.read_operand(inst_addr, ref in_data);
                    R[dst_reg] = in_data;
                    break;
               case 1: // store insruction
                    Simulator.my_memctrl.write_operand(inst_addr, R[src1_reg]);
                    break;
                case 2: // branch instruction
                    if(R[src1_reg] != R[src2_reg])
                    {
                        PC = inst_addr;
                    }
                    break;
                case 3: // add instruction
                    if((src1_add_mode == 3)&& (src2_add_mode == 3) && (dst_add_mode == 3) && (src1_reg == 3) && (src2_reg == 3) && (dst_reg == 3) )
                    {
                        //halt instrucstion
                        is_halted = true;
                        break;
                    }

                    if(src2_add_mode == 0)
                    {
                        R[dst_reg] = R[src1_reg] + R[src2_reg];
                    }
                    else if(src2_add_mode == 3)
                    {
                        R[dst_reg] = R[src1_reg] + inst_addr;
                    }
                    break;
                default: // bad opcode
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
