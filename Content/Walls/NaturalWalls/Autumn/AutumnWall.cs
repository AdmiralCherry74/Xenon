using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Walls.NaturalWalls.Autumn;

public class AutumnWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(158, 92, 73));
        DustType = ModContent.DustType<Dusts.AutumnDust>();
        HitSound = SoundID.Grass;
        //WallID.Sets.Conversion.Grass[Type] = true;
        
    }
}
