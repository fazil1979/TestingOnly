using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace DemoService.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlayCaddyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlayCaddyService.svc or PlayCaddyService.svc.cs at the Solution Explorer and start debugging.
    public class PlayCaddyService : IPlayCaddyService
    {
        public string DoWork()
        {
            return "Successful test";
        }

        //*********************demo_FileUpload 2*******************************//
        #region demo_FileUpload
        public string demo_FileUpload()
        {
            string execute = "Started";
            try
            {
                var httpRequest = HttpContext.Current.Request;
                execute += "1. Get hhtpRequest ";
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        execute += " 2. Get file";
                        string fname = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName.ToString());
                        execute += " 3. fname : " + fname;
                        string extension = Path.GetExtension(postedFile.FileName);
                        execute += " 4. extension : " + extension;
                        //string newFileName = "";
                        //if (FileTypeId == "1")
                        //    newFileName = UserId + DateTime.Now.ToString("_ddMMyyhhmmssfff") + ".jpeg";
                        //else if (FileTypeId == "2")
                        //    newFileName = UserId + DateTime.Now.ToString("_ddMMyyhhmmssfff") + ".mp4";
                        //else if (FileTypeId == "3")
                        //    newFileName = UserId + DateTime.Now.ToString("_ddMMyyhhmmssfff") + ".docx";
                        string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Files/" + postedFile.FileName);
                        execute += " 5. filePath : " + filePath;
                        postedFile.SaveAs(filePath);
                        execute += " 6. Saved file";
                    }
                }

                return "success..   \r\n" + execute;
            }
            catch (Exception EX)
            {
                return "failed " + execute;
            }

        }
        #endregion
    }
}
