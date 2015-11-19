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
using System.Drawing.Drawing2D;
using System.Threading;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.itlb_hit_num = new System.Windows.Forms.TextBox();
            this.itlb_miss_num = new System.Windows.Forms.TextBox();
            this.itlb_acs_num = new System.Windows.Forms.TextBox();
            this.dtlb_acs_num = new System.Windows.Forms.TextBox();
            this.dtlb_hit_num = new System.Windows.Forms.TextBox();
            this.dtlb_miss_num = new System.Windows.Forms.TextBox();
            this.tlb_acs_num = new System.Windows.Forms.TextBox();
            this.tlb_hit_num = new System.Windows.Forms.TextBox();
            this.tlb_miss_num = new System.Windows.Forms.TextBox();
            this.pt_miss_num = new System.Windows.Forms.TextBox();
            this.pt_hit_num = new System.Windows.Forms.TextBox();
            this.pt_acs_num = new System.Windows.Forms.TextBox();
            this.il1cache_miss_num = new System.Windows.Forms.TextBox();
            this.il1cache_hit_num = new System.Windows.Forms.TextBox();
            this.dl1cache_hit_num = new System.Windows.Forms.TextBox();
            this.dl1cache_miss_num = new System.Windows.Forms.TextBox();
            this.l2cache_hit_num = new System.Windows.Forms.TextBox();
            this.l2cache_miss_num = new System.Windows.Forms.TextBox();
            this.l3cache_hit_num = new System.Windows.Forms.TextBox();
            this.l3cache_miss_num = new System.Windows.Forms.TextBox();
            this.il1cache_acs_num = new System.Windows.Forms.TextBox();
            this.dl1cache_acs_num = new System.Windows.Forms.TextBox();
            this.l2cache_acs_num = new System.Windows.Forms.TextBox();
            this.l3cache_acs_num = new System.Windows.Forms.TextBox();
            this.mem_acs_num = new System.Windows.Forms.TextBox();
            this.disk_acs_num = new System.Windows.Forms.TextBox();
            this.disk_access = new NewProgressBar();
            this.mem_access = new NewProgressBar();
            this.dtlb_miss = new NewProgressBar();
            this.dtlb_hit = new NewProgressBar();
            this.itlb_miss = new NewProgressBar();
            this.itlb_hit = new NewProgressBar();
            this.tlb_miss = new NewProgressBar();
            this.tlb_hit = new NewProgressBar();
            this.pt_miss = new NewProgressBar();
            this.pt_hit = new NewProgressBar();
            this.il1cache_miss = new NewProgressBar();
            this.il1cache_hit = new NewProgressBar();
            this.dl1cache_miss = new NewProgressBar();
            this.dl1cache_hit = new NewProgressBar();
            this.l2cache_miss = new NewProgressBar();
            this.l2cache_hit = new NewProgressBar();
            this.l3cache_miss = new NewProgressBar();
            this.l3cache_hit = new NewProgressBar();
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
            this.il1cache_label.Location = new System.Drawing.Point(94, 544);
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
            this.tlb_label.Location = new System.Drawing.Point(571, 262);
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
            this.dtlb_label.Location = new System.Drawing.Point(336, 262);
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
            this.itlb_label.Location = new System.Drawing.Point(103, 261);
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
            this.l3cache_label.Location = new System.Drawing.Point(736, 543);
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
            this.l2cache_label.Location = new System.Drawing.Point(530, 543);
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
            this.il2cache_cache.Location = new System.Drawing.Point(326, 543);
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
            this.pt_label.Location = new System.Drawing.Point(748, 262);
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
            this.mem_label.Location = new System.Drawing.Point(206, 716);
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
            this.disk_label.Location = new System.Drawing.Point(641, 716);
            this.disk_label.Name = "disk_label";
            this.disk_label.Size = new System.Drawing.Size(107, 20);
            this.disk_label.TabIndex = 16;
            this.disk_label.Text = "Disk Access";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(75, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 252);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(284, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(188, 252);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(497, 41);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(188, 252);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox4.Location = new System.Drawing.Point(703, 41);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(188, 252);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Peru;
            this.pictureBox5.Location = new System.Drawing.Point(75, 323);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(188, 252);
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Peru;
            this.pictureBox6.Location = new System.Drawing.Point(284, 323);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(188, 252);
            this.pictureBox6.TabIndex = 42;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Peru;
            this.pictureBox7.Location = new System.Drawing.Point(497, 323);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(188, 252);
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Peru;
            this.pictureBox8.Location = new System.Drawing.Point(703, 323);
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
            // itlb_hit_num
            // 
            this.itlb_hit_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itlb_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itlb_hit_num.Location = new System.Drawing.Point(119, 129);
            this.itlb_hit_num.Name = "itlb_hit_num";
            this.itlb_hit_num.Size = new System.Drawing.Size(100, 19);
            this.itlb_hit_num.TabIndex = 54;
            this.itlb_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // itlb_miss_num
            // 
            this.itlb_miss_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itlb_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itlb_miss_num.Location = new System.Drawing.Point(119, 211);
            this.itlb_miss_num.Name = "itlb_miss_num";
            this.itlb_miss_num.Size = new System.Drawing.Size(100, 19);
            this.itlb_miss_num.TabIndex = 55;
            this.itlb_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // itlb_acs_num
            // 
            this.itlb_acs_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itlb_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itlb_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itlb_acs_num.Location = new System.Drawing.Point(119, 49);
            this.itlb_acs_num.Name = "itlb_acs_num";
            this.itlb_acs_num.Size = new System.Drawing.Size(100, 19);
            this.itlb_acs_num.TabIndex = 56;
            this.itlb_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtlb_acs_num
            // 
            this.dtlb_acs_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtlb_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtlb_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtlb_acs_num.Location = new System.Drawing.Point(328, 49);
            this.dtlb_acs_num.Name = "dtlb_acs_num";
            this.dtlb_acs_num.Size = new System.Drawing.Size(100, 19);
            this.dtlb_acs_num.TabIndex = 57;
            this.dtlb_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtlb_hit_num
            // 
            this.dtlb_hit_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtlb_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtlb_hit_num.Location = new System.Drawing.Point(328, 129);
            this.dtlb_hit_num.Name = "dtlb_hit_num";
            this.dtlb_hit_num.Size = new System.Drawing.Size(100, 19);
            this.dtlb_hit_num.TabIndex = 58;
            this.dtlb_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtlb_miss_num
            // 
            this.dtlb_miss_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtlb_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtlb_miss_num.Location = new System.Drawing.Point(328, 211);
            this.dtlb_miss_num.Name = "dtlb_miss_num";
            this.dtlb_miss_num.Size = new System.Drawing.Size(100, 19);
            this.dtlb_miss_num.TabIndex = 59;
            this.dtlb_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlb_acs_num
            // 
            this.tlb_acs_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlb_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlb_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlb_acs_num.Location = new System.Drawing.Point(541, 49);
            this.tlb_acs_num.Name = "tlb_acs_num";
            this.tlb_acs_num.Size = new System.Drawing.Size(100, 19);
            this.tlb_acs_num.TabIndex = 60;
            this.tlb_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlb_hit_num
            // 
            this.tlb_hit_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlb_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlb_hit_num.Location = new System.Drawing.Point(541, 129);
            this.tlb_hit_num.Name = "tlb_hit_num";
            this.tlb_hit_num.Size = new System.Drawing.Size(100, 19);
            this.tlb_hit_num.TabIndex = 61;
            this.tlb_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlb_miss_num
            // 
            this.tlb_miss_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlb_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlb_miss_num.Location = new System.Drawing.Point(541, 211);
            this.tlb_miss_num.Name = "tlb_miss_num";
            this.tlb_miss_num.Size = new System.Drawing.Size(100, 19);
            this.tlb_miss_num.TabIndex = 62;
            this.tlb_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pt_miss_num
            // 
            this.pt_miss_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pt_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pt_miss_num.Location = new System.Drawing.Point(747, 211);
            this.pt_miss_num.Name = "pt_miss_num";
            this.pt_miss_num.Size = new System.Drawing.Size(100, 19);
            this.pt_miss_num.TabIndex = 63;
            this.pt_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pt_hit_num
            // 
            this.pt_hit_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pt_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pt_hit_num.Location = new System.Drawing.Point(747, 129);
            this.pt_hit_num.Name = "pt_hit_num";
            this.pt_hit_num.Size = new System.Drawing.Size(100, 19);
            this.pt_hit_num.TabIndex = 64;
            this.pt_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pt_acs_num
            // 
            this.pt_acs_num.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pt_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pt_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pt_acs_num.Location = new System.Drawing.Point(747, 49);
            this.pt_acs_num.Name = "pt_acs_num";
            this.pt_acs_num.Size = new System.Drawing.Size(100, 19);
            this.pt_acs_num.TabIndex = 65;
            this.pt_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // il1cache_miss_num
            // 
            this.il1cache_miss_num.BackColor = System.Drawing.Color.Peru;
            this.il1cache_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.il1cache_miss_num.Location = new System.Drawing.Point(119, 490);
            this.il1cache_miss_num.Name = "il1cache_miss_num";
            this.il1cache_miss_num.Size = new System.Drawing.Size(100, 19);
            this.il1cache_miss_num.TabIndex = 66;
            this.il1cache_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // il1cache_hit_num
            // 
            this.il1cache_hit_num.BackColor = System.Drawing.Color.Peru;
            this.il1cache_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.il1cache_hit_num.Location = new System.Drawing.Point(119, 408);
            this.il1cache_hit_num.Name = "il1cache_hit_num";
            this.il1cache_hit_num.Size = new System.Drawing.Size(100, 19);
            this.il1cache_hit_num.TabIndex = 67;
            this.il1cache_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dl1cache_hit_num
            // 
            this.dl1cache_hit_num.BackColor = System.Drawing.Color.Peru;
            this.dl1cache_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dl1cache_hit_num.Location = new System.Drawing.Point(328, 408);
            this.dl1cache_hit_num.Name = "dl1cache_hit_num";
            this.dl1cache_hit_num.Size = new System.Drawing.Size(100, 19);
            this.dl1cache_hit_num.TabIndex = 68;
            this.dl1cache_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dl1cache_miss_num
            // 
            this.dl1cache_miss_num.BackColor = System.Drawing.Color.Peru;
            this.dl1cache_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dl1cache_miss_num.Location = new System.Drawing.Point(328, 490);
            this.dl1cache_miss_num.Name = "dl1cache_miss_num";
            this.dl1cache_miss_num.Size = new System.Drawing.Size(100, 19);
            this.dl1cache_miss_num.TabIndex = 69;
            this.dl1cache_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l2cache_hit_num
            // 
            this.l2cache_hit_num.BackColor = System.Drawing.Color.Peru;
            this.l2cache_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l2cache_hit_num.Location = new System.Drawing.Point(541, 408);
            this.l2cache_hit_num.Name = "l2cache_hit_num";
            this.l2cache_hit_num.Size = new System.Drawing.Size(100, 19);
            this.l2cache_hit_num.TabIndex = 70;
            this.l2cache_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l2cache_miss_num
            // 
            this.l2cache_miss_num.BackColor = System.Drawing.Color.Peru;
            this.l2cache_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l2cache_miss_num.Location = new System.Drawing.Point(541, 490);
            this.l2cache_miss_num.Name = "l2cache_miss_num";
            this.l2cache_miss_num.Size = new System.Drawing.Size(100, 19);
            this.l2cache_miss_num.TabIndex = 71;
            this.l2cache_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l3cache_hit_num
            // 
            this.l3cache_hit_num.BackColor = System.Drawing.Color.Peru;
            this.l3cache_hit_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l3cache_hit_num.Location = new System.Drawing.Point(747, 408);
            this.l3cache_hit_num.Name = "l3cache_hit_num";
            this.l3cache_hit_num.Size = new System.Drawing.Size(100, 19);
            this.l3cache_hit_num.TabIndex = 72;
            this.l3cache_hit_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l3cache_miss_num
            // 
            this.l3cache_miss_num.BackColor = System.Drawing.Color.Peru;
            this.l3cache_miss_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l3cache_miss_num.Location = new System.Drawing.Point(747, 490);
            this.l3cache_miss_num.Name = "l3cache_miss_num";
            this.l3cache_miss_num.Size = new System.Drawing.Size(100, 19);
            this.l3cache_miss_num.TabIndex = 73;
            this.l3cache_miss_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // il1cache_acs_num
            // 
            this.il1cache_acs_num.BackColor = System.Drawing.Color.Peru;
            this.il1cache_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.il1cache_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.il1cache_acs_num.Location = new System.Drawing.Point(119, 331);
            this.il1cache_acs_num.Name = "il1cache_acs_num";
            this.il1cache_acs_num.Size = new System.Drawing.Size(100, 19);
            this.il1cache_acs_num.TabIndex = 74;
            this.il1cache_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dl1cache_acs_num
            // 
            this.dl1cache_acs_num.BackColor = System.Drawing.Color.Peru;
            this.dl1cache_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dl1cache_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dl1cache_acs_num.Location = new System.Drawing.Point(328, 331);
            this.dl1cache_acs_num.Name = "dl1cache_acs_num";
            this.dl1cache_acs_num.Size = new System.Drawing.Size(100, 19);
            this.dl1cache_acs_num.TabIndex = 75;
            this.dl1cache_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l2cache_acs_num
            // 
            this.l2cache_acs_num.BackColor = System.Drawing.Color.Peru;
            this.l2cache_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l2cache_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2cache_acs_num.Location = new System.Drawing.Point(541, 331);
            this.l2cache_acs_num.Name = "l2cache_acs_num";
            this.l2cache_acs_num.Size = new System.Drawing.Size(100, 19);
            this.l2cache_acs_num.TabIndex = 76;
            this.l2cache_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l3cache_acs_num
            // 
            this.l3cache_acs_num.BackColor = System.Drawing.Color.Peru;
            this.l3cache_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l3cache_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3cache_acs_num.Location = new System.Drawing.Point(747, 331);
            this.l3cache_acs_num.Name = "l3cache_acs_num";
            this.l3cache_acs_num.Size = new System.Drawing.Size(100, 19);
            this.l3cache_acs_num.TabIndex = 77;
            this.l3cache_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mem_acs_num
            // 
            this.mem_acs_num.BackColor = System.Drawing.Color.DarkKhaki;
            this.mem_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mem_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mem_acs_num.Location = new System.Drawing.Point(223, 607);
            this.mem_acs_num.Name = "mem_acs_num";
            this.mem_acs_num.Size = new System.Drawing.Size(100, 19);
            this.mem_acs_num.TabIndex = 78;
            this.mem_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // disk_acs_num
            // 
            this.disk_acs_num.BackColor = System.Drawing.Color.DarkKhaki;
            this.disk_acs_num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.disk_acs_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disk_acs_num.Location = new System.Drawing.Point(644, 607);
            this.disk_acs_num.Name = "disk_acs_num";
            this.disk_acs_num.Size = new System.Drawing.Size(100, 19);
            this.disk_acs_num.TabIndex = 79;
            this.disk_acs_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // disk_access
            // 
            this.disk_access.ForeColor = System.Drawing.Color.Blue;
            this.disk_access.Location = new System.Drawing.Point(510, 644);
            this.disk_access.Name = "disk_access";
            this.disk_access.Size = new System.Drawing.Size(368, 35);
            this.disk_access.TabIndex = 53;
            // 
            // mem_access
            // 
            this.mem_access.ForeColor = System.Drawing.Color.Blue;
            this.mem_access.Location = new System.Drawing.Point(89, 644);
            this.mem_access.Name = "mem_access";
            this.mem_access.Size = new System.Drawing.Size(368, 35);
            this.mem_access.TabIndex = 52;
            // 
            // dtlb_miss
            // 
            this.dtlb_miss.ForeColor = System.Drawing.Color.Red;
            this.dtlb_miss.Location = new System.Drawing.Point(298, 174);
            this.dtlb_miss.Name = "dtlb_miss";
            this.dtlb_miss.Size = new System.Drawing.Size(160, 35);
            this.dtlb_miss.TabIndex = 28;
            // 
            // dtlb_hit
            // 
            this.dtlb_hit.ForeColor = System.Drawing.Color.Green;
            this.dtlb_hit.Location = new System.Drawing.Point(298, 92);
            this.dtlb_hit.Name = "dtlb_hit";
            this.dtlb_hit.Size = new System.Drawing.Size(160, 35);
            this.dtlb_hit.TabIndex = 26;
            // 
            // itlb_miss
            // 
            this.itlb_miss.ForeColor = System.Drawing.Color.Red;
            this.itlb_miss.Location = new System.Drawing.Point(89, 174);
            this.itlb_miss.Name = "itlb_miss";
            this.itlb_miss.Size = new System.Drawing.Size(160, 35);
            this.itlb_miss.TabIndex = 24;
            // 
            // itlb_hit
            // 
            this.itlb_hit.ForeColor = System.Drawing.Color.Green;
            this.itlb_hit.Location = new System.Drawing.Point(89, 92);
            this.itlb_hit.Name = "itlb_hit";
            this.itlb_hit.Size = new System.Drawing.Size(160, 35);
            this.itlb_hit.TabIndex = 22;
            // 
            // tlb_miss
            // 
            this.tlb_miss.ForeColor = System.Drawing.Color.Red;
            this.tlb_miss.Location = new System.Drawing.Point(511, 174);
            this.tlb_miss.Name = "tlb_miss";
            this.tlb_miss.Size = new System.Drawing.Size(160, 35);
            this.tlb_miss.TabIndex = 32;
            // 
            // tlb_hit
            // 
            this.tlb_hit.ForeColor = System.Drawing.Color.Green;
            this.tlb_hit.Location = new System.Drawing.Point(511, 92);
            this.tlb_hit.Name = "tlb_hit";
            this.tlb_hit.Size = new System.Drawing.Size(160, 35);
            this.tlb_hit.TabIndex = 30;
            // 
            // pt_miss
            // 
            this.pt_miss.ForeColor = System.Drawing.Color.Red;
            this.pt_miss.Location = new System.Drawing.Point(717, 174);
            this.pt_miss.Name = "pt_miss";
            this.pt_miss.Size = new System.Drawing.Size(160, 35);
            this.pt_miss.TabIndex = 36;
            // 
            // pt_hit
            // 
            this.pt_hit.ForeColor = System.Drawing.Color.Green;
            this.pt_hit.Location = new System.Drawing.Point(717, 92);
            this.pt_hit.Name = "pt_hit";
            this.pt_hit.Size = new System.Drawing.Size(160, 35);
            this.pt_hit.TabIndex = 34;
            // 
            // il1cache_miss
            // 
            this.il1cache_miss.ForeColor = System.Drawing.Color.Red;
            this.il1cache_miss.Location = new System.Drawing.Point(89, 453);
            this.il1cache_miss.Name = "il1cache_miss";
            this.il1cache_miss.Size = new System.Drawing.Size(160, 35);
            this.il1cache_miss.TabIndex = 40;
            // 
            // il1cache_hit
            // 
            this.il1cache_hit.ForeColor = System.Drawing.Color.Green;
            this.il1cache_hit.Location = new System.Drawing.Point(89, 371);
            this.il1cache_hit.Name = "il1cache_hit";
            this.il1cache_hit.Size = new System.Drawing.Size(160, 35);
            this.il1cache_hit.TabIndex = 38;
            // 
            // dl1cache_miss
            // 
            this.dl1cache_miss.ForeColor = System.Drawing.Color.Red;
            this.dl1cache_miss.Location = new System.Drawing.Point(298, 453);
            this.dl1cache_miss.Name = "dl1cache_miss";
            this.dl1cache_miss.Size = new System.Drawing.Size(160, 35);
            this.dl1cache_miss.TabIndex = 43;
            // 
            // dl1cache_hit
            // 
            this.dl1cache_hit.ForeColor = System.Drawing.Color.Green;
            this.dl1cache_hit.Location = new System.Drawing.Point(298, 371);
            this.dl1cache_hit.Name = "dl1cache_hit";
            this.dl1cache_hit.Size = new System.Drawing.Size(160, 35);
            this.dl1cache_hit.TabIndex = 41;
            // 
            // l2cache_miss
            // 
            this.l2cache_miss.ForeColor = System.Drawing.Color.Red;
            this.l2cache_miss.Location = new System.Drawing.Point(511, 453);
            this.l2cache_miss.Name = "l2cache_miss";
            this.l2cache_miss.Size = new System.Drawing.Size(160, 35);
            this.l2cache_miss.TabIndex = 46;
            // 
            // l2cache_hit
            // 
            this.l2cache_hit.ForeColor = System.Drawing.Color.Green;
            this.l2cache_hit.Location = new System.Drawing.Point(511, 371);
            this.l2cache_hit.Name = "l2cache_hit";
            this.l2cache_hit.Size = new System.Drawing.Size(160, 35);
            this.l2cache_hit.TabIndex = 44;
            // 
            // l3cache_miss
            // 
            this.l3cache_miss.ForeColor = System.Drawing.Color.Red;
            this.l3cache_miss.Location = new System.Drawing.Point(717, 453);
            this.l3cache_miss.Name = "l3cache_miss";
            this.l3cache_miss.Size = new System.Drawing.Size(160, 35);
            this.l3cache_miss.TabIndex = 49;
            // 
            // l3cache_hit
            // 
            this.l3cache_hit.ForeColor = System.Drawing.Color.Green;
            this.l3cache_hit.Location = new System.Drawing.Point(717, 371);
            this.l3cache_hit.Name = "l3cache_hit";
            this.l3cache_hit.Size = new System.Drawing.Size(160, 35);
            this.l3cache_hit.TabIndex = 47;
            // 
            // STAT_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 793);
            this.Controls.Add(this.disk_acs_num);
            this.Controls.Add(this.mem_acs_num);
            this.Controls.Add(this.l3cache_acs_num);
            this.Controls.Add(this.l2cache_acs_num);
            this.Controls.Add(this.dl1cache_acs_num);
            this.Controls.Add(this.il1cache_acs_num);
            this.Controls.Add(this.l3cache_miss_num);
            this.Controls.Add(this.l3cache_hit_num);
            this.Controls.Add(this.l2cache_miss_num);
            this.Controls.Add(this.l2cache_hit_num);
            this.Controls.Add(this.dl1cache_miss_num);
            this.Controls.Add(this.dl1cache_hit_num);
            this.Controls.Add(this.il1cache_hit_num);
            this.Controls.Add(this.il1cache_miss_num);
            this.Controls.Add(this.pt_acs_num);
            this.Controls.Add(this.pt_hit_num);
            this.Controls.Add(this.pt_miss_num);
            this.Controls.Add(this.tlb_miss_num);
            this.Controls.Add(this.tlb_hit_num);
            this.Controls.Add(this.tlb_acs_num);
            this.Controls.Add(this.dtlb_miss_num);
            this.Controls.Add(this.dtlb_hit_num);
            this.Controls.Add(this.dtlb_acs_num);
            this.Controls.Add(this.itlb_acs_num);
            this.Controls.Add(this.itlb_miss_num);
            this.Controls.Add(this.itlb_hit_num);
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
            this.Load += new System.EventHandler(this.STAT_FRM_Load);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private NewProgressBar itlb_hit;
        private NewProgressBar itlb_miss;
        private NewProgressBar dtlb_miss;
        private NewProgressBar dtlb_hit;
        private NewProgressBar tlb_miss;
        private NewProgressBar tlb_hit;
        private NewProgressBar pt_miss;
        private NewProgressBar pt_hit;
        private NewProgressBar il1cache_miss;
        private NewProgressBar il1cache_hit;
        private NewProgressBar dl1cache_miss;
        private NewProgressBar dl1cache_hit;
        private NewProgressBar l2cache_miss;
        private NewProgressBar l2cache_hit;
        private NewProgressBar l3cache_miss;
        private NewProgressBar l3cache_hit;
        private NewProgressBar mem_access;
        private NewProgressBar disk_access;
        private TextBox itlb_hit_num;
        private TextBox itlb_miss_num;
        private TextBox itlb_acs_num;
        private TextBox dtlb_acs_num;
        private TextBox dtlb_hit_num;
        private TextBox dtlb_miss_num;
        private TextBox tlb_acs_num;
        private TextBox tlb_hit_num;
        private TextBox tlb_miss_num;
        private TextBox pt_miss_num;
        private TextBox pt_hit_num;
        private TextBox pt_acs_num;
        private TextBox il1cache_miss_num;
        private TextBox il1cache_hit_num;
        private TextBox dl1cache_hit_num;
        private TextBox dl1cache_miss_num;
        private TextBox l2cache_hit_num;
        private TextBox l2cache_miss_num;
        private TextBox l3cache_hit_num;
        private TextBox l3cache_miss_num;
        private TextBox il1cache_acs_num;
        private TextBox dl1cache_acs_num;
        private TextBox l2cache_acs_num;
        private TextBox l3cache_acs_num;
        private TextBox mem_acs_num;
        private TextBox disk_acs_num;
    }
}


public class NewProgressBar : ProgressBar
{
    private SolidBrush brush = null;

    public NewProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (brush == null || brush.Color != this.ForeColor)
            brush = new SolidBrush(this.ForeColor);

        double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));


        Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
        if (ProgressBarRenderer.IsSupported)
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
        rec.Width = (int)((rec.Width * scaleFactor));
        rec.Height = rec.Height - 4;
        e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
    }
}
