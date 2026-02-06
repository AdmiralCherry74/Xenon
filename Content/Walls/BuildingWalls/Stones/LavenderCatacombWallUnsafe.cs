using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Stones;

public class LavenderCatacombWallUnsafe : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = false;
		AddMapEntry(new Color(72, 64, 78));
		DustType = DustID.Asphalt;
		RegisterItemDrop(ModContent.ItemType<Items.Placeable.Wall.BuildingWalls.Stone.LavenderCatacombWallItem>());
	}
}
