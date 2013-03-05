namespace CSharpWin
{
    partial class FrmShortCuts
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(99, 38);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(194, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Shortcut for FSCapture";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreateClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Shortcut for Web";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCreateWebShortcutClick);
            // 
            // FrmShortCuts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 152);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.Name = "FrmShortCuts";
            this.Text = "Create Shortcuts on Desktop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button1;
    }
}

