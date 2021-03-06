﻿namespace Cache_Simulation
{
    partial class Simulator
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
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nxt_inst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pc_counter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inst = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.il1_cache_show = new System.Windows.Forms.Button();
            this.dl1_cache_show = new System.Windows.Forms.Button();
            this.l2_cache_show = new System.Windows.Forms.Button();
            this.l3_cache_show = new System.Windows.Forms.Button();
            this.itlb_show = new System.Windows.Forms.Button();
            this.dtlb_show = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tlb_show = new System.Windows.Forms.Button();
            this.cpu_show = new System.Windows.Forms.Button();
            this.pt_show = new System.Windows.Forms.Button();
            this.mem_show = new System.Windows.Forms.Button();
            this.disk_show = new System.Windows.Forms.Button();
            this.hit_miss_stat = new System.Windows.Forms.Label();
            this.v_addr_stat = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.p_addr_stat = new System.Windows.Forms.Label();
            this.read_write_stat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.exe_time = new System.Windows.Forms.Label();
            this.filename_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(897, 55);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(158, 68);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 768);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // nxt_inst
            // 
            this.nxt_inst.Location = new System.Drawing.Point(862, 158);
            this.nxt_inst.Name = "nxt_inst";
            this.nxt_inst.Size = new System.Drawing.Size(138, 38);
            this.nxt_inst.TabIndex = 2;
            this.nxt_inst.Text = "Next Instruction";
            this.nxt_inst.UseVisualStyleBackColor = true;
            this.nxt_inst.Click += new System.EventHandler(this.nxt_inst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(834, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program Counter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1064, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 4;
            // 
            // pc_counter
            // 
            this.pc_counter.AutoSize = true;
            this.pc_counter.Location = new System.Drawing.Point(1048, 222);
            this.pc_counter.Name = "pc_counter";
            this.pc_counter.Size = new System.Drawing.Size(18, 20);
            this.pc_counter.TabIndex = 5;
            this.pc_counter.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(860, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Instruction";
            // 
            // inst
            // 
            this.inst.AutoSize = true;
            this.inst.Location = new System.Drawing.Point(976, 275);
            this.inst.Name = "inst";
            this.inst.Size = new System.Drawing.Size(181, 20);
            this.inst.TabIndex = 7;
            this.inst.Text = "00 00 00 00 00 00 00 00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(884, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.type.Location = new System.Drawing.Point(1048, 328);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(33, 20);
            this.type.TabIndex = 9;
            this.type.Text = "----";
            // 
            // il1_cache_show
            // 
            this.il1_cache_show.Location = new System.Drawing.Point(646, 108);
            this.il1_cache_show.Name = "il1_cache_show";
            this.il1_cache_show.Size = new System.Drawing.Size(94, 35);
            this.il1_cache_show.TabIndex = 10;
            this.il1_cache_show.Text = "iL1 Cache";
            this.il1_cache_show.UseVisualStyleBackColor = true;
            this.il1_cache_show.Click += new System.EventHandler(this.il1_cache_show_Click);
            // 
            // dl1_cache_show
            // 
            this.dl1_cache_show.Location = new System.Drawing.Point(646, 185);
            this.dl1_cache_show.Name = "dl1_cache_show";
            this.dl1_cache_show.Size = new System.Drawing.Size(94, 35);
            this.dl1_cache_show.TabIndex = 11;
            this.dl1_cache_show.Text = "dL1 Cache";
            this.dl1_cache_show.UseVisualStyleBackColor = true;
            this.dl1_cache_show.Click += new System.EventHandler(this.dl1_cache_show_Click);
            // 
            // l2_cache_show
            // 
            this.l2_cache_show.Location = new System.Drawing.Point(634, 262);
            this.l2_cache_show.Name = "l2_cache_show";
            this.l2_cache_show.Size = new System.Drawing.Size(120, 49);
            this.l2_cache_show.TabIndex = 13;
            this.l2_cache_show.Text = "L2 Cache";
            this.l2_cache_show.UseVisualStyleBackColor = true;
            this.l2_cache_show.Click += new System.EventHandler(this.l2_cache_show_Click);
            // 
            // l3_cache_show
            // 
            this.l3_cache_show.Location = new System.Drawing.Point(608, 352);
            this.l3_cache_show.Name = "l3_cache_show";
            this.l3_cache_show.Size = new System.Drawing.Size(170, 60);
            this.l3_cache_show.TabIndex = 15;
            this.l3_cache_show.Text = "L3 Cache";
            this.l3_cache_show.UseVisualStyleBackColor = true;
            this.l3_cache_show.Click += new System.EventHandler(this.l3_cache_show_Click);
            // 
            // itlb_show
            // 
            this.itlb_show.Location = new System.Drawing.Point(80, 108);
            this.itlb_show.Name = "itlb_show";
            this.itlb_show.Size = new System.Drawing.Size(70, 35);
            this.itlb_show.TabIndex = 16;
            this.itlb_show.Text = "iTLB";
            this.itlb_show.UseVisualStyleBackColor = true;
            this.itlb_show.Click += new System.EventHandler(this.itlb_show_Click);
            // 
            // dtlb_show
            // 
            this.dtlb_show.Location = new System.Drawing.Point(80, 185);
            this.dtlb_show.Name = "dtlb_show";
            this.dtlb_show.Size = new System.Drawing.Size(70, 35);
            this.dtlb_show.TabIndex = 17;
            this.dtlb_show.Text = "dTLB";
            this.dtlb_show.UseVisualStyleBackColor = true;
            this.dtlb_show.Click += new System.EventHandler(this.dtlb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(642, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 32);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cache";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 32);
            this.label6.TabIndex = 18;
            this.label6.Text = "TLB";
            // 
            // tlb_show
            // 
            this.tlb_show.Location = new System.Drawing.Point(56, 262);
            this.tlb_show.Name = "tlb_show";
            this.tlb_show.Size = new System.Drawing.Size(120, 49);
            this.tlb_show.TabIndex = 20;
            this.tlb_show.Text = "TLB";
            this.tlb_show.UseVisualStyleBackColor = true;
            this.tlb_show.Click += new System.EventHandler(this.tlb_show_Click);
            // 
            // cpu_show
            // 
            this.cpu_show.Location = new System.Drawing.Point(357, 152);
            this.cpu_show.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpu_show.Name = "cpu_show";
            this.cpu_show.Size = new System.Drawing.Size(100, 100);
            this.cpu_show.TabIndex = 21;
            this.cpu_show.Text = "CPU";
            this.cpu_show.UseVisualStyleBackColor = true;
            this.cpu_show.Click += new System.EventHandler(this.button1_Click);
            // 
            // pt_show
            // 
            this.pt_show.Location = new System.Drawing.Point(30, 352);
            this.pt_show.Name = "pt_show";
            this.pt_show.Size = new System.Drawing.Size(170, 60);
            this.pt_show.TabIndex = 22;
            this.pt_show.Text = "Page Table";
            this.pt_show.UseVisualStyleBackColor = true;
            this.pt_show.Click += new System.EventHandler(this.pt_show_Click);
            // 
            // mem_show
            // 
            this.mem_show.Location = new System.Drawing.Point(308, 351);
            this.mem_show.Name = "mem_show";
            this.mem_show.Size = new System.Drawing.Size(200, 80);
            this.mem_show.TabIndex = 23;
            this.mem_show.Text = "Main Memory";
            this.mem_show.UseVisualStyleBackColor = true;
            this.mem_show.Click += new System.EventHandler(this.mem_show_Click);
            // 
            // disk_show
            // 
            this.disk_show.Location = new System.Drawing.Point(282, 478);
            this.disk_show.Name = "disk_show";
            this.disk_show.Size = new System.Drawing.Size(250, 120);
            this.disk_show.TabIndex = 24;
            this.disk_show.Text = "Disk";
            this.disk_show.UseVisualStyleBackColor = true;
            this.disk_show.Click += new System.EventHandler(this.disk_show_Click);
            // 
            // hit_miss_stat
            // 
            this.hit_miss_stat.AutoSize = true;
            this.hit_miss_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hit_miss_stat.Location = new System.Drawing.Point(392, 102);
            this.hit_miss_stat.Name = "hit_miss_stat";
            this.hit_miss_stat.Size = new System.Drawing.Size(30, 29);
            this.hit_miss_stat.TabIndex = 25;
            this.hit_miss_stat.Text = "H";
            this.hit_miss_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hit_miss_stat.Visible = false;
            // 
            // v_addr_stat
            // 
            this.v_addr_stat.AutoSize = true;
            this.v_addr_stat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.v_addr_stat.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v_addr_stat.Location = new System.Drawing.Point(274, 20);
            this.v_addr_stat.Name = "v_addr_stat";
            this.v_addr_stat.Size = new System.Drawing.Size(264, 27);
            this.v_addr_stat.TabIndex = 26;
            this.v_addr_stat.Text = "00 00 00 00 00 00 ";
            this.v_addr_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.v_addr_stat.Visible = false;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(70, 517);
            this.speed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(90, 26);
            this.speed.TabIndex = 27;
            this.speed.Text = "1000";
            this.speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "Speed (ms)";
            // 
            // p_addr_stat
            // 
            this.p_addr_stat.AutoSize = true;
            this.p_addr_stat.BackColor = System.Drawing.Color.DarkOrange;
            this.p_addr_stat.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_addr_stat.Location = new System.Drawing.Point(296, 57);
            this.p_addr_stat.Name = "p_addr_stat";
            this.p_addr_stat.Size = new System.Drawing.Size(222, 27);
            this.p_addr_stat.TabIndex = 29;
            this.p_addr_stat.Text = "00 00 00 00 00 ";
            this.p_addr_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p_addr_stat.Visible = false;
            // 
            // read_write_stat
            // 
            this.read_write_stat.AutoSize = true;
            this.read_write_stat.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.read_write_stat.Location = new System.Drawing.Point(368, 275);
            this.read_write_stat.Name = "read_write_stat";
            this.read_write_stat.Size = new System.Drawing.Size(82, 27);
            this.read_write_stat.TabIndex = 30;
            this.read_write_stat.Text = "_____";
            this.read_write_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.read_write_stat.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(860, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Execution Time";
            // 
            // exe_time
            // 
            this.exe_time.AutoSize = true;
            this.exe_time.Location = new System.Drawing.Point(1070, 411);
            this.exe_time.Name = "exe_time";
            this.exe_time.Size = new System.Drawing.Size(18, 20);
            this.exe_time.TabIndex = 32;
            this.exe_time.Text = "0";
            // 
            // filename_text
            // 
            this.filename_text.Location = new System.Drawing.Point(862, 494);
            this.filename_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filename_text.Name = "filename_text";
            this.filename_text.Size = new System.Drawing.Size(114, 26);
            this.filename_text.TabIndex = 34;
            this.filename_text.Text = "test.txt";
            this.filename_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1024, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 35;
            this.button1.Text = "Assemble";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(938, 562);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 36;
            this.button2.Text = "Statistics";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1024, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 38);
            this.button3.TabIndex = 37;
            this.button3.Text = "Execute";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 649);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filename_text);
            this.Controls.Add(this.exe_time);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.read_write_stat);
            this.Controls.Add(this.p_addr_stat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.v_addr_stat);
            this.Controls.Add(this.hit_miss_stat);
            this.Controls.Add(this.disk_show);
            this.Controls.Add(this.mem_show);
            this.Controls.Add(this.pt_show);
            this.Controls.Add(this.cpu_show);
            this.Controls.Add(this.tlb_show);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtlb_show);
            this.Controls.Add(this.itlb_show);
            this.Controls.Add(this.l3_cache_show);
            this.Controls.Add(this.l2_cache_show);
            this.Controls.Add(this.dl1_cache_show);
            this.Controls.Add(this.il1_cache_show);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pc_counter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nxt_inst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Name = "Simulator";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Simulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nxt_inst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pc_counter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label inst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Button il1_cache_show;
        private System.Windows.Forms.Button dl1_cache_show;
        private System.Windows.Forms.Button l2_cache_show;
        private System.Windows.Forms.Button l3_cache_show;
        private System.Windows.Forms.Button itlb_show;
        private System.Windows.Forms.Button dtlb_show;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tlb_show;
        private System.Windows.Forms.Button cpu_show;
        private System.Windows.Forms.Button pt_show;
        private System.Windows.Forms.Button mem_show;
        private System.Windows.Forms.Button disk_show;
        private System.Windows.Forms.Label v_addr_stat;
        private System.Windows.Forms.Label hit_miss_stat;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label p_addr_stat;
        private System.Windows.Forms.Label read_write_stat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label exe_time;
        private System.Windows.Forms.TextBox filename_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

