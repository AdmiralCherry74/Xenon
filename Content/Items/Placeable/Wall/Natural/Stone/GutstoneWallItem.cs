using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Walls.NaturalWalls.Corrosion;

namespace Xenon.Content.Items.Placeable.Wall.Natural.Stone;

public class GutstoneWallItem : ModItem
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
        Item.createWall = ModContent.WallType<GutstoneWallSafe>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient(ModContent.ItemType<GutstoneBlock>())
            .AddTile(TileID.WorkBenches)
            .Register();

        Recipe.Create(ModContent.ItemType<GutstoneBlock>())
            .AddIngredient(this, 4)
            .AddTile(TileID.WorkBenches)
            .DisableDecraft()
            .Register();

    }
}
