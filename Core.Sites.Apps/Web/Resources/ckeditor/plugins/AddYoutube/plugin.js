/// <reference path="../../../Plugins/linq/linq.js" />

/*
* @example An iframe-based dialog with custom button handling logics.
*/
( function() {
    CKEDITOR.plugins.add('AddYoutube',
    {
        requires: [ 'iframedialog' ],
        init: function( editor )
        {
           var me = this;

           editor.addCommand('AddYoutube',
                new CKEDITOR.command(
                    editor,
                    {
                        exec : function(editor)
                        {
                            var popupContent = "<div class=\"form-horizontal\">";

                            popupContent += "<div class='form-group'>";
                            popupContent += "   <label class=\"control-label col-sm-3\">YoutubeId</label>";
                            popupContent += "   <div class='col-sm-9'>";
                            popupContent += "       <input value=\"\" class=\"form-control input-sm\" name=\"YoutubeId\" placeholder=\"YoutubeId\" type=\"text\">";            
                            popupContent += "   </div>";
                            popupContent += "</div>";

                            popupContent += "<div class='form-group'>";
                            popupContent += "   <label class=\"control-label col-sm-3\">Style</label>";
                            popupContent += "   <div class='col-sm-9'>";
                            popupContent += "       <select data-use-default=\"True\" name=\"Css\" data-width=\"100%\" data-disable-search=\"True\" style=\"width: 100%;\">";
                            //popupContent += "           <option value='embed-responsive embed-responsive-21by9'>embed-responsive embed-responsive-21by9</option>";
                            popupContent += "           <option value='embed-responsive embed-responsive-16by9'>embed-responsive embed-responsive-16by9</option>";
                            //popupContent += "           <option value='embed-responsive embed-responsive-4by3'>embed-responsive embed-responsive-4by3</option>";
                            //popupContent += "           <option value='embed-responsive embed-responsive-1by1'>embed-responsive embed-responsive-1by1</option>";
                            popupContent += "       </select>";
                            popupContent += "   </div>";
                            popupContent += "</div>";

                            var popup = new Popup();
                            popup.title = "Chèn ảnh vào bài viết";
                            popup.content = popupContent;
                            popup.clearWhenHide = true;
                            popup.buttons.push({ value: "Thực hiện", cls: "btn btn-primary", func: function (element, scope) 
                            { 
                                var css = popup.popupBody.find("[name=Css]").val();
                                var youtubeId = popup.popupBody.find("[name=YoutubeId]").val();
                                var html = "<div class=\"" + css + " mb-3\"><iframe class=\"embed-responsive-item\" frameborder=\"0\" scrolling=\"no\" src=\"https://www.youtube.com/embed/" + youtubeId + "\"></iframe></div>";
                                var newElement = CKEDITOR.dom.element.createFromHtml(html);
                                editor.insertElement(newElement)
                                //editor.insertHtml(html);
                                popup.hide(); 
                            } });
                            popup.onAlwaysShow = function () { popup.popupBody.benice(); };
                            popup.show();
                        }
                    }
                ) 
            );

           editor.ui.addButton('AddYoutube',
            {
                label: 'Chèn youtube',
                command: 'AddYoutube',
                icon: this.path + 'images/youtube.png'
            });
        }
    } );
})();
