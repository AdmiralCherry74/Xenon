using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Desert
{
    public class HardenedGutsandBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HardenedGutsand>());
        }
    }
}
