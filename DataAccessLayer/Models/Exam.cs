namespace DataAccessLayer.Models
{
	public class Exam
	{
		public int Id { get; set; }
		public DateTime ExamDateTime { get; set; } = DateTime.Now;
		public int Grade { get; set; }
		public List<Question> Questions { get; set; } = [];

	}
}
