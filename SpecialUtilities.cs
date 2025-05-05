using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles;

namespace Xenon;

public static class SpecialUtilities
{
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
					Main.tile[i, j].TileType == ModContent.TileType<Quickmud>() || Main.tile[i, j].TileType == ModContent.TileType<PowderedSnow>())
				{
					int num5 = 0;
					vector2.X = i * 16;
					vector2.Y = j * 16;
					if (vector.X + Width > vector2.X - num5 && vector.X < vector2.X + 16f + num5 && vector.Y + Height > vector2.Y && vector.Y < vector2.Y + 16.01)
					{
						//if (Main.tile[i, j].TileType == ModContent.TileType<Quicksand>() && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.NextBool(30))
						//	Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Sand);
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
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<Quickmud>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<Quickmud>() ||
			Main.tile[tileCoord.X, tileCoord.Y].TileType == ModContent.TileType<PowderedSnow>() || Main.tile[tileCoord.X + 1, tileCoord.Y].TileType == ModContent.TileType<PowderedSnow>())
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
		Snow = 5
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
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Quickmud>() ||
				type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quicksand>();
			}
		}
		// convert to corruption
		if (convert == ConversionType.Corruption)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Quickmud>() ||
				type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Ebonquicksand>();
			}
		}
		// convert to crimson
		if (convert == ConversionType.Crimson)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Quickmud>() ||
				type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Crimquicksand>();
			}
		}
		// convert to hallow
		if (convert == ConversionType.Hallow)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quickmud>() ||
				type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Pearlquicksand>();
			}
		}
		// convert to jungle/mud
		if (convert == ConversionType.Mud)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Crimquicksand>() ||
				type == ModContent.TileType<PowderedSnow>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quickmud>();
			}
		}
		// convert to jungle/mud
		if (convert == ConversionType.Snow)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Crimquicksand>() ||
				type == ModContent.TileType<Quickmud>())
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
