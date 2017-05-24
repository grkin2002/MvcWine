using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace MvcWine.Helpers
{
    public class DiskFileHandler
    {
      

        private  string physicalFolder; 
        
        public DiskFileHandler( string uploadFolder)
        {
           physicalFolder = HostingEnvironment.MapPath(uploadFolder);
        }

        public string SaveUploadedFile(HttpPostedFileBase fileBase)
        {
            fileBase.SaveAs(GetDiskLocation(fileBase));
            return  fileBase.FileName;
        }

        public string GetDiskLocation(HttpPostedFileBase fileBase)
        {
            return Path.Combine(physicalFolder, fileBase.FileName);
        }
    }
}
