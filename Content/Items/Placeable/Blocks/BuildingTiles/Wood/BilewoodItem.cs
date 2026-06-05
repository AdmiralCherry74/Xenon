using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.Organic;
using Xenon.Content.Tiles.Building.Wood;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood
{
    public class BilewoodItem : ModItem
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