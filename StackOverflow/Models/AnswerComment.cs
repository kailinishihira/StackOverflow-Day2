using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Models
{
	[Table("AnswerComments")]
	public class AnswerComment
	{
		[Key]
		public int AnswerCommentId { get; set; }

		[Required]
		public string BodyContent { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime PostDate { get; set; }

		public int AnswerId { get; set; }
		public virtual Answer Answer { get; set; }

		public virtual ApplicationUser User { get; set; }

	}
}