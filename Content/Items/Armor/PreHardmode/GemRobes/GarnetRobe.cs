using Avalon.Items.Armor.PreHardmode;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Armor.PreHardmode.GemRobes;


[AutoloadEquip(EquipType.Body)]
public class GarnetRobe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 1;

        Item.value = Item.sellPrice(0, 1, 75, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.Blue;
    }
    public override void Load()
    {
        if (Main.netMode == NetmodeID.Server) return;
        EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
    }
    public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
    {
        robes = true;
        equipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<GarnetRobe>() && (head.type == ItemID.WizardHat || head.type == ItemID.MagicHat);
    }
    public override void UpdateArmorSet(Player player)
    {
        if (player.head == 14)
        {
            player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.Robe1");
            player.GetCritChance(DamageClass.Magic) += 10;
        }
        else if (player.head == 159)
        {
            player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.Robe2");
            player.statManaMax2 += 60;
        }
    }
    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 50;
        player.manaCost -= 0.10f;
    }
}