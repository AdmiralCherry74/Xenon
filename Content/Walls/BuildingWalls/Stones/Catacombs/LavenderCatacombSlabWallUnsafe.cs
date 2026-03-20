using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone.Catacombs;

namespace Xenon.Content.Walls.BuildingWalls.Stones.Catacombs;

public class LavenderCatacombSlabWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(72, 64, 78));
        DustType = DustID.Asphalt;
        RegisterItemDrop(ModContent.ItemType<LavenderCatacombSlabWallItem>());
    }
}
