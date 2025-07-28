using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Ranged;

public class Hunglock : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 50;
        Item.height = 28;
        Item.damage = 9;
        Item.shootSpeed = 8f;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 4;
        Item.knockBack = 2f;
        Item.reuseDelay = 14;
        Item.consumeAmmoOnLastShotOnly = true;
        Item.shoot = ProjectileID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(gold: 2);
        Item.useAnimation = 12;
        Item.UseSound = SoundID.Item31;
        Item.rare = ItemRarityID.Blue;
        Item.autoReuse = true;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(10f, 2f);
    }
}