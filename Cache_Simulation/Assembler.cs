using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class Assembler
    {

        public void assemble(string fn)
        {
            int instruction_counter = 0;
            ulong starting_point;
            

            // create the file and write it.
            System.IO.StreamWriter hex_file = new System.IO.StreamWriter("../../test.hex", false);

            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("../../"+fn);
            char[] delimiterChars = { ' ', ',' };
            byte[,] current_instruction = new byte[1024, 8];
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                for (int i = 0; i < 8; i++)
                {
                    current_instruction[instruction_counter, i] = 0;
                }

                switch (words[0])
                {
                    case "load":
                        current_instruction[instruction_counter, 0] |= 0x00;
                        break;

                    case "store":
                        current_instruction[instruction_counter, 0] |= 0x40;
                        break;

                    case "branch":
                        current_instruction[instruction_counter, 0] |= 0x80;
                        break;

                    case "add":
                        current_instruction[instruction_counter, 0] |= 0xC0;
                        break;
                    case "data":
                        byte current_data = Convert.ToByte(words[8]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[7]);
                        current_instruction[instruction_counter, 6] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[6]);
                        current_instruction[instruction_counter, 5] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[5]);
                        current_instruction[instruction_counter, 4] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[4]);
                        current_instruction[instruction_counter, 3] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[3]);
                        current_instruction[instruction_counter, 2] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[2]);
                        current_instruction[instruction_counter, 1] = Convert.ToByte(current_data);
                        current_data = Convert.ToByte(words[1]);
                        current_instruction[instruction_counter, 0] = Convert.ToByte(current_data);
                        break;
                    case "halt":
                        current_instruction[instruction_counter, 0] |= 0xFF;
                        current_instruction[instruction_counter, 1] |= 0xFF;
                        current_instruction[instruction_counter, 2] |= 0xFF;
                        current_instruction[instruction_counter, 3] |= 0xFF;
                        current_instruction[instruction_counter, 4] |= 0xFF;
                        current_instruction[instruction_counter, 5] |= 0xFF;
                        current_instruction[instruction_counter, 6] |= 0xFF;
                        current_instruction[instruction_counter, 7] |= 0xFF;
                        break;
                    default:
                        if (instruction_counter == 0)
                        {
                            starting_point = Convert.ToUInt64(words[0]);
                            hex_file.Write(starting_point.ToString());
                            hex_file.Write(" ");
                        }
                        else
                        {
                            hex_file.Write(instruction_counter.ToString());
                            hex_file.Write(" ");
                            for (int i = 0; i < instruction_counter; i++)
                            {
                                hex_file.Write("0x");
                                for (int j = 0; j < 8; j++)
                                {
                                    hex_file.Write(current_instruction[i, j].ToString("X").PadLeft(2, '0'));
                                }
                                hex_file.Write(" ");
                            }
                            hex_file.Write(System.Environment.NewLine);

                            starting_point = Convert.ToUInt64(words[0]);
                            hex_file.Write(starting_point.ToString());
                            hex_file.Write(" ");
                        }


                        instruction_counter = 0;
                        continue;
                }

                char[] delimiter = { '(', ')' };

                /////////////////////////////////////////////////////// Destination
                if((words[0] == "halt") || (words[0]=="data"))
                {
                    //don't do anything
                }
                else if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    current_instruction[instruction_counter, 1] |= 0x00;
                }
                else
                {
                    if (words[1].StartsWith("r"))
                    {
                        string[] destination = words[1].Split(delimiter);
                        if (destination.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int dest_reg = Convert.ToInt32(destination[0][1]) - 0X30;
                            dest_reg = dest_reg << 2;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(dest_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int dest_reg = Convert.ToInt32(destination[0][1]) - 0X30;
                            dest_reg = dest_reg << 2;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(dest_reg);
                            current_instruction[instruction_counter, 0] |= 0x02;
                            int index = Convert.ToInt32(destination[1]);
                            current_instruction[instruction_counter, 7] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 6] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[1].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x01;
                        string[] destination = words[1].Split(delimiter);
                        ulong address = Convert.ToUInt64(destination[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x03;
                        ulong immediate = Convert.ToUInt64(words[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }

                /////////////////////////////////////////////////////// Source 1

                if ((words[0] == "halt") || (words[0] == "data"))
                {
                    //don't do anything
                }
                else if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    //Address Mode 0 Register direct
                    int src1_reg = Convert.ToInt32(words[1][1]) - 0X30;
                    src1_reg = src1_reg << 6;
                    current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                }
                else
                {
                    if (words[2].StartsWith("r"))
                    {
                        string[] source1 = words[2].Split(delimiter);
                        if (source1.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int src1_reg = Convert.ToInt32(source1[0][1]) - 0X30;
                            src1_reg = src1_reg << 6;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int src1_reg = Convert.ToInt32(source1[0][1]) - 0X30;
                            src1_reg = src1_reg << 6;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src1_reg);
                            current_instruction[instruction_counter, 0] |= 0x20;
                            int index = Convert.ToInt32(source1[1]);
                            current_instruction[instruction_counter, 3] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 2] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[2].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x10;
                        string[] source_1 = words[2].Split(delimiter);
                        ulong address = Convert.ToUInt64(source_1[1]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x30;
                        ulong immediate = Convert.ToUInt64(words[2]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }

                /////////////////////////////////////////////////////// Source 2

                if ((words[0] == "halt") || (words[0] == "data"))
                {
                    //don't do anything
                }
                else if (words[0] == "branch")
                {
                    current_instruction[instruction_counter, 0] |= 0x00;
                    //Address Mode 0 Register direct
                    int src2_reg = Convert.ToInt32(words[2][1]) - 0X30;
                    src2_reg = src2_reg << 4;
                    current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                }
                else if (words[0] == "add")
                {
                    if (words[3].StartsWith("r"))
                    {
                        string[] source2 = words[1].Split(delimiter);
                        if (source2.Length < 2)
                        {
                            //Address Mode 0 Register direct
                            int src2_reg = Convert.ToInt32(source2[0][1]) - 0X30;
                            src2_reg = src2_reg << 4;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                            current_instruction[instruction_counter, 0] |= 0x00;
                        }
                        else
                        {
                            //Address Mode 2 index
                            int src2_reg = Convert.ToInt32(source2[0][1]) - 0X30;
                            src2_reg = src2_reg << 4;
                            current_instruction[instruction_counter, 1] |= Convert.ToByte(src2_reg);
                            current_instruction[instruction_counter, 0] |= 0x08;
                            int index = Convert.ToInt32(source2[1]);
                            current_instruction[instruction_counter, 5] = Convert.ToByte(index & 0xFF);
                            current_instruction[instruction_counter, 4] = Convert.ToByte((index & 0xFF00) >> 8);
                        }
                    }
                    else if (words[1].StartsWith("("))
                    {
                        //Address Mode Indirect
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x04;
                        string[] source2 = words[1].Split(delimiter);
                        ulong address = Convert.ToUInt64(source2[0]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(address & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((address & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((address & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((address & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((address & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((address & 0xFF0000000000) >> 40);
                    }
                    else
                    {
                        //Adress Mode Immediate
                        current_instruction[instruction_counter, 1] |= 0x00;
                        current_instruction[instruction_counter, 0] |= 0x0C;
                        ulong immediate = Convert.ToUInt64(words[3]);
                        current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                        current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                        current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                        current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                        current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                        current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                    }
                }


                /////////////////////////////////////////////////////// JMP Address

                if (words[0] == "branch")
                {
                    ulong immediate = Convert.ToUInt64(words[3]);
                    current_instruction[instruction_counter, 7] = Convert.ToByte(immediate & 0xFF);
                    current_instruction[instruction_counter, 6] = Convert.ToByte((immediate & 0xFF00) >> 8);
                    current_instruction[instruction_counter, 5] = Convert.ToByte((immediate & 0xFF0000) >> 16);
                    current_instruction[instruction_counter, 4] = Convert.ToByte((immediate & 0xFF000000) >> 24);
                    current_instruction[instruction_counter, 3] = Convert.ToByte((immediate & 0xFF00000000) >> 32);
                    current_instruction[instruction_counter, 2] = Convert.ToByte((immediate & 0xFF0000000000) >> 40);
                }
                instruction_counter++;

            }


            if (instruction_counter != 0)
            {
                hex_file.Write(instruction_counter.ToString());
                hex_file.Write(" ");
                for (int i = 0; i < instruction_counter; i++)
                {
                    hex_file.Write("0x");
                    for (int j = 0; j < 8; j++)
                    {
                        hex_file.Write(current_instruction[i, j].ToString("X").PadLeft(2, '0'));
                    }
                    hex_file.Write(" ");
                }
                hex_file.Write(System.Environment.NewLine);
            }

            file.Close();
            hex_file.Close();

        }

    }
}
