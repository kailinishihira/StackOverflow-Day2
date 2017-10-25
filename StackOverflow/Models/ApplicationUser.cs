using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StackOverflow.Models
{
	public class ApplicationUser : IdentityUser
	{
  //      public virtual ICollection<Question>Questions
  //      {
  //          get;
  //          set;
  //      }
  //      public virtual ICollection<Answer> Answers
		//{
		//	get;
		//	set;
		//}
  //      public virtual ICollection<AnswerComment> AnswerComments
		//{
		//	get;
		//	set;
		//}
  //      public virtual ICollection<QuestionComment> QuestionComments
		//{
		//	get;
		//	set;
		//}

        //public static implicit operator ApplicationUser(ClaimsPrincipal v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}