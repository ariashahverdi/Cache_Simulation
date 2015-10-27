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
        bool valid;
        bool dirty;

        bool [] tag;
        int TAG_SIZE;

        byte[] payload;
        int PAYLOAD_SIZE;

        public block(int T_S, int P_S)
        {
            TAG_SIZE = T_S;
            tag = new bool[TAG_SIZE];
            //tag = new bool[TAG_SIZE];

            PAYLOAD_SIZE = P_S;
            payload = new byte[PAYLOAD_SIZE];

            //Initialize the cache randomly
            valid = Convert.ToBoolean(Simulator.rand.Next(2));
            dirty = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < TAG_SIZE; i++) tag[i] = Convert.ToBoolean(Simulator.rand.Next(2));
            for (int i = 0; i < PAYLOAD_SIZE; i++) payload[i] = (byte)Simulator.rand.Next(256);


            return;

        }

        public int tag_val_calc(bool []tag)
        {
            int tag_val = 0;
            for (int i = 0; i < TAG_SIZE; i++) tag_val = 2 * tag_val + Convert.ToInt32(tag[i]);
            return tag_val;
        }

        public string get_tag()
        {
            return tag_val_calc(tag).ToString("X");
        }

        public string get_payload()
        {
            return BitConverter.ToString(payload).Replace("-", "");
        }


    }

}
