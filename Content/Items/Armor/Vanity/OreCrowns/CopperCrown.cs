using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.Vanity.OreCrowns;

[AutoloadEquip(EquipType.Head)]
public class CopperCrown : ModItem
{
    public override void SetStaticDefaults()
    {
        ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 12;
        Item.vanity = true;
        Item.rare = ItemRarityID.White;
        Item.value = Item.buyPrice(silver: 50);
        Item.vanity = true;
    }
}