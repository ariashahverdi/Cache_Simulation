using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Cache_Simulation
{
    class animation
    {
        int cpu_x, cpu_y;
        int[] loc;


        public animation(Simulator mysim)
        {
            loc = new int[24];
            mysim.set_location(loc);
            int cpu_x = loc[0];
            int cpu_y = loc[1];
        }

        public int get_idx(string indata)
        {
            switch (indata)
            {
                case "itlb":        return 1;
                case "dtlb":        return 2;
                case "tlb":         return 3;
                case "pt":          return 4;
                case "il1cache":    return 5;
                case "dl1cache":     return 6;
                case "l2cache":     return 7;
                case "l3cache":     return 8;
                case "mem":         return 9;
                case "disk":        return 10;

                default: return 0;
            }
        }

        public void DrawLine(Simulator mysim, string block, int size, bool[] addr, bool hit_miss/*, bool [] addr*/)
        {
            int idx = get_idx(block);
            if (idx >= 5 && idx <= 9)
            {
                cpu_x = loc[22];
                cpu_y = loc[23];
            }
            else
            {
                cpu_x = loc[0];
                cpu_y = loc[1];
            }
            int dest_x = loc[2 * idx];
            int dest_y = loc[2 * idx + 1];

            int tempx;
            if (idx == 9) tempx = 80;
            else if (idx == 10) tempx = -90;
            else tempx = 0;

            System.Drawing.Pen myPen1;
            System.Drawing.Pen myPen2;
            System.Drawing.Pen myPen3;
            myPen1 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen2 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen3 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            System.Drawing.Graphics formGraphics = mysim.CreateGraphics();

            myPen1.EndCap = LineCap.RoundAnchor;
            formGraphics.DrawLine(myPen1, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y, cpu_x, cpu_y);
            myPen1.Dispose();

            formGraphics.DrawLine(myPen2, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y);
            myPen2.Dispose();

            myPen3.StartCap = LineCap.ArrowAnchor;
            formGraphics.DrawLine(myPen3, dest_x, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y);
            myPen3.Dispose();

            mysim.addr_show(addr, size);
            mysim.hit_miss_show(hit_miss);

            Thread.Sleep(mysim.get_speed());

            formGraphics.Clear(mysim.BackColor);

            mysim.addr_hide();
            mysim.hit_miss_hide();
        }

    }
}
