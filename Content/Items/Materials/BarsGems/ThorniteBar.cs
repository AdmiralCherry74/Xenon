// What libraries we use in the code
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials.BarsGems;

public class ThorniteBar : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
    }

    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 24;
        Item.maxStack = 9999;
        Item.value = 35;
        Item.rare = ItemRarityID.Lime;
    }
}