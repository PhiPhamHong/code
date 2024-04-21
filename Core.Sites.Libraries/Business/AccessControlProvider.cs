using Core.Extensions;
using CKFinder.Settings;
namespace Core.Sites.Libraries.Business
{
    public class AccessControlProvider
    {
        public virtual void BuildAccessControl(AccessControl acl)
        {
            acl.FolderView = true;
            acl.FolderCreate = true;
            acl.FolderRename = true;
            acl.FolderDelete = true;

            acl.FileView = true;
            acl.FileUpload = true;
            acl.FileRename = true;
            acl.FileDelete = true;
        }

        public static AccessControlProvider Create(string type)
        {
            return string.IsNullOrEmpty(type) ? new AccessControlProvider() : type.CreateInstance<AccessControlProvider>();
        }
    }
}
