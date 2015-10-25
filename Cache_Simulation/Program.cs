using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


public static class Globals
{
    public static int PC_INIT = 100;
    public static int pc_counter_val;

    public static int MEM_SIZE = 200;
    public static byte[] main_mem = new byte[MEM_SIZE]; // Main Memory

    public static byte[] cur_inst = new byte[8];

}

namespace Cache_Simulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Simulator());
            //Application.Run(new iTLB());
        }
    }
}
