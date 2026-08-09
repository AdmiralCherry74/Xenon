using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.FallingTiles;

namespace Xenon.Content.Tiles.Natural.MountainsAndTheKarst;

public class Gravel : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;

        Main.tileSand[Type] = true;
        TileID.Sets.Conversion.Sand[Type] = true;
        TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.Falling[Type] = true;
        TileID.Sets.Suffocate[Type] = true;
        TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<GravelBallFallingProjectile>());

        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
        TileID.Sets.ChecksForMerge[Type] = true;

        MineResist = 0.5f;
        DustType = DustID.Silt;
        AddMapEntry(new Color(145, 145, 145));
    }

    public override bool HasWalkDust() => Main.rand.NextBool(3);

    public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
    {
        dustType = DustType;
    }

    //public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}
