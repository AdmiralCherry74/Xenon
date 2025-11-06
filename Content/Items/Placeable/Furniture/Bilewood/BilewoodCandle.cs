using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodCandle : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodCandle>());
		Item.width = 8;
		Item.height = 18;
		Item.value = Item.sellPrice(copper: 60);
		Item.noWet = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>(), 4)
			.AddIngredient(ItemID.Torch)
			.AddTile(TileID.WorkBenches).Register();
	}
}
