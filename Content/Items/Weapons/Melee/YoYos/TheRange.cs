using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.YoYo;

namespace Xenon.Content.Items.Weapons.Melee.YoYos;

public class TheRange : ModItem
{
    public override void SetStaticDefaults()
    {
        // These are all related to gamepad controls and don't seem to affect anything else
        ItemID.Sets.Yoyo[Item.type] = true; // Used to increase the gamepad range when using Strings.
        ItemID.Sets.GamepadExtraRange[Item.type] = 10; // Increases the gamepad range. Some vanilla values: 4 (Wood), 10 (Valor), 13 (Yelets), 18 (The Eye of Cthulhu), 21 (Terrarian).
        ItemID.Sets.GamepadSmartQuickReach[Item.type] = true; // Unused, but weapons that require aiming on the screen are in this set.
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = SoundID.Item1;

        Item.damage = 21;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.knockBack = 3.80f;
        Item.crit = 0;
        Item.channel = true;
        Item.rare = ItemRarityID.Orange;
        Item.value = Item.sellPrice(silver: 20);

        Item.shoot = ModContent.ProjectileType<RangeYoYoProj>();
        Item.shootSpeed = 16f;
    }
}