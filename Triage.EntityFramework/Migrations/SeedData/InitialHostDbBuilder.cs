using Triage.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Triage.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TriageDbContext _context;

        public InitialHostDbBuilder(TriageDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
