using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centeva.Dal;
using Centeva.Interfaces.DataAccess;
using Centeva.Interfaces.Service;
using Esb.Bll.Providers;
using Triage.Models;

namespace Triage.BLL.Services
{

	public interface ISurveyService : IIdBllService<Survey, int> { }

	public class SurveyService : TriageService<Survey, int>, ISurveyService
	{
		public SurveyService(IIdDataAccess<Survey, int> idDataAccess = null, TriageServiceProvider serviceProvider = null) :
			   base(idDataAccess ?? new IdDataAccess<ApplicationDbContext, Survey, int>(), serviceProvider)
		{
		}
	}


}
