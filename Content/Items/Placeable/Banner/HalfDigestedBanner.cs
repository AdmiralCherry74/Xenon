using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture;

namespace Xenon.Content.Items.Placeable.Banner;

public class HalfDigestedBanner : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MonsterBanner>(), 10);
        Item.width = 10;
        Item.height = 24;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(silver: 10);
    }
}
