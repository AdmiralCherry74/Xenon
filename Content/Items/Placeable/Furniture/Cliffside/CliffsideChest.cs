using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;

namespace Xenon.Content.Items.Placeable.Furniture.Cliffside;

public class CliffsideChest : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Cliffside.CliffsideChest>());
		Item.width = 26;
		Item.height = 22;
		Item.value = Item.sellPrice(silver: 1);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<OuranoStoneBlock>(), 8)
			.AddRecipeGroup("IronBar", 2)
			.AddTile(TileID.WorkBenches).Register();
	}
}
