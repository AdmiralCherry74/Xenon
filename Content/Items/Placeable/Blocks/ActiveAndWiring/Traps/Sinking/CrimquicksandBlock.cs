using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Sinking
{
    public class CrimquicksandBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Crimquicksand>());
        }
    }
}
