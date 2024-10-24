
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ExaminationSystem
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Exam>()
				.HasMany(e => e.Questions)
				.WithMany(e => e.Exams);
			//modelBuilder.Entity<ExamQuestion>().HasNoKey();
			//modelBuilder.Entity<ExamQuestion>().ToTable("ExamQuestions");
		}
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Exam> Exams { get; set; }
		//public DbSet<ExamQuestion> ExamQuestions { get; set; }

	}
}
