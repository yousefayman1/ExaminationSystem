using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;



namespace BusinessLogicLayer.Repositry
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;

		public IRepo<Question> questions { get; private set; }
		public IRepo<Answer> answers { get; private set; }
		public IRepo<Exam> exams { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			questions = new Repositry<Question>(_context);
			answers = new Repositry<Answer>(_context);
			exams = new Repositry<Exam>(_context);
		}


		public async Task<int> complete()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
