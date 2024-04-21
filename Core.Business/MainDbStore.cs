namespace Core.Business
{
    public class MainDbStore
    {
        public const string sp_Languages_SelectForModule = "sp_Languages_SelectForModule";
        public const string sp_Languages_SelectForModule_Count = "sp_Languages_SelectForModule_Count";
        public const string sp_Companies_Save = "sp_Companies_Save";
        public const string sp_Companies_GetData = "sp_Companies_GetData";
        public const string sp_Companies_GetData_Count = "sp_Companies_GetData_Count";
        public const string sp_CompanyPackageServices_Save = "sp_CompanyPackageServices_Save";
        public const string sp_CompanyConfig_Save = "sp_CompanyConfig_Save";
        public const string sp_Languages_Labels_GetData = "sp_Languages_Labels_GetData";
        public const string sp_Languages_Labels_GetData_Count = "sp_Languages_Labels_GetData_Count";
        public const string sp_Languages_Labels_GetAll = "sp_Languages_Labels_GetAll";
        public const string sp_PackageServiceModules_Insert = "sp_PackageServiceModules_Insert";
        public const string sp_PackageServiceModules_Delete = "sp_PackageServiceModules_Delete";
        public const string sp_Users_Login = "sp_Users_Login";
        public const string sp_Users_GetByKey = "sp_Users_GetByKey";
        public const string sp_Users_Save = "sp_Users_Save";
        public const string sp_Users_UpdateInfo = "sp_Users_UpdateInfo";
        public const string sp_UserConfigs_Save = "sp_UserConfigs_Save";
    }

    public class MainDbTable
    {
        public const string Companies = "Companies";
        public const string CompanyConfigs = "CompanyConfigs";
        public const string Languages_Labels = "[Languages.Labels]";
        public const string Languages_LabelLanguages = "[Languages.LabelLanguages]";
        public const string Languages = "Languages";
        public const string MapTypes = "MapTypes";

        public const string PackageServices = "PackageServices";
        public const string PackageServiceModules = "PackageServiceModules";

        public const string Users = "Users";
        public const string UserConfigs = "UserConfigs";

    }
}