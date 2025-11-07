using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Corrosion;

public class Gutstone : ModTile
{
    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = XenonMod.CorrosionBiomeSightColor;
        return true;
    }
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(127, 115, 33));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Conversion.Stone[Type] = true;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
        TileID.Sets.Stone[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        HitSound = SoundID.Tink;
        MinPick = 60;
        DustType = ModContent.DustType<CorrosionDust>();
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail && !effectOnly)
        {
            if (Main.tile[i, j - 1].TileType == ModContent.TileType<CorrosionStalac>())
            {
                WorldGen.KillTile(i, j - 1);
                if (Main.tile[i, j - 2].TileType == ModContent.TileType<CorrosionStalac>())
                {
                    WorldGen.KillTile(i, j - 2);
                }
            }
            if (Main.tile[i, j + 1].TileType == ModContent.TileType<CorrosionStalac>())
            {
                WorldGen.KillTile(i, j + 1);
                if (Main.tile[i, j + 2].TileType == ModContent.TileType<CorrosionStalac>())
                {
                    WorldGen.KillTile(i, j + 2);
                }
            }
        }
    }
}
