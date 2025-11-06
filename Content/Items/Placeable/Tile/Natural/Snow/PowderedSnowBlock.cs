using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Snow
{
	public class PowderedSnowBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking.PowderedSnow>());
		}
	}
}
