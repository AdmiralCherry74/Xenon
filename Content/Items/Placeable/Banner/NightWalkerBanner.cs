using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture;

namespace Xenon.Content.Items.Placeable.Banner;

public class NightWalkerBanner : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MonsterBanner>(), 14);
        Item.width = 10;
        Item.height = 24;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(silver: 10);
    }
}
