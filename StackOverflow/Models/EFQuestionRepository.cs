using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Models
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private ApplicationDbContext db;
        public EFQuestionRepository(ApplicationDbContext connection = null)
        {
            if (connection == null)
            {
                db = new ApplicationDbContext();
            }
            else
            {
                db = connection;
            }
        }

        public IQueryable<Question> Questions => db.Questions;

        public bool Edit(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Remove(Question question)
        {
            db.Questions.Remove(question);
            db.SaveChanges();
            return true;
        }

        public bool Save(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return true;
        }
    }
}