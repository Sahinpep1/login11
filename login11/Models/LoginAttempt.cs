using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login11.Models
{
    public class LoginAttempt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime AttemptedAt { get; set; }

        [Required]
        public bool IsSuccessful { get; set; }

        public string FailureReason { get; set; } // Eğer giriş başarısızsa nedeni burada tutabiliriz
    }
}
