namespace barez_computer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lstcommands = new System.Windows.Forms.ListBox();
            this.TmrSpiking = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lstcommands
            // 
            this.lstcommands.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstcommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstcommands.ForeColor = System.Drawing.SystemColors.Window;
            this.lstcommands.FormattingEnabled = true;
            this.lstcommands.Location = new System.Drawing.Point(0, 0);
            this.lstcommands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstcommands.Name = "lstcommands";
            this.lstcommands.Size = new System.Drawing.Size(411, 358);
            this.lstcommands.TabIndex = 0;
            this.lstcommands.Visible = false;
            // 
            // TmrSpiking
            // 
            this.TmrSpiking.Enabled = true;
            this.TmrSpiking.Interval = 1000;
            this.TmrSpiking.Tick += new System.EventHandler(this.TmrSpiking_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(411, 358);
            this.Controls.Add(this.lstcommands);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstcommands;
        private System.Windows.Forms.Timer TmrSpiking;
    }
}

