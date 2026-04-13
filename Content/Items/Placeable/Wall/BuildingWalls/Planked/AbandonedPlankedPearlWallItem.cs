using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Walls.BuildingWalls.Planked;

namespace Xenon.Content.Items.Placeable.Wall.BuildingWalls.Planked;

public class AbandonedPlankedPearlWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 400;
        ItemID.Sets.DrawUnsafeIndicator[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 5;
        Item.createWall = ModContent.WallType<AbandonedPlankedPearlWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
    }
}
