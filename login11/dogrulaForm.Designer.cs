namespace login11
{
    partial class dogrulaForm
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
            this.tokenTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.yenidenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tokenTxt
            // 
            this.tokenTxt.Location = new System.Drawing.Point(216, 140);
            this.tokenTxt.Name = "tokenTxt";
            this.tokenTxt.Size = new System.Drawing.Size(100, 20);
            this.tokenTxt.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Doğrula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yenidenBtn
            // 
            this.yenidenBtn.Location = new System.Drawing.Point(216, 222);
            this.yenidenBtn.Name = "yenidenBtn";
            this.yenidenBtn.Size = new System.Drawing.Size(75, 23);
            this.yenidenBtn.TabIndex = 2;
            this.yenidenBtn.Text = "Yeniden Gönder";
            this.yenidenBtn.UseVisualStyleBackColor = true;
            this.yenidenBtn.Click += new System.EventHandler(this.yenidenBtn_Click);
            // 
            // dogrulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.yenidenBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tokenTxt);
            this.Name = "dogrulaForm";
            this.Text = "dogrulaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tokenTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button yenidenBtn;
    }
}