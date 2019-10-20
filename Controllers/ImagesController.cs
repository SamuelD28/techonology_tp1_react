using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using technology_tp1.Models;
using static technology_tp1.Models.ItemImage;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;

namespace technology_tp1.Controllers
{
    [Route("api/images")]
    public class ImagesController : CrudController<ItemImage>
    {
        public ImagesController(IRepository<ItemImage> repository)
            : base(repository) { }

        [HttpGet]
        public IActionResult Get()
            => base.GetAllRecord();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => base.GetRecordById(id);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => base.DeleteRecord(id);

        [HttpPost]
        public IActionResult Create([FromForm] ItemImage itemImage, IFormFile file)
        {
            try
            {
                // Limit maximum file size to 1mb.
                if (file.Length > MAXIMUM_FILE_SIZE)
                {
                    return ErrorResponse.InternalServerError("File size exceed 1mb");
                }

                itemImage.File = ParseImage(file).ToString();

                Repository.Create(itemImage);
                Repository.SaveChanges();
                return CreateValidResponse(itemImage, StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }
    }
}
