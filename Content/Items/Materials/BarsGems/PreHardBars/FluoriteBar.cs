using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;
using Xenon.Content.Tiles.Building.Decorational;

namespace Xenon.Content.Items.Materials.BarsGems.PreHardBars;

public class FluoriteBar : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<PlacedBars>(), 4);
        Item.width = 20;
        Item.height = 20;
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.maxStack = 9999;
    }
}