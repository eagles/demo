namespace ProgressBarEx
{
    partial class ProgressBarDemo
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
            this.btnShowProgressBar = new System.Windows.Forms.Button();
            this.btnShowPerProgressBar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowProgressBar
            // 
            this.btnShowProgressBar.Location = new System.Drawing.Point(188, 88);
            this.btnShowProgressBar.Name = "btnShowProgressBar";
            this.btnShowProgressBar.Size = new System.Drawing.Size(202, 23);
            this.btnShowProgressBar.TabIndex = 0;
            this.btnShowProgressBar.Text = "Show Progress Bar";
            this.btnShowProgressBar.UseVisualStyleBackColor = true;
            this.btnShowProgressBar.Click += new System.EventHandler(this.btnShowProgressBar_Click);
            // 
            // btnShowPerProgressBar
            // 
            this.btnShowPerProgressBar.Location = new System.Drawing.Point(188, 163);
            this.btnShowPerProgressBar.Name = "btnShowPerProgressBar";
            this.btnShowPerProgressBar.Size = new System.Drawing.Size(202, 23);
            this.btnShowPerProgressBar.TabIndex = 0;
            this.btnShowPerProgressBar.Text = "Show Percentage Progress Bar";
            this.btnShowPerProgressBar.UseVisualStyleBackColor = true;
            this.btnShowPerProgressBar.Click += new System.EventHandler(this.btnShowPerProgressBar_Click);
            // 
            // ProgressBarDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 268);
            this.Controls.Add(this.btnShowPerProgressBar);
            this.Controls.Add(this.btnShowProgressBar);
            this.Name = "ProgressBarDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress Bar by Background Worker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowProgressBar;
        private System.Windows.Forms.Button btnShowPerProgressBar;
    }
}

