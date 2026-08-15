using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Projectiles.Ranged.Ammo.Bolts;

namespace Xenon.Content.Items.Weapons.Ranged.Crossbows;

class SilverCrossbow : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.scale = 1f;
        Item.UseSound = SoundID.Item5;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Ranged;
        Item.damage = 13;
        Item.knockBack = 0.25f;
        Item.crit = 0;
        Item.noMelee = true;
        Item.shootSpeed = 8.1f;
        Item.shoot = AmmoID.Arrow;
        Item.useAmmo = AmmoID.Arrow;

        Item.value = 360;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-0.25f, 1f);
    }
}