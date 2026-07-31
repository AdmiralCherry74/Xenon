using Avalon.Tiles.Ores;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

namespace Xenon;

public static class SpecialUtilities
{
	public static Asset<Texture2D> GetTexture(this ModTexturedType texturedType) =>
		ModContent.Request<Texture2D>(texturedType.Texture);

	public static Asset<Texture2D> GetTexture(this ModItem modItem) =>
		ModContent.Request<Texture2D>(modItem.Texture);

	public static Asset<Texture2D> GetTexture(this ModProjectile modProjectile) =>
		ModContent.Request<Texture2D>(modProjectile.Texture);
	public static int GetPickaxePower(int tileType, int yPos)
	{
		if (!TileID.Sets.Ore[tileType]) return -1;

		int power = 0;
		if (TileLoader.GetTile(tileType) is ModTile modTile)
		{
			power = modTile.MinPick;
		}
		else
		{
			if (tileType == TileID.Chlorophyte) power = 200;
			if (tileType == TileID.Meteorite) power = 50;
			if ((tileType == TileID.Demonite || tileType == TileID.Crimtane) && yPos > Main.worldSurface) power = 55;
			if (tileType == TileID.Hellstone) power = 70;
			if (tileType == TileID.Cobalt || tileType == TileID.Palladium) power = 100;
			if (tileType == TileID.Mythril || tileType == TileID.Orichalcum) power = 110;
			if (tileType == TileID.Adamantite || tileType == TileID.Titanium) power = 150;
		}

		return power;
	}
	public static Player GetPlayerForTile(int x, int y)
	{
		return Main.player[Player.FindClosest(new Vector2(x, y) * 16f, 16, 16)];
	}
	/// <summary>
	/// <para/> Uses <see cref="Utils.SafeNormalize"/> instead of <see cref="Vector2.Normalize()"/> to ensure it doesn't return a value which is not a number.
	/// <para/> If the two provided Vector2 positions are the same, <see cref="Vector2.Zero"/> will be returned instead as a fallback.
	/// <para/> Using SafeDirectionTo instead of DirectionTo avoids many difficult to anticipate issues that would cause bugs.
	/// </summary>
	public static Vector2 SafeDirectionTo(this Vector2 Origin, Vector2 Target) => Utils.SafeNormalize(Target - Origin, Vector2.Zero);
	/// <summary>
	/// <inheritdoc cref="SafeDirectionTo(Vector2, Vector2)"/><para></para>
	/// Uses the Center of the provided Entity.
	/// </summary>
	public static Vector2 SafeDirectionTo(this Entity Entity, Vector2 Target) => Utils.SafeNormalize(Target - Entity.Center, Vector2.Zero);
	/// <summary>
	/// <para/> Uses <see cref="Utils.SafeNormalize"/> instead of <see cref="Vector2.Normalize()"/> to ensure it doesn't return a value which is not a number.
	/// <para/> If the two provided Vector2 positions are the same, <see cref="Vector2.Zero"/> will be returned instead as a fallback.
	/// <para/> Using SafeDirectionFrom instead of DirectionFrom avoids many difficult to anticipate issues that would cause bugs.
	/// </summary>
	public static Vector2 SafeDirectionFrom(this Vector2 Origin, Vector2 Target) => Utils.SafeNormalize(Origin - Target, Vector2.Zero);
	/// <summary>
	/// <inheritdoc cref="SafeDirectionFrom(Vector2, Vector2)"/><para></para>
	/// Uses the Center of the provided Entity.
	/// </summary>
	public static Vector2 SafeDirectionFrom(this Entity Entity, Vector2 Target) => Utils.SafeNormalize(Entity.Center - Target, Vector2.Zero);
	public static void GetPointOnSwungItemPath(float spriteWidth, float spriteHeight, float normalizedPointOnPath, float itemScale, out Vector2 location, out Vector2 outwardDirection, Player player)
	{
		float num = (float)Math.Sqrt(spriteWidth * spriteWidth + spriteHeight * spriteHeight);
		float num2 = (float)(player.direction == 1).ToInt() * ((float)Math.PI / 2f);
		if (player.gravDir == -1f)
		{
			num2 += (float)Math.PI / 2f * (float)player.direction;
		}
		outwardDirection = player.itemRotation.ToRotationVector2().RotatedBy(3.926991f + num2);
		location = player.RotatedRelativePoint(player.itemLocation + outwardDirection * num * normalizedPointOnPath * itemScale);
	}
	public static void DropCoinsProperly(float num7, int i, int j)
	{
		while ((int)num7 > 0)
		{
			if (num7 > 1000000f)
			{
				int num8 = (int)(num7 / 1000000f);
				if (num8 > 50 && Main.rand.NextBool(2))
				{
					num8 /= Main.rand.Next(3) + 1;
				}
				if (Main.rand.NextBool(2))
				{
					num8 /= Main.rand.Next(3) + 1;
				}
				num7 -= 1000000 * num8;
				int platinum = Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i, j, 16, 16, ItemID.PlatinumCoin, num8);
				if (Main.netMode == NetmodeID.MultiplayerClient && platinum >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, platinum, 1f);
				}
				continue;
			}
			if (num7 > 10000f)
			{
				int num9 = (int)(num7 / 10000f);
				if (num9 > 50 && Main.rand.NextBool(2))
				{
					num9 /= Main.rand.Next(3) + 1;
				}
				if (Main.rand.NextBool(2))
				{
					num9 /= Main.rand.Next(3) + 1;
				}
				num7 -= 10000 * num9;
				int gold = Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i, j, 16, 16, ItemID.GoldCoin, num9);
				if (Main.netMode == NetmodeID.MultiplayerClient && gold >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, gold, 1f);
				}
				continue;
			}
			if (num7 > 100f)
			{
				int num10 = (int)(num7 / 100f);
				if (num10 > 50 && Main.rand.NextBool(2))
				{
					num10 /= Main.rand.Next(3) + 1;
				}
				if (Main.rand.NextBool(2))
				{
					num10 /= Main.rand.Next(3) + 1;
				}
				num7 -= 100 * num10;
				int silver = Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i, j, 16, 16, ItemID.SilverCoin, num10);
				if (Main.netMode == NetmodeID.MultiplayerClient && silver >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, silver, 1f);
				}
				continue;
			}
			int num11 = (int)num7;
			if (num11 > 50 && Main.rand.NextBool(2))
			{
				num11 /= Main.rand.Next(3) + 1;
			}
			if (Main.rand.NextBool(2))
			{
				num11 /= Main.rand.Next(4) + 1;
			}
			if (num11 < 1)
			{
				num11 = 1;
			}
			num7 -= num11;
			int money = Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i, j, 16, 16, ItemID.CopperCoin, num11);
			if (Main.netMode == NetmodeID.MultiplayerClient && money >= 0)
			{
				NetMessage.SendData(MessageID.SyncItem, -1, -1, null, money, 1f);
			}
		}
	}
	public static void Active(this Tile t, bool a) => t.HasTile = a;
    public static Rectangle Expand(this Rectangle r, int xDist, int yDist)
	{
		r.X -= xDist;
		r.Y -= yDist;
		r.Width += xDist * 2;
		r.Height += yDist * 2;
		return r;
	}
	public static bool InPillarZone(this Player p)
	{
		if (!p.ZoneTowerStardust && !p.ZoneTowerVortex && !p.ZoneTowerSolar)
		{
			return p.ZoneTowerNebula;
		}

		return true;
	}
    public static bool DoublePressedReversedSetBonusActivateKey(this Player player)
    {
        return (player.doubleTapCardinalTimer[Main.ReversedUpDownArmorSetBonuses ? 0 : 1] < 15 && ((player.releaseDown && Main.ReversedUpDownArmorSetBonuses && player.controlDown) || (player.releaseUp && !Main.ReversedUpDownArmorSetBonuses && player.controlUp)));
    }

    public static bool DoublePressedDown(this Player player)
    {
        return player.doubleTapCardinalTimer[0] < 15 && player.releaseDown && player.controlDown;
    }

    public static bool IsOnGroundPrecise(this Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            var tileX = Main.tile[(int)((player.position.X + (player.width * i / 2f)) / 16f), (int)((player.position.Y + (player.gravDir == 1 ? player.height + 1 : -1)) / 16f)];

            if (tileX.HasTile && (Main.tileSolid[tileX.TileType] || Main.tileSolidTop[tileX.TileType]) && player.velocity.Y == 0f)
            {
                return true;
            }
        }
        return false;
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
				if (Main.tile[i, j].TileType == ModContent.TileType<Quicksand>() || Main.tile[i, j].TileType == ModContent.TileType<Crimquicksand>() ||
					Main.tile[i, j].TileType == ModContent.TileType<Ebonquicksand>() || Main.tile[i, j].TileType == ModContent.TileType<Pearlquicksand>() ||
                    Main.tile[i, j].TileType == ModContent.TileType<Gutquicksand>() || Main.tile[i, j].TileType == ModContent.TileType<Quickmud>() ||
                    Main.tile[i, j].TileType == ModContent.TileType<PowderedSnow>() || Main.tile[i, j].TileType == ModContent.TileType<Quickgravel>() ||
                    Main.tile[i, j].TileType == ModContent.TileType<MarineQuicksand>())
                {
					int num5 = 0;
					vector2.X = i * 16;
					vector2.Y = j * 16;
					if (vector.X + Width > vector2.X - num5 && vector.X < vector2.X + 16f + num5 && vector.Y + Height > vector2.Y && vector.Y < vector2.Y + 16.01)
					{
						if (Main.tile[i, j].TileType == ModContent.TileType<Quicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Sand);
						if (Main.tile[i, j].TileType == ModContent.TileType<Crimquicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Crimson);
						if (Main.tile[i, j].TileType == ModContent.TileType<Ebonquicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Corruption);
						if (Main.tile[i, j].TileType == ModContent.TileType<Pearlquicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Pearlsand);
						if (Main.tile[i, j].TileType == ModContent.TileType<Gutquicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<GutsandDust>());
						if (Main.tile[i, j].TileType == ModContent.TileType<Quickmud>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Mud);
						if (Main.tile[i, j].TileType == ModContent.TileType<PowderedSnow>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
							Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.SnowBlock);
                        if (Main.tile[i, j].TileType == ModContent.TileType<Quickgravel>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
                            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Silt);
                        if (Main.tile[i, j].TileType == ModContent.TileType<MarineQuicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
                            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<MarineSandDust>());
                        return new Vector2(i, j);
					}
				}
			}
		}
		return new Vector2(-1, -1);
	}

	public static bool SubmergedInQuicksandTiles(Vector2 Position)
	{
		Point tileCoord = Position.ToTileCoordinates();
		if (Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Quicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Quicksand>() ||
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Pearlquicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Pearlquicksand>() ||
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Crimquicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Crimquicksand>() ||
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Ebonquicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Ebonquicksand>() ||
            Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Gutquicksand>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Gutquicksand>() ||
            Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Quickmud>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Quickmud>() ||
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<PowderedSnow>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<PowderedSnow>() ||
            Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Quickgravel>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<MarineQuicksand>())
		{
			return true;
		}
		return false;
	}

	public enum ConversionType
	{
		Purity = 0,
		Corruption = 1,
		Crimson = 2,
		Hallow = 3,
		Mud = 4,
		Snow = 5,
        Confection = 6,
        Contagion = 7
    }
    public static void Convert(int x, int y, ConversionType convert, bool tileframe = true)
	{
		Tile tile = Main.tile[x, y];
		int type = tile.TileType;
		if (!WorldGen.InWorld(x, y, 1))
		{
			return;
		}
		// convert to purity
		if (convert == ConversionType.Purity)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Ebonquicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<OuranoStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyOuranoStone>();
			}
		}
		// convert to corruption
		if (convert == ConversionType.Corruption)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Ebonquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<NyxStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyNyxStone>();
			}
            if (type == TileID.Crimtane || type == ModContent.TileType<IngestaneOre>())
            {
				tile.TileType = TileID.Demonite;
            }
        }
		// convert to crimson
		if (convert == ConversionType.Crimson)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>())

            {
				tile.TileType = (ushort)ModContent.TileType<Crimquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<OuranoStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<AresStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyOuranoStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyAresStone>();
			}
            if (type == TileID.Demonite || type == ModContent.TileType<IngestaneOre>())
            {
				tile.TileType = TileID.Crimtane;
            }
        }
		// convert to hallow
		if (convert == ConversionType.Hallow)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Gutquicksand>())
            {
				tile.TileType = (ushort)ModContent.TileType<Pearlquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<AresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<HelioStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyAresStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyHelioStone>();
			}
		}
		// convert to jungle/mud
		if (convert == ConversionType.Mud)
		{
			if (type == ModContent.TileType<Quicksand>() || type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quickmud>();
			}
		}
		// convert to snow
		if (convert == ConversionType.Snow)
		{
			if (type == ModContent.TileType<Quicksand>() || type == ModContent.TileType<Quickmud>())
			{
				tile.TileType = (ushort)ModContent.TileType<PowderedSnow>();
			}
		}
        if (tileframe)
		{
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				WorldGen.SquareTileFrame(x, y);
			}
			else if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
			}
		}
        if (convert == ConversionType.Snow)
        {
            if (type == ModContent.TileType<Quicksand>() || type == ModContent.TileType<Quickmud>())
            {
                tile.TileType = (ushort)ModContent.TileType<PowderedSnow>();
            }
        }
        if (tileframe)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                WorldGen.SquareTileFrame(x, y);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendTileSquare(-1, x, y, 1);
            }
        }
    }
}
