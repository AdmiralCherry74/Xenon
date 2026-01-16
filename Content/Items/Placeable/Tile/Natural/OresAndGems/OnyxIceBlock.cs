using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.Natural.OresAndGems
{
    public class OnyxIceBlock : ModItem
    {
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 100;
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Natural.Ores.OnyxIce>());
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        }
    }
}