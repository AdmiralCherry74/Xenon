using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Walls.NaturalWalls.Mountain;

namespace Xenon.Content.Items.Placeable.Wall.Natural.Mountain;

public class OuranoStoneWallItem : ModItem
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
        Item.createWall = ModContent.WallType<OuranoStoneWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
    }
}
