using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles.Building.BuildingStone.CombinedGems;

namespace Xenon.Content.Tiles.Building.Bricks;

public class AmethystBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 500;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        #region Merge with other combined gems and gem bricks
        Main.tileMerge[Type][ModContent.TileType<AmethystBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<JadeBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<JadeBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<TopazBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<TopazBrick>()] = true; ;
        Main.tileMerge[Type][ModContent.TileType<SapphireBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<SapphireBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<GarnetBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<GarnetBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<EmeraldBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<EmeraldBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<RubyBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<RubyBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<LapisBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<LapisBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<DiamondBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<DiamondBrick>()] = true;
        Main.tileMerge[Type][ModContent.TileType<AmberBlock>()] = true;
        Main.tileMerge[Type][ModContent.TileType<AmberBrick>()] = true;
        #endregion
        AddMapEntry(new Color(165, 0, 236));
        HitSound = SoundID.Tink;
        DustType = DustID.GemAmethyst;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}