<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWine.ViewModels.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListBySubRegion
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <%Html.RenderPartial("TitleSubRegionUserControl", Model.SubRegion); %>

 <%Html.RenderPartial("ListProductUserControl", Model.Products); %> 

</asp:Content>
