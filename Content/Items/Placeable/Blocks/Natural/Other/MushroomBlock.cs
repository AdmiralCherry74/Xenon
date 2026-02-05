using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.FallingTiles;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.ForestMushroom;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Other;

public class MushroomBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Mushroom>());
		Item.width = 12;
		Item.height = 12;
	}
	public override void AddRecipes()
	{
			CreateRecipe(4)
			.AddIngredient(ItemID.Mushroom, 4)
			.Register();
	}
}