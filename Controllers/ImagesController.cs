using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using technology_tp1.Models;
using System.Drawing;
using System.Drawing.Imaging;
using static technology_tp1.Models.ItemImage;
using Technology_Tp1_React.General;

namespace technology_tp1.Controllers
{
    public class ImagesController : CrudController<ItemImage>
    {
        public ImagesController(IRepository<ItemImage> repository): base(repository){}

        public IActionResult Create([Bind("Name")] ItemImage itemImage, IFormFile file)
        {
            // Limit maximum file size to 1mb.
            if(file.Length > MAXIMUM_FILE_SIZE)
            {
                ErrorResponse.InternalServerError("File size exceed 1mb");
            }

            try
            {
                //Temporaire 
                //itemImage.Full = ParseImage(file).ToString();
                //itemImage.Medium = ScaleImage(itemImage.GetFullSize(), 500, 500);
                //itemImage.Small = ScaleImage(itemImage.FullBlob, 250, 250);

                Repository.Create(itemImage);
                Repository.SaveChanges();
                return Redirect("/");
            }
            catch (IOException)
            {
                return Redirect("/");
            }
        }
    }
}
