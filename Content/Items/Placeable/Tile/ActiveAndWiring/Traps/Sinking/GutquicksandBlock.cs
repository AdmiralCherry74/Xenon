using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles;

namespace Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Traps.Sinking
{
	public class GutquicksandBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Gutquicksand>());
		}
	}
}
