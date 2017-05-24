<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Grape>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                GrapeId
            </th>
            <th>
                GrapeType
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
                <%= Html.ActionLink("Edit", "Edit", new { id=item.GrapeId }) %> |
                
                <%= Html.ActionLink("Delete", "Delete", new { id=item.GrapeId })%>
            </td>
            <td>
                <%= Html.Encode(item.GrapeId) %>
            </td>
            <td>
                <%= Html.Encode(item.GrapeType) %>
            </td>
            <td>
                <%= Html.Encode(item.PhotoUrl) %>
            </td>
            <td>
                <%= Html.Encode(item.IntroText) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>


