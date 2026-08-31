using Avalon.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Avalon.Common.Players;
using Xenon.Content.Buffs.Debuffs;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.ModSupport.Avalon;

[ExtendsFromMod("Avalon")]
internal class AvalonSupportPlayer : ModPlayer
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return XenonMod.AvalonContentEnabled;
	}
	public void UpdateStaminaRegenForXenon(Player player)
	{
		if (player.GetModPlayer<XenonPlayer>().GastricCloakOn)
		{
            player.GetModPlayer<AvalonStaminaPlayer>().StaminaRegen += 3;
		}
	}
	public override void PostUpdate()
	{
		QuicksandMovement();

		if (SubmergedInSnotquicksand(Player.position))
		{
			Player.AddBuff(ModContent.BuffType<QuicksandSuffocation>(), 1);
		}
	}
	public static bool SubmergedInSnotquicksand(Vector2 Position)
	{
		Point tileCoord = Position.ToTileCoordinates();
		if (Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Snotquicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Snotquicksand>())
		{
			return true;
		}
		return false;
	}
	public void QuicksandMovement()
	{
		if (Player.shimmering)
			return;

		bool mounted = false;
		if (Player.mount.Type > MountID.Rudolph && MountID.Sets.Cart[Player.mount.Type] && Math.Abs(Player.velocity.X) > 5f)
			mounted = true;

		Vector2 vector = QuicksandTiles(Player.position, Player.velocity, Player.width, Player.height);
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
	public static Vector2 QuicksandTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
	{
		Vector2 vector = Position;
		int num = (int)(Position.X / 16f) - 1;
		int num2 = (int)((Position.X + Width) / 16f) + 2;
		int num3 = (int)(Position.Y / 16f) - 1;
		int num4 = (int)((Position.Y + Height) / 16f) + 2;
		if (num < 0)
		{
			num = 0;
		}
		if (num2 > Main.maxTilesX)
		{
			num2 = Main.maxTilesX;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (num4 > Main.maxTilesY)
		{
			num4 = Main.maxTilesY;
		}
		Vector2 vector2 = default;
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				if (Main.tile[i, j].TileType == ModContent.TileType<Snotquicksand>())
				{
					int num5 = 0;
					vector2.X = i * 16;
					vector2.Y = j * 16;
					if (vector.X + Width > vector2.X - num5 && vector.X < vector2.X + 16f + num5 && vector.Y + Height > vector2.Y && vector.Y < vector2.Y + 16.01)
					{
						if (Main.tile[i, j].TileType == ModContent.TileType<Snotquicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<SnotsandDust>());
						return new Vector2(i, j);
					}
				}
			}
		}
		return new Vector2(-1, -1);
	}
}
