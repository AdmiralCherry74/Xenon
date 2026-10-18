using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class SilverOreWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        AddMapEntry(new Color(77, 89, 91));
        DustType = DustID.Silver;
    }
}
