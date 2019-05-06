using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Blog.Domain {
	/*ToDo:
	 * gavaketot content ze shemdegi bma:
	 * contents unda qondes 1 listingis da 1 cover is photo (shesadzloa nullable ic).
	 * aseve contents unda qondes mravali suratis mibmis sashualeba (tviton content shi).
	 */
	public class Photo {
		[Key]
		public int ID { get; set; }

		[Required]
		[MaxLength(50)]
		public string OriginalFileName { get; set; }

		[NotMapped]
		public string FileName => $"Photo_{ID}.{Path.GetExtension(OriginalFileName)}";

		[Required]
		public virtual Content Content { get; set; }
	}

	public enum PhotoType : byte {
		Cover = 0,
		Listing = 1,
		Content = 2,
	}
}
