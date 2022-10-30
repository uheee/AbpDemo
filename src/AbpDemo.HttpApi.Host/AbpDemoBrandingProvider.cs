using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpDemo;

[Dependency(ReplaceServices = true)]
public class AbpDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpDemo";
}