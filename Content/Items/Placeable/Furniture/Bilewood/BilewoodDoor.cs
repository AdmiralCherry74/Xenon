using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodDoor : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodDoorClosed>());
		Item.width = 14;
		Item.height = 28;
		Item.value = Item.sellPrice(copper: 40);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Tile.Bilewood>(), 6)
			.AddTile(TileID.WorkBenches).Register();
	}
}
