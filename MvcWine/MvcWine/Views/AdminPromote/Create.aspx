<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.Models.Promote>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">
    $(function() {
        $('.date-pick').datepicker({ buttonImage: '../../Image/datepicker.gif' });
    });
    </script>

    <h2>
        Create</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.PromoteType) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.PromoteType) %>
            <%= Html.ValidationMessageFor(model => model.PromoteType) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.Description) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Description) %>
            <%= Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.StartDate) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.StartDate, new { @class="date-pick"})%>
            <%= Html.ValidationMessageFor(model => model.StartDate) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.EndDate)%>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.EndDate, new { @class = "date-pick" })%>
            <%= Html.ValidationMessageFor(model => model.EndDate) %>
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
