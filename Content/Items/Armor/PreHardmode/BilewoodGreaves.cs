using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode;


[AutoloadEquip(EquipType.Legs)]
public class BilewoodGreaves : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 18;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 0, 0, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }
}
