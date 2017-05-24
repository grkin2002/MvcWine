<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.Models.Grape>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
   
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.GrapeType) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.GrapeType) %>
                <%= Html.ValidationMessageFor(model => model.GrapeType) %>
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
                <%= Html.TextBoxFor(model => model.IntroText) %>
                <%= Html.ValidationMessageFor(model => model.IntroText) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>



