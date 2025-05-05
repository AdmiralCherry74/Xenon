using System.Collections.Generic;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Xenon.Common.Globals;

namespace Xenon.Content.Items.Accessories;

public class FossilizedBlessing : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToAccessory();
        Item.rare = ItemRarityID.Green;
    }
    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        for (int i = 0; i < tooltips.Count; i++)
        {
            if (tooltips[i].Mod.Equals("Terraria") && tooltips[i].Name.Equals("Tooltip0"))
            {
                tooltips.RemoveAt(i);
                tooltips.Add(new TooltipLine(Mod, "Tooltip0", Language.GetTextValue("Mods.Xenon.Tooltips.FossilizedBlessing",
                    Language.GetTextValue(!Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN"))));
                break;
            }
        }
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<XenonPlayer>().FossilBlessing = true;
        player.lavaMax += 420;
    }
}
