using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class TinOreWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        AddMapEntry(new Color(61, 56, 44));
        DustType = DustID.Tin;
    }
}
