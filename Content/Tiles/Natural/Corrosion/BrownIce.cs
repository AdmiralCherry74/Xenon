using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Corrosion;

public class BrownIce : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(123, 90, 67));
        Main.tileBrick[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        HitSound = SoundID.Item50;
        DustType = ModContent.DustType<BrownIceDust>();
        TileID.Sets.Conversion.Ice[Type] = true;
        TileID.Sets.Ices[Type] = true;
        TileID.Sets.IcesSlush[Type] = true;
        TileID.Sets.IcesSnow[Type] = true;
        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
    }
    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = XenonMod.CorrosionBiomeSightColor;
        return true;
    }
}
