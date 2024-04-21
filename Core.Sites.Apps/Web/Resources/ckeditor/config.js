/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.extraPlugins = 'AddNews,AddYoutube,AddNotepad,AddArticles,AddFiles';
    // config.height = '200px';
    config.filebrowserImageBrowseUrl = "/Web/Resources/ckfinder/ckfinder.html?type=Images";
    config.filebrowserImageUploadUrl = "/Web/Resources/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"
    config.allowedContent = true;
    config.fontSize_sizes = '12/12px;13/13px;14/14px;15/15px;16/16px;17/17px;';
    // ALLOW <i></i>
    config.protectedSource.push(/<i[^>]*><\/i>/g);
    config.toolbar = [
            // { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source'] },
            // { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
            // { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
            // { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
            // { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'Iframe', 'pbckcode'] },
            // { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },


             { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', '-', 'RemoveFormat'] },
             //{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize', 'Table', 'Link'] },
             { name: 'styles', items: ['Format', 'Font', 'FontSize', 'Table', 'Link'] },
             //{ name: 'styles', items: ['Format', 'FontSize', 'Table', 'Link'] },
             { name: 'paragraph', groups: ['list', 'blocks', 'align'], items: ['NumberedList', 'BulletedList', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
             { name: 'colors', items: ['TextColor', 'BGColor'] },
             { name: "MyBars", items: ['AddNews', 'AddYoutube', 'AddNotepad', 'AddArticles'] },
             { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source'] }];
};

var MyCustomEditor =
{
    current: null,

    insertNews : function(news)
    {
        var final_html = '<div>';
        final_html += "<a href='#'>" + news.Title + "</a>";
        final_html += "<p>" + news.Sapo + "</p>";
        final_html += "</div>";

        MyCustomEditor.current.insertHtml(final_html);
    }
}

//config.toolbar_mycustom2 = [
//    { name: 'styles',       items: [ 'Format' ] },
//    { name: 'morestyles',   items: [ 'Font', 'FontSize' ] },
//    { name: 'colors',       items: [ 'BGColor', 'TextColor' ] }
//];
//<script>
//    CKEDITOR.replace('MyObject', {toolbar: 'mycustom2'});
//</script>