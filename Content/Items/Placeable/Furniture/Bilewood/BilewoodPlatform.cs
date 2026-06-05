using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodPlatform : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 200;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodPlatform>());
        Item.width = 8;
        Item.height = 10;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2).AddIngredient(ModContent.ItemType<BilewoodItem>()).Register();
        Recipe.Create(ModContent.ItemType<BilewoodItem>()).AddIngredient(this, 2).Register();
    }
}
