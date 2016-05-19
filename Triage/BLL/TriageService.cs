using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using AutoMapper;
using Centeva.Bll.Core;
using Centeva.Bll.Exceptions;
using Centeva.Dal;
using Centeva.Interfaces.Data;
using Centeva.Interfaces.DataAccess;
using Centeva.Interfaces.Service;
using Esb.Bll.Providers;
using Microsoft.AspNet.Identity.EntityFramework;
using Triage.BLL.Services;
using Triage.Models;

namespace Triage.BLL
{
	public class TriageService<TEntity, TId> : ProvidedSecureIdBllService<TriageServiceProvider, ITriageSecurity, TEntity, TId> where TEntity : class, IId<TId>, new()
	{
		public TriageService(IIdDataAccess<TEntity, TId> idDataAccess = null, TriageServiceProvider serviceProvider = null) :
			   base(idDataAccess ?? new IdDataAccess<ApplicationDbContext, TEntity, TId>(), serviceProvider)
		{
		}
	}
}



namespace Esb.Bll.Providers
{
	public interface ITriageSecurity : IServiceSecurity
	{
		User CurrentUser { get; }
	}


	public class TriageSecurity : ITriageSecurity
	{
		public TriageSecurity(IPrincipal userPrincipal, IIdDataAccess<User, int> dataAccess = null)
		{
			//dataAccess = dataAccess ?? new IdDataAccess<CadContext, User, int>();
			//var includes = new List<Expression<Func<User, object>>>{
			//     x => x.UserRoles,
			//     x => x.UserRoles.Select(r => r.RoleType.RoleTypePermissions),
			//     x => x.UserRoles.Select(r => r.Organization)
			//};
			//Expression<Func<User, bool>> withActiveRoles = u => u.UserRoles.Any(r => r.StartDate <= DateTime.Now && (r.EndDate == null || r.EndDate > DateTime.Now));
			//CurrentUser = dataAccess.GetEntity(withActiveRoles.And(u => u.DomainUserName == userPrincipal.Identity.Name), includes);

			//var validUser = CurrentUser != null && CurrentUser.UserRoles.Any(r => r.StartDate <= DateTime.Now && (r.EndDate == null || r.EndDate > DateTime.Now));
			//if(!validUser) {
			//     throw new NotAuthorizedException("You are not an Authorized user of the system.");
			//}
			//CurrentUser.UserRoles.RemoveAll(r => r.StartDate > DateTime.Now || r.EndDate <= DateTime.Now);
		}

		public User CurrentUser { get; private set; }

		private static void VerifyAuthorization()
		{// Put Security here, it will be inherited into each child by default
			if (false)
				throw new NotAuthorizedException("You are not authorized to perform this Action.");
		}

		public void VerifyCreateAuthorization()
		{
			VerifyAuthorization();
		}

		public void VerifyCountAuthorization()
		{
			VerifyAuthorization();
		}

		public void VerifyReadAuthorization()
		{
			VerifyAuthorization();
		}

		public void VerifyUpdateAuthorization()
		{
			VerifyAuthorization();
		}

		public void VerifyDeleteAuthorization()
		{
			VerifyAuthorization();
		}
	}
}


// Service Provider
namespace Esb.Bll.Providers
{
	//public interface IEsbServiceProvider : ISecureProvider<ITriageSecurity>
	//{
	//	User CurrentUser { get; }
	//	// ReportData Services
	//	IActionLinkServiceV16_01 ActionLinkV16_01 { get; }
	//	IActionServiceV16_01 ActionV16_01 { get; }
	//	IActionServiceV16_02 ActionV16_02 { get; }
	//	IFolderServiceV16_01 FolderV16_01 { get; }
	//	IvActionFileServiceV16_01 vActionFileV16_01 { get; }
	//	IvActionFileValueServiceV16_01 vActionFileValueV16_01 { get; }
	//	IvFilePathServiceV16_01 vFilePathV16_01 { get; }
	//	IvSysConfigServiceV16_01 vSysConfigV16_01 { get; }
	//	IvUserDesktopServiceV16_01 vUserDesktopV16_01 { get; }
	//	IvUserServiceV16_01 vUserV16_01 { get; }
	//	IUserServiceV16_01 UserV16_01 { get; }
	//	IContractServiceV16_01 ContractV16_01 { get; }
	//	IContractServiceV16_02 ContractV16_02 { get; }
	//	IContractArtifactServiceV16_02 ContractArtifactV16_02 { get; }
	//	// Toms Services
	//	IAttachmentServiceV16_01 AttachmentServiceV16_01 { get; }
	//	IDocumentServiceV16_01 DocumentServiceV16_01 { get; }
	//	IEpicOrgServiceV16_01 EpicOrgServiceV16_01 { get; }
	//	IEpicRoleServiceV16_01 EpicRoleServiceV16_01 { get; }
	//	IEpicUserOrgRoleServiceV16_01 EpicUserOrgRoleServiceV16_01 { get; }
	//	IEpicUserServiceV16_01 EpicUserServiceV16_01 { get; }
	//	IListServiceV16_01 ListServiceV16_01 { get; }
	//	//IRequirementEpicOrgServiceV16_01 RequirementEpicOrgServiceV16_01 { get; }
	//	IRequirementProcurementVehicleServiceV16_01 RequirementProcurementVehicleServiceV16_01 { get; }
	//	IRequirementSecServiceV16_01 RequirementSecServiceV16_01 { get; }
	//	IRequirementServiceV16_01 RequirementServiceV16_01 { get; }
	//	//ISpecialManagementCodeRequirementServiceV16_01 SpecialManagementCodeRequirementServiceV16_01 { get; }

	//	// Aams Services

	//	// Cad Services
	//	IAttachmentTypeServiceV16_01 AttachmentTypeServiceV16_01 { get; }
	//	IClassificationCodeServiceV16_01 ClassificationCodeServiceV16_01 { get; }
	//	INaicsCodeServiceV16_01 NaicsCodeServiceV16_01 { get; }
	//	IProcurementVehicleServiceV16_01 ProcurementVehicleServiceV16_01 { get; }
	//	IRequirementRequestedActionServiceV16_01 RequirementRequestedActionServiceV1601 { get; }
	//	IRequirementPriorityServiceV16_01 RequirementPriorityServiceV16_01 { get; }
	//	ISocioEconomicCategoryServiceV16_01 SocioEconomicCategoryServiceV16_01 { get; }
	//	ISpecialManagementCodeServiceV16_01 SpecialManagementCodeServiceV16_01 { get; }

	//	// Other
	//	IConfiguration Config { get; }
	//}

	public class TriageServiceProvider : BllServiceProvider<ITriageSecurity> //, ITriageServiceProvider
	{
		public TriageServiceProvider(ITriageSecurity serviceSecurity) : base(serviceSecurity)
		{
			//Register(() => new ActionLinkServiceV16_01(serviceProvider: this));
			Register(() => new SurveyService(serviceProvider: this));

		}

		public User CurrentUser
		{
			get { return ServiceSecurity.CurrentUser; }
		}

		public virtual SurveyService SurveryService => Lookup<SurveyService>();
	}
}
