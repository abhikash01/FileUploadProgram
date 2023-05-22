using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FileUploadApp.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage Upload()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var httpRequest = HttpContext.Current.Request;
                var files = new List<string>();
                if (httpRequest.Files.Count > 0)
                {
                    foreach(string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/Content/Uploads/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        files.Add(filePath);
                    }
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}