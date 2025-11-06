using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Stones
{
	public class GutstoneBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Gutstone>());
		}
	}
}
