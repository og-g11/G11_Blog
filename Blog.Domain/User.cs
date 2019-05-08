using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VarChar")]
        public string Email { get; set; }

        //ToDo: Paroli Hashirebuli
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
