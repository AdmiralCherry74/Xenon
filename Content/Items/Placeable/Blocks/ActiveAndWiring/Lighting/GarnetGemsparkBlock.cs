using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting
{
    public class GarnetGemsparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ActiveAndWiring.Lighting.GarnetGemsparkBlock>());
        }
    }
}