using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture;
using Xenon.Content.Tiles.Furniture.PrideBanners;

namespace Xenon.Content.Items.Placeable.Banner.PrideBannerItems;

public class BisexualPrideBannerItem : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<BisexualPrideBanner>());
        Item.width = 10;
        Item.height = 24;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(silver: 10);
    }
}
