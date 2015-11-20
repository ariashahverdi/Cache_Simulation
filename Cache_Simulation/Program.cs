using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class Globals
{
    public static ulong PC_INIT = 104;

    public static int MEM_SIZE = 65536;
    public static int HD_SIZE = 65536;

    public static byte[] cur_inst = new byte[8];

    public const int VIRTUAL_ADD_LEN = 48; // 48 bits
    public const int PAGE_OFF_LEN = 12;
    public const int PHYSICAL_ADD_LEN = 36; // 36 bits
    public const int BYTE_OFF_LEN = 6; // 6 bits
    public const int DATA_BYTE_LEN = 8; // 8 bytes

    public const int L1_HIT = 4; 
    public const int L2_HIT = 8;
    public const int L3_HIT = 16;

    public const int MEM_ACCESS = 100;
    public const int DISK_ACCESS = 100000;

    public static int EXEC_TIME = 0;


    public static double il1cache_hit = 0, il1cache_miss =0;
    public static double dl1cache_hit =0, dl1cache_miss =0;
    public static double l2cache_hit =0 , l2cache_miss =0;
    public static double l3cache_hit =0, l3cache_miss =0;

    public static double itlb_hit , itlb_miss;
    public static double dtlb_hit, dtlb_miss;
    public static double tlb_hit, tlb_miss;
    public static double pt_hit, pt_miss;

    public static int mem_access = 0;
    public static int disk_access = 0;
}

namespace Cache_Simulation
{
    static class Program
    {
        public static Simulator my_sim;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            my_sim = new Simulator();
            Application.Run(my_sim);
        }
    }
}
