using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Decoration.SeeThrough;
using Xenon.Content.Walls.DecorationWall.SeeThrough;

namespace Xenon.Content.Items.Placeable.Wall.DecorationWalls.SeeThrough;

public class TintedGlassPane : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 400;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = 32;
        Item.height = 32;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.createWall = ModContent.WallType<TintedGlassWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(4);

        recipe.AddIngredient(ModContent.ItemType<TintedGlass>(), 1);
        recipe.AddTile(TileID.TinkerersWorkbench);
        recipe.Register();
    }
}