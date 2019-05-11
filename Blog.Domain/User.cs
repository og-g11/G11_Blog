using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Blog.Domain
{
    public class User
    {   [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName {get; set;}
        [Required]
        [MaxLength(50)]
        public string Password {get; set;}
        [Required]
        public bool IsDeleted {get; set;}
    }
}
