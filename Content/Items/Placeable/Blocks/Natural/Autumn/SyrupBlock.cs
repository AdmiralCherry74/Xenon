using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Autumn;

public class SyrupBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<SyrupTile>());

        Item.width = 16;
        Item.height = 16;
        Item.maxStack = 9999;
        Item.value = 0;
        Item.rare = ItemRarityID.White;
    }
}