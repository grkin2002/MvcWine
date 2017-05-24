<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Wellcome to Home page</h2>
    <fieldset>
        <legend>Browse</legend>
        <%=Html.ActionLink("ItemList", "Index", "List", null, null) %>
    </fieldset>
    <fieldset>
        <legend>管理</legend>
        <table>
            <tr>
                <td>
                    <%=Html.ActionLink("AdminCountry", "Index", "AdminCountry", null, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("AdminWine", "Index", "AdminWine", null, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("AdminGrape", "Index", "AdminGrape", null, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("AdminRegion", "Index", "AdminRegion", null, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("AdminSubregion", "Index", "AdminSubregion", null, null)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%=Html.ActionLink("AdminMadeBy", "Index", "AdminMadeBy", null, null) %>
                </td>
                <td>
                    <%=Html.ActionLink("AdminProdcut","Index", "AdminProduct",null,null) %>
                </td>
                <td>
                    <%=Html.ActionLink("AdminTaste", "Index", "AdminTaste", null, null) %>
                </td>
                <td>
                    <%=Html.ActionLink("AdminPromote", "Index", "AdminPromote", null, null) %>
                </td>
                <td>
                
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
            http://asp.net/mvc</a>.
    </p>
</asp:Content>
