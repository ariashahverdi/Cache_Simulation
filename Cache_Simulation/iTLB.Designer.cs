namespace Cache_Simulation
{
    partial class iTLB
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
            this.label60 = new System.Windows.Forms.Label();
            this.itlb_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.SystemColors.Control;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(171, 129);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(475, 32);
            this.label60.TabIndex = 18;
            this.label60.Text = "Status of iTLB will be shown here.";
            // 
            // itlb_close
            // 
            this.itlb_close.Location = new System.Drawing.Point(335, 331);
            this.itlb_close.Name = "itlb_close";
            this.itlb_close.Size = new System.Drawing.Size(120, 46);
            this.itlb_close.TabIndex = 19;
            this.itlb_close.Text = "close";
            this.itlb_close.UseVisualStyleBackColor = true;
            this.itlb_close.Click += new System.EventHandler(this.itlb_close_Click);
            // 
            // iTLB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 395);
            this.Controls.Add(this.itlb_close);
            this.Controls.Add(this.label60);
            this.Name = "iTLB";
            this.Text = "iTLB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button itlb_close;
    }
}

