using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Armour.Vanity;

[AutoloadEquip(EquipType.Head)]
public class CarrotHeadBand : ModItem
{
    public override void SetDefaults()

    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public void SetDefualts()
    {
        Item.width = 32;
        Item.height = 24;
        Item.vanity = true;
        Item.rare = ModContent.RarityType<Brown>();
        Item.value = Item.buyPrice(silver: 50);
    }
}