using System;
using CartelLoyola.Domain;
using CartelLoyola.Service;
using CartelLoyola.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace CartelLoyola.UIAdmin.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {

        CartelLoyolaContext _dbContext = new CartelLoyolaContext();
        private Guid imageId;

        [HttpPost("[action]")]
        public Guid UploadImage(IList<IFormFile> files)
        {

            IFormFile uploadedImage = files.FirstOrDefault();
            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                using (CartelLoyolaContext dbContext = new CartelLoyolaContext())
                {
                    MemoryStream ms = new MemoryStream();
                    uploadedImage.OpenReadStream().CopyTo(ms);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                    // Convert the array to a base 64 sring.
                    String s = Convert.ToBase64String(ms.ToArray(),
                                         Base64FormattingOptions.InsertLineBreaks);

                    Imagem imageEntity = new Imagem()
                    {
                        Id = Guid.NewGuid(),
                        Name = uploadedImage.Name,
                        Data = s,
                        Width = img.Width,
                        Height = img.Height,
                        ContentType = uploadedImage.ContentType
                    };
                    dbContext.Images.Add(imageEntity);
                    dbContext.SaveChanges();

                    imageId = imageEntity.Id;

                }
            }
            return imageId;
        }

        [HttpGet("[action]")]
        public JsonResult GetImageId(Guid id)
        {
            var image = _dbContext.Images.FirstOrDefault(m => m.Id == id);

            return Json(image);
        }

    }
}