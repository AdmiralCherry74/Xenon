using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodWorkBench : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodWorkBench>());
		Item.width = 28;
		Item.height = 14;
		Item.value = Item.sellPrice(copper: 30);
	}

	public override void AddRecipes()
	{
		CreateRecipe().AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>(), 10).Register();
	}
}
