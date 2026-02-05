using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;

namespace Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone;

public class RedCatacombWallItem : ModItem
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
        Item.useTime = 10;
        Item.createWall = ModContent.WallType<Walls.BuildingWalls.Stones.RedCatacombWallUnsafe>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4).AddIngredient(ModContent.ItemType<RedCatacombBrickBlock>()).AddTile(TileID.WorkBenches).Register();
        Recipe.Create(ModContent.ItemType<RedCatacombBrickBlock>()).AddIngredient(this, 4).AddTile(TileID.WorkBenches).DisableDecraft().Register();
    }
}
