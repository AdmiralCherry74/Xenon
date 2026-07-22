using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Somnolent;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Snow
{
    public class IndigoIceBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<IndigoIce>());
        }
    }
}
