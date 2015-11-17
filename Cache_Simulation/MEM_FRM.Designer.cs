namespace Cache_Simulation
{
    partial class MEM_FRM
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
            this.mem_show = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mem_show)).BeginInit();
            this.SuspendLayout();
            // 
            // mem_show
            // 
            this.mem_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mem_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.val});
            this.mem_show.Location = new System.Drawing.Point(46, 141);
            this.mem_show.Name = "mem_show";
            this.mem_show.RowTemplate.Height = 28;
            this.mem_show.Size = new System.Drawing.Size(276, 414);
            this.mem_show.TabIndex = 0;
            // 
            // num
            // 
            this.num.HeaderText = "Address";
            this.num.Name = "num";
            // 
            // val
            // 
            this.val.HeaderText = "Value";
            this.val.Name = "val";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(92, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 29);
            this.label8.TabIndex = 30;
            this.label8.Text = "Page";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(192, 33);
            this.speed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(90, 26);
            this.speed.TabIndex = 29;
            this.speed.Text = "10";
            this.speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 31;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 32;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MEM_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 593);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.mem_show);
            this.Name = "MEM_FRM";
            this.Text = "MEM_FRM";
            ((System.ComponentModel.ISupportInitialize)(this.mem_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mem_show;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn val;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}