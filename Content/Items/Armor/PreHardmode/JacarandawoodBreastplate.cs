using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Body)]
public class JacarandawoodBreastplate : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 00, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }
}
