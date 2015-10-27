﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class cache
    {
        int TAG_SIZE;
        int PAYLOAD_SIZE;

        int BANK_NUM;
        int BLOCK_NUM;

        public static block[,] bankS;
        
        public cache(int BA_N, int BL_N, int T_S, int P_S)
        {
            TAG_SIZE = T_S;
            PAYLOAD_SIZE = P_S;

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

        public void access()
        { }
    }
}