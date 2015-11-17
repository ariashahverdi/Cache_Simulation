namespace Cache_Simulation
{
    partial class PT_FRM
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
            this.pt_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.virtual_addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physical_addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pt_show)).BeginInit();
            this.SuspendLayout();
            // 
            // pt_show
            // 
            this.pt_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pt_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.virtual_addr,
            this.physical_addr});
            this.pt_show.Location = new System.Drawing.Point(53, 41);
            this.pt_show.Name = "pt_show";
            this.pt_show.RowTemplate.Height = 28;
            this.pt_show.Size = new System.Drawing.Size(373, 524);
            this.pt_show.TabIndex = 38;
            // 
            // num
            // 
            this.num.HeaderText = "#";
            this.num.Name = "num";
            // 
            // virtual_addr
            // 
            this.virtual_addr.HeaderText = "Virtual";
            this.virtual_addr.Name = "virtual_addr";
            // 
            // physical_addr
            // 
            this.physical_addr.HeaderText = "Physical";
            this.physical_addr.Name = "physical_addr";
            // 
            // PT_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 595);
            this.Controls.Add(this.pt_show);
            this.Name = "PT_FRM";
            this.Text = "PT_Frm";
            ((System.ComponentModel.ISupportInitialize)(this.pt_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView pt_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn virtual_addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn physical_addr;
    }
}