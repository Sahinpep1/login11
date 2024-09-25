using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login11.Models
{
    public class User
    {
        [Key] // Anahtar alan
        public int Id { get; set; }

        [Required] // Zorunlu alan
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [Index(IsUnique = true)] // Eşsiz indeks
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool IsVerified { get; set; } = false; // Varsayılan değer
        public string VerificationToken { get; set; }
        public DateTime PasswordLastChanged { get; set; } // Şifre değişiklik tarihi
        public DateTime? VerificationTokenExpiry { get; set; }
        public virtual ICollection<UserPassword> PreviousPasswords { get; set; } // Önceki şifreler
    }
}
