using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Materials.BarsGems;

public class Garnet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.alpha = 50;
        Item.value = Item.sellPrice(0, 4, 25);
        Item.maxStack = 9999;
        Item.DefaultToPlaceableTile(ModContent.TileType<PlacedGarnet>());
    }
}