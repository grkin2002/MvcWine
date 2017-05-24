<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PagedList<MvcWine.Models.Product>>" %>
<div id="dvProducts">
    <div class="item">
        <%=Html.AjaxPager(Model, new PagerOptions() { PageIndexParameterName = "pageIndex",HorizontalAlign="right" }, new AjaxOptions() { UpdateTargetId = "dvProducts" })%>
    <br />
    </div>
    <%foreach (var item in Model)
      { %>
    <div class="item">
        <span class="item-left"><a href='<%=Url.Action("Index","Product", new{ id=item.ProductId }) %>'>
            <img alt="<%= Html.Encode(item.PName) %>" src="<%=Html.getProductPhotoUrl(item.PhotoUrl) %>" />
        </a></span><span class="item-middle"><span style="font-weight: bold; font-family: Sans-Serif;
            letter-spacing: 0.1px; color: Black;">
            <%=Html.Encode(item.PName) %></span>
            <br />
            <span style="font-size: x-small">
                <%=Html.ActionLink(Html.getCountryNameByCode(item.CountryCode.Trim()),"ListByCountry","List", new{ id=item.CountryCode.Trim() },null) %>
                >
                <%=Html.ActionLink(Html.getRegionNameByCode(item.RegionCode.Trim()), "ListByRegion", "list", new {id=item.RegionCode.Trim() },null)%>
                >
                <%=Html.ActionLink(Html.getSubRegionNameByCode(item.SubRegionCode.Trim()),"ListBySubRegion", "List", new {id=item.SubRegionCode.Trim()},null) %>
            </span>
            <br />
            <br />
            <span style="letter-spacing: 0.1px; word-spacing: 0.1px; font-family: Sans-Serif;">
                <%=Html.getGrapeTypeById(item.GrapeId??0) %>,
                <%=Html.getTasteTypeById(item.TasteType.Trim()) %>,
                <%=Html.Encode(string.Format("{0}%", item.VOL)) %>
            </span>
            <br />
            <br />
            <span style="font-style: italic; color: Blue">Drink now/Lay down
                <%=Html.Encode(item.DrinkStart)%>-<%=Html.Encode(item.DrinkEnd)%>
            </span><span class="item-right">Bottle&nbsp
                <%=Html.Encode(string.Format( "{0:F}",item.UnitPrice)) %>
                <br />
                <br />
                <img alt="add-to-basket" src="../../Image/Add-to-basket-001mini.png" />
            </span></span><span class="clear"></span>
    </div>
    <%} %>
       <div class="item">
        <%=Html.AjaxPager(Model, new PagerOptions() { PageIndexParameterName = "pageIndex",HorizontalAlign="right" }, new AjaxOptions() { UpdateTargetId = "dvProducts" })%>
    <br />
    </div>
</div>
