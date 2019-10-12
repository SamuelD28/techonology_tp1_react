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
        public string Small { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        public string Full { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime UpdatedOn { get; set ; }

        public byte[] GetSmallSize()
            => Convert.FromBase64String(Small ?? String.Empty);

        public byte[] GetMediumSize()
            => Convert.FromBase64String(Medium ?? String.Empty);

        public byte[] GetFullSize()
            => Convert.FromBase64String(Full ?? String.Empty);

        public string GetBase64Encoded(byte[] file)
        {
            string base64 = Convert.ToBase64String(file);
            return string.Format("data:image/png;base64,{0}", base64);
        }

        public static byte[] ScaleImage(byte[] imageInBytes, int height, int width)
        {
            using (MemoryStream imageStream = new MemoryStream(imageInBytes))
            using (MemoryStream scaledImage = new MemoryStream())
            {
                Image image =
                    Image
                    .FromStream(imageStream)
                    .GetThumbnailImage(height,
                        width,
                        null,
                        IntPtr.Zero
                );
                image.Save(scaledImage, ImageFormat.Png);
                return scaledImage.ToArray();
            }
        }

        public static byte[] ParseImage(IFormFile file)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                file.CopyTo(stream);
                return stream.ToArray();
            }
        }
    }
}
