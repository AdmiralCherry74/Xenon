using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

public class LavenderCatacombWall : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = true;
		AddMapEntry(new Color(72, 64, 78));
		DustType = DustID.Asphalt;
		//RegisterItemDrop(ModContent.ItemType<Items.Placeable.Wall.BuildingWalls.Stone.SmoothRhyoliteWall>());
	}
}
