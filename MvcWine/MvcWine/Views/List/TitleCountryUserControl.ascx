<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWine.Models.Country>" %>
<div class="item">
    <div class="editor-field">
        &nbsp</div>
    <h2 class="titlebar">
        <%=Html.Encode(Model.CountryName)%></h2>
    <div class="left">
        <div class="image_container">
            <img alt='<%=Model.CountryName %>' src="<%=Html.getPhotoUrl(Model.PhotoUrl) %>" />
        </div>
    </div>
    <%= Html.Encode(Model.IntroText) %>
    <div class="clear">
    </div>
    <div class="titlebar">
        &nbsp</div>
</div>
