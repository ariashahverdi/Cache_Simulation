using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public static class ModifyProgressBarColor
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
    public static void SetState(this ProgressBar pBar, int state)
    {
        SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    }
}

namespace Cache_Simulation
{
    public partial class STAT_FRM : Form
    {
        public STAT_FRM()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            itlb_hit.Value = (int)((Globals.itlb_hit / Globals.itlb_access)*100);
            itlb_miss.Value = (int)((Globals.itlb_miss / Globals.itlb_access) * 100);
            ModifyProgressBarColor.SetState(itlb_miss, 2);


            dtlb_hit.Value = (int)((Globals.dtlb_hit / Globals.dtlb_access) * 100);
            dtlb_miss.Value = (int)((Globals.dtlb_miss / Globals.dtlb_access) * 100);
            ModifyProgressBarColor.SetState(dtlb_miss, 2);

            tlb_hit.Value = (int)((Globals.tlb_hit / Globals.tlb_access) * 100);
            tlb_miss.Value = (int)((Globals.tlb_miss / Globals.tlb_access) * 100);
            ModifyProgressBarColor.SetState(tlb_miss, 2);

            pt_hit.Value = (int)((Globals.pt_hit / Globals.pt_access) * 100);
            pt_miss.Value = (int)((Globals.pt_miss / Globals.pt_access) * 100);
            ModifyProgressBarColor.SetState(pt_miss, 2);

            il1cache_hit.Value = (int)((Globals.il1cache_hit / Globals.il1cache_access) * 100);
            il1cache_miss.Value = (int)((Globals.il1cache_miss / Globals.il1cache_access) * 100);
            ModifyProgressBarColor.SetState(il1cache_miss, 2);

            dl1cache_hit.Value = (int)((Globals.dl1cache_hit / Globals.dl1cache_access) * 100);
            dl1cache_miss.Value = (int)((Globals.dl1cache_miss / Globals.dl1cache_access) * 100);
            ModifyProgressBarColor.SetState(dl1cache_miss, 2);

            l2cache_hit.Value = (int)((Globals.l2cache_hit / Globals.l2cache_access) * 100);
            l2cache_miss.Value = (int)((Globals.l2cache_miss / Globals.l2cache_access) * 100);
            ModifyProgressBarColor.SetState(l2cache_miss, 2);

            l3cache_hit.Value = (int)((Globals.l3cache_hit / Globals.l3cache_access) * 100);
            l3cache_miss.Value = (int)((Globals.l3cache_miss / Globals.l3cache_access) * 100);
            ModifyProgressBarColor.SetState(l3cache_miss, 2);

            mem_access.Value = Globals.mem_access;
            disk_access.Value = Globals.disk_access;
        }

    }
}
