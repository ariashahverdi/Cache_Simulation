using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Simulation
{
    class block
    {
        bool valid;
        bool dirty;

        bool[] tag;
        int TAG_SIZE;

        byte[] payload;
        int PAYLOAD_SIZE;

        public void block_init(int T_S, int P_S)
        {
            TAG_SIZE = T_S;
            tag = new bool[TAG_SIZE];

            PAYLOAD_SIZE = P_S;
            payload = new byte[PAYLOAD_SIZE];

        }
    }
}
