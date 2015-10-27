namespace Cache_Simulation
{
    partial class L2Cache
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
            this.button1 = new System.Windows.Forms.Button();
            this.l2cache_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payload8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.l2cache_show)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(891, 671);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Display";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // l2cache_show
            // 
            this.l2cache_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.l2cache_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.tag1,
            this.payload1,
            this.tag2,
            this.payload2,
            this.tag3,
            this.payload3,
            this.tag4,
            this.payload4,
            this.tag5,
            this.payload5,
            this.tag6,
            this.payload6,
            this.tag7,
            this.payload7,
            this.tag8,
            this.payload8});
            this.l2cache_show.Location = new System.Drawing.Point(47, 33);
            this.l2cache_show.Name = "l2cache_show";
            this.l2cache_show.RowTemplate.Height = 28;
            this.l2cache_show.Size = new System.Drawing.Size(1785, 600);
            this.l2cache_show.TabIndex = 2;
            this.l2cache_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.l2cache_show_CellContentClick);
            // 
            // num
            // 
            this.num.HeaderText = "#";
            this.num.Name = "num";
            // 
            // tag1
            // 
            this.tag1.HeaderText = "Tag";
            this.tag1.Name = "tag1";
            // 
            // payload1
            // 
            this.payload1.HeaderText = "Payload";
            this.payload1.Name = "payload1";
            // 
            // tag2
            // 
            this.tag2.HeaderText = "Tag";
            this.tag2.Name = "tag2";
            // 
            // payload2
            // 
            this.payload2.HeaderText = "Payload";
            this.payload2.Name = "payload2";
            // 
            // tag3
            // 
            this.tag3.HeaderText = "Tag";
            this.tag3.Name = "tag3";
            // 
            // payload3
            // 
            this.payload3.HeaderText = "Payload";
            this.payload3.Name = "payload3";
            // 
            // tag4
            // 
            this.tag4.HeaderText = "Tag";
            this.tag4.Name = "tag4";
            // 
            // payload4
            // 
            this.payload4.HeaderText = "Payload";
            this.payload4.Name = "payload4";
            // 
            // tag5
            // 
            this.tag5.HeaderText = "Tag";
            this.tag5.Name = "tag5";
            // 
            // payload5
            // 
            this.payload5.HeaderText = "Payload";
            this.payload5.Name = "payload5";
            // 
            // tag6
            // 
            this.tag6.HeaderText = "Tag";
            this.tag6.Name = "tag6";
            // 
            // payload6
            // 
            this.payload6.HeaderText = "Payload";
            this.payload6.Name = "payload6";
            // 
            // tag7
            // 
            this.tag7.HeaderText = "Tag";
            this.tag7.Name = "tag7";
            // 
            // payload7
            // 
            this.payload7.HeaderText = "Payload";
            this.payload7.Name = "payload7";
            // 
            // tag8
            // 
            this.tag8.HeaderText = "Tag";
            this.tag8.Name = "tag8";
            // 
            // payload8
            // 
            this.payload8.HeaderText = "Payload";
            this.payload8.Name = "payload8";
            // 
            // L2Cache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1878, 745);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.l2cache_show);
            this.Name = "L2Cache";
            this.Text = "L2Cache";
            ((System.ComponentModel.ISupportInitialize)(this.l2cache_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView l2cache_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag1;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag2;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag3;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag4;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag5;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag6;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag7;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload7;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag8;
        private System.Windows.Forms.DataGridViewTextBoxColumn payload8;
    }
}