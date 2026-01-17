using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodBathtub : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodBathtub>());
		Item.width = 20;
		Item.height = 20;
		Item.value = Item.sellPrice(copper: 60);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Blocks.BuildingTiles.Wood.Bilewood>(), 14)
			.AddTile(TileID.Sawmill).Register();
	}
}
