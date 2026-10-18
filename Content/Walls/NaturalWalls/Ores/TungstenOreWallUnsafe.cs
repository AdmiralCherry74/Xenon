using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class TungstenOreWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        AddMapEntry(new Color(54, 85, 52));
        DustType = DustID.Tungsten;
    }
}
