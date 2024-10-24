using System.Linq.Expressions;

namespace ExaminationSystem.Interfaces
{
	public interface IRepo<T> where T : class
	{
		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null, string? Path = null);
		Task<T> GetById(Expression<Func<T, bool>>? predicate = null, string? Path = null);
		Task<T> Create(T entity);
		Task Update(T entity);
		Task Delete(T entity);
	}

}
