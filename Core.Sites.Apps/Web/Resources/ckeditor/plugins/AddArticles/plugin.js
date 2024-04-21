/// <reference path="../../../Plugins/linq/linq.js" />

/*
* @example An iframe-based dialog with custom button handling logics.
*/
( function() {
    CKEDITOR.plugins.add('AddArticles',
    {
        requires: [ 'iframedialog' ],
        init: function( editor )
        {
           var me = this;

           editor.addCommand('AddArticles',
                new CKEDITOR.command(
                    editor,
                    {
                        exec : function(editor)
                        {
                            var form = new FormPopupNews();
                            form.onOk = function () 
                            {
                                // form.IdsAdded
                                form.getNews(function (newses) 
                                {
                                    var content = Enumerable.From(newses).ToString(", ", function (news) 
                                    {
                                        return "[newsId=" + news.NewsId + ",titleShow={title},title=" + news.Title + "]";
                                    });
                                    editor.insertHtml(content);
                                });
                            };
                            form.show();
                        }
                    }
                ) 
            );

           editor.ui.addButton('AddArticles',
            {
                label: 'Chèn bài viết',
                command: 'AddArticles',
                icon: this.path + 'images/news.png'
            });
        }
    } );
})();
