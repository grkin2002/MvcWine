<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.Models.Country>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>

        <div class="editor-field">
            国家名称：
            <%= Html.TextBoxFor(model => model.CountryName) %>
            <%= Html.ValidationMessageFor(model => model.CountryName) %>
        </div>
        <div class="editor-field">
            国家介绍：
            <%= Html.TextAreaFor(model => model.IntroText, new { @class="Intro"})%>
            <%= Html.ValidationMessageFor(model => model.IntroText) %>
        </div>
        <div class="editor-field">
            上传图片：
            <input type="file" id="PhotoUrl" name="Country" />
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

    <script type="text/javascript">
        $(function() {
        $("#PhotoUrl").makeAsyncUploader({
        upload_url: "/Utility/AsyncUpload ", // Important! This isn't a directory, it's a HANDLER such as an ASP.NET MVC action method, or a PHP file, or a Classic ASP file, or an ASP.NET .ASHX handler. The handler should save the file to disk (or database).
                flash_url: '../../Scripts/swfupload.swf',
                button_image_url: '../../Image/blankButton.png'
                
            });
        });        
    </script>

</asp:Content>
