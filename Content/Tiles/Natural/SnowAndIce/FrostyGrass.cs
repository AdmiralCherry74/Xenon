using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Snow;

namespace Xenon.Content.Tiles.Natural.SnowAndIce;

public class FrostyGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(128, 180, 226));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        DustType = DustID.SnowBlock;
        TileID.Sets.Conversion.Grass[Type] = true;
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<PermafrostDirtIce>();
        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<PermafrostDirt>();
        Main.tileMerge[ModContent.TileType<PermafrostDirt>()][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<PermafrostDirt>()] = true;
        Main.tileMerge[ModContent.TileType<PermafrostDirtIce>()][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<PermafrostDirtIce>()] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.CorruptIce][Type] = true;
        Main.tileMerge[Type][TileID.CorruptIce] = true;
        Main.tileMerge[TileID.FleshIce][Type] = true;
        Main.tileMerge[Type][TileID.FleshIce] = true;
        Main.tileMerge[TileID.HallowedIce][Type] = true;
        Main.tileMerge[Type][TileID.HallowedIce] = true;
        

        //TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = false;
        //TileID.Sets.CanBeDugByShovel[Type] = true;
        //TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
        //TileID.Sets.SpreadOverground[Type] = true;
        //TileID.Sets.SpreadUnderground[Type] = true;
        TileID.Sets.Grass[Type] = true;
        //TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        RegisterItemDrop(ModContent.ItemType<PermafrostDirtIceBlock>());
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

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (fail && !effectOnly)
        {
            noItem = true;
            Main.tile[i, j].TileType = (ushort)ModContent.TileType<PermafrostDirtIce>();
            WorldGen.SquareTileFrame(i, j);
        }
    }
}
