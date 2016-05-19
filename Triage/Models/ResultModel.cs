namespace Triage.Models
{
	public class ResultModel
	{
		public int Id { get; set; }
		public int SurveyId { get; set; }
		public Survey Survey { get; set; }
		public string Title { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
	}
}
