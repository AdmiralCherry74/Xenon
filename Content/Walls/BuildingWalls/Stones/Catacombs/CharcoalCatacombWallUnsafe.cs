using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone.Catacombs;

namespace Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

public class CharcoalCatacombWallUnsafe : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[Type] = false;
		AddMapEntry(new Color(29, 35, 50));
		DustType = DustID.Asphalt;
		RegisterItemDrop(ModContent.ItemType<CharcoalCatacombWallItem>());
	}
}
