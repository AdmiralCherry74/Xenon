using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Accessories.Shield;

//[AutoloadEquip(EquipType.Shield)]
public class PalladiumBuckler : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToAccessory();
        Item.sellPrice(silver: 175);
        Item.rare = ItemRarityID.Green;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.lifeRegen += 1;
        player.noKnockback = true;
    }
}
