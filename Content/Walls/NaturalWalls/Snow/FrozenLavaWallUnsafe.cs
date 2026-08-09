using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.Snow;

public class FrozenLavaWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(50, 30, 27));
        DustType = DustID.Torch;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
}
