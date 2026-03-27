using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.Organic;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood
{
    public class Bilewood : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Corrosion.Bilewood>());
        }
    }
}