using login11.Data;
using login11.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using System.Net.Mail;
using System.Net;

namespace login11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();
            // Temel doğrulama
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                // E-posta zaten kullanılıyor mu kontrolü
                var existingUser = context.Users.FirstOrDefault(u => u.Email == email);
                if (existingUser != null)
                {
                    MessageBox.Show("Bu e-posta zaten kullanılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parola hashleme
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                // E-posta doğrulama token'ı oluşturma (isteğe bağlı)
                string verificationToken = Guid.NewGuid().ToString();
                DateTime tokenExpiry = DateTime.Now.AddMinutes(5);

                // Yeni kullanıcı oluşturma
                var user = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordHash,
                    VerificationToken = verificationToken,
                    VerificationTokenExpiry = tokenExpiry,
                    PasswordLastChanged = DateTime.Now
                };
                var userpass = new UserPassword
                {
                    PasswordHash = passwordHash,
                    CreatedAt = DateTime.Now,
                };

                context.Users.Add(user);
                context.UserPasswords.Add(userpass);
                context.SaveChanges();

                SendVerificationEmail(email, verificationToken);
                MessageBox.Show("Kayıt başarılı! Lütfen e-posta adresinizi doğrulayın.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }


    public void SendVerificationEmail(string recipientEmail, string verificationToken)
    {
        // SMTP istemcisi için yapılandırma
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("sahinpepsi@gmail.com", "hhwy rnyi yxzm glbi"), // Gmail uygulama şifresi
            EnableSsl = true, // Güvenli bağlantı kullan
        };

        // E-posta içeriği
        var mailMessage = new MailMessage
        {
            From = new MailAddress("sahinpepsi@gmail.com"),
            Subject = "Email Doğrulama",
            Body = $"Doğrulama kodunuz aşağıdadır: \n\n {verificationToken}",
            IsBodyHtml = false, // Düz metin
        };

        mailMessage.To.Add(recipientEmail);

        try
        {
            smtpClient.Send(mailMessage);
            MessageBox.Show("Doğrulama e-postası gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"E-posta gönderilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var girisForm = new girisForm();
            girisForm.Show();
        }
    }
}
