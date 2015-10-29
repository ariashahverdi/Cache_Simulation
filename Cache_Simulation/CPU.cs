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
            for (ulong i = 0; i < 8; i++) { Simulator.my_cpu.IR1[i] = Simulator.my_memory.main_mem[Simulator.my_cpu.PC + i]; }
            for (ulong i = 0; i < 8; i++) { Simulator.my_cpu.IR2[i] = Simulator.my_memory.main_mem[Simulator.my_cpu.PC + i + 8]; }
            PC += 8;
        }

        public void execute()
        {
            
        }
    }
}
