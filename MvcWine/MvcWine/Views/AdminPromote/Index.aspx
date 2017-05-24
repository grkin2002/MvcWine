<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Promote>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                PromoteType
            </th>
            <th>
                Description
            </th>
            <th>
                StartDate
            </th>
            <th>
                EndDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.PromoteType.Trim() }) %> |
                
                <%= Html.ActionLink("Delete", "Delete", new { id=item.PromoteType.Trim() })%>
            </td>
            <td>
                <%= Html.Encode(item.PromoteType) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.StartDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.EndDate)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

