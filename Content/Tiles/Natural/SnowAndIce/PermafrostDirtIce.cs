using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Tiles.Natural.SnowAndIce;

namespace Xenon.Content.Tiles.Natural.SnowAndIce;

public class PermafrostDirtIce : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[ModContent.TileType<FrostyGrass>()][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<FrostyGrass>()] = true;
        Main.tileMerge[ModContent.TileType<PermafrostDirt>()][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<PermafrostDirt>()] = true;
        Main.tileMerge[TileID.SnowBlock][Type] = true;
        Main.tileMerge[Type][TileID.SnowBlock] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.CorruptIce][Type] = true;
        Main.tileMerge[Type][TileID.CorruptIce] = true;
        Main.tileMerge[TileID.FleshIce][Type] = true;
        Main.tileMerge[Type][TileID.FleshIce] = true;
        Main.tileMerge[TileID.HallowedIce][Type] = true;
        Main.tileMerge[Type][TileID.HallowedIce] = true;
        AddMapEntry(new Color(173, 132, 108));
        HitSound = SoundID.Dig;
        DustType = DustID.Dirt;
        MineResist = 0.50f;
    }

    #region Hit Sound
    public override bool KillSound(int i, int j, bool fail)
    {
        switch (Main.rand.Next(3))
        {
            case 0:
                SoundEngine.PlaySound(PFDHit1);
                break;
            case 1:
                SoundEngine.PlaySound(PFDHit2);
                break;
            case 2:
                SoundEngine.PlaySound(PFDHit3);
                break;
        }
        return true;
    }
    static SoundStyle PFDHit1 = new SoundStyle($"Xenon/Assets/SFX/PermafrostDirtHit1")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle PFDHit2 = new SoundStyle($"Xenon/Assets/SFX/PermafrostDirtHit2")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle PFDHit3 = new SoundStyle($"Xenon/Assets/SFX/PermafrostDirtHit3")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    #endregion

    public override bool HasWalkDust() => Main.rand.NextBool(3);

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}