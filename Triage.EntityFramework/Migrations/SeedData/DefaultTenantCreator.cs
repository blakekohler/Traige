using System.Linq;
using Triage.EntityFramework;
using Triage.MultiTenancy;

namespace Triage.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly TriageDbContext _context;

        public DefaultTenantCreator(TriageDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = "Default", Name = "Default"});
                _context.SaveChanges();
            }
        }
    }
}