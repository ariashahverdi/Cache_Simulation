using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Page_Table
    {
        public pte[] entries;
        public int size;
        public string program_file_name;

        public Page_Table(int n, string file_name)
        {
            size = n;
            entries = new pte[size];
            program_file_name = file_name;
        }

        public bool search_pt(ulong vaddress, ref ulong paddress)
        {
            ulong page_offset = (vaddress & (0xFFF));
            vaddress = (vaddress >> 12);
            int iterator = 0;
            while (entries[iterator].valid == true)
            {
                if (entries[iterator].virtual_address == vaddress)
                {
                    paddress = entries[iterator].physical_address;
                    paddress = paddress << 12;
                    paddress = paddress | page_offset; 
                    return true;
                }
                iterator++;
            }
            return false;
        }

        public void initialize()
        {
            // initialize the PTPTEs
            for(int i=0; i<size; i++)
            {
                entries[i] = new pte();
            }

            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("../../test.hex");
            char[] delimiterChars = { ' ' };
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                int page_size = Convert.ToInt32(words[1]);
                ulong address = Convert.ToUInt64(words[0]);

                // add the page_table entry
                int iterator = 0;

                while(entries[iterator].valid == true)
                {
                    iterator++;
                }

                ulong vaddress = (address >> 12);
                
                entries[iterator].valid = true;
                entries[iterator].virtual_address = vaddress;
                entries[iterator].physical_address = Convert.ToUInt64(Simulator.rand.Next(Convert.ToInt32(Simulator.my_memory.size >> 12)));


                ulong phys_address = 0;
                search_pt(address, ref phys_address);
                for (int i = 0; i < page_size; i++)
                {
                    ulong instruction = Convert.ToUInt64(words[2 + i], 16);
                    Simulator.my_memory.add_instruction(instruction, (phys_address + Convert.ToUInt64(8 * i)));
                }

            }
            file.Close();
        }

    }
}
