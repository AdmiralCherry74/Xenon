using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.GlugGlugs
{
    // This item showcases some advanced capabilities of healing potions. It heals a dynamic amount and adjusts its tooltip accordingly.
    // A typical healing potion can get rid of the ModifyTooltips and GetHealLife methods and just assign Item.healLife.
    // A mana potion is exactly the same, except Item.healMana is used instead. (Also GetHealMana would be used for dynamic mana recovery values)
    public class PainPills : ModItem
    {
        public static LocalizedText RestoreLifeText { get; private set; }

        public override void SetStaticDefaults()
        {
            RestoreLifeText = this.GetLocalization(nameof(RestoreLifeText));

            Item.ResearchUnlockCount = 30;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 1);

            Item.healLife = 50; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
            Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            Item.buffType = ModContent.BuffType<Effects.Debuffs.TemporaryHealthPills>();
            Item.buffTime = 3000;
        }
    }
}