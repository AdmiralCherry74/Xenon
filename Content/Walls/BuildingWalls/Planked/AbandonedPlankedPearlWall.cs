using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Planked;

namespace Xenon.Content.Walls.BuildingWalls.Planked;

public class AbandonedPlankedPearlWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(119, 108, 81));
        DustType = DustID.Pearlwood;
        RegisterItemDrop(ModContent.ItemType<PlankedPearlWallItem>());
    }
    public override bool CanExplode(int i, int j)
    {
        if (Main.hardMode)
        {
            return true;
        }
        return false;
    }
}