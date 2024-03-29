﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.Models.Taste>" %>

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
                <%= Html.LabelFor(model => model.TasteType) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.TasteType) %>
                <%= Html.ValidationMessageFor(model => model.TasteType) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.TasteDesc) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.TasteDesc) %>
                <%= Html.ValidationMessageFor(model => model.TasteDesc) %>
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

