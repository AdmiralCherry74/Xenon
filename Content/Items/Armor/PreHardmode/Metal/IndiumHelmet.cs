using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Head)]
public class IndiumHelmet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 28;

        Item.defense = 3;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.White;
    }

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
        return head.type == Type && body.type == ModContent.ItemType<IndiumChainmail>() && legs.type == ModContent.ItemType<IndiumGreaves>();
	}
	public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.ThreeDefense");
        player.statDefense += 3;
    }
}
