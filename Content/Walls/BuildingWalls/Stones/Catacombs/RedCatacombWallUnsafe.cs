using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone.Catacombs;

namespace Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

public class RedCatacombWallUnsafe : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = false;
		AddMapEntry(new Color(50, 30, 27));
		DustType = DustID.RedMoss;
		RegisterItemDrop(ModContent.ItemType<RedCatacombWallItem>());
	}
}
