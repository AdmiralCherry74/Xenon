using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.OreBasedFurniture.Candelabra;

namespace Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Candelabra;

public class CopperCandelabra : ModItem
{
    public override void SetDefaults()
    {

        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<CopperCandelabraTile>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 1500;
        Item.useAnimation = 15;
        Item.height = 16;
    }
}
