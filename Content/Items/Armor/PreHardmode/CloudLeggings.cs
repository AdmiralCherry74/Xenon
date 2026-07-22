using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Legs)]
public class CloudLeggings : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 18;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.MagicSummonHybrid) += 1;
    }
}
