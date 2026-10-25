using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.Fountains;

namespace Xenon.Content.Items.Placeable.Furniture.Fountains;

public class CorrosionWaterFountainItem : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CorrosionWaterFountain>(), 0);
        Item.width = 26;
        Item.height = 36;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(0, 4);
    }
}