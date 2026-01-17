using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class GarnetMudBlock : ModItem
    {
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 100;
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Ores.GarnetMud>());
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        }
    }
}