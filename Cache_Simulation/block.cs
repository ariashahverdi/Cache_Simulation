using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    public class block
    {
        int LRU;

        bool valid; // 1 : valid || 0 : invalid
        bool dirty; // 1 : dirty || 0 : clean

        bool [] tag;
        int TAG_SIZE;

        byte[] payload;
        int PAYLOAD_SIZE;

        public block(int T_S, int P_S)
        {
            LRU = 8; //LEAST RECENTLY USED

            TAG_SIZE = T_S;
            tag = new bool[TAG_SIZE];

            PAYLOAD_SIZE = P_S;
            payload = new byte[PAYLOAD_SIZE];

            //Initialize the cache randomly
            valid = Convert.ToBoolean(Simulator.rand.Next(2));
            dirty = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < TAG_SIZE; i++) tag[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < PAYLOAD_SIZE; i++) payload[i] = (byte)Simulator.rand.Next(256);


            return;

        }

        public bool get_block(bool[] tag_in, bool [] tag_out, byte [] payload_out, bool dirty_out)
        {
            bool hit = true;
            for (int i=0; i<TAG_SIZE; i++)
            {
                if (tag_in[i] != tag[i]) hit = false;
            }           
            if (hit & valid)
            {
                LRU = 0; //update the LRU policy
                dirty_out = dirty;
                if (dirty)
                {
                    for (int i = 0; i < TAG_SIZE; i++) tag_out[i] = tag[i];
                }
                for (int i = 0; i < PAYLOAD_SIZE; i++) payload_out[i] = payload[i];
                return true;
            }
            else if(!hit & valid) if (LRU != 8) LRU++;
            return false;
        }

        public bool set_block(bool[] tag_in, byte[] payload_in, bool dirty_in)
        {
            valid = true;
            dirty = dirty_in; // if it's a write command the dirty should be set to true
            LRU = 0;
            for (int i = 0; i < TAG_SIZE; i++) tag[i] = tag_in[i];
            for (int i = 0; i < PAYLOAD_SIZE; i++) payload[i] = payload_in[i];
            return true;
        }

        public bool check_valid()
        {
            return valid;
        }

        public int get_LRU()
        {
            return LRU;
        }

        /*For printing purposes ...*/
        public int give_me_int(bool[] tag)
        {
            int tag_val = 0;
            for (int i = 0; i < TAG_SIZE; i++) tag_val = 2 * tag_val + Convert.ToInt32(tag[i]);
            return tag_val;
        }

        public string get_tag()
        {
            return give_me_int(tag).ToString("X");
        }

        public string get_payload()
        {
            return BitConverter.ToString(payload).Replace("-", "");
        }



    }

}
