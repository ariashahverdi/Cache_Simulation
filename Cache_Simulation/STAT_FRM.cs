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

using System.Threading;



namespace Cache_Simulation
{
    public partial class STAT_FRM : Form
    {
        public STAT_FRM()
        {
            InitializeComponent();
            //ModifyProgressBarColor.SetState(itlb_miss, 2);
        }

        public void refresh()
        {
            double itlb_hit_val, itlb_miss_val, itlb_acs_val;
            double dtlb_hit_val, dtlb_miss_val, dtlb_acs_val;
            double tlb_hit_val, tlb_miss_val, tlb_acs_val;
            double pt_hit_val, pt_miss_val, pt_acs_val;

            double il1cache_hit_val, il1cache_miss_val, il1cache_acs_val;
            double dl1cache_hit_val, dl1cache_miss_val, dl1cache_acs_val;
            double l2cache_hit_val, l2cache_miss_val, l2cache_acs_val;
            double l3cache_hit_val, l3cache_miss_val, l3cache_acs_val;


            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.itlb_hit + Globals.itlb_miss) != 0)
            {
                itlb_hit_val = (Globals.itlb_hit / (Globals.itlb_hit + Globals.itlb_miss) )* 100;
                itlb_miss_val = (Globals.itlb_miss / (Globals.itlb_hit + Globals.itlb_miss)) * 100;
                itlb_acs_val = Globals.itlb_hit + Globals.itlb_miss;
            }
            else
            {
                itlb_hit_val = (Globals.itlb_hit / 1) * 100;
                itlb_miss_val = (Globals.itlb_miss / 1) * 100;
                itlb_acs_val = 0;
            }
            itlb_hit.Value = (int)itlb_hit_val;
            itlb_miss.Value = (int)itlb_miss_val;
            itlb_hit_num.Text = itlb_hit_val.ToString("N" + 2);
            itlb_miss_num.Text = itlb_miss_val.ToString("N" + 2);
            itlb_acs_num.Text = itlb_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.dtlb_hit + Globals.dtlb_miss) != 0)
            {
                dtlb_hit_val = ((Globals.dtlb_hit / (Globals.dtlb_hit + Globals.dtlb_miss)) * 100);
                dtlb_miss_val = ((Globals.dtlb_miss / (Globals.dtlb_hit + Globals.dtlb_miss)) * 100);
                dtlb_acs_val = Globals.dtlb_hit + Globals.dtlb_miss;
            }
            else
            {
                dtlb_hit_val = ((Globals.dtlb_hit / 1) * 100);
                dtlb_miss_val = ((Globals.dtlb_miss / 1) * 100);
                dtlb_acs_val = 0;
            }
            dtlb_hit.Value = (int)dtlb_hit_val;
            dtlb_miss.Value = (int)dtlb_miss_val;
            dtlb_hit_num.Text = dtlb_hit_val.ToString("N" + 2);
            dtlb_miss_num.Text = dtlb_miss_val.ToString("N" + 2);
            dtlb_acs_num.Text = dtlb_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.tlb_hit + Globals.tlb_miss) != 0)
            {
                tlb_hit_val = ((Globals.tlb_hit / (Globals.tlb_hit + Globals.tlb_miss)) * 100);
                tlb_miss_val = ((Globals.tlb_miss / (Globals.tlb_hit + Globals.tlb_miss)) * 100);
                tlb_acs_val = Globals.tlb_hit + Globals.tlb_miss;
            }
            else
            {
                tlb_hit_val = ((Globals.tlb_hit / 1) * 100);
                tlb_miss_val = ((Globals.tlb_miss / 1) * 100);
                tlb_acs_val = 0;
            }
            tlb_hit.Value = (int)tlb_hit_val;
            tlb_miss.Value = (int)tlb_miss_val;
            tlb_hit_num.Text = tlb_hit_val.ToString("N" + 2);
            tlb_miss_num.Text = tlb_miss_val.ToString("N" + 2);
            tlb_acs_num.Text = tlb_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.pt_hit + Globals.pt_miss) != 0)
            {
                pt_hit_val = ((Globals.pt_hit / (Globals.pt_hit + Globals.pt_miss)) * 100);
                pt_miss_val = ((Globals.pt_miss / (Globals.pt_hit + Globals.pt_miss)) * 100);
                pt_acs_val = Globals.pt_hit + Globals.pt_miss;
            }
            else
            {
                pt_hit_val = ((Globals.pt_hit / 1) * 100);
                pt_miss_val = ((Globals.pt_miss / 1) * 100);
                pt_acs_val = 0;
            }
            pt_hit.Value = (int)pt_hit_val;
            pt_miss.Value = (int)pt_miss_val;
            pt_hit_num.Text = pt_hit_val.ToString("N" + 2);
            pt_miss_num.Text = pt_miss_val.ToString("N" + 2);
            pt_acs_num.Text = pt_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.il1cache_hit + Globals.il1cache_miss) != 0)
            {
                il1cache_hit_val = ((Globals.il1cache_hit / (Globals.il1cache_hit + Globals.il1cache_miss)) * 100);
                il1cache_miss_val = ((Globals.il1cache_miss / (Globals.il1cache_hit + Globals.il1cache_miss)) * 100);
                il1cache_acs_val = Globals.il1cache_hit + Globals.il1cache_miss;
            }
            else
            {
                il1cache_hit_val = ((Globals.il1cache_hit / 1) * 100);
                il1cache_miss_val = ((Globals.il1cache_miss / 1) * 100);
                il1cache_acs_val = 0;
            }
            il1cache_hit.Value = (int)il1cache_hit_val;
            il1cache_miss.Value = (int)il1cache_miss_val;
            il1cache_hit_num.Text = il1cache_hit_val.ToString("N" + 2);
            il1cache_miss_num.Text = il1cache_miss_val.ToString("N" + 2);
            il1cache_acs_num.Text = il1cache_acs_val.ToString();
 
            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.dl1cache_hit + Globals.dl1cache_miss) != 0)
            {
                dl1cache_hit_val = ((Globals.dl1cache_hit / (Globals.dl1cache_hit + Globals.dl1cache_miss)) * 100);
                dl1cache_miss_val = ((Globals.dl1cache_miss / (Globals.dl1cache_hit + Globals.dl1cache_miss)) * 100);
                dl1cache_acs_val = Globals.dl1cache_hit + Globals.dl1cache_miss;
            }
            else
            {
                dl1cache_hit_val = ((Globals.dl1cache_hit / 1) * 100);
                dl1cache_miss_val = ((Globals.dl1cache_miss / 1) * 100);
                dl1cache_acs_val = 0;
            }
            dl1cache_hit.Value = (int)dl1cache_hit_val;
            dl1cache_miss.Value = (int)dl1cache_miss_val;
            dl1cache_hit_num.Text = dl1cache_hit_val.ToString("N" + 2);
            dl1cache_miss_num.Text = dl1cache_miss_val.ToString("N" + 2);
            dl1cache_acs_num.Text = dl1cache_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.l2cache_hit + Globals.l2cache_miss) != 0)
            {
                l2cache_hit_val = ((Globals.l2cache_hit / (Globals.l2cache_hit + Globals.l2cache_miss)) * 100);
                l2cache_miss_val = ((Globals.l2cache_miss / (Globals.l2cache_hit + Globals.l2cache_miss)) * 100);
                l2cache_acs_val = Globals.l2cache_hit + Globals.l2cache_miss;
            }
            else
            {
                l2cache_hit_val = ((Globals.l2cache_hit / 1) * 100);
                l2cache_miss_val = ((Globals.l2cache_miss / 1) * 100);
                l2cache_acs_val = 0;
            }
            l2cache_hit.Value = (int)l2cache_hit_val;
            l2cache_miss.Value = (int)l2cache_miss_val;
            l2cache_hit_num.Text = l2cache_hit_val.ToString("N" + 2);
            l2cache_miss_num.Text = l2cache_miss_val.ToString("N" + 2);
            l2cache_acs_num.Text = l2cache_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            if ((Globals.l3cache_hit + Globals.l3cache_miss) != 0)
            {
                l3cache_hit_val = ((Globals.l3cache_hit / (Globals.l3cache_hit + Globals.l3cache_miss)) * 100);
                l3cache_miss_val = ((Globals.l3cache_miss / (Globals.l3cache_hit + Globals.l3cache_miss)) * 100);
                l3cache_acs_val = Globals.l3cache_hit + Globals.l3cache_miss;
            }
            else
            {
                l3cache_hit_val = ((Globals.l3cache_hit / 1) * 100);
                l3cache_miss_val = ((Globals.l3cache_miss / 1) * 100);
                l3cache_acs_val = 0;
            }
            l3cache_hit.Value = (int)l3cache_hit_val;
            l3cache_miss.Value = (int)l3cache_miss_val;
            l3cache_hit_num.Text = l3cache_hit_val.ToString("N" + 2);
            l3cache_miss_num.Text = l3cache_miss_val.ToString("N" + 2);
            l3cache_acs_num.Text = l3cache_acs_val.ToString();

            ////////////////////////////////////////////////////////////////////////////////////////////////

            mem_access.Value = Globals.mem_access;
            mem_acs_num.Text = Globals.mem_access.ToString();
            disk_access.Value = Globals.disk_access;
            disk_acs_num.Text = Globals.disk_access.ToString();

            Application.DoEvents();
        }

        private void STAT_FRM_Load(object sender, EventArgs e)
        {

        }
    }
}

