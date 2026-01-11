using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheConfectionRebirth.Projectiles;
using Xenon.ModSupport.Confection;

namespace Xenon.ModSupport.Confection;

[ExtendsFromMod("TheConfectionRebirth")]
internal class ConfectionSupportProjectile : GlobalProjectile
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.TheConfectionRebirthContentEnabled;
	}
	public override void PostAI(Projectile projectile)
	{
		if (projectile.owner != Main.myPlayer || (projectile.type != ProjectileID.CorruptSpray && projectile.type != ProjectileID.CrimsonSpray &&
			projectile.type != ProjectileID.HallowSpray && projectile.type != ProjectileID.PureSpray && projectile.type != ProjectileID.SnowSpray &&
			projectile.type != ProjectileID.PurificationPowder && projectile.type != ProjectileID.MushroomSpray &&
			projectile.type != ModContent.ProjectileType<CreamSolution>() && projectile.type != ProjectileID.ViciousPowder &&
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
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Purity, !flag);
				}
				if (projectile.type == ProjectileID.CorruptSpray || projectile.type == ProjectileID.VilePowder)
				{
                    ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Corruption, !flag);
				}
				if (projectile.type == ProjectileID.CrimsonSpray || projectile.type == ProjectileID.ViciousPowder)
				{
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Crimson, !flag);
				}
				if (projectile.type == ModContent.ProjectileType<CreamSolution>());
				{
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Confection, !flag);
				}
				if (projectile.type == ProjectileID.HallowSpray)
				{
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Hallow, !flag);
				}
				if (projectile.type == ProjectileID.SnowSpray)
				{
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Snow, !flag);
				}
				if (projectile.type == ProjectileID.MushroomSpray)
				{
					ConfectionSystem.Convert(i, j, SpecialUtilities.ConversionType.Mud, !flag);
				}
				NetMessage.SendTileSquare(-1, i, j, 1, 1);
			}
		}
	}
}
