namespace GroupProjectDJT
{
    partial class Events
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
            this.eventsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.eventsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventsPanel
            // 
            this.eventsPanel.Controls.Add(this.label1);
            this.eventsPanel.Location = new System.Drawing.Point(12, 12);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(760, 522);
            this.eventsPanel.TabIndex = 0;
            this.eventsPanel.Tag = "Events";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "events";
            // 
            // Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 553);
            this.Controls.Add(this.eventsPanel);
            this.Name = "Events";
            this.Text = "Events";
            this.eventsPanel.ResumeLayout(false);
            this.eventsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel eventsPanel;
        private System.Windows.Forms.Label label1;
    }
}