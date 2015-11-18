using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class Globals
{
    public static ulong PC_INIT = 104;

    public static int MEM_SIZE = 65536;

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


    public static double il1cache_hit, il1cache_miss, il1cache_access = 1;
    public static double dl1cache_hit, dl1cache_miss, dl1cache_access = 1;
    public static double l2cache_hit, l2cache_miss, l2cache_access = 1;
    public static double l3cache_hit, l3cache_miss, l3cache_access = 1;

    public static double itlb_hit , itlb_miss, itlb_access = 1;
    public static double dtlb_hit, dtlb_miss, dtlb_access = 1;
    public static double tlb_hit, tlb_miss, tlb_access = 1;
    public static double pt_hit, pt_miss, pt_access = 1;

    public static int mem_access = 1;
    public static int disk_access = 1;
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
