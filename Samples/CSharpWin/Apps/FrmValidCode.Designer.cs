namespace CSharpWin.Apps
{
    partial class FrmValidCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtValidCode = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.picValidCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入验证码 :";
            // 
            // txtValidCode
            // 
            this.txtValidCode.Location = new System.Drawing.Point(96, 51);
            this.txtValidCode.Name = "txtValidCode";
            this.txtValidCode.Size = new System.Drawing.Size(128, 20);
            this.txtValidCode.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(96, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "登录";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // picValidCode
            // 
            this.picValidCode.Location = new System.Drawing.Point(248, 51);
            this.picValidCode.Name = "picValidCode";
            this.picValidCode.Size = new System.Drawing.Size(85, 20);
            this.picValidCode.TabIndex = 3;
            this.picValidCode.TabStop = false;
            this.picValidCode.Click += new System.EventHandler(this.picValidCodeClick);
            // 
            // FrmValidCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picValidCode);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValidCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmValidCode";
            this.Size = new System.Drawing.Size(402, 138);
            this.Load += new System.EventHandler(this.FrmValidCodeLoad);
            ((System.ComponentModel.ISupportInitialize)(this.picValidCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValidCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox picValidCode;
    }
}
