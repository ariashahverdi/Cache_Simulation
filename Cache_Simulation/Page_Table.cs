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

        public int real_size;

        public Page_Table(int n, string file_name)
        {
            real_size = 0;
            size = n;
            entries = new pte[size];
            program_file_name = file_name;
        }

        public bool search_pt(ulong vaddress, ref ulong paddress)
        {
            ulong page_offset = (vaddress & (0xFFF));
            vaddress = (vaddress >> 12);
            for(int i=0; i<real_size; i++)
            {
                if (entries[i].virtual_address == vaddress)
                {
                    if(entries[i].valid == true)
                    {
                        paddress = entries[i].physical_address;
                        paddress = paddress << 12;
                        paddress = paddress | page_offset;
                        return true;
                    }
                    else
                    {
                        paddress = entries[i].physical_address;
                        paddress = paddress << 12;
                        paddress = paddress | page_offset;
                        return false;
                    }
                    
                }
            }
            return false;
        }

        public void set_valid(ulong vaddress, ulong paddress)
        {
            ulong temp_vaddress = (vaddress >> 12);
            ulong temp_paddress = (paddress >> 12);
            for (int i = 0; i < real_size; i++)
            {
                if (entries[i].virtual_address == temp_vaddress)
                {
                    if (entries[i].physical_address == temp_paddress)
                    {
                        entries[i].valid = true;
                    }
                }
            }
        }


        public bool is_mem_available(ulong phys_address, ref ulong v_address)
        {
            ulong temp_phys_address = (phys_address >> 12);
            for (int i = 0; i < real_size; i++)
            {
                if (entries[i].physical_address == temp_phys_address)
                {
                    if (entries[i].valid == true)
                    {
                        v_address = entries[i].virtual_address;
                        v_address = v_address << 12;
                        entries[i].valid = false;
                        return false;
                    }
                }
            }
            return true;
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
                
                ulong temp_address = address;

                for (int i=2; i<(page_size+2); i++)
                {
                    ulong instruction = Convert.ToUInt64(words[i], 16);
                    Simulator.my_hard_disk.add_instruction(instruction, (address + Convert.ToUInt64(8 * (i-2))));

                    // add the page_table entry if it's not already there
                    ulong vaddress = ((address + Convert.ToUInt64(8 * (i - 2))) >> 12);
                    bool found = false;
                    for(int j=0; j<real_size; j++)
                    {
                        if (entries[j].virtual_address == vaddress)
                            found = true;
                    }

                    if(!found)
                    {
                        entries[real_size].virtual_address = vaddress;
                        entries[real_size].physical_address = Convert.ToUInt64(Simulator.rand.Next(Convert.ToInt32(Simulator.my_memory.size >> 12)));
                        real_size++;
                    }
                }
            }
            file.Close();
        }

    }
}
