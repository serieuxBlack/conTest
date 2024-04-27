namespace ClientApp
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ackButton;

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
            ackButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ackButton
            // 
            ackButton.Location = new System.Drawing.Point(58, 58);
            ackButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ackButton.Name = "ackButton";
            ackButton.Size = new System.Drawing.Size(117, 46);
            ackButton.TabIndex = 0;
            ackButton.Text = "ACK";
            ackButton.UseVisualStyleBackColor = true;
            ackButton.Click += ackButton_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(233, 173);
            Controls.Add(ackButton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ClientForm";
            Text = "Client";
            ResumeLayout(false);
        }

        #endregion
    }
}
