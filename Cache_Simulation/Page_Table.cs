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
            System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
            char[] delimiterChars = { ' ' };
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                ulong instruction = Convert.ToUInt64(words[0],16);
                ulong address = Convert.ToUInt64(words[1]);
                Simulator.my_memory.add_instruction(instruction, address);
            }
            file.Close();
        }
    }
}
