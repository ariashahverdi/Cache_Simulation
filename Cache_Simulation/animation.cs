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
        int[] loc;
        int cpu_x, cpu_y;

        public animation(Simulator x)
        {
            loc = new int[24];
            x.set_location(loc);
            cpu_x = loc[0];
            cpu_y = loc[1];
        }



        public void DrawLine(Simulator x, int idx)
        {
            if (idx>=5 && idx<=9)
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
            if (idx == 9) tempx = 100;
            else if (idx == 10) tempx = -90;
            else tempx = 0;

            
            System.Drawing.Pen myPen1;
            System.Drawing.Pen myPen2;
            System.Drawing.Pen myPen3;
            myPen1 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen2 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            myPen3 = new System.Drawing.Pen(Color.FromArgb(255, 0, 0, 255), 6);
            System.Drawing.Graphics formGraphics1 = x.CreateGraphics();
            System.Drawing.Graphics formGraphics2 = x.CreateGraphics();
            System.Drawing.Graphics formGraphics3 = x.CreateGraphics();

            myPen1.EndCap = LineCap.RoundAnchor;
            formGraphics1.DrawLine(myPen1, tempx + cpu_x-(cpu_x-dest_x)/2, cpu_y, cpu_x, cpu_y);
            myPen1.Dispose();

            formGraphics2.DrawLine(myPen2, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, cpu_y);
            myPen2.Dispose();

            myPen3.StartCap = LineCap.ArrowAnchor;
            formGraphics3.DrawLine(myPen3, dest_x, dest_y, tempx + cpu_x - (cpu_x - dest_x) / 2, dest_y);
            myPen3.Dispose();

            Thread.Sleep(1000); //10 seconds

            formGraphics1.Clear(x.BackColor);
            formGraphics2.Clear(x.BackColor);
            formGraphics3.Clear(x.BackColor);
        }

    }
}
