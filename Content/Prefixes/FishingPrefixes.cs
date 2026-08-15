using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Prefixes
{
    //thanks example mod
    public class MehFishingPrefix : ModPrefix
    {
        public virtual float Power => 1f;
        // Change your category this way, defaults to PrefixCategory.Custom. Affects which items can get this prefix.
        public override PrefixCategory Category => PrefixCategory.Accessory;

        // See documentation for vanilla weights and more information.
        // In case of multiple prefixes with similar functions this can be used with a switch/case to provide different chances for different prefixes
        // Note: a weight of 0f might still be rolled. See CanRoll to exclude prefixes.
        // Note: if you use PrefixCategory.Custom, actually use ModItem.ChoosePrefix instead.
        public override float RollChance(Item item)
        {
            return 1f;
        }

        // Determines if it can roll at all.
        // Use this to control if a prefix can be rolled or not.
        public override bool CanRoll(Item item)
        {
            return true;
        }

        // Modify the cost of items with this modifier with this function.
        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * 1f;
        }

        // This is used to modify most other stats of items which have this modifier.
        public override void ApplyAccessoryEffects(Player player)
        {
            player.fishingSkill += 1;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            // Due to inheritance, this code runs for ExamplePrefix and ExampleDerivedPrefix. We add 2 tooltip lines, the first is the typical prefix tooltip line showing the stats boost, while the other is just some additional flavor text.

            // The localization key for Mods.ExampleMod.Prefixes.PowerTooltip uses a special format that will automatically prefix + or - to the value.
            // This shared localization is formatted with the Power value, resulting in different text for ExamplePrefix and ExampleDerivedPrefix.
            // This results in "+1 Power" for ExamplePrefix and "+2 Power" for ExampleDerivedPrefix.
            // Power isn't an actual stat, the effects of Power are already shown in the "+X% damage" tooltip, so this example is purely educational.
            yield return new TooltipLine(Mod, "MehFishingPrefix", PowerTooltip.Format(Power))
            {
                IsModifier = true, // Sets the color to the positive modifier color.
            };
            // This localization is not shared with the inherited classes. ExamplePrefix and ExampleDerivedPrefix have their own translations for this line.
            yield return new TooltipLine(Mod, "MehFishingPrefixDescription", AdditionalTooltip.Value)
            {
                IsModifier = true,
            };
            // If possible and suitable, try to reuse the name identifier and translation value of Terraria prefixes. For example, this code uses the vanilla translation for the word defense, resulting in "-5 defense". Note that IsModifierBad is used for this bad modifier.
            /*yield return new TooltipLine(Mod, "PrefixAccDefense", "-5" + Lang.tip[25].Value) {
				IsModifier = true,
				IsModifierBad = true,
			};*/
        }

        // PowerTooltip is shared between ExamplePrefix and ExampleDerivedPrefix. 
        public static LocalizedText PowerTooltip { get; private set; }

        // AdditionalTooltip shows off how to do the inheritable localized properties approach. This is necessary this this example uses inheritance and we want different translations for each inheriting class. https://github.com/tModLoader/tModLoader/wiki/Localization#inheritable-localized-properties
        public LocalizedText AdditionalTooltip => this.GetLocalization(nameof(AdditionalTooltip));

        public override void SetStaticDefaults()
        {
            // this.GetLocalization is not used here because we want to use a shared key
            PowerTooltip = Mod.GetLocalization($"{LocalizationCategory}.{nameof(PowerTooltip)}");
            // This seemingly useless code is required to properly register the key for AdditionalTooltip
            _ = AdditionalTooltip;
        }
    }
    public class OkFishingPrefix : ModPrefix
    {
        public virtual float Power => 2f;
        public override PrefixCategory Category => PrefixCategory.Accessory;

        public override float RollChance(Item item)
        {
            return 0.75f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * 1.5f;
        }

        public override void ApplyAccessoryEffects(Player player)
        {
            player.fishingSkill += 2;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {

            yield return new TooltipLine(Mod, "OkFishingPrefix", PowerTooltip.Format(Power))
            {
                IsModifier = true,
            };
            yield return new TooltipLine(Mod, "OkFishingPrefixDescription", AdditionalTooltip.Value)
            {
                IsModifier = true,
            };
        }
        public static LocalizedText PowerTooltip { get; private set; }
        public LocalizedText AdditionalTooltip => this.GetLocalization(nameof(AdditionalTooltip));

        public override void SetStaticDefaults()
        {
            PowerTooltip = Mod.GetLocalization($"{LocalizationCategory}.{nameof(PowerTooltip)}");
            _ = AdditionalTooltip;
        }
    }
    public class GoodFishingPrefix : ModPrefix
    {
        public virtual float Power => 3f;
        public override PrefixCategory Category => PrefixCategory.Accessory;

        public override float RollChance(Item item)
        {
            return 0.50f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * 2f;
        }

        public override void ApplyAccessoryEffects(Player player)
        {
            player.fishingSkill += 3;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            yield return new TooltipLine(Mod, "GoodFishingPrefix", PowerTooltip.Format(Power))
            {
                IsModifier = true, // Sets the color to the positive modifier color.
            };
            yield return new TooltipLine(Mod, "GoodFishingPrefixDescription", AdditionalTooltip.Value)
            {
                IsModifier = true,
            };
        }

        public static LocalizedText PowerTooltip { get; private set; }

        public LocalizedText AdditionalTooltip => this.GetLocalization(nameof(AdditionalTooltip));

        public override void SetStaticDefaults()
        {
            PowerTooltip = Mod.GetLocalization($"{LocalizationCategory}.{nameof(PowerTooltip)}");
            _ = AdditionalTooltip;
        }
    }
    public class GreatFishingPrefix : ModPrefix
    {
        public virtual float Power => 4f;
        public override PrefixCategory Category => PrefixCategory.Accessory;

        public override float RollChance(Item item)
        {
            return 0.25f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * 2.5f;
        }

        public override void ApplyAccessoryEffects(Player player)
        {
            player.fishingSkill += 4;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            yield return new TooltipLine(Mod, "GreatFishingPrefix", PowerTooltip.Format(Power))
            {
                IsModifier = true, // Sets the color to the positive modifier color.
            };
            yield return new TooltipLine(Mod, "GreatFishingPrefixDescription", AdditionalTooltip.Value)
            {
                IsModifier = true,
            };
        }

        public static LocalizedText PowerTooltip { get; private set; }

        public LocalizedText AdditionalTooltip => this.GetLocalization(nameof(AdditionalTooltip));

        public override void SetStaticDefaults()
        {
            PowerTooltip = Mod.GetLocalization($"{LocalizationCategory}.{nameof(PowerTooltip)}");
            _ = AdditionalTooltip;
        }
    }
}