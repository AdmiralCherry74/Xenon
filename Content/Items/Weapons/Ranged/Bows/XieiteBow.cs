using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Weapons.Ranged.Bows;

class XieiteBow : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.scale = 1f;
        Item.UseSound = SoundID.Item5;
        Item.useTime = 26;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;

        Item.damage = 12;
        Item.DamageType = DamageClass.Ranged;
        Item.knockBack = 0f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 6.6f;
        Item.useAmmo = AmmoID.Arrow;

        Item.value = 360;
    }
}