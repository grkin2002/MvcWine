<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.ViewModels.ProductAdminViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Product.PName) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Product.PName, new { style="width:600px"})%>
            <%= Html.ValidationMessageFor(model => model.Product.PName) %>
        </div>
        <br />
        <div>
            <% Html.RenderPartial("LocationUserControl",Model); %>
        </div>
        <br />
        <div>
            <% Html.RenderPartial("CategoryUserControl",Model); %>
        </div>
        <br />
        <div>
            <% Html.RenderPartial("DetailsUserControl",Model); %>
        </div>
        <br />
        <div>
            <% Html.RenderPartial("TextPhotoUserControl",Model); %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
    

</asp:Content>
