using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Items.Placeable.Tile
{
	public class RoughGrass : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RoughGrass>());
		}
	}
}
