<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWine.Models.Product>>" %>

<%@ Import Namespace="MvcWine.Helpers" %>
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
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Country-Region-SubRegion
            </th>
            <th>
                GrapeType-WineId-MakeBy
            </th>
            <th>
                Price
                <br />
                Package
                <br />
                Promote
                <br />
                InStock-Valid
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.ProductId }) %>
                |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.ProductId })%>
            </td>
            <td>
                <%= Html.Encode(item.ProductId) %>
            </td>
            <td>
                <%= Html.Encode(item.PName) %>
            </td>
            <td>
                <%= Html.getCountryNameByCode(item.CountryCode?? "") %>
                <br />
                <%= Html.getRegionNameByCode(item.RegionCode?? "") %>
                <br />
                <%= Html.getSubRegionNameByCode(item.SubRegionCode?? "") %>
            </td>
            <td>
                <%= Html.getGrapeTypeById(item.GrapeId?? 0) %>
                <br />
                <%= Html.getWineTypeById(item.WineId?? 0) %>
                <br />
                <%= Html.getProducerNameById(item.ProducerId?? 0) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.UnitPrice)) %>
                <br />
                <%= Html.Encode(item.Package) %>
                <br />
                <%= Html.Encode(item.PromoteType) %>
                <br />
                <%= Html.CheckBox("InStock",item.InStock) %>&nbsp;&nbsp;
                <%= Html.CheckBox("Valid",item.Valid) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
