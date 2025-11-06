using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Content.Tiles.NaturalTile.Snow;

public class OnyxIceBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.SnowBlock] = true;
        Main.tileMerge[Type][TileID.BreakableIce] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[Type][TileID.CorruptIce] = true;
        Main.tileMerge[Type][TileID.HallowedIce] = true;
        Main.tileMerge[Type][TileID.FleshIce] = true;
        Main.tileMerge[Type][ModContent.TileType<TanIce>()] = true;
        Main.tileMerge[Type][ModContent.TileType<PowderedSnow>()] = true;
        Main.tileMerge[Type][ModContent.TileType<FrozenLava>()] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        TileID.Sets.Ore[Type] = true;
        AddMapEntry(new Color(40, 152, 240));
        RegisterItemDrop(ModContent.ItemType<Items.Materials.Onyx>(), 1);
        HitSound = SoundID.Item50;
        DustType = DustID.Asphalt;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}