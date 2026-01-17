using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.FallingTiles;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Desert;

public class GutsandBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
		ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<GutsandSandgunProjectile>(), 5);
	}
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Gutsand>());
		Item.width = 12;
		Item.height = 12;
		Item.ammo = AmmoID.Sand;
		Item.notAmmo = true;
	}
}
