using Terraria;
using Terraria.ModLoader;
using Xenon.ModSupport.Avalon.Content.Tiles;

namespace Xenon.ModSupport.Avalon.Content.Items;

public class SnotquicksandBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Snotquicksand>());
	}
}
