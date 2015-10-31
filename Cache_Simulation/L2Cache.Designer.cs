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
            this.l2cache_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.l2cache_show)).BeginInit();
            this.SuspendLayout();
            // 
            // l2cache_show
            // 
            this.l2cache_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.l2cache_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.bank1,
            this.bank2,
            this.bank3,
            this.bank4,
            this.bank5,
            this.bank6,
            this.bank7,
            this.bank8});
            this.l2cache_show.Location = new System.Drawing.Point(43, 71);
            this.l2cache_show.Name = "l2cache_show";
            this.l2cache_show.RowTemplate.Height = 28;
            this.l2cache_show.Size = new System.Drawing.Size(1000, 600);
            this.l2cache_show.TabIndex = 2;
            this.l2cache_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.l2cache_show_CellContentClick);
            // 
            // num
            // 
            this.num.HeaderText = "#";
            this.num.Name = "num";
            // 
            // bank1
            // 
            this.bank1.HeaderText = "Bank 1";
            this.bank1.Name = "bank1";
            // 
            // bank2
            // 
            this.bank2.HeaderText = "Bank 2";
            this.bank2.Name = "bank2";
            // 
            // bank3
            // 
            this.bank3.HeaderText = "Bank 3";
            this.bank3.Name = "bank3";
            // 
            // bank4
            // 
            this.bank4.HeaderText = "Bank 4";
            this.bank4.Name = "bank4";
            // 
            // bank5
            // 
            this.bank5.HeaderText = "Bank 5";
            this.bank5.Name = "bank5";
            // 
            // bank6
            // 
            this.bank6.HeaderText = "Bank 6";
            this.bank6.Name = "bank6";
            // 
            // bank7
            // 
            this.bank7.HeaderText = "Bank 7";
            this.bank7.Name = "bank7";
            // 
            // bank8
            // 
            this.bank8.HeaderText = "Bank 8";
            this.bank8.Name = "bank8";
            // 
            // L2Cache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 745);
            this.Controls.Add(this.l2cache_show);
            this.Name = "L2Cache";
            this.Text = "L2Cache";
            ((System.ComponentModel.ISupportInitialize)(this.l2cache_show)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView l2cache_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank3;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank4;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank5;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank6;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank7;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank8;
    }
}