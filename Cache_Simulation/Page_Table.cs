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

        public void initialize()
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("../../test.txt");
            char[] delimiterChars = { ' ' };
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                int page_size = Convert.ToInt32(words[0]);
                ulong address = Convert.ToUInt64(words[1]);
                for (int i = 0; i < page_size; i++)
                {
                    ulong instruction = Convert.ToUInt64(words[2+i], 16); 
                    Simulator.my_memory.add_instruction(instruction, (address+Convert.ToUInt64(8* i)));
                }

                /*
                // add the page_table entry
                int iterator = 0;
                while(entries[iterator].valid == false)
                {
                    iterator++;
                }

                bool[] virtual_address = new bool[Globals.VIRTUAL_ADD_LEN - Globals.PAGE_OFF_LEN];
                bool[] physical_address = new bool[Globals.PHYSICAL_ADD_LEN - Globals.PAGE_OFF_LEN];
                bool[] protection = new bool[4];
                protection[0] = false; protection[1] = false; protection[2] = false; protection[3] = false;

                ulong vaddress = (address >> 12);

                for (int i = 0; i < Globals.PHYSICAL_ADD_LEN; i++)
                {
                    virtual_address[Globals.VIRTUAL_ADD_LEN - Globals.PAGE_OFF_LEN - i - 1] = (((vaddress >> i) & 1) == 1);
                }

                

                add some code here


                

                entries[iterator].set_pte(virtual_address, physical_address, protection);
                */
            }
            file.Close();
        }
    }
}
