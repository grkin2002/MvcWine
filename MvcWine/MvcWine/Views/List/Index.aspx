<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Country>>" %>

<%@ Import Namespace="MvcWine.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    
       
    <ul class="ListContent">
        <% foreach (var item in Model)
           { %>
        <li>
            <div class="left">
                <div class="image_container">
                <a href='<%=Url.Action("ListByCountry", new{ id=item.CountryCode.Trim() }) %>'>
                    <img  alt="<%= Html.Encode(item.CountryName) %>" src="<%=Html.getPhotoUrl(item.PhotoUrl) %>" />
                </a>
                </div>
            </div>
            <div class="right">
                <div class="text_container">
                     <a href='<%=Url.Action("ListByCountry", new{ id=item.CountryCode.Trim() }) %>'>
                     <strong><%= Html.Encode(item.CountryName)%></strong>
                     </a>
                    
                    <br />
                    <%= Html.Encode(item.IntroText)%>
                </div>
            </div>
            <div class="clear">
            </div>
        </li>
        <% } %>
    </ul>
</asp:Content>
