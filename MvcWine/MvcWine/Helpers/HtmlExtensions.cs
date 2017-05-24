using System.Collections.Generic;
using System.Web;
using MvcWine.Models;
using System.Web.Mvc;

namespace MvcWine.Helpers
{

    public  static class HtmlExtensions
    {
        public static string getPhotoUrl(this HtmlHelper html, string photoUrl)
        {
            string virtualFolder = "/UploadFile/";
            if (!string.IsNullOrEmpty(photoUrl))
                return virtualFolder + html.Encode(photoUrl);
            else
                return virtualFolder + "NotFound.jpg";       
        }

        public static string getProductPhotoUrl(this HtmlHelper html, string photoUrl)
        {
            string virtualFolder = "/ProductFile/";
            if (!string.IsNullOrEmpty(photoUrl))
                return virtualFolder + html.Encode(photoUrl);
            else
                return virtualFolder + "nopicture.gif"; //白色画面
        }


        public static string getCountryNameByCode(this HtmlHelper html, string countryCode)
        {
            //从Application拿到Dictionary
            Dictionary<string, string> CountryDict =(Dictionary<string, string>) HttpContext.Current.Application[ConstName.CountryDict];
            return CountryDict[countryCode.Trim()];
        }

        public static string getRegionNameByCode(this HtmlHelper html, string regionCode)
        {
            Dictionary<string, string> RegionDict = (Dictionary<string, string>)HttpContext.Current.Application[ConstName.RegionDict];
            return RegionDict[regionCode.Trim()];
        }

        public static string getSubRegionNameByCode(this HtmlHelper html, string subRegionCode)
        {
            Dictionary<string, string> SubRegionDict = (Dictionary<string, string>)HttpContext.Current.Application[ConstName.SubRegionDict];
            return SubRegionDict[subRegionCode.Trim()];

        }

        public static string getGrapeTypeById(this HtmlHelper html, int grapeId)
        {
            Dictionary<int, string> GrapeDict = (Dictionary<int, string>)HttpContext.Current.Application[ConstName.GrapeDict];
            return GrapeDict[grapeId];
        }

        public static string getWineTypeById(this HtmlHelper html, int wineId)
        {
            Dictionary<int, string> WineDict = (Dictionary<int, string>)HttpContext.Current.Application[ConstName.WineDict];
            return WineDict[wineId];
        }
        public static string getProducerNameById(this HtmlHelper html, int producerId)
        {
            Dictionary<int, string> ProducerDict = (Dictionary<int, string>)HttpContext.Current.Application[ConstName.ProducerDict];
            return ProducerDict[producerId];
        }
        public static string getTasteTypeById(this HtmlHelper html, string tasteType)
        {
            Dictionary<string, string> TasteDict = (Dictionary<string, string>)HttpContext.Current.Application[ConstName.TasteDict];
            return TasteDict[tasteType];

        }

       
    }
}
