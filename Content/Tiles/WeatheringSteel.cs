using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles;

public class WeatheringSteel : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(134, 85, 77));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = DustID.Iron;
        HitSound = SoundID.Item52;
        MinPick = 100;
        MineResist = 2;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}