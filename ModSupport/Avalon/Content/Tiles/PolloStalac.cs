using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.ModSupport.Avalon.Content.Tiles;

public class PolloStalac : ModTile
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = false;
		Main.tileNoFail[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileObsidianKill[Type] = true;
		TileID.Sets.BreakableWhenPlacing[Type] = true;
		Main.tileMerge[ModContent.TileType<PolloStone>()][Type] = true;
		Main.tileMerge[Type][ModContent.TileType<PolloStone>()] = true;
		DustType = DustID.Crimstone;
		AddMapEntry(new Color(135, 80, 70));
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
