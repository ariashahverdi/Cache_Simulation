namespace Cache_Simulation
{
    partial class iTLB_FRM
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
            this.itlb_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itlb_show)).BeginInit();
            this.SuspendLayout();
            // 
            // itlb_show
            // 
            this.itlb_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itlb_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.bank1,
            this.bank2,
            this.bank3,
            this.bank4});
            this.itlb_show.Location = new System.Drawing.Point(55, 30);
            this.itlb_show.Name = "itlb_show";
            this.itlb_show.RowTemplate.Height = 28;
            this.itlb_show.Size = new System.Drawing.Size(570, 930);
            this.itlb_show.TabIndex = 3;
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
            // iTLB_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 1005);
            this.Controls.Add(this.itlb_show);
            this.Name = "iTLB_FRM";
            this.Text = "iTLB";
            ((System.ComponentModel.ISupportInitialize)(this.itlb_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView itlb_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank3;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank4;
    }
}

