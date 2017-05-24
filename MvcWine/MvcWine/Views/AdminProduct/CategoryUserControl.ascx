<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWine.ViewModels.ProductAdminViewModel>" %>


<script type="text/javascript" language="javascript">
    $(function() {
        $('.date-pick').datepicker({ buttonImage: '../../Image/datepicker.gif' });
    });
</script>

<fieldset>
    <legend>各种分类</legend>
    
    
    <div class="editor-field">
        葡萄类型：
        <%= Html.DropDownListFor(model => model.Product.GrapeId, new SelectList(Model.Grapes, "GrapeId", "GrapeType", Model.Product.GrapeId)) %>
        <%= Html.ValidationMessageFor(model => model.Product.GrapeId) %>
        酒类型：
        <%= Html.DropDownListFor(model => model.Product.WineId, new SelectList(Model.Wines,"WineId", "WineType", Model.Product.WineId)) %>
        <%= Html.ValidationMessageFor(model => model.Product.WineId) %>
    </div>
    <br />
    <div class="editor-field">
        口味：
        <%= Html.DropDownListFor(model => model.Product.TasteType,new SelectList(Model.Tastes,"TasteType", "TasteDesc", Model.Product.TasteType)) %>
        <%= Html.ValidationMessageFor(model => model.Product.TasteType) %>
    
       
        促销类型：
        <%= Html.DropDownListFor(model => model.Product.PromoteType, new SelectList(Model.Promotes, "PromoteType", "Description", Model.Product.PromoteType)) %>
        <%= Html.ValidationMessageFor(model => model.Product.PromoteType) %>
       
        瓶盖类型：
        <%= Html.DropDownListFor(model => model.Product.CapTypeId, new SelectList(Model.CapeTypes, "id", "CapType", Model.Product.CapTypeId)) %>
        <%= Html.ValidationMessageFor(model => model.Product.CapTypeId) %>
    </div>
    <br />
    <div class="editor-field">
        生产商：
        <%= Html.DropDownListFor(model => model.Product.ProducerId, new SelectList(Model.Producers,"ProducerId", "ProducerName", Model.Product.ProducerId)) %>
        <%= Html.ValidationMessageFor(model => model.Product.ProducerId) %>
        <%=Html.ActionLink("找不到生产商，增加新的生产商","Index","AdminMadeBy") %>
    </div>
    <br />

    <div class="editor-field">
适合饮用时间：&nbsp &nbsp 开始：
        <%= Html.DropDownListFor(model=>model.Product.DrinkStart, new SelectList(Model.DrinkYear, "YearValue", "YearString", Model.Product.DrinkStart))%>
        <%= Html.ValidationMessageFor(model => model.Product.DrinkStart) %>
        结束：
        <%= Html.DropDownListFor(model => model.Product.DrinkEnd, new SelectList(Model.DrinkYear, "YearValue", "YearString", Model.Product.DrinkEnd))%>
        <%= Html.ValidationMessageFor(model => model.Product.DrinkEnd) %>
    </div>
    

</fieldset>
