using System;
using System.Collections.Generic;
using Centeva.Interfaces.Data;

namespace Triage.Models
{
    // Models returned by AccountController actions.

    public class Survey : IId<int>
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public SurveyStatusModel SurveyStatus { get; set; }
		public Authority Authority { get; set; }
		public string AuthorityCode { get; set; }
		public string  SurveyStatusModelCode { get; set; }
		public SurveyStatusActiveTypeModel SurveyStatusActiveType { get; set; }
		public string SurveyStatusActiveTypeModelCode { get; set; }
		public List<QuestionModel> Questions { get; set; }
	}
}
