using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.CraftingStations;

namespace Xenon.Content.Items.Placeable.Furniture.Crafting
{
    public class CopperFurnace : ModItem
    {

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CopperFurnaceTile>());
            Item.width = 30;
            Item.height = 26;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 4, 50);
        }
    }
}