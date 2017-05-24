<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Producer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
            <th>
                ProducerId
            </th>
            <th>
                ProducerName
            </th>
            <th>
                PhotoUrl
            </th>
            <th>
                IntroText
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.ProducerId }) %>
                |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.ProducerId })%>
            </td>
            <td>
                <%= Html.Encode(item.ProducerId) %>
            </td>
            <td>
                <%= Html.Encode(item.ProducerName) %>
            </td>
            <td>
                <%= Html.Encode(item.PhotoUrl) %>
            </td>
            <td>
                <%= Html.Encode(item.IntroText!=null&&item.IntroText.Length>100? item.IntroText.Substring(1,100): item.IntroText) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
