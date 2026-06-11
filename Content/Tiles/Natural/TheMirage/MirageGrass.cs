using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Tiles.Natural.TheMirage
{
    public class MirageGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            #region Tile Merging
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[TileID.Sand][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[Type][TileID.Ebonsand] = true;
            Main.tileMerge[Type][TileID.CorruptHardenedSand] = true;
            Main.tileMerge[Type][TileID.CorruptSandstone] = true;
            Main.tileMerge[Type][TileID.Crimsand] = true;
            Main.tileMerge[Type][TileID.CrimsonHardenedSand] = true;
            Main.tileMerge[Type][TileID.CrimsonSandstone] = true;
            Main.tileMerge[Type][TileID.Pearlsand] = true;
            Main.tileMerge[Type][TileID.HallowHardenedSand] = true;
            Main.tileMerge[Type][TileID.HallowSandstone] = true;
            Main.tileMerge[Type][ModContent.TileType<Gutsand>()] = true;
            Main.tileMerge[Type][ModContent.TileType<HardenedGutsand>()] = true;
            Main.tileMerge[Type][ModContent.TileType<Gutsandstone>()] = true;
            Main.tileMerge[Type][TileID.Grass] = true;
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[Type][TileID.DirtiestBlock] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[Type][TileID.Ebonstone] = true;
            Main.tileMerge[Type][TileID.CorruptGrass] = true;
            Main.tileMerge[Type][TileID.Crimstone] = true;
            Main.tileMerge[Type][TileID.CrimsonGrass] = true;
            Main.tileMerge[Type][TileID.Pearlstone] = true;
            Main.tileMerge[Type][TileID.HallowedGrass] = true;
            Main.tileMerge[Type][ModContent.TileType<CorrosionGrass>()] = true;
            Main.tileMerge[Type][ModContent.TileType<Gutstone>()] = true;
            #endregion
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(131, 152, 28));
            HitSound = SoundID.Dig;
            DustType = DustID.JungleGrass;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}