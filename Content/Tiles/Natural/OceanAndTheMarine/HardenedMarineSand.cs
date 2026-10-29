using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

namespace Xenon.Content.Tiles.Natural.OceanAndTheMarine;

public class HardenedMarineSand : ModTile
{
	public override void SetStaticDefaults()
	{
		AddMapEntry(new Color(78, 93, 168));
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;
		TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
		TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        Main.tileMerge[Type][TileID.Sand] = true;
        Main.tileMerge[TileID.Sand][Type] = true;
        Main.tileMerge[Type][TileID.SnowBlock] = true;
        Main.tileMerge[TileID.SnowBlock][Type] = true;

        DustType = ModContent.DustType<MarineSandDust>();
	}
}
