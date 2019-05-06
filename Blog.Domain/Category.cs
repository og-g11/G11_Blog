using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain {
	public class Category {
		[Key]
		public int ID { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		
		[MaxLength(250)]
		public string Description { get; set; }

		[Required]
		public bool IsDeleted { get; set; }
	}
}
