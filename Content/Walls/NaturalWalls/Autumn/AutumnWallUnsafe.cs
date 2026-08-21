using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Autumn;

public class AutumnWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(158, 92, 73));
        DustType = ModContent.DustType<Dusts.AutumnDust>();
        HitSound = SoundID.Grass;
        WallID.Sets.Conversion.Grass[Type] = true;

        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        
    }
}
