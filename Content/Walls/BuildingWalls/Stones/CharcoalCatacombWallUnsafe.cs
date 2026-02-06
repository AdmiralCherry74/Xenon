using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Xenon.Content.Walls.BuildingWalls.Stones;

public class CharcoalCatacombWallUnsafe : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = false;
		AddMapEntry(new Color(29, 35, 50));
		DustType = DustID.Asphalt;
		RegisterItemDrop(ModContent.ItemType<Items.Placeable.Wall.BuildingWalls.Stone.CharcoalCatacombWallItem>());
	}
}
