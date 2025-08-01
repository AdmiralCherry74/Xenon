using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Accessories
{
    public class LaserSight : ModItem
    {
        // By declaring these here, changing the values will alter the effect, and the tooltip
        public static readonly int GunCritBonus = 100;

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GunCritBonus);

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            // GetCrit, similarly to GetDamage, returns a reference to the specified damage class' crit chance.
            // In this case, we're adding 10% crit chance, but only for the melee DamageClass (as such, only melee weapons will receive this bonus).
            // NOTE: Once all crit calculations are complete, a weapon or class' total crit chance is typically cast to an int. Plan accordingly.
            player.GetCritChance(DamageClass.Ranged) += GunCritBonus / 10;
        }
    }
}