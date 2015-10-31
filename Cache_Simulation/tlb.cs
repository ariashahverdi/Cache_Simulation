using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class tlb
    {
        int VIRTUAL_SIZE;
        int PHYSICAL_SIZE;
        int INDEX_SIZE;

        int BANK_NUM;
        int PTE_NUM;

        public static pte[,] bankS_pte;

        public tlb(int BA_N, int PT_N, int V_T_S, int P_T_S)
        {
            VIRTUAL_SIZE = V_T_S;
            PHYSICAL_SIZE = P_T_S;

            INDEX_SIZE = Globals.VIRTUAL_ADD_LEN - VIRTUAL_SIZE - Globals.PAGE_OFF_LEN;

            BANK_NUM = BA_N;
            PTE_NUM = PT_N;


            bankS_pte = new pte[PTE_NUM, BANK_NUM];
            for (int i = 0; i < PTE_NUM; i++)
                for (int j = 0; j < BANK_NUM; j++)
                    bankS_pte[i, j] = new pte(VIRTUAL_SIZE, PHYSICAL_SIZE);
        }

        public pte get_pte(int block_num, int bank_num)
        {
            return bankS_pte[block_num, bank_num];
        }

        public int get_pte_num()
        {
            return PTE_NUM;
        }

        public bool read_from_tlb(bool[] v_addr, bool[] p_addr, bool[] prot)
        {
            bool[] prot_temp = new bool[4];
            bool[] page_addr_tag = new bool[VIRTUAL_SIZE];
            bool[] read_idx = new bool[INDEX_SIZE];
            bool[] page_offset = new bool[Globals.PAGE_OFF_LEN];
            bool[] phy_addr_tag = new bool[PHYSICAL_SIZE];

            for (int i = 0; i < VIRTUAL_SIZE; i++) page_addr_tag[i] = v_addr[INDEX_SIZE+i];
            for (int i = 0; i < INDEX_SIZE; i++) read_idx[i] = v_addr[i];
            for (int i = 0; i < (Globals.PAGE_OFF_LEN); i++) page_offset[i] = v_addr[INDEX_SIZE + VIRTUAL_SIZE + i];

            int read_idx_val = give_me_int(read_idx, INDEX_SIZE);
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS_pte[read_idx_val, i].get_pte(page_addr_tag, phy_addr_tag, prot_temp))
                {
                    for (int j = 0; j < 4; j++) prot[j] = prot_temp[j];
                    for (int j = 0; j < PHYSICAL_SIZE; j++) p_addr[j] = phy_addr_tag[j];
                    for (int j = 0; j < Globals.PAGE_OFF_LEN; j++) p_addr[j] = page_offset[j];

                    return true;
                }
            }
            return false;
        }

        public bool write_to_tlb(bool[] v_addr, bool[] p_addr, bool[] prot)
        {
            bool[] prot_temp = new bool[4];
            bool[] page_addr_tag = new bool[VIRTUAL_SIZE];
            bool[] read_idx = new bool[INDEX_SIZE];
            bool[] page_offset = new bool[Globals.PAGE_OFF_LEN];
            bool[] phy_addr_tag = new bool[PHYSICAL_SIZE];

            for (int i = 0; i < VIRTUAL_SIZE; i++) page_addr_tag[i] = v_addr[INDEX_SIZE + i];
            for (int i = 0; i < PHYSICAL_SIZE; i++) phy_addr_tag[i] = p_addr[i];
            for (int i = 0; i < INDEX_SIZE; i++) read_idx[i] = v_addr[i];
            for (int i = 0; i < (Globals.PAGE_OFF_LEN); i++) page_offset[i] = v_addr[INDEX_SIZE + VIRTUAL_SIZE + i];


            // Hit TLB
            int write_idx_val = give_me_int(read_idx, INDEX_SIZE);
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS_pte[write_idx_val, i].get_pte(page_addr_tag, phy_addr_tag, prot_temp))
                {
                    bankS_pte[write_idx_val, i].set_pte(page_addr_tag, phy_addr_tag, prot);

                    return true;
                }
            }

            //it was not in TLB
            int valid_cnt = 0;
            int[] valid_arr = new int[BANK_NUM];
            int write_bank_idx;
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (!bankS_pte[write_idx_val, i].get_valid())
                {
                    valid_arr[valid_cnt] = i;
                    valid_cnt++;
                }
            }
            if (valid_cnt > 0)
            {
                write_bank_idx = valid_arr[Simulator.rand.Next(valid_cnt)]; //select a random bank to write to
                bankS_pte[write_idx_val, write_bank_idx].set_pte(page_addr_tag, phy_addr_tag, prot);
                return true;
            }
            //TLB's row is full, pick random bank
            write_bank_idx = valid_arr[Simulator.rand.Next(BANK_NUM)]; //select a random bank to write to
            bankS_pte[write_idx_val, write_bank_idx].set_pte(page_addr_tag, phy_addr_tag, prot);
            return true;
        }

        public int give_me_int(bool[] in_val, int size_val)
        {
            int ret_val = 0;
            for (int i = 0; i < size_val; i++) ret_val = 2 * ret_val + Convert.ToInt32(in_val[i]);
            return ret_val;
        }

    }
}
