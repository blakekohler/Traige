using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Triage.MultiTenancy.Dto;

namespace Triage.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
