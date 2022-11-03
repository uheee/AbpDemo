﻿namespace AbpDemo.Permissions;

public static class AbpDemoPermissions
{
    public const string GroupName = "BookStore";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Books
    {
        public const string Default = $"{GroupName}.Books";
        public const string Create = $"{Default}.Create";
        public const string Edit = $"{Default}.Edit";
        public const string Delete = $"{Default}.Delete";
    }
}