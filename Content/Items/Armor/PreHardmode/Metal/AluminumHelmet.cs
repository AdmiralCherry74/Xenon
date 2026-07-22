using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Head)]
public class AluminumHelmet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 30;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<AluminumChainmail>() && legs.type == ModContent.ItemType<AluminumGreaves>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.OneDefense");
        player.statDefense += 1;
    }
}
