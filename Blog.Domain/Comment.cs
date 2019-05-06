using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Blog.Domain {
	public class Comment {
		[Key]
		public int ID { get; set; }

		[Required]
		[MaxLength(500)]
		public string Text { get; set; }

		[Required]
		public DateTime DateCreated { get; set; } = DateTime.Now;

		[Required]
		public bool IsDeleted { get; set; }

		[Required]
		public virtual Content Content { get; set; }

		[Required]
		public virtual User Creator { get; set; }
	}
}
