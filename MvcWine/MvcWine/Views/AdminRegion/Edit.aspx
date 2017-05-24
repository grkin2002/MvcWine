<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.ViewModels.RegionAdminViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>

        <div class="editor-field">
            地区名称：
            <%=Html.TextBoxFor(model=>model.Region.RegionName) %>
            <%=Html.ValidationMessageFor(model=>model.Region.RegionName) %>
        </div>
        <div class="editor-field">
            选择国家：
            <%=Html.DropDownListFor(model=>model.Region.CountryCode, new SelectList(Model.Countries,"CountryCode","CountryName",Model.Region.CountryCode)) %>
            <%=Html.ValidationMessageFor(model=>model.Region.CountryCode) %>
        </div>
        <div class="editor-field">
            介绍文字：
            <%=Html.TextAreaFor(model => model.Region.IntroText, new { @class="Intro"})%>
            <%=Html.ValidationMessageFor(model=>model.Region.IntroText) %>
        </div>
        <div class="editor-field">
            上传图片：
            <input type="file" id="PhotoUrl" name="Region" />
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



