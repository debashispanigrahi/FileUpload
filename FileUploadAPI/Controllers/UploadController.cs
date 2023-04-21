using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FileUploadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [RequestSizeLimit(int.MaxValue)]
        public IActionResult FileUpload(InputModel inputModel)
        {
            try
            {
                //52428800
                var uploadModel = JsonConvert.DeserializeObject<UploadModel>(inputModel.FileData);
                Uploading(uploadModel);
                return Ok("Uploaded");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private void Uploading(UploadModel uploadModel)
        {
            string filePath = Path.Combine(@"/Users/debashispanigrahi/Documents",uploadModel.FileName); // example file path

            System.IO.File.WriteAllBytes(filePath, uploadModel.FileBytes);

        }
    }
}
