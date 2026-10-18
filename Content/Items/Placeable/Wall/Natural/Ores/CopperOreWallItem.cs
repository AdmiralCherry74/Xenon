using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Bricks;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Bricks;
using Xenon.Content.Walls.NaturalWalls.Ores;

namespace Xenon.Content.Items.Placeable.Wall.Natural.Ores;

public class CopperOreWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 400;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 5;
        Item.createWall = ModContent.WallType<CopperOreWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
        Item.sellPrice(0, 0, 0, 12);
    }
}
