<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.Models.Producer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%= Html.ValidationSummary(true) %>
    <p>
        <input type="submit" value="Save" />
    </p>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.ProducerName) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.ProducerName) %>
            <%= Html.ValidationMessageFor(model => model.ProducerName) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.PhotoUrl) %>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.PhotoUrl) %>
            <%= Html.ValidationMessageFor(model => model.PhotoUrl) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.IntroText) %>
        </div>
        <div class="editor-field">
            <%= Html.TextAreaFor(model => model.IntroText, new { @class="Intro"})%>
            <%= Html.ValidationMessageFor(model => model.IntroText) %>
        </div>
    </fieldset>
    <% } %>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
