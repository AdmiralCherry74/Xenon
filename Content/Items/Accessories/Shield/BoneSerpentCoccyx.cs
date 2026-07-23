using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Accessories.Shield;

[AutoloadEquip(EquipType.Shield)]
public class BoneSerpentCoccyx : ModItem
{
    public override void SetDefaults()
    {
        Item.height = 22;
        Item.width = 26;
        Item.DefaultToAccessory();
        Item.sellPrice(silver: 50);
        Item.rare = ItemRarityID.Blue;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<XenonPlayer>().HotDamageResistShield = true;
    }
}