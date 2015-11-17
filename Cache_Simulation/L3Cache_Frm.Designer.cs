namespace Cache_Simulation
{
    partial class L3Cache_FRM
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
            this.l3cache_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cache_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.l3cache_show)).BeginInit();
            this.SuspendLayout();
            // 
            // l3cache_show
            // 
            this.l3cache_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.l3cache_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.cache_data});
            this.l3cache_show.Location = new System.Drawing.Point(45, 67);
            this.l3cache_show.Name = "l3cache_show";
            this.l3cache_show.RowTemplate.Height = 28;
            this.l3cache_show.Size = new System.Drawing.Size(288, 450);
            this.l3cache_show.TabIndex = 39;
            this.l3cache_show.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.l3cache_show_CellContentClick);
            // 
            // num
            // 
            this.num.HeaderText = "Bank #";
            this.num.Name = "num";
            // 
            // cache_data
            // 
            this.cache_data.HeaderText = "Data";
            this.cache_data.Name = "cache_data";
            // 
            // L3Cache_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 595);
            this.Controls.Add(this.l3cache_show);
            this.Name = "L3Cache_FRM";
            this.Text = "L3Cache_Frm";
            ((System.ComponentModel.ISupportInitialize)(this.l3cache_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView l3cache_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn cache_data;
    }
}