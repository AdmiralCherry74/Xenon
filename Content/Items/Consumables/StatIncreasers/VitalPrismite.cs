using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Consumables.StatIncreasers
{
    public class VitalPrismite : ModItem
    {
        public static readonly int MaxVitalPrismite = 10;
        public static readonly int LifePerVP = 10;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(LifePerVP, MaxVitalPrismite);

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = ItemRarityID.Pink;
        }

        public override bool CanUseItem(Player player)
        {
            // This check prevents this item from being used before vanilla health upgrades are maxed out.
            return player.ConsumedLifeCrystals == Player.LifeCrystalMax;
        }

        public override bool? UseItem(Player player)
        {
            // Moving the exampleLifeFruits check from CanUseItem to here allows this example fruit to still "be used" like Life Fruit can be
            // when at the max allowed, but it will just play the animation and not affect the player's max life
            if (player.GetModPlayer<XenonStatIncrease>().VitalPrismiteUses >= MaxVitalPrismite)
            {
                // Returning null will make the item not be consumed
                return null;
            }

            // This method handles permanently increasing the player's max health and displaying the green heal text
            player.UseHealthMaxIncreasingItem(LifePerVP);

            // This field tracks how many of the example fruit have been consumed
            player.GetModPlayer<XenonStatIncrease>().VitalPrismiteUses++;

            return true;
        }
    }
}