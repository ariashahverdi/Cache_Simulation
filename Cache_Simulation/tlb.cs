using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    class tlb
    {
        int VIRTUAL_SIZE;
        int PHYSICAL_SIZE;
        int INDEX_SIZE;

        int BANK_NUM;
        int PTE_NUM;

        public static pte[,] bankS_pte;

        public tlb(int BA_N, int PT_N, int V_S, int P_S, int I_S)
        {
            VIRTUAL_SIZE = V_S;
            PHYSICAL_SIZE = P_S;

            INDEX_SIZE = I_S;

            BANK_NUM = BA_N;
            PTE_NUM = PT_N;


            bankS_pte = new pte[PTE_NUM, BANK_NUM];
            for (int i = 0; i < PTE_NUM; i++)
                for (int j = 0; j < BANK_NUM; j++)
                    bankS_pte[i, j] = new pte(VIRTUAL_SIZE, PHYSICAL_SIZE);
        }

        public bool read_from_tlb(bool[] v_addr, bool[] p_addr)
        {
            bool[] read_tag = new bool[TAG_SIZE];
            bool[] read_idx = new bool[Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN];
            bool[] block_offset = new bool[Globals.BYTE_OFF_LEN - 3];
            byte[] payload = new byte[PAYLOAD_SIZE];

            for (int i = 0; i < TAG_SIZE; i++) read_tag[i] = address[i];
            for (int i = 0; i < INDEX_SIZE; i++) read_idx[i] = address[TAG_SIZE + i];
            for (int i = 0; i < (Globals.BYTE_OFF_LEN - 3); i++) block_offset[i] = address[TAG_SIZE + INDEX_SIZE + i];

            bool[] read_tag_out = new bool[TAG_SIZE]; //no use!!! pfff
            bool dirty_check = false; //no use

            int read_idx_val = give_me_int(read_idx, INDEX_SIZE);
            int block_off_val = give_me_int(block_offset, 3); //<<<<<<<<<<<<<<
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS[read_idx_val, i].get_block(read_tag, read_tag_out, payload, dirty_check))
                {
                    for (int j = 0; j < Globals.DATA_BYTE_LEN; j++) data[j] = payload[block_off_val * Globals.DATA_BYTE_LEN + j];
                    return true;
                }
            }
            return false;
        }

    }
}
