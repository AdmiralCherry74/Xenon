using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Building.Decorational;

public class UlcerBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(206, 168, 34));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Gold;
    }
}
