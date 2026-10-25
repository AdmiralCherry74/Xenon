using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.LargeGeode;

public class Tachylite : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(50, 46, 44));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
        TileID.Sets.Stone[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<TachyliteDust>();
    }
}
