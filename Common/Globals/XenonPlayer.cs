using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Common.Globals;

public class XenonPlayer : ModPlayer
{
	public override void PostUpdateEquips()
	{
		if (Player.lavaImmune || Player.resistCold)
		{
			Player.buffImmune[ModContent.BuffType<Iceburn>()] = true;
		}
	}
	public override void PostUpdate()
	{
		QuicksandMovement();

		if (SpecialUtilities.SubmergedInQuicksandTiles(Player.position))
		{
			Player.AddBuff(ModContent.BuffType<QuicksandSuffocation>(), 1);
		}
	}
	public void QuicksandMovement()
	{
		if (Player.shimmering)
			return;

		bool mounted = false;
		if (Player.mount.Type > 0 && MountID.Sets.Cart[Player.mount.Type] && Math.Abs(Player.velocity.X) > 5f)
			mounted = true;

		Vector2 vector = SpecialUtilities.QuicksandTiles(Player.position, Player.velocity, Player.width, Player.height);
		if (vector.Y != -1f && vector.X != -1f)
		{
			int num3 = (int)vector.X;
			int num4 = (int)vector.Y;
			int type = Main.tile[num3, num4].TileType;

			if (mounted)
				return;

			Player.fallStart = (int)(Player.position.Y / 16f);
			if (type != 229)
				Player.jump = 0;

			if (Player.velocity.X > 1f)
				Player.velocity.X = 1f;

			if (Player.velocity.X < -1f)
				Player.velocity.X = -1f;

			if (Player.velocity.X > 0.75f || Player.velocity.X < -0.75f)
				Player.velocity.X *= 0.95f;
			else
				Player.velocity.X *= 0.9f;

			if (Player.gravDir == -1f)
			{
				if (Player.velocity.Y < -1f)
					Player.velocity.Y = -1f;

				if (Player.velocity.Y > 5f)
					Player.velocity.Y = 5f;

				if (Player.velocity.Y > 0f)
					Player.velocity.Y *= 0.99f;
				else
					Player.velocity.Y *= 0.6f;
			}
			else
			{
				if (Player.velocity.Y > 1f)
					Player.velocity.Y = 1f;

				if (Player.velocity.Y < -5f)
					Player.velocity.Y = -5f;

				if (Player.velocity.Y < 0f)
					Player.velocity.Y *= 0.99f;
				else
					Player.velocity.Y *= 0.6f;
			}
		}
	}
}
