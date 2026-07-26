using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems
{
    public class CinnabarOreBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CinnabarOre>());
            Item.rare = ItemRarityID.White;
        }
    }
}