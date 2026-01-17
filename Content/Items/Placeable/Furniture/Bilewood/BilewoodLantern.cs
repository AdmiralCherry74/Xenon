using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodLantern : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodLantern>());
		Item.width = 12;
		Item.height = 28;
		Item.value = Item.sellPrice(copper: 30);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Blocks.BuildingTiles.Wood.Bilewood>(), 6)
			.AddIngredient(ItemID.Torch)
			.AddTile(TileID.WorkBenches).Register();
	}
}
