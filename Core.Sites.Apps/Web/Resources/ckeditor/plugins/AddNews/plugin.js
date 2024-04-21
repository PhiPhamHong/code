/// <reference path="../../../Plugins/linq/linq.js" />

/*
* @example An iframe-based dialog with custom button handling logics.
*/
( function() {
    CKEDITOR.plugins.add('AddNews',
    {
        requires: [ 'iframedialog' ],
        init: function( editor )
        {
           var me = this;

           editor.addCommand('AddNews',
                new CKEDITOR.command(
                    editor,
                    {
                        exec : function(editor)
                        {
                            var popupContent = "<div class=\"form-horizontal\">";
                            popupContent += "<div class='form-group'>";
                            popupContent += "   <label class=\"control-label col-sm-3\">Kiểu</label>";
                            popupContent += "   <div class='col-sm-9'>";
                            popupContent += "       <select data-use-default=\"True\" data-width=\"100%\" data-disable-search=\"True\" data-value-default=\"0\" data-text-default=\"-- Chọn --\" \style=\"width: 100%;\">";
                            popupContent += "           <option value='0'>Chèn ảnh không có ghi chú</option>";
                            popupContent += "           <option value='1'>Chèn ảnh có ghi chú</option>";
                            popupContent += "       </select>";
                            popupContent += "   </div>";
                            popupContent += "</div>";
                            popupContent += "</div>";

                            var doAction = function(type)
                            {
                                Core.showFiles("Images", true, function (folder, files) 
                                {
                                    switch(type)
                                    {
                                        case "0": editor.insertHtml(type_0(folder, files)); break;
                                        case "1": editor.insertHtml(type_1(folder, files)); break;
                                    }
                                });

                                var type_0 = function(folder, files)
                                {
                                    return Enumerable.From(files).ToString("", function (file) 
                                    {
                                        return "<p style=\"text-align: center;\" data-image='slide'><img src=\"" + folder + file + "\" class=\"img-fluid\" alt=\"\"></p>";
                                    });
                                }

                                var type_1 = function(folder, files)
                                {
                                    return Enumerable.From(files).ToString("", function (file) 
                                    {
                                        return "<p style=\"text-align: center;\" data-image='slide'><img src=\"" + folder + file + "\" class=\"img-fluid\" alt=\"\"></p><p data-title='image' style=\"text-align: center;\">Ghi chú của ảnh</p>";
                                    });
                                }
                            }

                            var popup = new Popup();
                            popup.title = "Chèn ảnh vào bài viết";
                            popup.content = popupContent;
                            popup.clearWhenHide = true;
                            popup.buttons.push({ value: "Thực hiện", cls: "btn btn-primary", func: function (element, scope) 
                            { 
                                doAction(popup.popupBody.find("select").val());
                                popup.hide(); 
                            } });
                            popup.onAlwaysShow = function () { popup.popupBody.benice(); };
                            popup.show();
                        }
                    }
                ) 
            );

           editor.ui.addButton('AddNews',
            {
                label: 'Chèn ảnh',
                command: 'AddNews',
                icon: this.path + 'images/icon.gif'
            });
        }
    } );
})();
