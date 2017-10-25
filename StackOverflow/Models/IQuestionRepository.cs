using System;
using System.Linq;

namespace StackOverflow.Models
{
    public interface IQuestionRepository
    {
        IQueryable<Question> Questions { get; }
        bool Save(Question question);
        bool Edit(Question question);
        bool Remove(Question question);
    }
}
