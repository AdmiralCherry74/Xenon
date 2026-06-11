using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Building.Wood;

public class Bilewood : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(116, 103, 49));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<Dusts.BilewoodDust>();
    }
}
