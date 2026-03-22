using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Xenon.SpecialUtilities;
using Xenon.Content.Tiles.Natural.Mountains.Mossy;
using Xenon.Content.Tiles.Natural.Mountains;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;
using Xenon.Content.Tiles.Natural.Other;
using Avalon.Tiles.Ores;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.ModSupport;

[ExtendsFromMod("Avalon", "TheConfectionRebirth")]
internal class CompatSystem : ModSystem
{
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
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Creamquicksand>() || type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<HestiaStone>() || type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<OuranoStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyHestiaStone>() || type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyOuranoStone>();
			}
		}
		// convert to corruption
		if (convert == ConversionType.Corruption)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Creamquicksand>() || type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Ebonquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<HestiaStone>() || type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<NyxStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyHestiaStone>() || type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyNyxStone>();
			}
			if (type == TileID.Crimtane || type == ModContent.TileType<IngestaneOre>() ||
				type == ModContent.TileType<BacciliteOre>())
			{
				tile.TileType = TileID.Demonite;
			}
		}
		// convert to crimson
		if (convert == ConversionType.Crimson)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Creamquicksand>() || type == ModContent.TileType<Snotquicksand>())

			{
				tile.TileType = (ushort)ModContent.TileType<Crimquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<OuranoStone>() ||
				type == ModContent.TileType<HestiaStone>() || type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<AresStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyOuranoStone>() ||
				type == ModContent.TileType<MossyHestiaStone>() || type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyAresStone>();
			}
			if (type == TileID.Demonite || type == ModContent.TileType<IngestaneOre>() ||
				type == ModContent.TileType<BacciliteOre>())
			{
				tile.TileType = TileID.Crimtane;
			}
		}
		// convert to hallow
		if (convert == ConversionType.Hallow)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Creamquicksand>() || type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Pearlquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<HestiaStone>() || type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<HelioStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyHestiaStone>() || type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyHelioStone>();
			}
		}
		if (convert == ConversionType.Contagion)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Quicksand>() || type == ModContent.TileType<Creamquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Snotquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HestiaStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<PolloStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHestiaStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyPolloStone>();
			}
			if (type == TileID.Demonite || type == ModContent.TileType<IngestaneOre>() ||
				type == TileID.Crimtane)
			{
				tile.TileType = (ushort)ModContent.TileType<BacciliteOre>();
			}
		}
		// convert to confection
		if (convert == ConversionType.Confection)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Quicksand>() || type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Creamquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<HestiaStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyHestiaStone>();
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
	}
}
