using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
	[ComplexType]
	public class ContentType {
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		
		[MaxLength(250)]
		public string Summary { get; set; }

		[Required]
		public string Text { get; set; }
	}
}
