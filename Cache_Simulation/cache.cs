using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class cache
    {
        int TAG_SIZE;
        int INDEX_SIZE;
        int PAYLOAD_SIZE;

        int BANK_NUM;
        int BLOCK_NUM;

        public static block[,] bankS;
        
        public cache(int BA_N, int BL_N, int T_S, int P_S)
        {
            TAG_SIZE = T_S;
            PAYLOAD_SIZE = P_S;

            INDEX_SIZE = Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN;

            BANK_NUM = BA_N;
            BLOCK_NUM = BL_N;


            bankS = new block[ BLOCK_NUM , BANK_NUM];
            for (int i = 0; i < BLOCK_NUM; i++)
                for (int j = 0; j < BANK_NUM; j++)
                    bankS[i, j] = new block(TAG_SIZE, PAYLOAD_SIZE);
        }

        public block get_block(int block_num, int bank_num)
        {
            return bankS[block_num, bank_num];
        }

        public int get_block_num()
        {
            return BLOCK_NUM;
        }

        public int give_me_int(bool[] in_val, int size_val)
        {
            int ret_val = 0;
            for (int i = 0; i < size_val; i++) ret_val = 2 * ret_val + Convert.ToInt32(in_val[i]);
            return ret_val;
        }

        public bool read_from_cache(bool[] address, byte[] data)
        { 
            bool[] read_tag = new bool[TAG_SIZE];
            bool[] read_idx = new bool[Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN];
            bool[] block_offset = new bool[Globals.BYTE_OFF_LEN-3];
            byte[] payload = new byte[PAYLOAD_SIZE];

            for (int i = 0; i < TAG_SIZE; i++) read_tag[i] = address[i];
            for (int i = 0; i < INDEX_SIZE; i++) read_idx[i] = address[TAG_SIZE + i];
            for (int i = 0; i < (Globals.BYTE_OFF_LEN-3); i++) block_offset[i] = address[TAG_SIZE + INDEX_SIZE + i];

            int read_idx_val = give_me_int(read_idx, INDEX_SIZE);
            int block_off_val = give_me_int(block_offset, 3); //<<<<<<<<<<<<<<
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS[read_idx_val,i].get_block(read_tag, payload))
                    {
                    for (int j=0; j < Globals.DATA_BYTE_LEN; j++) data[j] = payload[block_off_val * Globals.DATA_BYTE_LEN + j];
                    return true;
                }
            }
            return false;
        }

        public bool write_to_cache(bool[] address, byte [] data, bool dirty)
        {
            bool[] write_tag = new bool[TAG_SIZE];
            bool[] write_idx = new bool[Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN];

            for (int i = 0; i < TAG_SIZE; i++) write_tag[i] = address[i];
            for (int i = 0; i < INDEX_SIZE; i++) write_idx[i] = address[TAG_SIZE + i];

            int write_idx_val = give_me_int(write_idx, INDEX_SIZE);

            int valid_cnt = 0;
            int[] valid_arr = new int[BANK_NUM];
            int write_bank_idx;
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (!bankS[write_idx_val, i].check_valid())
                {
                    valid_arr[valid_cnt] = i;
                    valid_cnt++;
                }
            }
            if (valid_cnt > 0)
            {
                write_bank_idx = valid_arr[Simulator.rand.Next(valid_cnt)]; //select a random bank to write to
                bankS[write_idx_val, write_bank_idx].set_block(write_tag, data, dirty);
                return true;
            }
            // Nothing is valid search for LRU
            else
            {
                int max_LRU = 0;
                int max_LRU_cnt = 0;
                int[] max_LRU_arr = new int[BANK_NUM];
                int cur_LRU;
                for (int i = 0; i < BANK_NUM; i++)
                {
                    cur_LRU = bankS[write_idx_val, i].get_LRU();
                    if (cur_LRU > max_LRU)
                    {
                        max_LRU = cur_LRU;
                        max_LRU_arr[max_LRU_cnt] = i;
                        max_LRU_cnt++;
                    }
                }
                write_bank_idx = max_LRU_arr[Simulator.rand.Next(max_LRU_cnt)]; //select a random bank to write to
                bankS[write_idx_val, write_bank_idx].set_block(write_tag, data, dirty);

                return true;
            }
        }
    }
}
