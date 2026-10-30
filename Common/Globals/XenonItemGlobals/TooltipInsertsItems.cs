using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Melee.Broadswords;
using Xenon.Content.Items.Weapons.Melee.Shortswords;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class TooltipInsertsItems : GlobalItem
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
            if (item.type == ItemID.FlipperPotion)
            {
                int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                if (tooltipInsert != 1)
                {
                    tooltips.RemoveAt(tooltipInsert + 4);
                    tooltips.Insert(tooltipInsert + 5, new TooltipLine(Mod, "FlipperPotionRelocalization", Language.GetTextValue("Mods.Xenon.Items.FlipperPotionRelocalization")));
                }
            }
            #region Basic Gameplay Changes Relocalization

            #region Pickaxe tooltips
            if (item.type == ModContent.ItemType<WoodenMattock>())
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.Insert(tooltipInsert + 8, new TooltipLine(Mod, "WoodenMattockBGCConfigLocalization", Language.GetTextValue("Mods.Xenon.Items.WoodenMattockBGCConfigLocalization")));
                    }
                }
            }
            if (item.type == ItemID.CopperPickaxe)
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "CopperTierPickBGCConfigLocalization", Language.GetTextValue("Mods.Xenon.Items.CopperTierPickBGCConfigLocalization")));
                    }
                }
            }
            if (item.type == ItemID.TinPickaxe || item.type == ModContent.ItemType<AluminumPickaxe>())
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "CopperTierPickBGCConfigLocalization", Language.GetTextValue("Mods.Xenon.Items.CopperTierPickBGCConfigLocalization")));
                    }
                }
            }
            if (item.type == ItemID.IronPickaxe || item.type == ItemID.LeadPickaxe || item.type == ModContent.ItemType<CinnabarPickaxe>())
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "IronTierPickBGCConfigLocalization", Language.GetTextValue("Mods.Xenon.Items.IronTierPickBGCConfigLocalization")));
                    }
                }
            }
            if (item.type == ItemID.SilverPickaxe || item.type == ModContent.ItemType<IndiumPickaxe>())
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "SilverTierPickBGCConfigLocalization", Language.GetTextValue("Mods.Xenon.Items.SilverTierPickBGCConfigLocalization")));
                    }
                }
            }
            if (item.type == ItemID.TungstenPickaxe)
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.RemoveAt(tooltipInsert + 8);
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "TungstenPickBGCConfigRelocalization", Language.GetTextValue("Mods.Xenon.Items.TungstenPickBGCConfigRelocalization")));
                    }
                }
            }
            if (item.type == ItemID.GoldPickaxe || item.type == ItemID.PlatinumPickaxe || item.type == ModContent.ItemType<FluoritePickaxe>())
            {
                if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                {
                    int tooltipInsert = tooltips.FindIndex((line) => line.Mod == "Terraria" && line.Name.StartsWith("axePower"));
                    if (tooltipInsert != 1)
                    {
                        tooltips.RemoveAt(tooltipInsert + 8);
                        tooltips.Insert(tooltipInsert + 7, new TooltipLine(Mod, "Tier3PickBGCConfigRelocalization", Language.GetTextValue("Mods.Xenon.Items.Tier4PickBGCConfigRelocalization")));
                    }
                }
            }
            #endregion
            #endregion
        }
    }
}
