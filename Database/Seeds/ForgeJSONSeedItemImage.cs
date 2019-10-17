using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace technology_tp1
{
    public class ForgeJSONSeedItemImage<T> : ForgeJSONSeed<T> where T : Models.ItemImage
    {
        private const string PicturesDirectory = "Database/Seeds/Pictures/";

        protected override string FileName => "ItemImage.json";

        public override IEnumerable<T> Values
        {
            get
            {
                List<Models.ItemImage> images = new List<Models.ItemImage>();
                foreach (var item in JToken)
                {
                    JObject jsonItem = (JObject)item;
                    images.Add(new Models.ItemImage()
                    {
                        Id = jsonItem.Value<int>("id"),
                        Name = jsonItem.Value<string>("name"),
                        File = jsonItem.Value<string>("full"),
                        CreatedOn = jsonItem.Value<DateTime>("createdOn"),
                        UpdatedOn = jsonItem.Value<DateTime?>("updatedOn"),
                    });
                }
                return images.Cast<T>();
            }
        }

        protected override JToken CreateJSON()
        {
            JArray jArray = new JArray();
            int id = 1;
            foreach (var picturePath in Directory.GetFiles(PicturesDirectory))
            {
                byte[] image = File.ReadAllBytes(picturePath);
                string name = picturePath.Split('/').Last();
                JObject picture = new JObject();
                string imageDataBase64 = Convert.ToBase64String(File.ReadAllBytes(picturePath));

                picture.Add("id", new JValue(id++ * -1));
                picture.Add("name", new JValue(name));
                picture.Add("small", new JValue(imageDataBase64));
                picture.Add("medium", new JValue(imageDataBase64));
                picture.Add("full", new JValue(imageDataBase64));
                picture.Add("createdOn", new JValue(DateTime.Now));
                picture.Add("updatedOn", null);
                jArray.Add(picture);
            }
            return jArray;
        }
    }
}

