using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheConfectionRebirth.Projectiles;
using Avalon.Projectiles;

namespace Xenon.ModSupport;

[ExtendsFromMod("TheConfectionRebirth", "Avalon")]
internal class CompatProjectile : GlobalProjectile
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.TheConfectionRebirthContentEnabled && XenonMod.AvalonContentEnabled;
	}
	public override void PostAI(Projectile projectile)
	{
		if (projectile.owner != Main.myPlayer || (projectile.type != ProjectileID.CorruptSpray && projectile.type != ProjectileID.CrimsonSpray &&
			projectile.type != ProjectileID.HallowSpray && projectile.type != ProjectileID.PureSpray && projectile.type != ProjectileID.SnowSpray &&
			projectile.type != ProjectileID.PurificationPowder && projectile.type != ProjectileID.MushroomSpray &&
			projectile.type != ModContent.ProjectileType<CreamSolution>() && projectile.type != ProjectileID.ViciousPowder &&
			projectile.type != ProjectileID.VilePowder && projectile.type != ModContent.ProjectileType<ContagionSpray>()))
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
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Purity, !flag);
				}
				if (projectile.type == ProjectileID.CorruptSpray || projectile.type == ProjectileID.VilePowder)
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Corruption, !flag);
				}
				if (projectile.type == ProjectileID.CrimsonSpray || projectile.type == ProjectileID.ViciousPowder)
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Crimson, !flag);
				}
				if (projectile.type == ModContent.ProjectileType<CreamSolution>())
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Confection, !flag);
				}
				if (projectile.type == ModContent.ProjectileType<ContagionSpray>())
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Contagion, !flag);
				}
				if (projectile.type == ProjectileID.HallowSpray)
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Hallow, !flag);
				}
				if (projectile.type == ProjectileID.SnowSpray)
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Snow, !flag);
				}
				if (projectile.type == ProjectileID.MushroomSpray)
				{
					CompatSystem.Convert(i, j, SpecialUtilities.ConversionType.Mud, !flag);
				}
				NetMessage.SendTileSquare(-1, i, j, 1, 1);
			}
		}
	}
}
