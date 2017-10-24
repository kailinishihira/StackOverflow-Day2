using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflow.Models
{
	[Table("Answers")]
	public class Answer
	{
		[Key]
		public int AnswerId { get; set; }

		[Required]
		public string BodyContent { get; set; }

		public int Votes { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime PostDate { get; set; }

		public virtual ApplicationUser User { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public virtual ICollection<AnswerComment> AnswerComments { get; set; }
	}
}