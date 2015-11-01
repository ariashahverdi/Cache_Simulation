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

        public /*static*/ block[,] bankS;
        
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

        public int give_off_bit(bool[]offset, int num)
        {
            int offset_bit = 0;

            bool[] byte_off = new bool[3];
            bool[] block_off = new bool[3];
            for (int i = 0; i < 3; i++) byte_off[i] = offset[3 + i];
            for (int i = 0; i < 3; i++) block_off[i] = offset[i];
            int byte_off_val = give_me_int(byte_off, 3);
            int block_off_val = give_me_int(block_off, 3);

            switch (num)
            {
                case 1:
                    offset_bit = block_off_val * Globals.DATA_BYTE_LEN + byte_off_val;
                    break;
                case 8:
                    offset_bit = block_off_val * Globals.DATA_BYTE_LEN;
                    break;
                case 64:
                    offset_bit = 0;
                    break;
                default:
                    offset_bit = 0;
                    break;
            }
            return offset_bit;
        }

        public bool read_from_cache(bool[] address, int num, byte[] data)
        {
            bool[] read_tag = new bool[TAG_SIZE];
            bool[] read_idx = new bool[Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN];
            bool[] offset = new bool[Globals.BYTE_OFF_LEN];
            byte[] payload = new byte[PAYLOAD_SIZE];

            for (int i = 0; i < TAG_SIZE; i++) read_tag[i] = address[i];
            for (int i = 0; i < INDEX_SIZE; i++) read_idx[i] = address[TAG_SIZE + i];
            for (int i = 0; i < Globals.BYTE_OFF_LEN ; i++) offset[i] = address[TAG_SIZE + INDEX_SIZE + i];
            int off_bit = give_off_bit(offset, num);

            bool[] read_tag_out = new bool[TAG_SIZE]; 
            bool dirty_check = false; //no use

            int read_idx_val = give_me_int(read_idx, INDEX_SIZE);
            
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS[read_idx_val,i].get_block(read_tag, read_tag_out, payload, ref dirty_check))
                    {
                    for (int j=0; j < num; j++) data[j] = payload[off_bit + j];
                    return true;
                }
            }
            return false;
        }

        public bool write_to_cache(bool[] address_in, int num, byte [] data_in, bool dirty_in, bool[] address_out, byte [] data_out, ref bool dirty_out)
        {
            bool[] write_tag = new bool[TAG_SIZE];
            bool[] write_idx = new bool[Globals.PHYSICAL_ADD_LEN - TAG_SIZE - Globals.BYTE_OFF_LEN];
            bool[] offset = new bool[Globals.BYTE_OFF_LEN];

            for (int i = 0; i < TAG_SIZE; i++) write_tag[i] = address_in[i];
            for (int i = 0; i < INDEX_SIZE; i++) write_idx[i] = address_in[TAG_SIZE + i];
            for (int i = 0; i < Globals.BYTE_OFF_LEN; i++) offset[i] = address_in[TAG_SIZE + INDEX_SIZE + i];
            int off_bit = give_off_bit(offset, num);

            int write_idx_val = give_me_int(write_idx, INDEX_SIZE);

            byte [] payload_temp = new byte[PAYLOAD_SIZE];
            //*
            //Hit on write
            bool dirty_check =false;
            bool[] tag_out = new bool[TAG_SIZE];
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (bankS[write_idx_val, i].get_block(write_tag, tag_out, data_out, ref dirty_check)) //hit
                {
                    //bool[] addr_out_temp = new bool[Globals.PHYSICAL_ADD_LEN];
                    for (int j = 0; j < Globals.PHYSICAL_ADD_LEN; j++) address_out[j] = false;
                    for (int j = 0; j < TAG_SIZE; j++) address_out[j] = tag_out[j];
                    for (int j = 0; j < INDEX_SIZE; j++) address_out[TAG_SIZE+j] = write_idx[j];
                    for (int j = 0; j < PAYLOAD_SIZE; j++) payload_temp[j] = data_out[j];
                    for (int j = 0; j < num; j++) payload_temp[off_bit + j] = data_in[j];
                    if (dirty_check) dirty_out = true; //dirty so it should be gone
                    bankS[write_idx_val, i].set_block(write_tag, payload_temp, dirty_in);
                    return true;
                }
            }

            // Cache Miss then the whole block is expected to be received
            if (num != 64) return false;

            int valid_cnt = 0;
            int[] valid_arr = new int[BANK_NUM];
            int write_bank_idx;
            for (int i = 0; i < BANK_NUM; i++)
            {
                if (!bankS[write_idx_val, i].get_valid() && !bankS[write_idx_val, i].get_dirty())
                {
                    valid_arr[valid_cnt] = i;
                    valid_cnt++;
                }
            }
            if (valid_cnt > 0)
            {
                write_bank_idx = valid_arr[Simulator.rand.Next(valid_cnt)]; //select a random bank to write to
                bankS[write_idx_val, write_bank_idx].set_block(write_tag, data_in, dirty_in);
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
                    if (!bankS[write_idx_val, i].get_valid())
                    {
                        cur_LRU = bankS[write_idx_val, i].get_LRU();
                        if (cur_LRU > max_LRU)
                        {
                            max_LRU = cur_LRU;
                            max_LRU_arr[max_LRU_cnt] = i;
                            max_LRU_cnt++;
                        }
                    }
                }
                write_bank_idx = max_LRU_arr[Simulator.rand.Next(max_LRU_cnt)]; //select a random bank to write to
                bankS[write_idx_val, write_bank_idx].set_block(write_tag, data_in, dirty_in);

                return true;
            }
        }
    }
}
