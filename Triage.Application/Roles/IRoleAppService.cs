using System.Threading.Tasks;
using Abp.Application.Services;
using Triage.Roles.Dto;

namespace Triage.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
