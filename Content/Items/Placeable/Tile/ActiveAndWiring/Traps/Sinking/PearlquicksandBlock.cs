using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;

namespace Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Traps.Sinking
{
	public class PearlquicksandBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Pearlquicksand>());
		}
	}
}
