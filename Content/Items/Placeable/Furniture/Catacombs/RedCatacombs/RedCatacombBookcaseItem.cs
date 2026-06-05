using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;
using Xenon.Content.Tiles.Furniture;
using Xenon.Content.Tiles.Furniture.Catacombs.RedCatacombs;

namespace Xenon.Content.Items.Placeable.Furniture.Catacombs.RedCatacombs;

public class RedCatacombBookcaseItem : ModItem
{
    public override void SetDefaults()
    {

        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<RedCatacombBookcase>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 300;
        Item.useAnimation = 15;
        Item.height = 16;
    }
}
