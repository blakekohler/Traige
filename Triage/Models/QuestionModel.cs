using System.Collections.Generic;

namespace Triage.Models
{
	public class QuestionModel
	{
		public int Id { get; set; }
		public int SurveyId { get; set; }
		public Survey Survey { get; set; }
		public Authority Authority { get; set; }
		public string AuthorityCode { get; set; }
		public bool IsPrivate { get; set; }
		public string HelpTest { get; set; }
		public string Title { get; set; }
		public List<AnswerModel> Answers { get; set; }

	}
}
