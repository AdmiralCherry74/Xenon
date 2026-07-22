using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Body)]
public class IndiumChainmail : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 18;

        Item.defense = 4;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }
}
