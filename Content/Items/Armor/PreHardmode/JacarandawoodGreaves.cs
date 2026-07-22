using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Legs)]
public class JacarandawoodGreaves : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 18;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 0, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }
}
