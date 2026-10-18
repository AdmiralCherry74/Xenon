using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Bricks;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Walls.BuildingWalls.Bricks;
using Xenon.Content.Walls.NaturalWalls.Stone;

namespace Xenon.Content.Items.Placeable.Wall.BuildingWalls.Bricks;

public class FluoriteBrickWallItem : ModItem
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
        Item.createWall = ModContent.WallType<FluoriteBrickWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
    }
    public override void AddRecipes()
    {
        Recipe.Create(ModContent.ItemType<FluoriteBrickWallItem>(), 4)
            .AddIngredient(ModContent.ItemType<FluoriteBrickItem>())
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBrickItem>())
            .Register();

        Recipe.Create(ModContent.ItemType<FluoriteBrickItem>())
            .AddIngredient(ModContent.ItemType<FluoriteBrickWallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBrickWallItem>())
            .Register();
    }
}
