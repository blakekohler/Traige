using Abp.Web.Mvc.Views;

namespace Triage.Web.Views
{
    public abstract class TriageWebViewPageBase : TriageWebViewPageBase<dynamic>
    {

    }

    public abstract class TriageWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TriageWebViewPageBase()
        {
            LocalizationSourceName = TriageConsts.LocalizationSourceName;
        }
    }
}