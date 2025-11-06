using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Bilewood;

public class BilewoodChest : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Bilewood.BilewoodChest>());
		Item.width = 26;
		Item.height = 22;
		Item.value = Item.sellPrice(silver: 1);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Corrosion.Bilewood>(), 8)
			.AddRecipeGroup("IronBar", 2)
			.AddTile(TileID.WorkBenches).Register();
	}
}
