

using ExaminationSystem.Interfaces;
using ExaminationSystem.Models;
using ExaminationSystem.Repositry;

namespace ExaminationSystem.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepo<Question> questions { get; }
        IRepo<Answer> answers { get; }
        IRepo<Exam> exams { get; }
        IRepo<ExamQuestion> examQuestions { get; }
        
        Task<int> complete();

    }
}
