using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Walls.NaturalWalls.Ores;

public class IndiumOreWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        AddMapEntry(new Color(26, 12, 57));
        DustType = ModContent.DustType<IndiumDust>();
    }
}
