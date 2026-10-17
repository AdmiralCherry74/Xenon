using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Autumn
{
	public class Mulch : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBrick[Type] = true;

			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			TileID.Sets.Conversion.Dirt[Type] = true;

			DustType = ModContent.DustType<MulchDust>();

			Main.tileMerge[Type][ModContent.TileType<AutumnGrass>()] = true;
			Main.tileMerge[Type][ModContent.TileType<MushroomGrassMulch>()] = true;
			Main.tileMerge[Type][ModContent.TileType<CrimsonAutumnGrass>()] = true;
			Main.tileMerge[Type][ModContent.TileType<CorruptionAutumnGrass>()] = true;
			Main.tileMerge[Type][ModContent.TileType<CorrosionAutumnGrass>()] = true;

			AddMapEntry(new Color(97, 58, 53));
		}
	}
}