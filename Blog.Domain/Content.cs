using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Domain
{
    public class Content
    {
       [Key]
       public int ContentID { get; set; }
       [Required]
       [MaxLength(50)]
       public string ContentTitle { get; set; }
       [Required]
       public string ContentText { get; set; }
       [Required]
       public DateTime DateCreated { get; set; }
       [Required]
       public bool IsCreated { get; set; }
       [Required]
       public bool IsPublic { get; set; }
       [Required]
       public bool IsDeleted { get; set; }
       [Required]
       public virtual User Creator { get; set; }
       [Required]
       public virtual Category Category {get; set;}
    }
}
