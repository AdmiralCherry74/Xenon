using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Wall.Natural.LivingWood;

public class LivingJacarandawoodWallUnsafe : ModItem
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
        Item.useTime = 10;
        Item.createWall = ModContent.WallType<Walls.NaturalWalls.LivingWoodWalls.LivingJacarandawoodWallUnsafe>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
        Item.scale = 0.5f;
    }
}