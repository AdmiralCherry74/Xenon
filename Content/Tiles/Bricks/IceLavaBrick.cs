using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Bricks;
public class IceLavaBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(240, 108, 21));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        DustType = DustID.Torch;
        HitSound = SoundID.Item50;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
        TileID.Sets.IceSkateSlippery[Type] = false;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.CorruptIce][Type] = true;
        Main.tileMerge[Type][TileID.CorruptIce] = true;
        Main.tileMerge[TileID.FleshIce][Type] = true;
        Main.tileMerge[Type][TileID.FleshIce] = true;
        Main.tileMerge[TileID.HallowedIce][Type] = true;
        Main.tileMerge[Type][TileID.HallowedIce] = true;
    }
}