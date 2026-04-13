using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Body)]
public class CloudChestplate : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 2;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.MagicSummonHybrid) += 1;
    }
}
