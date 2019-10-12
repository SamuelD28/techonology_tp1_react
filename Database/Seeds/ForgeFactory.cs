using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technology_tp1
{
    public static class ForgeFactory
    {
        public static ForgeJSONSeed<Models.DeliveryMan> ForgeDeliveryMan => new ForgeJSONSeedDeliveryMan<Models.DeliveryMan>();

        public static ForgeJSONSeed<Models.ItemImage> ForgeImageItem => new ForgeJSONSeedItemImage<Models.ItemImage>();

        public static ForgeJSONSeed<Models.MenuItem> ForgeMenuItem => new ForgeJSONSeedMenuItem<Models.MenuItem>();
    }
}
