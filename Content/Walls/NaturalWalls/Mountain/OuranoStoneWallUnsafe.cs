using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.Mountain;

public class OuranoStoneWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(50, 30, 27));
        DustType = DustID.Stone;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
}
