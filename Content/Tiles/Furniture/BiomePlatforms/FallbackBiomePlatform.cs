using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Furniture.BiomePlatforms
{
    public class FallbackBiomePlatform : PlatformTemplate
    {
        public override int Dust => DustID.WhiteTorch;
    }
}
