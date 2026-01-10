using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Common.Globals;

internal class XenonGlobalProjectile : GlobalProjectile
{
	public override void PostAI(Projectile projectile)
	{
		if (projectile.owner != Main.myPlayer || (projectile.type != ProjectileID.CorruptSpray && projectile.type != ProjectileID.CrimsonSpray &&
			projectile.type != ProjectileID.HallowSpray && projectile.type != ProjectileID.PureSpray && projectile.type != ProjectileID.SnowSpray &&
			projectile.type != ProjectileID.PurificationPowder && projectile.type != ProjectileID.MushroomSpray && projectile.type != ProjectileID.ViciousPowder &&
			projectile.type != ProjectileID.VilePowder))
		{
			return;
		}
		Point p = projectile.Center.ToTileCoordinates();
		bool flag = projectile.type == ProjectileID.PurificationPowder;
		for (int i = p.X - 1; i <= p.X + 1; i++)
		{
			for (int j = p.Y - 1; j <= p.Y + 1; j++)
			{
				if (projectile.type == ProjectileID.PureSpray || projectile.type == ProjectileID.PurificationPowder)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Purity, !flag);
				}
				if (projectile.type == ProjectileID.CorruptSpray || projectile.type == ProjectileID.VilePowder)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Corruption, !flag);
				}
				if (projectile.type == ProjectileID.CrimsonSpray || projectile.type == ProjectileID.ViciousPowder)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Crimson, !flag);
				}
				if (projectile.type == ProjectileID.HallowSpray)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Hallow, !flag);
				}
				if (projectile.type == ProjectileID.SnowSpray)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Snow, !flag);
				}
				if (projectile.type == ProjectileID.MushroomSpray)
				{
					SpecialUtilities.Convert(i, j, SpecialUtilities.ConversionType.Mud, !flag);
				}
				NetMessage.SendTileSquare(-1, i, j, 1, 1);
			}
		}
	}
}
