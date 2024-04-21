/// <reference path="../../../Plugins/linq/linq.js" />

/*
* @example An iframe-based dialog with custom button handling logics.
*/
( function() {
    CKEDITOR.plugins.add('AddNotepad',
    {
        requires: [ 'iframedialog' ],
        init: function( editor )
        {
           var me = this;

           editor.addCommand('AddNotepad',
                new CKEDITOR.command(
                    editor,
                    {
                        exec : function(editor)
                        {
                            var popupContent = "<div class=\"form-horizontal\">";
                            popupContent += "<div class='form-group'>";
                            popupContent += "   <div class='col-sm-12'>";
                            popupContent += "       <textarea class='form-control input-sm' placeholder='Copy nội dung cần chèn vô đây' style='width:100%; height: 400px'></textarea>";
                            popupContent += "   </div>";
                            popupContent += "</div>";
                            popupContent += "</div>";

                            var popup = new Popup();
                            popup.title = "Chèn nội dung vào Editor từ Word hoặc từ nội dung web khác";
                            popup.content = popupContent;
                            popup.clearWhenHide = true;
                            popup.buttons.push({ value: "Thực hiện", cls: "btn btn-primary", func: function (element, scope) 
                            { 
                                var html = Enumerable.From(popup.popupBody.find("textarea").val().split('\n')).ToString("", function (p) { return "<p>" + p + "</p>"; });
                                editor.insertHtml(html);
                                popup.hide(); 
                            } });
                            popup.onAlwaysShow = function () { popup.popupBody.benice(); };
                            popup.show();
                        }
                    }
                ) 
            );

            editor.ui.addButton('AddNotepad',
            {
                label: 'Copy như Notepad',
                command: 'AddNotepad',
                icon: this.path + 'images/notepad.png'
            });
        }
    } );
})();
