using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Walls.DecorationWall.SeeThrough;

namespace Xenon.Content.Items.Placeable.Wall.DecorationWalls.SeeThrough;

public class IndigoStainedGlassPane : ModItem
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
        Item.useTime = 5;
        Item.createWall = ModContent.WallType<IndigoStainedGlassWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 10;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(4);

        recipe.AddIngredient(ModContent.ItemType<Lapis>(), 1);
        recipe.AddIngredient(ItemID.GlassWall, 20);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}