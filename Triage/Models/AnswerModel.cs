namespace Triage.Models
{
	public class AnswerModel
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public int Value { get; set; }
		public string HelpText { get; set; }
		public string Title { get; set; }
	}
}