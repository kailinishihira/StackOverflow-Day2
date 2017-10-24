using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflow.Models
{
	[Table("Tags")]
	public class Tag
	{
		[Key]
		public int TagId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

	}
}