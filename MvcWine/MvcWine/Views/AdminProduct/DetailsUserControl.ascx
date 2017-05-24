<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWine.ViewModels.ProductAdminViewModel>" %>
<fieldset>
    <legend>产品细节</legend>
    <table style="width: 100%;">
        <tr>
            <td>
                价格：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.Product.UnitPrice) %>
                    <%= Html.ValidationMessageFor(model => model.Product.UnitPrice) %>
                </div>
            </td>
            <td>
                酒精度：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.Product.VOL, new { style="width:35px" })%>%
                    <%= Html.ValidationMessageFor(model => model.Product.VOL) %>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                包装细节：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.Product.Package) %>
                    <%= Html.ValidationMessageFor(model => model.Product.Package) %>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                年份：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.DropDownListFor(model => model.Product.Vintage, new SelectList(Model.Vintages, "VintageValue", "VintageString", Model.Product.Vintage))%>
                    <%= Html.ValidationMessageFor(model => model.Product.Vintage) %>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                库存（有货否）：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.CheckBoxFor(model => model.Product.InStock) %>
                    <%= Html.ValidationMessageFor(model => model.Product.InStock) %>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                是否有效（删除为无效）：
            </td>
            <td>
                <div class="editor-field">
                    <%= Html.CheckBoxFor(model => model.Product.Valid) %>
                    <%= Html.ValidationMessageFor(model => model.Product.Valid) %>
                </div>
            </td>
        </tr>
    </table>
</fieldset>
