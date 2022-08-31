using System;
using System.ComponentModel.DataAnnotations;

namespace Project.AVIew.EF.Entities.User
{
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string HashedPin { get; set; }
        [Required]
        public DateTime Updated { get; set; }
    }
}
