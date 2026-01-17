using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodLamp : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodLamp>());
		Item.width = 10;
		Item.height = 24;
		Item.value = Item.sellPrice(silver: 1);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Torch)
			.AddIngredient(ModContent.ItemType<Blocks.BuildingTiles.Wood.Bilewood>(), 3)
			.AddTile(TileID.WorkBenches).Register();
	}
}
