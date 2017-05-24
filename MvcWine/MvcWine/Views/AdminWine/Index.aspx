<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Wine>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th></th>
            <th>
                WineId
            </th>
            <th>
                WineType
            </th>
            <th>
                PhotoUrl
            </th>
            <th>
                IntroText
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.WineId }) %> |
               
                <%= Html.ActionLink("Delete", "Delete", new { id=item.WineId })%>
            </td>
            <td>
                <%= Html.Encode(item.WineId) %>
            </td>
            <td>
                <%= Html.Encode(item.WineType) %>
            </td>
            <td>
               <img alt="<%=Html.Encode(item.WineType) %>" src=" <%=Html.getPhotoUrl(item.PhotoUrl) %>" />
            </td>
            <td>
                <%= Html.Encode(item.IntroText) %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>



