using System;
using System.ComponentModel.DataAnnotations;

namespace Project.AVIew.EF.Entities.User
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHashed { get; set; }
        [Required]
        public DateTime Updated { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
