namespace GroupProjectDJT
{
    partial class ReservationDetails
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
            this.reservaionDetailsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelReservationButton = new System.Windows.Forms.Button();
            this.seatsReservedLabel = new System.Windows.Forms.Label();
            this.eventDateLabel = new System.Windows.Forms.Label();
            this.eventNameLabel = new System.Windows.Forms.Label();
            this.reservaionDetailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservaionDetailsPanel
            // 
            this.reservaionDetailsPanel.Controls.Add(this.button1);
            this.reservaionDetailsPanel.Controls.Add(this.label3);
            this.reservaionDetailsPanel.Controls.Add(this.label1);
            this.reservaionDetailsPanel.Controls.Add(this.cancelReservationButton);
            this.reservaionDetailsPanel.Controls.Add(this.seatsReservedLabel);
            this.reservaionDetailsPanel.Controls.Add(this.eventDateLabel);
            this.reservaionDetailsPanel.Controls.Add(this.eventNameLabel);
            this.reservaionDetailsPanel.Location = new System.Drawing.Point(12, 12);
            this.reservaionDetailsPanel.Name = "reservaionDetailsPanel";
            this.reservaionDetailsPanel.Size = new System.Drawing.Size(760, 522);
            this.reservaionDetailsPanel.TabIndex = 0;
            this.reservaionDetailsPanel.Tag = "Reservation Details";
            this.reservaionDetailsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.reservaionDetailsPanel_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 75);
            this.button1.TabIndex = 5;
            this.button1.Text = "Finalize reservation!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "login status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "cost";
            // 
            // cancelReservationButton
            // 
            this.cancelReservationButton.AutoSize = true;
            this.cancelReservationButton.Location = new System.Drawing.Point(322, 205);
            this.cancelReservationButton.Name = "cancelReservationButton";
            this.cancelReservationButton.Size = new System.Drawing.Size(110, 23);
            this.cancelReservationButton.TabIndex = 1;
            this.cancelReservationButton.Text = "Cancel Reservation";
            this.cancelReservationButton.UseVisualStyleBackColor = true;
            this.cancelReservationButton.Click += new System.EventHandler(this.cancelReservationButton_Click);
            // 
            // seatsReservedLabel
            // 
            this.seatsReservedLabel.AutoSize = true;
            this.seatsReservedLabel.Location = new System.Drawing.Point(334, 177);
            this.seatsReservedLabel.Name = "seatsReservedLabel";
            this.seatsReservedLabel.Size = new System.Drawing.Size(88, 13);
            this.seatsReservedLabel.TabIndex = 0;
            this.seatsReservedLabel.Text = "<seats reserved>";
            // 
            // eventDateLabel
            // 
            this.eventDateLabel.AutoSize = true;
            this.eventDateLabel.Location = new System.Drawing.Point(334, 148);
            this.eventDateLabel.Name = "eventDateLabel";
            this.eventDateLabel.Size = new System.Drawing.Size(70, 13);
            this.eventDateLabel.TabIndex = 0;
            this.eventDateLabel.Text = "<event date>";
            // 
            // eventNameLabel
            // 
            this.eventNameLabel.AutoSize = true;
            this.eventNameLabel.Location = new System.Drawing.Point(334, 120);
            this.eventNameLabel.Name = "eventNameLabel";
            this.eventNameLabel.Size = new System.Drawing.Size(75, 13);
            this.eventNameLabel.TabIndex = 0;
            this.eventNameLabel.Text = "<event name>";
            // 
            // ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.reservaionDetailsPanel);
            this.Name = "ReservationDetails";
            this.Text = "ReservationDetails";
            this.reservaionDetailsPanel.ResumeLayout(false);
            this.reservaionDetailsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel reservaionDetailsPanel;
        private System.Windows.Forms.Label eventNameLabel;
        private System.Windows.Forms.Label eventDateLabel;
        private System.Windows.Forms.Button cancelReservationButton;
        private System.Windows.Forms.Label seatsReservedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}