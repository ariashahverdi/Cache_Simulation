namespace Cache_Simulation
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
            this.dtlb = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tlb_show = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(318, 38);
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
            this.label1.Location = new System.Drawing.Point(404, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // nxt_inst
            // 
            this.nxt_inst.Location = new System.Drawing.Point(288, 149);
            this.nxt_inst.Name = "nxt_inst";
            this.nxt_inst.Size = new System.Drawing.Size(232, 38);
            this.nxt_inst.TabIndex = 2;
            this.nxt_inst.Text = "Next Instruction";
            this.nxt_inst.UseVisualStyleBackColor = true;
            this.nxt_inst.Click += new System.EventHandler(this.nxt_inst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program Counter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 4;
            // 
            // pc_counter
            // 
            this.pc_counter.AutoSize = true;
            this.pc_counter.Location = new System.Drawing.Point(458, 222);
            this.pc_counter.Name = "pc_counter";
            this.pc_counter.Size = new System.Drawing.Size(18, 20);
            this.pc_counter.TabIndex = 5;
            this.pc_counter.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Instruction";
            // 
            // inst
            // 
            this.inst.AutoSize = true;
            this.inst.Location = new System.Drawing.Point(374, 285);
            this.inst.Name = "inst";
            this.inst.Size = new System.Drawing.Size(181, 20);
            this.inst.TabIndex = 7;
            this.inst.Text = "00 00 00 00 00 00 00 00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(278, 340);
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
            this.type.Location = new System.Drawing.Point(412, 340);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(33, 20);
            this.type.TabIndex = 9;
            this.type.Text = "----";
            // 
            // il1_cache_show
            // 
            this.il1_cache_show.Location = new System.Drawing.Point(70, 155);
            this.il1_cache_show.Name = "il1_cache_show";
            this.il1_cache_show.Size = new System.Drawing.Size(94, 34);
            this.il1_cache_show.TabIndex = 10;
            this.il1_cache_show.Text = "iL1 Cache";
            this.il1_cache_show.UseVisualStyleBackColor = true;
            this.il1_cache_show.Click += new System.EventHandler(this.il1_cache_show_Click);
            // 
            // dl1_cache_show
            // 
            this.dl1_cache_show.Location = new System.Drawing.Point(656, 155);
            this.dl1_cache_show.Name = "dl1_cache_show";
            this.dl1_cache_show.Size = new System.Drawing.Size(94, 34);
            this.dl1_cache_show.TabIndex = 11;
            this.dl1_cache_show.Text = "dL1 Cache";
            this.dl1_cache_show.UseVisualStyleBackColor = true;
            this.dl1_cache_show.Click += new System.EventHandler(this.dl1_cache_show_Click);
            // 
            // l2_cache_show
            // 
            this.l2_cache_show.Location = new System.Drawing.Point(638, 228);
            this.l2_cache_show.Name = "l2_cache_show";
            this.l2_cache_show.Size = new System.Drawing.Size(128, 48);
            this.l2_cache_show.TabIndex = 13;
            this.l2_cache_show.Text = "L2 Cache";
            this.l2_cache_show.UseVisualStyleBackColor = true;
            this.l2_cache_show.Click += new System.EventHandler(this.l2_cache_show_Click);
            // 
            // l3_cache_show
            // 
            this.l3_cache_show.Location = new System.Drawing.Point(616, 312);
            this.l3_cache_show.Name = "l3_cache_show";
            this.l3_cache_show.Size = new System.Drawing.Size(170, 60);
            this.l3_cache_show.TabIndex = 15;
            this.l3_cache_show.Text = "L3 Cache";
            this.l3_cache_show.UseVisualStyleBackColor = true;
            // 
            // itlb_show
            // 
            this.itlb_show.Location = new System.Drawing.Point(84, 72);
            this.itlb_show.Name = "itlb_show";
            this.itlb_show.Size = new System.Drawing.Size(68, 34);
            this.itlb_show.TabIndex = 16;
            this.itlb_show.Text = "iTLB";
            this.itlb_show.UseVisualStyleBackColor = true;
            this.itlb_show.Click += new System.EventHandler(this.itlb_show_Click);
            // 
            // dtlb
            // 
            this.dtlb.Location = new System.Drawing.Point(669, 72);
            this.dtlb.Name = "dtlb";
            this.dtlb.Size = new System.Drawing.Size(68, 34);
            this.dtlb.TabIndex = 17;
            this.dtlb.Text = "dTLB";
            this.dtlb.UseVisualStyleBackColor = true;
            this.dtlb.Click += new System.EventHandler(this.dtlb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(663, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 32);
            this.label7.TabIndex = 19;
            this.label7.Text = "Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 32);
            this.label6.TabIndex = 18;
            this.label6.Text = "Instruction";
            // 
            // tlb_show
            // 
            this.tlb_show.Location = new System.Drawing.Point(70, 248);
            this.tlb_show.Name = "tlb_show";
            this.tlb_show.Size = new System.Drawing.Size(104, 58);
            this.tlb_show.TabIndex = 20;
            this.tlb_show.Text = "TLB";
            this.tlb_show.UseVisualStyleBackColor = true;
            this.tlb_show.Click += new System.EventHandler(this.tlb_show_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 75);
            this.button1.TabIndex = 21;
            this.button1.Text = "CPU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 558);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tlb_show);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtlb);
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
        private System.Windows.Forms.Button dtlb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tlb_show;
        private System.Windows.Forms.Button button1;
    }
}

