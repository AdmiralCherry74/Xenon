using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Weapons.Melee.Broadswords;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class TooltipInserts : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Data.ItemSets.ItemsThatDefenseDecreaseWithoutSpecialBuffsFromXenonThatShouldGetLocalized[item.type])
            {
                int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                if (tooltipInsert != 1)
                {
                    tooltips.Insert(tooltipInsert + 6, new TooltipLine(Mod, "WeaponDefenseDebuff", Language.GetTextValue("Mods.Xenon.Items.WeaponDefenseDebuff")));
                }
            }
            if (Data.ItemSets.SplashPotions[item.type])
            {
                int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                if (tooltipInsert != 1)
                {
                    tooltips.Insert(tooltipInsert + 6, new TooltipLine(Mod, "SplashPotionLocalization", Language.GetTextValue("Mods.Xenon.Items.SplashPotionLocalization")));
                }
            }
        }
    }
}
