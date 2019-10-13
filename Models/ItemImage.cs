using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Technology_Tp1_React.General;

namespace technology_tp1.Models
{
    /// <summary>
    /// Class that handle the item image model data
    /// </summary>
    public class ItemImage : IEntity
    {
        public ItemImage(){
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        // Limits the maximum file size to 1mb
        public static int MAXIMUM_FILE_SIZE = 1000000;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string File { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set ; }

        public static string ParseImage(IFormFile file)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                file.CopyTo(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
