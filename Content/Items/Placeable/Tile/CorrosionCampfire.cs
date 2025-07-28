using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile;

public class CorrosionCampfire : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Corrosion.CorrosionCampfire>());
		Item.width = 12;
		Item.height = 12;
	}
	public override void AddRecipes()
	{
		CreateRecipe(1).AddRecipeGroup("Wood", 10).AddIngredient(ModContent.ItemType<CorrosionTorch>(), 5).Register();
	}
}
