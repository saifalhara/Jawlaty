using Jawlaty.Models;

namespace Jawlaty.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetQuestion();

        Task AddQuestion(Question Questionobj);

        Task UpdateQuestion(Question Questionobj);

        Task DeleteQuestion(int QuestionID);

        Task<Question> GetByID(int QuestionID);

    }
}
