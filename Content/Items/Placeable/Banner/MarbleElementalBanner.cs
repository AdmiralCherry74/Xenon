using Xenon.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Banner;

public class MarbleElementalBanner : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<MonsterBanner>(), 12);
		Item.width = 10;
		Item.height = 24;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.buyPrice(silver: 10);
	}
}
