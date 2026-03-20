using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

public class RedCatacombSlabWall : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		AddMapEntry(new Color(50, 30, 27));
		DustType = DustID.RedMoss;
		//RegisterItemDrop(ModContent.ItemType<Items.Placeable.Wall.BuildingWalls.Stone.RedCatacombWallItem>());
	}
}
