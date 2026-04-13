using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Weapons.Ranged.Bows;

class AluminumBow : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.scale = 1f;
        Item.UseSound = SoundID.Item5;
        Item.useTime = 29;
        Item.useAnimation = 28;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;

        Item.damage = 6;
        Item.DamageType = DamageClass.Ranged;
        Item.knockBack = 0f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 6.7f;
        Item.useAmmo = AmmoID.Arrow;

        Item.value = 360;
    }
}