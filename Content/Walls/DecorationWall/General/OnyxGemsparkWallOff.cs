using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.DecorationWall.General;

public class OnyxGemsparkWallOff : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        AddMapEntry(new Color(108, 108, 108));
        DustType = DustID.GemDiamond;
    }
}