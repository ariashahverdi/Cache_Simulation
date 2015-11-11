using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class pte
    {
        bool[] prot;

        int UNUSED_SIZE;
        bool[] unused;

        public bool valid;

        int VIRTUAL_SIZE;
        bool[] page_addr_tag;

        public ulong physical_address;
        public ulong virtual_address;

        int PHYSICAL_SIZE;
        public bool[] phys_addr;

        public pte()
        {
            valid = false;
            virtual_address = 0;
            physical_address = 0;
        }

        public pte(int V_S, int P_S)
        {
            prot = new bool[4];

            VIRTUAL_SIZE = V_S;
            page_addr_tag = new bool[VIRTUAL_SIZE];

            PHYSICAL_SIZE = P_S;
            phys_addr = new bool[PHYSICAL_SIZE];

            UNUSED_SIZE = 64 - 4 - 1 - VIRTUAL_SIZE - PHYSICAL_SIZE;
            unused = new bool[UNUSED_SIZE];
            for (int i = 0; i < UNUSED_SIZE; i++) unused[i] = false;

            //Initialize the tlb randomly
            for (int i = 0; i < 4; i++) prot[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            valid = false; //Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < VIRTUAL_SIZE; i++) page_addr_tag[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < PHYSICAL_SIZE; i++) phys_addr[i] = Convert.ToBoolean(Simulator.rand.Next(2));


        }


        public bool get_pte(bool[] page_addr_tag_in, bool[] phys_addr_out, bool[] prot_out)
        {
            bool hit = true;
            for (int i = 0; i < PHYSICAL_SIZE; i++)
            {
                if (page_addr_tag[i] != page_addr_tag_in[i]) hit = false;
            }
            if (hit & valid)
            {
                for (int i = 0; i < 4; i++) prot_out[i] = prot[i];
                for (int i = 0; i < PHYSICAL_SIZE; i++) phys_addr_out[i] = phys_addr[i];
                return true;
            }
            return false;
        }

        public bool set_pte(bool[] page_addr_tag_in, bool[] physical_addr_in, bool[] prot_in)
        {
            valid = true;
            for (int i = 0; i < 4; i++) prot[i] = prot_in[i];
            for (int i = 0; i < VIRTUAL_SIZE; i++) page_addr_tag[i] = page_addr_tag_in[i];
            for (int i = 0; i < PHYSICAL_SIZE; i++) phys_addr[i] = physical_addr_in[i];
            return true;
        }


        /*For printing purposes ...*/
        public int give_me_int(bool[] data, int size_data)
        {
            int data_int = 0;
            for (int i = 0; i < size_data; i++) data_int = 2 * data_int + Convert.ToInt32(data[i]);
            return data_int;
        }

        public string get_page_addr_tag()
        {
            return give_me_int(page_addr_tag,VIRTUAL_SIZE).ToString("X");
        }

        public string get_physical_addr()
        {
            return give_me_int(phys_addr, PHYSICAL_SIZE).ToString("X");
        }

        public string get_tag_payload()
        {
            return get_page_addr_tag() + get_physical_addr();
        }

        public bool get_valid()
        {
            return valid;
        }

        public string get_prot()
        {
            return give_me_int(prot, 4).ToString("X");
        }



    }
}
