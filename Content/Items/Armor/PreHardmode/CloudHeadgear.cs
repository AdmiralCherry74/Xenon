using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Head)]
public class CloudHeadgear : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 30;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.MagicSummonHybrid) += 1;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<CloudChestplate>() && legs.type == ModContent.ItemType<CloudLeggings>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.CloudArmor");
        player.maxMinions += 1;
        player.GetCritChance(DamageClass.Magic) += 4;
        player.GetDamage(DamageClass.MagicSummonHybrid) += 1;
    }
}