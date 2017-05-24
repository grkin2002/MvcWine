<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Region>>" %>
<%@ Import Namespace="MvcWine.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                RegionCode
            </th>
            <th>
                RegionName
            </th>
            <th>
                CountryCode
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
                <%= Html.ActionLink("Edit", "Edit", new { id=item.RegionCode.Trim() }) %> |
             
                <%= Html.ActionLink("Delete", "Delete", new { id=item.RegionCode.Trim() })%>
            </td>
            <td>
                <%= Html.Encode(item.RegionCode) %>
            </td>
            <td>
                <%= Html.Encode(item.RegionName) %>
            </td>
            <td>
                <%= Html.getCountryNameByCode(item.CountryCode.Trim())%>
            </td>
            <td>
                <%= Html.Encode(item.PhotoUrl) %>
            </td>
            <td>
                <%= Html.Encode(item.IntroText!=null&&item.IntroText.Length>100? item.IntroText.Substring(1,100)+"...more": item.IntroText )%>
            </td>
        </tr>
    
    <% } %>

    </table>



</asp:Content>

