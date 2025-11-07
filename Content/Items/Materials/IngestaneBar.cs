using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile;
using Xenon.Content.Rarities;
using Xenon.Content.Tiles;

namespace Xenon.Content.Items.Materials;

public class IngestaneBar : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}
	public override void SetDefaults()
	{
        Item.DefaultToPlaceableTile(ModContent.TileType<PlacedBars>());
        Item.width = 20;
        Item.height = 20;
        Item.rare = 2;
        Item.value = Item.sellPrice(0, 0, 21);
	}
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<IngestaneOre>(), 3)
			.AddTile(TileID.Furnaces)
			.Register();
	}
}
