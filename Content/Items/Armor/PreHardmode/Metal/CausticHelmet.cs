using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Head)]
public class CausticHelmet : ModItem
{
    private const int PercentIncrease = 4;

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 20;

        Item.defense = 6;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.Blue;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<CausticScalemail>() && legs.type == ModContent.ItemType<CausticGreaves>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.Caustic");
        player.GetModPlayer<XenonPlayer>().KnockbackBoostCaustic = true;
    }
}
