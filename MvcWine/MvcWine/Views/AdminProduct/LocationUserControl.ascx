<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<MvcWine.ViewModels.ProductAdminViewModel>" %>

<script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>

<script type="text/javascript">

    var ddlCountries;
    var ddlRegions;
    var ddlSubRegions;

    function pageLoad() {
     
        ddlCountries = $get("Product_CountryCode");
        ddlRegions = $get("Product_RegionCode");
        ddlSubRegions = $get("Product_SubRegionCode");
        $addHandler(ddlCountries, "change", bindOptionsRegion);
        $addHandler(ddlRegions, "change", bindOptionsSubRegion);
        bindOptionsRegion();
        bindOptionsSubRegion();
    }

    function bindOptionsRegion() {
        ddlRegions.options.length = 0;
        ddlSubRegions.options.length = 0;
        var countryCode = $.trim(ddlCountries.value);

        if (countryCode) {
            Sys.Net.WebServiceProxy.invoke
            (
                "/Services/LocationService.asmx",
                "Regions",
                false,
                { "CountryCode": countryCode },
                bindOptionResultsRegion

            );
        }
    }

    function bindOptionsSubRegion() {
        ddlSubRegions.options.length = 0;
        var regionCode = $.trim(ddlRegions.value);

        if (regionCode) {
            Sys.Net.WebServiceProxy.invoke
                (
                    "/Services/LocationService.asmx",
                    "SubRegions",
                    false,
                    { "RegionCode": regionCode },
                    bindOptionResultsSubRegion
                );


        }
    }

    function bindOptionResultsRegion(data) {

        var newOption = new Option("请选择", "");
        ddlRegions.options.add(newOption);
        for (var k = 0; k < data.length; k++) {
            newOption = new Option(data[k].RegionName, data[k].RegionCode);
            ddlRegions.options.add(newOption);
        }
    }

    function bindOptionResultsSubRegion(data) {

        var newOption;
        for (var k = 0; k < data.length; k++) {
            newOption = new Option(data[k].SubRegionName, data[k].SubRegionCode);
            ddlSubRegions.options.add(newOption);
        }

    }
  
</script>

<fieldset>
    <legend>出产地</legend>
    <div class="editor-field">
        <label for="Country">
            国家：</label>
        <%=Html.DropDownListFor(model=>model.Product.CountryCode, new SelectList(Model.Countries, "CountryCode", "CountryName", Model.Product.CountryCode), "--请选择--", null)%>
        <label for="Region">
            地区：</label>
        <select name="Product.RegionCode" id="Product_RegionCode">
        </select>
        <label for="SubRegion">
            小区：</label>
        <select name="Product.SubRegionCode" id="Product_SubRegionCode">
        </select>
    </div>
</fieldset>
