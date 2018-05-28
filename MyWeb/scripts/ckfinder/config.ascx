<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="false" Inherits="CKFinder.Settings.ConfigFile" %>
<%@ Import Namespace="CKFinder.Settings" %>
<script runat="server">

	/**
	 * This function must check the user session to be sure that he/she is
	 * authorized to upload and access files using CKFinder.
	 */
	public override bool CheckAuthentication()
	{
        bool IsAuthorized = true;
		if ( Session[ "IsAuthorized" ] != null && (bool)Session["IsAuthorized"] == true )
		{
            IsAuthorized = true;
		}
        return IsAuthorized;
	}

	public override void SetConfig()
	{
		LicenseName = "";
		LicenseKey = "";
		BaseUrl = "/uploads/";
		BaseDir = Server.MapPath("/uploads/");
		Thumbnails.Url = BaseUrl + "_thumbs/";
		Thumbnails.Dir = BaseDir + "_thumbs/";
		Thumbnails.Enabled = true;
		Thumbnails.DirectAccess = false;
		Thumbnails.MaxWidth = 270;
		Thumbnails.MaxHeight = 270;
		Thumbnails.Quality = 80;
		Images.MaxWidth = 1200;
		Images.MaxHeight = 1200;
		Images.Quality = 80;

		// Indicates that the file size (MaxSize) for images must be checked only
		// after scaling them. Otherwise, it is checked right after uploading.
		CheckSizeAfterScaling = true;

		// Due to security issues with Apache modules, it is recommended to leave the
		// following setting enabled. It can be safely disabled on IIS.
		ForceSingleExtension = true;

		// For security, HTML is allowed in the first Kb of data for files having the
		// following extensions only.
		HtmlExtensions = new string[] { "html", "htm", "xml", "js" };

		// Folders to not display in CKFinder, no matter their location. No
		// paths are accepted, only the folder name.
		// The * and ? wildcards are accepted.
		HideFolders = new string[] { ".svn", "CVS" };

		// Files to not display in CKFinder, no matter their location. No
		// paths are accepted, only the file name, including extension.
		// The * and ? wildcards are accepted.
		HideFiles = new string[] { ".*" };

		// Perform additional checks for image files.
		SecureImageUploads = true;

		// The session variable name that CKFinder must use to retrieve the
		// "role" of the current user. The "role" is optional and can be used
		// in the "AccessControl" settings (bellow in this file).
		RoleSessionVar = "CKFinder_UserRole";

		// ACL (Access Control) settings. Used to restrict access or features
		// to specific folders.
		// Several "AccessControl.Add()" calls can be made, which return a
		// single ACL setting object to be configured. All properties settings
		// are optional in that object.
		// Subfolders inherit their default settings from their parents' definitions.
		//
		//	- The "Role" property accepts the special "*" value, which means
		//	  "everybody".
		//	- The "ResourceType" attribute accepts the special value "*", which
		//	  means "all resource types".
		AccessControl acl = AccessControl.Add();
		acl.Role = "*";
		acl.ResourceType = "*";
		acl.Folder = "/";

		acl.FolderView = true;
		acl.FolderCreate = true;
		acl.FolderRename = true;
		acl.FolderDelete = true;

		acl.FileView = true;
		acl.FileUpload = true;
		acl.FileRename = true;
		acl.FileDelete = true;

		// Resource Type settings.
		// A resource type is nothing more than a way to group files under
		// different paths, each one having different configuration settings.
		// Each resource type name must be unique.
		// When loading CKFinder, the "type" querystring parameter can be used
		// to display a specific type only. If "type" is omitted in the URL,
		// the "DefaultResourceTypes" settings is used (may contain the
		// resource type names separated by a comma). If left empty, all types
		// are loaded.

		DefaultResourceTypes = "";

		ResourceType type;

		type = ResourceType.Add( "Files" );
		type.Url = BaseUrl + "files/";
		type.Dir = BaseDir == "" ? "" : BaseDir + "files/";
        type.MaxSize = 0; // 104857600; //100Mb
		type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "zip" };
		type.DeniedExtensions = new string[] { };

		type = ResourceType.Add( "Images" );
		type.Url = BaseUrl + "images/";
		type.Dir = BaseDir == "" ? "" : BaseDir + "images/";
		type.MaxSize = 1048576; //1Mb
		type.AllowedExtensions = new string[] { "bmp", "gif", "jpeg", "jpg", "png" };
		type.DeniedExtensions = new string[] { };

		type = ResourceType.Add( "Flash" );
		type.Url = BaseUrl + "flash/";
		type.Dir = BaseDir == "" ? "" : BaseDir + "flash/";
		type.MaxSize = 1048576; //1Mb
		type.AllowedExtensions = new string[] { "swf", "flv" };
		type.DeniedExtensions = new string[] { };

        type = ResourceType.Add("Media");
        type.Url = BaseUrl + "media/";
        type.Dir = BaseDir == "" ? "" : BaseDir + "media/";
        type.MaxSize = 104857600; //100Mb
        type.AllowedExtensions = new string[] { "avi", "asf", "fla", "flv", "mov", "mp3", "mp4", "mpg", "mpeg", "qt", "rm", "swf", "wma", "wmv" };
        type.DeniedExtensions = new string[] { };
		
		type = ResourceType.Add( "News" );
		type.Url = BaseUrl + "news/";
		type.Dir = BaseDir == "" ? "" : BaseDir + "news/";
		type.MaxSize = 1048576; //1Mb
		type.AllowedExtensions = new string[] { "bmp", "gif", "jpeg", "jpg", "png" };
		type.DeniedExtensions = new string[] { };

        type = ResourceType.Add("Product");
        type.Url = BaseUrl + "product/";
        type.Dir = BaseDir == "" ? "" : BaseDir + "product/";
        type.MaxSize = 1048576; //1Mb
        type.AllowedExtensions = new string[] { "bmp", "gif", "jpeg", "jpg", "png" };
        type.DeniedExtensions = new string[] { };
        
        type = ResourceType.Add( "Advertise" );
		type.Url = BaseUrl + "advertise/";
		type.Dir = BaseDir == "" ? "" : BaseDir + "advertise/";
        type.MaxSize = 104857600; //1Mb
        type.AllowedExtensions = new string[] { "avi", "flv", "wmv", "swf", "bmp", "gif", "jpeg", "jpg", "png" };
		type.DeniedExtensions = new string[] { };
	}

</script>
