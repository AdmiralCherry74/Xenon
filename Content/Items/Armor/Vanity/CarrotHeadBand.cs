using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.Vanity;

[AutoloadEquip(EquipType.Head)]
public class CarrotHeadBand : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;
        Item.vanity = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(silver: 50);
    }
}