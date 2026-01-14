using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.FallingTiles;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Other;

public class GravelBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Gravel>());
		Item.width = 12;
		Item.height = 12;
		Item.notAmmo = true;
	}
}
