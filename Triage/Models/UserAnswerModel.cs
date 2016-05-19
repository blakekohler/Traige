namespace Triage.Models
{
	public class UserAnswerModel
	{
		public int Id { get; set; }
		public int ResultId { get; set; }
		public ResultModel Result { get; set; }
	    public int AnswerId { get; set; }
		public AnswerModel Answer { get; set; }
	}
}
