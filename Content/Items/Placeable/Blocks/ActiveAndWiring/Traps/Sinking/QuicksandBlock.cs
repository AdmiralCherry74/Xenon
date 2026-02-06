using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Sinking
{
    public class QuicksandBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Quicksand>());
        }
    }
}
