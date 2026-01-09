using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.LivingWoodWalls;

public class LivingJacarandawoodWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(29, 22, 18));
        DustType = DustID.BorealWood;
    }
}
