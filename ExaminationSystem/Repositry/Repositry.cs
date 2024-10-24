using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using ExaminationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Repositry
{
	public class Repositry<T> : IRepo<T> where T : class
	{
		private DbSet<T> _dbSet;
		private readonly ApplicationDbContext _context;

		public Repositry(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public async Task<T> Create(T entity)
		{
			await _dbSet.AddRangeAsync(entity);
			return entity;
		}

		public async Task Delete(T entity)
		{
			_dbSet.Remove(entity);

		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null, string? Path = null)
		{
			IQueryable<T> query = _dbSet;
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (Path != null)
			{

				foreach (var Word in Path.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(Word);
				}
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetById(Expression<Func<T, bool>>? predicate = null, string? Path = null)
		{
			IQueryable<T> query = _dbSet;
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (Path != null)
			{

				foreach (var Word in Path.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(Word);
				}
			}
			return await query.SingleOrDefaultAsync();
		}

		public async Task Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
