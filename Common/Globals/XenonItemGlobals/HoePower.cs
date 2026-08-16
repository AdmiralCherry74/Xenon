using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class HoePower : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public int hoePower; //heh... hoe power :3

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           if (hoePower > 0)
           {
                int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                if (tooltipInsert != 1)
                {
                    tooltips.Insert(tooltipInsert + 6, new TooltipLine(Mod, "hoePower", Language.GetTextValue("Mods.Xenon.Items.HoePowerTooltip", item.GetGlobalItem<HoePower>().hoePower)));
                }
           }
        }
    }
}