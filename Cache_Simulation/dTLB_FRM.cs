using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cache_Simulation
{
    public partial class dTLB_FRM : Form
    {
        public dTLB_FRM()
        {
            InitializeComponent();
            dtlb_show.AllowUserToAddRows = false; //Disable The last Row
            for (int i = 0; i < Simulator.my_dtlb.get_pte_num(); i++)
            {
                string[] data = new string[5] { num.ToString(), bank1.ToString(), bank2.ToString(), bank3.ToString(), bank4.ToString() };
                data = new string[] { i.ToString(), Simulator.my_dtlb.get_pte(i, 0).get_tag_payload(), Simulator.my_dtlb.get_pte(i, 1).get_tag_payload(), Simulator.my_dtlb.get_pte(i, 2).get_tag_payload(), Simulator.my_dtlb.get_pte(i, 3).get_tag_payload() };
                dtlb_show.Rows.Add(data);
                dtlb_show.FirstDisplayedScrollingRowIndex = dtlb_show.RowCount - 1;

            }
            for (int i = 0; i < dtlb_show.RowCount; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (Simulator.my_dtlb.get_pte(i, j - 1).get_valid() == false) dtlb_show.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else if (Simulator.my_dtlb.get_pte(i, j - 1).get_valid() == true) dtlb_show.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void dtlb_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtlb_show.CurrentCell != null && dtlb_show.CurrentCell.Value != null && dtlb_show.CurrentCell.ColumnIndex != 0)
            {
                tlb_pte form_tlb_pte = new tlb_pte(Simulator.my_dtlb, dtlb_show.CurrentCell.RowIndex, dtlb_show.CurrentCell.ColumnIndex - 1);
                form_tlb_pte.ShowDialog();
            }
        }
    }
    
}
