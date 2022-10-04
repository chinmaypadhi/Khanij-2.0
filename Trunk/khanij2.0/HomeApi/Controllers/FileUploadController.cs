using HomeEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
       [HttpPost]
        public FileUpload ReturnDocPath(FileUpload obj)
        {
            fileUploadReturnData objon = new fileUploadReturnData();
            return objon.returnFile(obj);
        }
    }


    public class fileUploadReturnData
    {
        public FileUpload returnFile(FileUpload objdata)
        {
            FileUpload objReturn = new FileUpload();
            string mystr = objdata.KeyTotalFile.Replace("base64,", string.Empty);  
            var testb = Convert.FromBase64String(mystr);//base 64 to  binary
            using var writer = new BinaryWriter(File.OpenWrite(objdata.FilePath+objdata.FileName));
            writer.Write(testb);           
            return objdata;
        }
    }
}
