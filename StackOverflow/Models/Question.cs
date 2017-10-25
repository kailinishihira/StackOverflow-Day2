using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
	[Table("Questions")]
	public class Question
	{
		[Key]
		public int QuestionId { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
        [Display(Name = "Question Content")]
		public string BodyContent { get; set; }

        [Required]
        public string Tag { get; set; }

		public bool IsClosed { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime PostDate { get; set; }

		public virtual ApplicationUser User { get; set; }

		public virtual ICollection<Answer> Answers { get; set; }

		public virtual ICollection<QuestionComment> QuestionComments { get; set; }


		public override bool Equals(System.Object otherQuestion)
		{
			if (!(otherQuestion is Question))
			{
				return false;
			}
			else
			{
				Question newQuestion = (Question)otherQuestion;
				return this.QuestionId.Equals(newQuestion.QuestionId);

			}
		}

		public override int GetHashCode()
		{

			return this.QuestionId.GetHashCode();
		}

	}
}