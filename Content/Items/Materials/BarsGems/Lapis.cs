using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Materials.BarsGems;

public class Lapis : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 17, 50);
        Item.maxStack = 9999;
        Item.DefaultToPlaceableTile(ModContent.TileType<PlacedLapis>());
    }
}