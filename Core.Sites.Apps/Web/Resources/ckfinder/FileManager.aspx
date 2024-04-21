<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="Core.Sites.Apps.Web.Resources.ckfinder.FileManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Quản lý file</title>
        <meta name="robots" content="noindex, nofollow" />
        <script src="../Plugins/jQuery/jQuery-2.1.3.min.js"></script>
        <script src="/Web/Resources/ckfinder/ckfinder.js"></script>
        
	    <style type="text/css">
		    body, html, iframe, #ckfinder 
            {
			    margin: 0;
			    padding: 0;
			    border: 0;
			    width: 100%;
			    height: 100%;
			    overflow: hidden;
		    }
	    </style>
    </head>
    <body>
        <div id="ckfinder">
        <script type="text/javascript">
            var finder = new CKFinder();

            var config = {};

            finder.basePath = '/Web/Resources/ckfinder/';
            finder.width = '<%= With %>';
            finder.height = "100%";

            finder.removePlugins = 'basket';
            finder.selectActionData = "container";
            finder.selectActionFunction = function (fileUrl, data) {
                window.opener.Core.fileManagerCallback(api.getSelectedFolder().getUrl(), api.getSelectedFiles());
            };
            finder.selectMultiple = <%= Multi ? "true":"false" %>;
            finder.resourceType = '<%= string.IsNullOrEmpty(Type) ? "Images" : Type %>';
            //finder.tabIndex = 1;
            //finder.startupPath = "Images:/";

            finder.connectorInfo = 'acl=<%= Request.QueryString["acl"] %>';
            finder.language = "vi";
            //config.skin = "v1";

            //var finder = new CKFinder( config );
            //finder.replace( 'ckfinder', config );

            var api = (finder).create();

            var runToCondition = function (condition, timeout) {
                var to = null;
                var func = function () {
                    if (to != null) {
                        clearTimeout(to);
                        to = null;
                    }

                    to = setTimeout(function () {
                        var result = condition();
                        if (result) return;
                        func();
                    }, timeout);
                }

                func();
            }

            runToCondition(function () {
                if ($("#ckfinder iframe").length == 0) return false;
                var folderDiv = $($("#ckfinder iframe")[0].contentWindow.document).find("body").find("#folders_view");
                if (folderDiv.length == 0) return false;
                var licensDiv = folderDiv.next();
                if (licensDiv.length == 0) return false;
                folderDiv.height(folderDiv.height() + licensDiv.height() + 100);
                licensDiv.hide();
                return true;
            }, 10);
        </script>
            </div>
    </body>
</html>
