using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.NaturalWalls.LivingWoodWalls.LivingLeafWalls;

public class LivingJacarandaLeafWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(48, 43, 92));
        DustType = DustID.PurpleMoss;
    }
}
