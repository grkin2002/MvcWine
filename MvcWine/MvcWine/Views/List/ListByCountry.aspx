<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.ViewModels.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ListByCountry
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%Html.RenderPartial("TitleCountryUserControl", Model.Country); %>

 <%Html.RenderPartial("ListProductUserControl", Model.Products); %>       
</asp:Content>
