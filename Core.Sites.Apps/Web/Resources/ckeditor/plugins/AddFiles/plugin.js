/// <reference path="../../../Plugins/linq/linq.js" />

/*
* @example An iframe-based dialog with custom button handling logics.
*/
( function() {
    CKEDITOR.plugins.add('AddFiles',
    {
        requires: [ 'iframedialog' ],
        init: function( editor )
        {
           var me = this;

           editor.addCommand('AddFiles',
                new CKEDITOR.command(
                    editor,
                    {
                        exec : function(editor)
                        {
                            Core.showFiles("Files", false, function (folder, files)
                            {   
                                Enumerable.From(files).ToString("", function (file)
                                {
                                    editor.insertHtml("<a href='" + folder + file + "'>" + file + "</a>");
                                });
                            });
                        }
                    }
                ) 
            );

           editor.ui.addButton('AddFiles',
            {
                label: 'Chèn tệp',
                command: 'AddFiles',
                icon: this.path + 'images/icon.png'
            });
        }
    } );
})();
