using AbpDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpDemo;

[DependsOn(
    typeof(AbpDemoEntityFrameworkCoreTestModule)
)]
public class AbpDemoDomainTestModule : AbpModule
{
}