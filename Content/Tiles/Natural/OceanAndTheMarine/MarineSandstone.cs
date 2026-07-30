using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.OceanAndTheMarine;

public class MarineSandstone : ModTile
{
	public override void SetStaticDefaults()
	{
		AddMapEntry(new Color(83, 85, 149));
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;
		TileID.Sets.Conversion.Sandstone[Type] = true;
		TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
		TileID.Sets.isDesertBiomeSand[Type] = true;
		TileID.Sets.CanBeClearedDuringGeneration[Type] = false;
		DustType = ModContent.DustType<MarineSandDust>();

		TileID.Sets.ChecksForMerge[Type] = true;
	}
	public override void ModifyFrameMerge(int i, int j, ref int up, ref int down, ref int left, ref int right, ref int upLeft, ref int upRight, ref int downLeft, ref int downRight)
	{
		WorldGen.TileMergeAttempt(-2, ModContent.TileType<HardenedMarineSand>(), ref up, ref down, ref left, ref right, ref upLeft, ref upRight, ref downLeft, ref downRight);
		WorldGen.TileMergeAttempt(-2, ModContent.TileType<MarineSand>(), ref up, ref down, ref left, ref right, ref upLeft, ref upRight, ref downLeft, ref downRight);
	}
}
