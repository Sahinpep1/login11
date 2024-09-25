namespace login11
{
    partial class sifredegisForm
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
            this.eskiTxt = new System.Windows.Forms.TextBox();
            this.yeniTxt = new System.Windows.Forms.TextBox();
            this.kntrlTxt = new System.Windows.Forms.TextBox();
            this.degisButton = new System.Windows.Forms.Button();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eskiTxt
            // 
            this.eskiTxt.Location = new System.Drawing.Point(153, 93);
            this.eskiTxt.Name = "eskiTxt";
            this.eskiTxt.Size = new System.Drawing.Size(100, 20);
            this.eskiTxt.TabIndex = 0;
            // 
            // yeniTxt
            // 
            this.yeniTxt.Location = new System.Drawing.Point(153, 143);
            this.yeniTxt.Name = "yeniTxt";
            this.yeniTxt.Size = new System.Drawing.Size(100, 20);
            this.yeniTxt.TabIndex = 1;
            // 
            // kntrlTxt
            // 
            this.kntrlTxt.Location = new System.Drawing.Point(153, 187);
            this.kntrlTxt.Name = "kntrlTxt";
            this.kntrlTxt.Size = new System.Drawing.Size(100, 20);
            this.kntrlTxt.TabIndex = 2;
            // 
            // degisButton
            // 
            this.degisButton.Location = new System.Drawing.Point(153, 229);
            this.degisButton.Name = "degisButton";
            this.degisButton.Size = new System.Drawing.Size(75, 23);
            this.degisButton.TabIndex = 3;
            this.degisButton.Text = "Değiştir";
            this.degisButton.UseVisualStyleBackColor = true;
            this.degisButton.Click += new System.EventHandler(this.degisButton_Click);
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(153, 38);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(100, 20);
            this.emailTxt.TabIndex = 4;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(379, 229);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 5;
            this.backBtn.Text = "Geri";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mevcut Şifre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Yeni Şifre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Şifre Kontrol";
            // 
            // sifredegisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.degisButton);
            this.Controls.Add(this.kntrlTxt);
            this.Controls.Add(this.yeniTxt);
            this.Controls.Add(this.eskiTxt);
            this.Name = "sifredegisForm";
            this.Text = "sifredegisForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eskiTxt;
        private System.Windows.Forms.TextBox yeniTxt;
        private System.Windows.Forms.TextBox kntrlTxt;
        private System.Windows.Forms.Button degisButton;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}