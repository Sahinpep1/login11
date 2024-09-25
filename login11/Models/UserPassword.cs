using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login11.Models
{
    public class UserPassword
    {
        
            [Key]
            public int Id { get; set; }

            [Required]
            public string PasswordHash { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; }

            [ForeignKey("User")]
            public int UserId { get; set; }

            public virtual User User { get; set; }
    }
}
