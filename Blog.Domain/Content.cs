using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Domain {
	public class Content {
		[Key]
		public int ID { get; set; }

		public ContentType Live { get; set; }

		public ContentType Draft { get; set; }

		[Required]
		public DateTime DateCreated { get; set; } = DateTime.Now;
		
		[Required]
		public bool IsPublic { get; set; }

		[Required]
		public bool IsDeleted { get; set; }

		[Required]
		public virtual User Creator { get; set; }

		[Required]
		public virtual Category Category { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }
	}
}
