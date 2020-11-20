namespace GroupProjectDJT
{
    partial class ShowEvents
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.showEventsPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.showEventsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here are all events currently available for reservations!";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(151, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(371, 214);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showEventsPanel
            // 
            this.showEventsPanel.Controls.Add(this.dataGridView1);
            this.showEventsPanel.Controls.Add(this.button1);
            this.showEventsPanel.Controls.Add(this.label1);
            this.showEventsPanel.Location = new System.Drawing.Point(12, 12);
            this.showEventsPanel.Name = "showEventsPanel";
            this.showEventsPanel.Size = new System.Drawing.Size(760, 522);
            this.showEventsPanel.TabIndex = 3;
            this.showEventsPanel.Tag = "Show Events";
            // 
            // ShowEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 546);
            this.Controls.Add(this.showEventsPanel);
            this.Name = "ShowEvents";
            this.Text = "ShowEvents";
            this.Load += new System.EventHandler(this.ShowEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.showEventsPanel.ResumeLayout(false);
            this.showEventsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel showEventsPanel;
    }
}