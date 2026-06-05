using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.FakeNatural
{
    public class CoarseDirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Building.SyntheticNatural.CoarseDirt>());
        }
    }
}