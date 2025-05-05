using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Armor.Vanity;

[AutoloadEquip(EquipType.Head)]
public class CarrotHeadBand : ModItem
{

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;
        Item.vanity = true;
        Item.rare = ModContent.RarityType<Brown>();
        Item.value = Item.buyPrice(silver: 50);
    }
}