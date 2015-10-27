using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class pte
    {
        bool valid;

        bool[] prot;

        int VIRTUAL_SIZE;
        bool[] page_addr_tag;

        int PHYSICAL_SIZE;
        bool[] phys_addr;

        public pte(int V_S, int P_S)
        {
            prot = new bool[4];

            VIRTUAL_SIZE = V_S;
            page_addr_tag = new bool[VIRTUAL_SIZE];

            PHYSICAL_SIZE = P_S;
            phys_addr = new bool[PHYSICAL_SIZE];

            //Initialize the tlb randomly
            for (int i = 0; i < 4; i++) prot[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            valid = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < VIRTUAL_SIZE; i++) page_addr_tag[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < PHYSICAL_SIZE; i++) phys_addr[i] = Convert.ToBoolean(Simulator.rand.Next(2));


        }
/*
        public int tag_val_calc(bool[] tag)
        {
            int tag_val = 0;
            for (int i = 0; i < TAG_SIZE; i++) tag_val = 2 * tag_val + Convert.ToInt32(tag[i]);
            return tag_val;
        }

        public string get_tag()
        {
            return tag_val_calc(tag).ToString("X");
        }

        public string get_payload()
        {
            return BitConverter.ToString(payload).Replace("-", "");
        }
*/
    }
}
