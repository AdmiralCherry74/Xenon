using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Stone;

public class NyxStalac : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileNoFail[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileObsidianKill[Type] = true;
        TileID.Sets.BreakableWhenPlacing[Type] = true;
        Main.tileMerge[ModContent.TileType<NyxStone>()][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<NyxStone>()] = true;
        DustType = DustID.Ebonwood;
		AddMapEntry(new Color(100, 100, 149));
	}
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        switch (tileFrameY)
        {
            case <= 18:
            case 72:
                offsetY = -2;
                break;

            case >= 36 and <= 54:
            case 90:
                offsetY = 2;
                break;
        }
    }

    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        WorldGen.CheckTight(i, j);
        return false;
    }
}
