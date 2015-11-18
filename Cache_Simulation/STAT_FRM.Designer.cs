﻿namespace Cache_Simulation
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
            this.itlb_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.itlb_miss = new System.Windows.Forms.ProgressBar();
            this.dtlb_miss = new System.Windows.Forms.ProgressBar();
            this.dtlb_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tlb_miss = new System.Windows.Forms.ProgressBar();
            this.tlb_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pt_miss = new System.Windows.Forms.ProgressBar();
            this.pt_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.il1cache_miss = new System.Windows.Forms.ProgressBar();
            this.il1cache_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dl1cache_miss = new System.Windows.Forms.ProgressBar();
            this.dl1cache_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.l2cache_miss = new System.Windows.Forms.ProgressBar();
            this.l2cache_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.l3cache_miss = new System.Windows.Forms.ProgressBar();
            this.l3cache_hit = new System.Windows.Forms.ProgressBar();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.mem_access = new System.Windows.Forms.ProgressBar();
            this.disk_access = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // il1cache_label
            // 
            this.il1cache_label.AutoSize = true;
            this.il1cache_label.BackColor = System.Drawing.Color.Peru;
            this.il1cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.il1cache_label.Location = new System.Drawing.Point(94, 522);
            this.il1cache_label.Name = "il1cache_label";
            this.il1cache_label.Size = new System.Drawing.Size(151, 20);
            this.il1cache_label.TabIndex = 8;
            this.il1cache_label.Text = "Instruction Cache";
            // 
            // tlb_label
            // 
            this.tlb_label.AutoSize = true;
            this.tlb_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlb_label.Location = new System.Drawing.Point(569, 248);
            this.tlb_label.Name = "tlb_label";
            this.tlb_label.Size = new System.Drawing.Size(41, 20);
            this.tlb_label.TabIndex = 9;
            this.tlb_label.Text = "TLB";
            // 
            // dtlb_label
            // 
            this.dtlb_label.AutoSize = true;
            this.dtlb_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtlb_label.Location = new System.Drawing.Point(335, 248);
            this.dtlb_label.Name = "dtlb_label";
            this.dtlb_label.Size = new System.Drawing.Size(85, 20);
            this.dtlb_label.TabIndex = 10;
            this.dtlb_label.Text = "Data TLB";
            // 
            // itlb_label
            // 
            this.itlb_label.AutoSize = true;
            this.itlb_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itlb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itlb_label.Location = new System.Drawing.Point(103, 248);
            this.itlb_label.Name = "itlb_label";
            this.itlb_label.Size = new System.Drawing.Size(132, 20);
            this.itlb_label.TabIndex = 11;
            this.itlb_label.Text = "Instruction TLB";
            // 
            // l3cache_label
            // 
            this.l3cache_label.AutoSize = true;
            this.l3cache_label.BackColor = System.Drawing.Color.Peru;
            this.l3cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3cache_label.Location = new System.Drawing.Point(737, 522);
            this.l3cache_label.Name = "l3cache_label";
            this.l3cache_label.Size = new System.Drawing.Size(122, 20);
            this.l3cache_label.TabIndex = 12;
            this.l3cache_label.Text = "Level 3 Cache";
            // 
            // l2cache_label
            // 
            this.l2cache_label.AutoSize = true;
            this.l2cache_label.BackColor = System.Drawing.Color.Peru;
            this.l2cache_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2cache_label.Location = new System.Drawing.Point(529, 522);
            this.l2cache_label.Name = "l2cache_label";
            this.l2cache_label.Size = new System.Drawing.Size(122, 20);
            this.l2cache_label.TabIndex = 13;
            this.l2cache_label.Text = "Level 2 Cache";
            // 
            // il2cache_cache
            // 
            this.il2cache_cache.AutoSize = true;
            this.il2cache_cache.BackColor = System.Drawing.Color.Peru;
            this.il2cache_cache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.il2cache_cache.Location = new System.Drawing.Point(326, 522);
            this.il2cache_cache.Name = "il2cache_cache";
            this.il2cache_cache.Size = new System.Drawing.Size(104, 20);
            this.il2cache_cache.TabIndex = 14;
            this.il2cache_cache.Text = "Data Cache";
            // 
            // pt_label
            // 
            this.pt_label.AutoSize = true;
            this.pt_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pt_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pt_label.Location = new System.Drawing.Point(749, 248);
            this.pt_label.Name = "pt_label";
            this.pt_label.Size = new System.Drawing.Size(99, 20);
            this.pt_label.TabIndex = 15;
            this.pt_label.Text = "Page Table";
            // 
            // mem_label
            // 
            this.mem_label.AutoSize = true;
            this.mem_label.BackColor = System.Drawing.Color.DarkKhaki;
            this.mem_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mem_label.Location = new System.Drawing.Point(206, 709);
            this.mem_label.Name = "mem_label";
            this.mem_label.Size = new System.Drawing.Size(134, 20);
            this.mem_label.TabIndex = 17;
            this.mem_label.Text = "Memory Access";
            // 
            // disk_label
            // 
            this.disk_label.AutoSize = true;
            this.disk_label.BackColor = System.Drawing.Color.DarkKhaki;
            this.disk_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disk_label.Location = new System.Drawing.Point(641, 709);
            this.disk_label.Name = "disk_label";
            this.disk_label.Size = new System.Drawing.Size(107, 20);
            this.disk_label.TabIndex = 16;
            this.disk_label.Text = "Disk Access";
            // 
            // itlb_hit
            // 
            this.itlb_hit.Location = new System.Drawing.Point(89, 79);
            this.itlb_hit.Name = "itlb_hit";
            this.itlb_hit.Size = new System.Drawing.Size(160, 35);
            this.itlb_hit.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(75, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 252);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // itlb_miss
            // 
            this.itlb_miss.Location = new System.Drawing.Point(89, 161);
            this.itlb_miss.Name = "itlb_miss";
            this.itlb_miss.Size = new System.Drawing.Size(160, 35);
            this.itlb_miss.TabIndex = 24;
            // 
            // dtlb_miss
            // 
            this.dtlb_miss.Location = new System.Drawing.Point(297, 161);
            this.dtlb_miss.Name = "dtlb_miss";
            this.dtlb_miss.Size = new System.Drawing.Size(160, 35);
            this.dtlb_miss.TabIndex = 28;
            // 
            // dtlb_hit
            // 
            this.dtlb_hit.Location = new System.Drawing.Point(297, 79);
            this.dtlb_hit.Name = "dtlb_hit";
            this.dtlb_hit.Size = new System.Drawing.Size(160, 35);
            this.dtlb_hit.TabIndex = 26;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(283, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(188, 252);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // tlb_miss
            // 
            this.tlb_miss.Location = new System.Drawing.Point(509, 161);
            this.tlb_miss.Name = "tlb_miss";
            this.tlb_miss.Size = new System.Drawing.Size(160, 35);
            this.tlb_miss.TabIndex = 32;
            // 
            // tlb_hit
            // 
            this.tlb_hit.Location = new System.Drawing.Point(509, 79);
            this.tlb_hit.Name = "tlb_hit";
            this.tlb_hit.Size = new System.Drawing.Size(160, 35);
            this.tlb_hit.TabIndex = 30;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(495, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(188, 252);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pt_miss
            // 
            this.pt_miss.Location = new System.Drawing.Point(718, 161);
            this.pt_miss.Name = "pt_miss";
            this.pt_miss.Size = new System.Drawing.Size(160, 35);
            this.pt_miss.TabIndex = 36;
            // 
            // pt_hit
            // 
            this.pt_hit.Location = new System.Drawing.Point(718, 79);
            this.pt_hit.Name = "pt_hit";
            this.pt_hit.Size = new System.Drawing.Size(160, 35);
            this.pt_hit.TabIndex = 34;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox4.Location = new System.Drawing.Point(704, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(188, 252);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // il1cache_miss
            // 
            this.il1cache_miss.Location = new System.Drawing.Point(89, 444);
            this.il1cache_miss.Name = "il1cache_miss";
            this.il1cache_miss.Size = new System.Drawing.Size(160, 35);
            this.il1cache_miss.TabIndex = 40;
            // 
            // il1cache_hit
            // 
            this.il1cache_hit.Location = new System.Drawing.Point(89, 362);
            this.il1cache_hit.Name = "il1cache_hit";
            this.il1cache_hit.Size = new System.Drawing.Size(160, 35);
            this.il1cache_hit.TabIndex = 38;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Peru;
            this.pictureBox5.Location = new System.Drawing.Point(75, 316);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(188, 252);
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // dl1cache_miss
            // 
            this.dl1cache_miss.Location = new System.Drawing.Point(298, 444);
            this.dl1cache_miss.Name = "dl1cache_miss";
            this.dl1cache_miss.Size = new System.Drawing.Size(160, 35);
            this.dl1cache_miss.TabIndex = 43;
            // 
            // dl1cache_hit
            // 
            this.dl1cache_hit.Location = new System.Drawing.Point(298, 362);
            this.dl1cache_hit.Name = "dl1cache_hit";
            this.dl1cache_hit.Size = new System.Drawing.Size(160, 35);
            this.dl1cache_hit.TabIndex = 41;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Peru;
            this.pictureBox6.Location = new System.Drawing.Point(284, 316);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(188, 252);
            this.pictureBox6.TabIndex = 42;
            this.pictureBox6.TabStop = false;
            // 
            // l2cache_miss
            // 
            this.l2cache_miss.Location = new System.Drawing.Point(510, 444);
            this.l2cache_miss.Name = "l2cache_miss";
            this.l2cache_miss.Size = new System.Drawing.Size(160, 35);
            this.l2cache_miss.TabIndex = 46;
            // 
            // l2cache_hit
            // 
            this.l2cache_hit.Location = new System.Drawing.Point(510, 362);
            this.l2cache_hit.Name = "l2cache_hit";
            this.l2cache_hit.Size = new System.Drawing.Size(160, 35);
            this.l2cache_hit.TabIndex = 44;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Peru;
            this.pictureBox7.Location = new System.Drawing.Point(496, 316);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(188, 252);
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            // 
            // l3cache_miss
            // 
            this.l3cache_miss.Location = new System.Drawing.Point(718, 444);
            this.l3cache_miss.Name = "l3cache_miss";
            this.l3cache_miss.Size = new System.Drawing.Size(160, 35);
            this.l3cache_miss.TabIndex = 49;
            // 
            // l3cache_hit
            // 
            this.l3cache_hit.Location = new System.Drawing.Point(718, 362);
            this.l3cache_hit.Name = "l3cache_hit";
            this.l3cache_hit.Size = new System.Drawing.Size(160, 35);
            this.l3cache_hit.TabIndex = 47;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Peru;
            this.pictureBox8.Location = new System.Drawing.Point(704, 316);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(188, 252);
            this.pictureBox8.TabIndex = 48;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox9.Location = new System.Drawing.Point(75, 595);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(397, 160);
            this.pictureBox9.TabIndex = 50;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox10.Location = new System.Drawing.Point(496, 595);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(397, 160);
            this.pictureBox10.TabIndex = 51;
            this.pictureBox10.TabStop = false;
            // 
            // mem_access
            // 
            this.mem_access.Location = new System.Drawing.Point(89, 630);
            this.mem_access.Name = "mem_access";
            this.mem_access.Size = new System.Drawing.Size(368, 35);
            this.mem_access.TabIndex = 52;
            // 
            // disk_access
            // 
            this.disk_access.Location = new System.Drawing.Point(510, 630);
            this.disk_access.Name = "disk_access";
            this.disk_access.Size = new System.Drawing.Size(368, 35);
            this.disk_access.TabIndex = 53;
            // 
            // STAT_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 793);
            this.Controls.Add(this.disk_access);
            this.Controls.Add(this.mem_access);
            this.Controls.Add(this.dtlb_label);
            this.Controls.Add(this.dtlb_miss);
            this.Controls.Add(this.dtlb_hit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.itlb_miss);
            this.Controls.Add(this.itlb_hit);
            this.Controls.Add(this.mem_label);
            this.Controls.Add(this.disk_label);
            this.Controls.Add(this.pt_label);
            this.Controls.Add(this.il2cache_cache);
            this.Controls.Add(this.l2cache_label);
            this.Controls.Add(this.l3cache_label);
            this.Controls.Add(this.itlb_label);
            this.Controls.Add(this.tlb_label);
            this.Controls.Add(this.il1cache_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tlb_miss);
            this.Controls.Add(this.tlb_hit);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pt_miss);
            this.Controls.Add(this.pt_hit);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.il1cache_miss);
            this.Controls.Add(this.il1cache_hit);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.dl1cache_miss);
            this.Controls.Add(this.dl1cache_hit);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.l2cache_miss);
            this.Controls.Add(this.l2cache_hit);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.l3cache_miss);
            this.Controls.Add(this.l3cache_hit);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Name = "STAT_FRM";
            this.Text = "STAT_FRM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
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
        private System.Windows.Forms.ProgressBar itlb_hit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar itlb_miss;
        private System.Windows.Forms.ProgressBar dtlb_miss;
        private System.Windows.Forms.ProgressBar dtlb_hit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar tlb_miss;
        private System.Windows.Forms.ProgressBar tlb_hit;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ProgressBar pt_miss;
        private System.Windows.Forms.ProgressBar pt_hit;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ProgressBar il1cache_miss;
        private System.Windows.Forms.ProgressBar il1cache_hit;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ProgressBar dl1cache_miss;
        private System.Windows.Forms.ProgressBar dl1cache_hit;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ProgressBar l2cache_miss;
        private System.Windows.Forms.ProgressBar l2cache_hit;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ProgressBar l3cache_miss;
        private System.Windows.Forms.ProgressBar l3cache_hit;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.ProgressBar mem_access;
        private System.Windows.Forms.ProgressBar disk_access;
    }
}