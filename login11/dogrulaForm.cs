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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace login11
{
    public partial class dogrulaForm : Form
    {
        public dogrulaForm()
        {
            InitializeComponent();
        }
        public string dogrulamail;
        private void button1_Click(object sender, EventArgs e)
        {
            string token = tokenTxt.Text;
            VerifyUser(token);
        }
        public void VerifyUser(string token)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.VerificationToken == token);

                if (user != null)
                {
                    // Doğrulama kodunun süresi geçti mi kontrol et
                    if (user.VerificationTokenExpiry.HasValue && DateTime.Now > user.VerificationTokenExpiry.Value)
                    {
                        MessageBox.Show("Doğrulama kodunun süresi doldu. Lütfen yeniden kayıt olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!user.IsVerified)
                    {
                        user.IsVerified = true;
                        user.VerificationToken = null;
                        user.VerificationTokenExpiry = null; // Artık gerekli değil
                        context.SaveChanges();

                        MessageBox.Show("E-posta adresiniz başarıyla doğrulandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("E-posta zaten doğrulanmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz doğrulama kodu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void yenidenBtn_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == dogrulamail);

                string verificationToken = Guid.NewGuid().ToString();
                DateTime tokenExpiry = DateTime.Now.AddMinutes(5);


                user.VerificationToken = verificationToken;
                user.VerificationTokenExpiry = tokenExpiry;

                context.SaveChanges();
                var form1 = new Form1();
                form1.SendVerificationEmail(dogrulamail, verificationToken);
            }
        }
    }
}
