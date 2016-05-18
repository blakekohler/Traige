using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Triage
{
    [DependsOn(typeof(TriageCoreModule), typeof(AbpAutoMapperModule))]
    public class TriageApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
