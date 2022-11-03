using AbpDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpDemo.Permissions;

public class AbpDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpDemoPermissions.GroupName, L("Permission:BookStore"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        var booksPermission = myGroup.AddPermission(AbpDemoPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpDemoPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpDemoPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpDemoPermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpDemoResource>(name);
    }
}