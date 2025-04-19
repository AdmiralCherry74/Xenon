using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Walls;

namespace Xenon.Content.Items.Blocks
{
    public class RhyoliteWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DrawUnsafeIndicator[Type] = true;
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Walls.RhyoliteWall>());
        }
    }
}