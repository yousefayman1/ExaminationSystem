using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepo<Question> questions { get; }
        IRepo<Answer> answers { get; }
        IRepo<Exam> exams { get; }
        Task<int> complete();

    }
}
