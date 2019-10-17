﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace technology_tp1
{
    public class ForgeJSONSeedMenuItem<T> : ForgeJSONSeed<T> where T : Models.MenuItem
    {
        private Dictionary<string, Models.MenuItem> menu = new Dictionary<string, Models.MenuItem>()
        {
            {
                "All_Dress.png" ,
                new Models.MenuItem()
                {
                    Id = -1,
                    Name = "All dress",
                    Price = 25.25M,
                    Category = Models.Category.Pizza,
                }
            },
            {
                "Chocolate_cake_dessert.png" ,
                new Models.MenuItem()
                {
                    Id = -2,
                    Name = "Chocolate cake",
                    Price = 5M,
                    Category = Models.Category.Dessert,
                }
            },
            {
                "coke_drink.png" ,
                new Models.MenuItem()
                {
                    Id = -3,
                    Name = "Coke drink",
                    Price = 1.33M,
                    Category = Models.Category.Drink,
                }
            },
            {
                "French_fries.png" ,
                new Models.MenuItem()
                {
                    Id = -4,
                    Name = "French fries",
                    Price = 4.0M,
                    Category = Models.Category.Other,
                }
            },
            {
                "Fromage.png" ,
                new Models.MenuItem()
                {
                    Id = -1,
                    Name = "Chesse",
                    Price = 15M,
                    Category = Models.Category.Pizza,
                }
            },
            {
                "Hawaiian.png" ,
                new Models.MenuItem()
                {
                    Id = -1,
                    Name = "Hawaiian",
                    Price = 18.25M,
                    Category = Models.Category.Pizza,
                }
            },
            {
                "PeperonniFromage.png" ,
                new Models.MenuItem()
                {
                    Id = -1,
                    Name = "Pepperoni & chesse",
                    Price = 14.58M,
                    Category = Models.Category.Pizza,
                }
            },
        };

        protected override string FileName => "MenuItem.json";

        public override IEnumerable<T> Values
        {
            get
            {
                List<Models.MenuItem> items = new List<Models.MenuItem>();
                foreach (var item in JToken)
                {
                    JObject jsonItem = (JObject)item;
                    items.Add(new Models.MenuItem()
                    {
                        Id = jsonItem.Value<int>("id"),
                        Name = jsonItem.Value<string>("name"),
                        Price = jsonItem.Value<decimal>("price"),
                        ImageId = jsonItem.Value<int>("imageId"),
                        Category = (Models.Category)jsonItem.Value<int>("category"),
                        CreatedOn = jsonItem.Value<DateTime>("createdOn"),
                        UpdatedOn = jsonItem.Value<DateTime?>("updatedOn"),
                    });
                }
                return items.Cast<T>();
            }
        }

        protected override JToken CreateJSON()
        {
            var forge = ForgeFactory.ForgeImageItem;

            if (!forge.Exist)
            {
                forge.Forge();
            }

            var images = forge.Values;

            JArray jArray = new JArray();
            int id = 1;
            foreach (var item in menu)
            {
                int imageId = images.First(i => i.Name == item.Key).Id;

                JObject items = new JObject();

                items.Add("id", new JValue(id++ * -1));
                items.Add("name", new JValue(item.Value.Name));
                items.Add("price", new JValue(item.Value.Price));
                items.Add("imageId", new JValue(imageId));
                items.Add("category", new JValue(item.Value.Category));
                items.Add("createdOn", new JValue(DateTime.Now));
                items.Add("updatedOn", null);
                jArray.Add(items);
            }
            return jArray;
        }
    }
}
