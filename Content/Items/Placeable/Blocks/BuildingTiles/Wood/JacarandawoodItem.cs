using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Building.Wood;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood
{
    public class JacarandawoodItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Bilewood>());
        }
    }
}
