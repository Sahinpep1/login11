using login11.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login11
{
    public partial class girisForm : Form
    {
        public girisForm()
        {
            InitializeComponent();
        }

        private void SıgnupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1();
            Form1.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email = UsernameTxt.Text.Trim();
            string password = PasswordTxt.Text.Trim();

            // Temel doğrulama
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen e-posta ve şifrenizi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                // Kullanıcıyı e-posta ile bul
                var user = context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    MessageBox.Show("E-posta veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parola doğrulaması
                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    MessageBox.Show("E-posta veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcı e-posta doğrulamasını yaptı mı?
                if (!user.IsVerified)
                {
                    MessageBox.Show("Lütfen önce e-posta adresinizi doğrulayın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    var dogrula = new dogrulaForm();
                    dogrula.Show();
                    dogrula.dogrulamail = email;
                    return;
                }
                if (user.PasswordLastChanged.AddDays(30) <= DateTime.Now)
                {
                    MessageBox.Show("Şifrenizi 30 günde bir yenilemeniz gerekiyor.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Oturum açma başarılı
                MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Burada oturum açma işlemi sonrası yapılacakları ekleyebilirsiniz
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var sifredegisForm = new sifredegisForm();
            sifredegisForm.Show();
        }
    }
}
