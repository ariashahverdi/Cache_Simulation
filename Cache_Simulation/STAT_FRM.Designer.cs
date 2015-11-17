namespace Cache_Simulation
{
    partial class STAT_FRM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.il1cache_label = new System.Windows.Forms.Label();
            this.tlb_label = new System.Windows.Forms.Label();
            this.dtlb_label = new System.Windows.Forms.Label();
            this.itlb_label = new System.Windows.Forms.Label();
            this.l3cache_label = new System.Windows.Forms.Label();
            this.l2cache_label = new System.Windows.Forms.Label();
            this.il2cache_cache = new System.Windows.Forms.Label();
            this.pt_label = new System.Windows.Forms.Label();
            this.mem_label = new System.Windows.Forms.Label();
            this.disk_label = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // il1cache_label
            // 
            this.il1cache_label.AutoSize = true;
            this.il1cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.il1cache_label.Location = new System.Drawing.Point(85, 479);
            this.il1cache_label.Name = "il1cache_label";
            this.il1cache_label.Size = new System.Drawing.Size(151, 20);
            this.il1cache_label.TabIndex = 8;
            this.il1cache_label.Text = "Instruction Cache";
            // 
            // tlb_label
            // 
            this.tlb_label.AutoSize = true;
            this.tlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlb_label.Location = new System.Drawing.Point(571, 248);
            this.tlb_label.Name = "tlb_label";
            this.tlb_label.Size = new System.Drawing.Size(41, 20);
            this.tlb_label.TabIndex = 9;
            this.tlb_label.Text = "TLB";
            // 
            // dtlb_label
            // 
            this.dtlb_label.AutoSize = true;
            this.dtlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtlb_label.Location = new System.Drawing.Point(361, 248);
            this.dtlb_label.Name = "dtlb_label";
            this.dtlb_label.Size = new System.Drawing.Size(85, 20);
            this.dtlb_label.TabIndex = 10;
            this.dtlb_label.Text = "Data TLB";
            // 
            // itlb_label
            // 
            this.itlb_label.AutoSize = true;
            this.itlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itlb_label.Location = new System.Drawing.Point(104, 248);
            this.itlb_label.Name = "itlb_label";
            this.itlb_label.Size = new System.Drawing.Size(132, 20);
            this.itlb_label.TabIndex = 11;
            this.itlb_label.Text = "Instruction TLB";
            // 
            // l3cache_label
            // 
            this.l3cache_label.AutoSize = true;
            this.l3cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3cache_label.Location = new System.Drawing.Point(723, 479);
            this.l3cache_label.Name = "l3cache_label";
            this.l3cache_label.Size = new System.Drawing.Size(122, 20);
            this.l3cache_label.TabIndex = 12;
            this.l3cache_label.Text = "Level 3 Cache";
            // 
            // l2cache_label
            // 
            this.l2cache_label.AutoSize = true;
            this.l2cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2cache_label.Location = new System.Drawing.Point(514, 479);
            this.l2cache_label.Name = "l2cache_label";
            this.l2cache_label.Size = new System.Drawing.Size(122, 20);
            this.l2cache_label.TabIndex = 13;
            this.l2cache_label.Text = "Level 2 Cache";
            // 
            // il2cache_cache
            // 
            this.il2cache_cache.AutoSize = true;
            this.il2cache_cache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.il2cache_cache.Location = new System.Drawing.Point(323, 479);
            this.il2cache_cache.Name = "il2cache_cache";
            this.il2cache_cache.Size = new System.Drawing.Size(104, 20);
            this.il2cache_cache.TabIndex = 14;
            this.il2cache_cache.Text = "Data Cache";
            // 
            // pt_label
            // 
            this.pt_label.AutoSize = true;
            this.pt_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pt_label.Location = new System.Drawing.Point(737, 248);
            this.pt_label.Name = "pt_label";
            this.pt_label.Size = new System.Drawing.Size(99, 20);
            this.pt_label.TabIndex = 15;
            this.pt_label.Text = "Page Table";
            // 
            // mem_label
            // 
            this.mem_label.AutoSize = true;
            this.mem_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mem_label.Location = new System.Drawing.Point(215, 714);
            this.mem_label.Name = "mem_label";
            this.mem_label.Size = new System.Drawing.Size(134, 20);
            this.mem_label.TabIndex = 17;
            this.mem_label.Text = "Memory Access";
            // 
            // disk_label
            // 
            this.disk_label.AutoSize = true;
            this.disk_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disk_label.Location = new System.Drawing.Point(555, 714);
            this.disk_label.Name = "disk_label";
            this.disk_label.Size = new System.Drawing.Size(107, 20);
            this.disk_label.TabIndex = 16;
            this.disk_label.Text = "Disk Access";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(117, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 25);
            this.progressBar1.TabIndex = 18;
            // 
            // STAT_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 793);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mem_label);
            this.Controls.Add(this.disk_label);
            this.Controls.Add(this.pt_label);
            this.Controls.Add(this.il2cache_cache);
            this.Controls.Add(this.l2cache_label);
            this.Controls.Add(this.l3cache_label);
            this.Controls.Add(this.itlb_label);
            this.Controls.Add(this.dtlb_label);
            this.Controls.Add(this.tlb_label);
            this.Controls.Add(this.il1cache_label);
            this.Name = "STAT_FRM";
            this.Text = "STAT_FRM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label il1cache_label;
        private System.Windows.Forms.Label tlb_label;
        private System.Windows.Forms.Label dtlb_label;
        private System.Windows.Forms.Label itlb_label;
        private System.Windows.Forms.Label l3cache_label;
        private System.Windows.Forms.Label l2cache_label;
        private System.Windows.Forms.Label il2cache_cache;
        private System.Windows.Forms.Label pt_label;
        private System.Windows.Forms.Label mem_label;
        private System.Windows.Forms.Label disk_label;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}