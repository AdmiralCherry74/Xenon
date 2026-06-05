using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Xenon.Content.Tiles.Building.Decorational;

public class PlacedBars : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[Type] = true;
		Main.tileSolidTop[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileShine[Type] = 1100;

		DustType = -1;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.addTile(Type);
	}

	// basically just makes sure the bar below it isn't hammered, and causes it to break if so
	public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
	{
		WorldGen.Check1x1(i, j, Type);
		return false;
	}

	// selects the map entry depending on the frameX
	public override ushort GetMapOption(int i, int j)
	{
		return (ushort)(Main.tile[i, j].TileFrameX / 18);
	}
	public override bool CreateDust(int i, int j, ref int type)
	{
		switch (Main.tile[i, j].TileFrameX / 18)
		{
			case 0:
				type = ModContent.DustType<Dusts.CorrosionDust>();
				break;
		}
		return base.CreateDust(i, j, ref type);
	}
}
