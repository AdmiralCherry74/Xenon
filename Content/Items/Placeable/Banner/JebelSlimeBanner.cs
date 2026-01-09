using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Buffs;

namespace Xenon.Content.Items.Placeable.Banner;

public class JebelSlimeBanner : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<MonsterBanner>(), 19);
		Item.width = 10;
		Item.height = 24;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.buyPrice(silver: 10);
	}
}
