using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using vad_core.HubFunctions;
using Microsoft.AspNetCore.Http.Features;
using vad_core.Hubs;
using vad_core.ClientsRepo;
using vad_core.Validators;
using Microsoft.AspNetCore.Mvc.Routing;
//using vad_core.Hubs;
//using vad_core.Hubs;

namespace vad_core.Controllers
{
    public class UploaderController : Controller
    {

        private IHostingEnvironment hostingEnvironment;
        private readonly IConnectionManager connectionManager;
        public UploaderController(IHostingEnvironment hostingEnvironment, IConnectionManager connMangr)
        {
            this.hostingEnvironment = hostingEnvironment;
            connectionManager = connMangr;
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile files)
        {
            long totalBytes = files.Length;
            var hubContext = connectionManager.GetHubContext<ProgressHub>();
            var ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
            var connectionId = RepositoryIsolator.Of.Clients.GetId(ip);
            string filename = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');

            filename = this.EnsureCorrectFilename(filename);
            IValidator validator = new AudioExtensionValidator();
            bool isExtensionValid =  validator.Validate(ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"'));
            string fileServerPath = this.GetPathAndFilename(filename);
            if (isExtensionValid)
            {


                byte[] buffer = new byte[16 * 1024];

                using (FileStream output = System.IO.File.Create(fileServerPath))
                {
                    using (Stream input = files.OpenReadStream())
                    {
                        long totalReadBytes = 0;
                        int readBytes;

                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalReadBytes += readBytes;
                            int percentage = (int)((float)totalReadBytes / (float)totalBytes * 100.0);
                            //var hubContext = connectionManager.GetHubContext<ProgressHub>();
                            //hubContext.Clients.All.AddProgress(percentage);

                            ProgressBarFunction sendProgress = new ProgressBarFunction(hubContext);
                            sendProgress.SendToHub(percentage, connectionId);

                        }
                    }

                    

                }
                return Json(new { status = "success", filePath = fileServerPath });
            }
            else
            { 
                return Json(new { status = "error" });
            }
        }

        //[HttpPost]
        //public  IActionResult FileUploaded()
        //{
        //    System.Diagnostics.Debug.WriteLine(fileServerPath);
        //    //var actionUrl = Url.Action("AudioProcess", "Process", new { filePath = fileServerPath });
        //    //var urlHelper = HttpContext.Features.Get<IUrlHelper>();
        //    //var actionUrl = urlHelper.Action("AudioProcess", "Process", new { filePath = fileServerPath });
            

        //}

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            string path = this.hostingEnvironment.WebRootPath + "\\uploads\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + filename;
        }


    }
}