using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.DeveloperItems;

//[AutoloadEquip(EquipType.Shield)]
public class DirtShield : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToAccessory();
        Item.sellPrice(gold: 1);
        Item.rare = ItemRarityID.Blue;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statLifeMax2 += 999999999;
        player.statManaMax2 += 999999999;
        player.statDefense += 999999999;
        player.noKnockback = true;
    }
}
