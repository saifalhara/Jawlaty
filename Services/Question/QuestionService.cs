
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly JawlatyDbContext _dbcontext;

        public QuestionService(JawlatyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddQuestion(Question Questionobj)
        {
            await _dbcontext.Question.AddAsync(Questionobj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int QuestionID)
        {
            Question? Questionobj = await _dbcontext.Question.SingleOrDefaultAsync(x => x.ID == QuestionID);
            if (Questionobj is not null)
            {
                _dbcontext.Question.Remove(Questionobj);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<Question> GetByID(int QuestionID)
        {
            Question? Questionobj = await _dbcontext.Question.SingleOrDefaultAsync(x => x.ID == QuestionID);
            if (Questionobj is not null)
            {
                return Questionobj;
            }
            return null ?? new Question();
        }

        public async Task<IEnumerable<Question>> GetQuestion()
        {
            return await _dbcontext.Question.AsNoTracking().OrderBy(x=>x.ID).ToListAsync();
        }

        public async Task UpdateQuestion(Question Questionobj)
        {
            Question? QuestionUpdateObj = await _dbcontext.Question.AsNoTracking().SingleOrDefaultAsync(x => x.ID == Questionobj.ID);
            if (QuestionUpdateObj is not null)
            {
                _dbcontext.Question.Update(Questionobj);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
