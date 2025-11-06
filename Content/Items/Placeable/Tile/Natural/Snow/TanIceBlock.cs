using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Snow
{
	public class TanIceBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<TanIce>());
		}
	}
}
