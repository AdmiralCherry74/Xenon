using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Weapons.Ranged.Bows;

class JacarandawoodBow : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 32;
        Item.scale = 1f;
        Item.UseSound = SoundID.Item5;
        Item.useTime = 29;
        Item.useAnimation = 29;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;

        Item.damage = 6;
        Item.DamageType = DamageClass.Ranged;
        Item.knockBack = 0f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 6.6f;
        Item.useAmmo = AmmoID.Arrow;

        Item.value = Item.sellPrice(copper: 20);
    }
}