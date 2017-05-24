using System.Web.Mvc;
using MvcWine.Helpers;

namespace MvcWine.Controllers
{
    public class UtilityController : Controller
    {
        public string uploadFolder;
        //public string virtualFolder;
        

        [HttpPost]
        public string AsyncUpload()
        {
            uploadFolder = "~/UploadFile/";
            DiskFileHandler fileHandler = new DiskFileHandler( uploadFolder );
            return fileHandler.SaveUploadedFile(Request.Files[0]);
        }

        [HttpPost]
        public string ProductUpload()
        {
            uploadFolder = "~/ProductFile/";
            DiskFileHandler fileHandler = new DiskFileHandler(uploadFolder);
            return fileHandler.SaveUploadedFile(Request.Files[0]);
        }


        //[HttpPost]
        //public ActionResult FileUpload()
        //{
        //    var r = new List<ViewDataUploadFilesResult>();
        //    foreach (string file in Request.Files)
        //    {
        //        HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
        //        if (hpf.ContentLength == 0)
        //            continue;
        //        string savedFileName = Path.Combine(
        //            AppDomain.CurrentDomain.BaseDirectory+"\\UploadFile\\",
        //            Path.GetFileName(hpf.FileName));
        //        hpf.SaveAs(savedFileName);
        //        r.Add(new ViewDataUploadFilesResult()
        //        {
        //            Name = savedFileName,
        //            Length = hpf.ContentLength
        //        });
        //    }
        //    ViewData["FileResult"] = r;
        //    return View("Create");
        //}


    }
}
