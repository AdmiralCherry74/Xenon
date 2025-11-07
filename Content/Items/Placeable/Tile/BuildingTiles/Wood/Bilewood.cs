using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.BuildingTiles.Wood
{
	public class Bilewood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Corrosion.Bilewood>());
		}
	}
}
