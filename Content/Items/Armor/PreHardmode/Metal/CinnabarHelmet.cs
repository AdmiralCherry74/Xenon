using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Head)]
public class CinnabarHelmet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 26;

        Item.defense = 2;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<CinnabarChainmail>() && legs.type == ModContent.ItemType<CinnabarGreaves>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.ThreeDefense");
        player.statDefense += 3;
    }
}
