using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Tiles.Natural.Ores.Gems;

public class FlintFrozenLavaBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
        TileID.Sets.IceSkateSlippery[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<FrozenLava>()] = true;
        Main.tileMerge[ModContent.TileType<FrozenLava>()][Type] = true;
        Main.tileMerge[TileID.IceBlock][Type] = true;
        Main.tileMerge[Type][TileID.IceBlock] = true;
        Main.tileMerge[TileID.CorruptIce][Type] = true;
        Main.tileMerge[Type][TileID.CorruptIce] = true;
        Main.tileMerge[TileID.FleshIce][Type] = true;
        Main.tileMerge[Type][TileID.FleshIce] = true;
        Main.tileMerge[TileID.HallowedIce][Type] = true;
        Main.tileMerge[Type][TileID.HallowedIce] = true;
        Main.tileStone[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 900;
        TileID.Sets.Ore[Type] = true;
        RegisterItemDrop(ModContent.ItemType<Flint>());
        AddMapEntry(new Color(108, 108, 108));
        HitSound = SoundID.Item50;
        DustType = DustID.Asphalt;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}