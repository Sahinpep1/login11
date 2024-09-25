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
using login11.Models;

namespace login11
{
    public partial class sifredegisForm : Form
    {
        public sifredegisForm()
        {
            InitializeComponent();
        }

        private void degisButton_Click(object sender, EventArgs e)
        {
            string newPassword = yeniTxt.Text.Trim();
            string confirmPassword = kntrlTxt.Text.Trim();
            string email = emailTxt.Text.Trim();
            string oldPass = emailTxt.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                // Get the current user (you can modify this based on your login system)
                var user = context.Users.FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check the last three passwords
                var lastThreePasswords = context.UserPasswords
                    .Where(up => up.UserId == user.Id)
                    .OrderByDescending(up => up.CreatedAt)
                    .Take(3)
                    .Select(up => up.PasswordHash)
                    .ToList();

                if (lastThreePasswords.Any(p => BCrypt.Net.BCrypt.Verify(newPassword, p)))
                {
                    MessageBox.Show("Yeni şifreniz, son üç şifrenizden biriyle aynı olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the password
                string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                user.PasswordHash = newPasswordHash;
                user.PasswordLastChanged = DateTime.Now;

                // Add the new password to UserPassword history
                var userPassword = new UserPassword
                {
                    UserId = user.Id,
                    PasswordHash = newPasswordHash,
                    CreatedAt = DateTime.Now
                };

                context.UserPasswords.Add(userPassword);
                context.SaveChanges();

                MessageBox.Show("Şifreniz başarıyla değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var girisForm = new girisForm();
            girisForm.Show();
        }
    
    }
}
