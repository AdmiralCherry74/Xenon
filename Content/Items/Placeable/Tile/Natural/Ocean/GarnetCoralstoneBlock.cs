using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.Natural.Ocean
{
    public class GarnetCoralstoneBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.NaturalTile.Ocean.GarnetCoralstoneBlock>());
        }
    }
}