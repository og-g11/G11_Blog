using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Blog.Domain
{
    public class Comment
    {   [Key]
        public int CommentID {get; set;}
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public virtual Content Content { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
