using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Head)]
public class BilewoodHelmet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 22;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 0, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<BilewoodBreastplate>() && legs.type == ModContent.ItemType<BilewoodGreaves>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.OneDefense");
        player.statDefense += 1;
    }
}