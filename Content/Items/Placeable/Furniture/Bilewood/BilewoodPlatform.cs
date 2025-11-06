using Terraria;
using Terraria.ModLoader;

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
		CreateRecipe(2).AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>()).Register();
		Recipe.Create(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>()).AddIngredient(this, 2).Register();
	}
}
