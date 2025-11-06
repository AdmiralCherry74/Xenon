using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Desert
{
	public class QuicksandBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.Quicksand>());
		}
	}
}
