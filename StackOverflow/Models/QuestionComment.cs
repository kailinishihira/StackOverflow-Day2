using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Models
{
	[Table("QuestionComments")]
	public class QuestionComment
	{
		[Key]
		public int QuestionCommentId { get; set; }

		[Required]
		public string BodyContent { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime PostDate { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public virtual ApplicationUser User { get; set; }

	}
}