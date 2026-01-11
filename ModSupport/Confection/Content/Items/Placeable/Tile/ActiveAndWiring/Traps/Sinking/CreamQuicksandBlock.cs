using Terraria;
using Terraria.ModLoader;
using Xenon.ModSupport.Confection.Content.Tiles.ActiveAndWiring.Traps.Sinking;

namespace Xenon.ModSupport.Confection.Content.Items.Placeable.Tile.ActiveAndWiring.Traps.Sinking
{
	public class CreamQuicksandBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Creamquicksand>());
		}
	}
}
