using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace technology_tp1
{
    public class ForgeJSONSeedDeliveryMan<T> : ForgeJSONSeed<T> where T : Models.DeliveryMan
    {
        public override IEnumerable<T> Values
        {
            get
            {
                List<Models.DeliveryMan> deliveryMen = new List<Models.DeliveryMan>();
                foreach (var item in JToken)
                {
                    JObject jsonItem = (JObject)item;
                    deliveryMen.Add(new Models.DeliveryMan()
                    {
                        Id = jsonItem.Value<int>("id"),
                        Name = jsonItem.Value<string>("name"),
                        Phone = jsonItem.Value<string>("phone"),
                        IsEmployed = jsonItem.Value<bool>("isEmployed"),
                    });
                }
                return deliveryMen.Cast<T>();
            }
        }

        protected override string FileName => "DeliveryManSeed.json";

        protected override JToken CreateJSON()
        {
            JArray jArray = new JArray();
            for (int i = 1; i < 50; i++)
            {
                JObject deliveryMan = new JObject();
                deliveryMan.Add("id", new JValue(i * -1));
                deliveryMan.Add("name", new JValue(Faker.NameFaker.Name()));
                deliveryMan.Add("phone", new JValue(Faker.PhoneFaker.Phone()));
                deliveryMan.Add("isEmployed", new JValue(Faker.BooleanFaker.Boolean()));
                jArray.Add(deliveryMan);
            }

            return jArray;
        }
    }
}
