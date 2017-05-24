<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Country>>" %>
<%@ Import Namespace="MvcWine.Helpers" %>
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
            <th style="width:100px;">操作：</th>
            <th style="width:100px;">
                编码：
            </th>
            <th style="width:150px;">
                国家名字：
            </th>
            <th>
                国家图景：
            </th>
            <th>
                介绍文字：
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
       
                <%= Html.ActionLink("Edit", "Edit", new { id=item.CountryCode.Trim() })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.CountryCode.Trim() })%>
            </td>
            <td>
                <%= Html.Encode(item.CountryCode) %>
            </td>
            <td>
                <%= Html.Encode(item.CountryName) %>
            </td>
            <td>
                
               <img alt="", src="<%= Html.getPhotoUrl(item.PhotoUrl) %>" style=" height:100px;" />
            </td>
            <td>
                <%= Html.Encode(item.IntroText.Length>200 ? item.IntroText.Substring(0,200)+"...": item.IntroText) %>
            </td>
        </tr>
    
    <% } %>

    </table>



</asp:Content>

