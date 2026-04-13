using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class LapisStoneBlock : ModItem
    {
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 100;
            Item.DefaultToPlaceableTile(ModContent.TileType<LapisGemstoneBlock>());
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        }
    }
}