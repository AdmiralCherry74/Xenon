using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Accessories
{
    public class LaserSight : ModItem
    {
        // By declaring these here, changing the values will alter the effect, and the tooltip
        public static readonly int GunArmorPenetration = 1;
        public static readonly int GunCritDamageBonus = 80;

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GunCritDamageBonus, GunArmorPenetration);

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<Indigo>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            // GetCrit, similarly to GetDamage, returns a reference to the specified damage class' crit chance.
            // In this case, we're adding 10% crit chance, but only for the melee DamageClass (as such, only melee weapons will receive this bonus).
            // NOTE: Once all crit calculations are complete, a weapon or class' total crit chance is typically cast to an int. Plan accordingly.
            player.GetCritChance(DamageClass.Ranged) += GunCritDamageBonus / 10;

            // GetAttackSpeed is functionally identical to GetDamage and GetKnockback; it's for attack speed.
            // In this case, we'll make ranged weapons 15% faster to use overall.
            // NOTE: Zero or a negative value as the result of these calculations will throw an exception. Plan accordingly.
            player.GetArmorPenetration(DamageClass.Ranged) += GunArmorPenetration / 10f;
        }
    }
}