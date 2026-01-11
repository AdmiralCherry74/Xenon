using Avalon.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.Decoration.Torches;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Natural.Stone.Mossy;
using Xenon.Content.Tiles.Natural.Stone;
using Xenon.ModSupport.Avalon.Content.Tiles;
using static Xenon.SpecialUtilities;
using Xenon.Content.Tiles.Natural.Corrosion;
using Avalon.Tiles.Ores;

namespace Xenon.ModSupport.Avalon;

[ExtendsFromMod("Avalon")]
public class AvalonSystem : ModSystem
{
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		if (XenonMod.AvalonContentEnabled)
		{
			ModContent.GetInstance<Common.Systems.BiomeTileCounts>().MountainTiles +=
				tileCounts[ModContent.TileType<PolloStone>()] +
				tileCounts[ModContent.TileType<MossyPolloStone>()];

			ModContent.GetInstance<BiomeTileCounts>().ContagionTiles +=
				tileCounts[ModContent.TileType<PolloStone>()] +
				tileCounts[ModContent.TileType<MossyPolloStone>()] +
				tileCounts[ModContent.TileType<Snotquicksand>()];
		}
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
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Quicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<OuranoStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyOuranoStone>();
			}
		}
		// convert to corruption
		if (convert == ConversionType.Corruption)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Ebonquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<NyxStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyNyxStone>();
			}
			if (type == TileID.Crimtane || type == ModContent.TileType<IngestaneOre>() || type == ModContent.TileType<BacciliteOre>() || type == ModContent.TileType<HallowedOre>())
			{
				tile.TileType = TileID.Demonite;
			}
		}
		// convert to crimson
		if (convert == ConversionType.Crimson)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Crimquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<OuranoStone>() ||
				type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<AresStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyOuranoStone>() ||
				type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyAresStone>();
			}
			if (type == TileID.Demonite || type == ModContent.TileType<IngestaneOre>() || type == ModContent.TileType<BacciliteOre>() || type == ModContent.TileType<HallowedOre>())
			{
				tile.TileType = TileID.Crimtane;
			}
		}
		// convert to hallow
		if (convert == ConversionType.Hallow)
		{
			if (type == ModContent.TileType<Ebonquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Snotquicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Pearlquicksand>();
			}
			if (type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<PolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<HelioStone>();
			}
			if (type == ModContent.TileType<MossyNyxStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyPolloStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyHelioStone>();
			}
            if (type == TileID.Demonite || type == TileID.Crimtane || type == ModContent.TileType<IngestaneOre>() || type == ModContent.TileType<BacciliteOre>())
            {
                tile.TileType = (ushort)ModContent.TileType<HallowedOre>();
            }
        }
		// convert to contagion
		if (convert == ConversionType.Contagion)
		{
			if (type == ModContent.TileType<Crimquicksand>() || type == ModContent.TileType<Quicksand>() ||
				type == ModContent.TileType<Pearlquicksand>() || type == ModContent.TileType<Gutquicksand>() ||
				type == ModContent.TileType<Quicksand>())
			{
				tile.TileType = (ushort)ModContent.TileType<Snotquicksand>();
			}
			if (type == ModContent.TileType<OuranoStone>() || type == ModContent.TileType<HephStone>() ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<AresStone>() ||
				type == ModContent.TileType<NyxStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<PolloStone>();
			}
			if (type == ModContent.TileType<MossyOuranoStone>() || type == ModContent.TileType<MossyHephStone>() ||
				type == ModContent.TileType<MossyHelioStone>() || type == ModContent.TileType<MossyAresStone>() ||
				type == ModContent.TileType<MossyNyxStone>())
			{
				tile.TileType = (ushort)ModContent.TileType<MossyPolloStone>();
			}
			if (type == TileID.Demonite || type == TileID.Crimtane || type == ModContent.TileType<IngestaneOre>() || type == ModContent.TileType<HallowedOre>())
			{
				tile.TileType = (ushort)ModContent.TileType<BacciliteOre>();
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
	public override void PostSetupContent()
	{
		if (!ModLoader.TryGetMod("Avalon", out Mod avalon))
		{
			return;
		}
		avalon.Call("AddTorchLauncherLightColor", ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Decoration.Torches.CorrosionTorch>(), new Vector3(0.8f, 1.4f, 0));
		avalon.Call("AddTorchLauncherDust", ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Decoration.Torches.CorrosionTorch>(), (int)DustID.JungleTorch);
		avalon.Call("AddTorchLauncherTexture", ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Decoration.Torches.CorrosionTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Natural.Corrosion.CorrosionTorch>().Texture);
		avalon.Call("AddTorchLauncherFlameTexture", ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Decoration.Torches.CorrosionTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Natural.Corrosion.CorrosionTorch>().Texture + "_Flame");
		avalon.Call("AddTorchLauncherDebuffType", ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Decoration.Torches.CorrosionTorch>(), -1);

		avalon.Call("AddTorchLauncherLightColor", ModContent.ItemType<GrayTorch>(), new Vector3(0.5f, 0.5f, 0.5f));
		avalon.Call("AddTorchLauncherDust", ModContent.ItemType<GrayTorch>(), (int)DustID.Ash);
		avalon.Call("AddTorchLauncherTexture", ModContent.ItemType<GrayTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.GrayTorch>().Texture);
		avalon.Call("AddTorchLauncherFlameTexture", ModContent.ItemType<GrayTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.GrayTorch>().Texture + "_Flame");
		avalon.Call("AddTorchLauncherDebuffType", ModContent.ItemType<GrayTorch>(), -1);

		avalon.Call("AddTorchLauncherLightColor", ModContent.ItemType<IndigoTorch>(), new Vector3(0.75f, 0.55f, 1.5f));
		avalon.Call("AddTorchLauncherDust", ModContent.ItemType<IndigoTorch>(), (int)DustID.ShadowbeamStaff);
		avalon.Call("AddTorchLauncherTexture", ModContent.ItemType<IndigoTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.IndigoTorch>().Texture);
		avalon.Call("AddTorchLauncherFlameTexture", ModContent.ItemType<IndigoTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.IndigoTorch>().Texture + "_Flame");
		avalon.Call("AddTorchLauncherDebuffType", ModContent.ItemType<IndigoTorch>(), -1);

		avalon.Call("AddTorchLauncherLightColor", ModContent.ItemType<RoseTorch>(), new Vector3(1.3f, 0.43f, 0.93f));
		avalon.Call("AddTorchLauncherDust", ModContent.ItemType<RoseTorch>(), (int)DustID.PinkTorch);
		avalon.Call("AddTorchLauncherTexture", ModContent.ItemType<RoseTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.RoseTorch>().Texture);
		avalon.Call("AddTorchLauncherFlameTexture", ModContent.ItemType<RoseTorch>(), ModContent.GetInstance<Xenon.Content.Tiles.Decoration.Torches.RoseTorch>().Texture + "_Flame");
		avalon.Call("AddTorchLauncherDebuffType", ModContent.ItemType<RoseTorch>(), -1);
	}
}
