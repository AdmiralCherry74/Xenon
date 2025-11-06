using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodTable : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodTable>());
		Item.width = 26;
		Item.height = 20;
		Item.value = Item.sellPrice(copper: 60);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>(), 8)
			.AddTile(TileID.WorkBenches).Register();
	}
}
