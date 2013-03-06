namespace CSharpWin.Apps
{
    partial class FrmDemo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowMsg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowMsg
            // 
            this.btnShowMsg.Location = new System.Drawing.Point(144, 73);
            this.btnShowMsg.Name = "btnShowMsg";
            this.btnShowMsg.Size = new System.Drawing.Size(75, 23);
            this.btnShowMsg.TabIndex = 0;
            this.btnShowMsg.Text = "Show Message";
            this.btnShowMsg.UseVisualStyleBackColor = true;
            this.btnShowMsg.Click += new System.EventHandler(this.btnShowMsgClick);
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowMsg);
            this.Name = "frmDemo";
            this.Size = new System.Drawing.Size(386, 182);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowMsg;
    }
}
