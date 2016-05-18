using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Triage.EntityFramework;

namespace Triage.Migrator
{
    [DependsOn(typeof(TriageDataModule))]
    public class TriageMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TriageDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}