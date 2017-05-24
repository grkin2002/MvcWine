<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWine.ViewModels.ProductAdminViewModel>" %>
<fieldset>
    <legend>评论照片</legend>
    <div class="editor-label">
        <%= Html.LabelFor(model => model.Product.Comment) %>
    </div>
    <div class="editor-field">
        <%= Html.TextBoxFor(model => model.Product.Comment, new { style="width:600px"})%>
        <%= Html.ValidationMessageFor(model => model.Product.Comment) %>
    </div>
    <div class="editor-label">
        <%= Html.LabelFor(model => model.Product.IntroText) %>
    </div>
    <div class="editor-field">
        <%= Html.TextAreaFor(model => model.Product.IntroText, new{@class="Intro"}) %>
        <%= Html.ValidationMessageFor(model => model.Product.IntroText) %>
    </div>
    <div class="editor-field">
        上传图片：
        <input type="file" id="PhotoUrl" name="Country" />
    </div>

    <script type="text/javascript">
        $(function() {
        $("#PhotoUrl").makeAsyncUploader({
        upload_url: "/Utility/ProductUpload ", // Important! This isn't a directory, it's a HANDLER such as an ASP.NET MVC action method, or a PHP file, or a Classic ASP file, or an ASP.NET .ASHX handler. The handler should save the file to disk (or database).
                flash_url: '../../Scripts/swfupload.swf',
                button_image_url: '../../Image/blankButton.png'
                
            });
        });        
    </script>

</fieldset>
