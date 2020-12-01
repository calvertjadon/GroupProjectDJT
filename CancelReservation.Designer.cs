namespace GroupProjectDJT
{
    partial class CancelReservation
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
            this.cancelReservationPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.reservationIdTextBox = new System.Windows.Forms.TextBox();
            this.cancelReservationButton = new System.Windows.Forms.Button();
            this.cancelReservationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelReservationPanel
            // 
            this.cancelReservationPanel.Controls.Add(this.cancelReservationButton);
            this.cancelReservationPanel.Controls.Add(this.reservationIdTextBox);
            this.cancelReservationPanel.Controls.Add(this.label1);
            this.cancelReservationPanel.Location = new System.Drawing.Point(13, 13);
            this.cancelReservationPanel.Name = "cancelReservationPanel";
            this.cancelReservationPanel.Size = new System.Drawing.Size(760, 522);
            this.cancelReservationPanel.TabIndex = 0;
            this.cancelReservationPanel.Tag = "Cancel Reservation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation ID: ";
            // 
            // reservationIdTextBox
            // 
            this.reservationIdTextBox.Location = new System.Drawing.Point(374, 150);
            this.reservationIdTextBox.Name = "reservationIdTextBox";
            this.reservationIdTextBox.Size = new System.Drawing.Size(134, 20);
            this.reservationIdTextBox.TabIndex = 1;
            // 
            // cancelReservationButton
            // 
            this.cancelReservationButton.AutoSize = true;
            this.cancelReservationButton.Location = new System.Drawing.Point(341, 190);
            this.cancelReservationButton.Name = "cancelReservationButton";
            this.cancelReservationButton.Size = new System.Drawing.Size(110, 23);
            this.cancelReservationButton.TabIndex = 2;
            this.cancelReservationButton.Text = "Cancel Reservation";
            this.cancelReservationButton.UseVisualStyleBackColor = true;
            this.cancelReservationButton.Click += new System.EventHandler(this.cancelReservationButton_Click);
            // 
            // CancelReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 551);
            this.Controls.Add(this.cancelReservationPanel);
            this.Name = "CancelReservation";
            this.Text = "CancelReservation";
            this.cancelReservationPanel.ResumeLayout(false);
            this.cancelReservationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cancelReservationPanel;
        private System.Windows.Forms.Button cancelReservationButton;
        private System.Windows.Forms.TextBox reservationIdTextBox;
        private System.Windows.Forms.Label label1;
    }
}