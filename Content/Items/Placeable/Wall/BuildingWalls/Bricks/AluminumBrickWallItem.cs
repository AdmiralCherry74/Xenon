using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Bricks;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Walls.BuildingWalls.Bricks;
using Xenon.Content.Walls.NaturalWalls.Stone;

namespace Xenon.Content.Items.Placeable.Wall.BuildingWalls.Bricks;

public class AluminumBrickWallItem : ModItem
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
        Item.createWall = ModContent.WallType<AluminumBrickWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
    }
    public override void AddRecipes()
    {
        Recipe.Create(ModContent.ItemType<AluminumBrickWallItem>(), 4)
            .AddIngredient(ModContent.ItemType<AluminumBrickItem>())
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBrickItem>())
            .Register();

        Recipe.Create(ModContent.ItemType<AluminumBrickItem>())
            .AddIngredient(ModContent.ItemType<AluminumBrickWallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBrickWallItem>())
            .Register();
    }
}
