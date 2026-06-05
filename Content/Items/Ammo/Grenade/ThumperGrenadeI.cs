using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Ranged.Ammo.Grenade;

namespace Xenon.Content.Items.Ammo.Grenade;

public class ThumperGrenadeI : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.damage = 40;
        Item.DamageType = DamageClass.Ranged;

        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.knockBack = 10f;
        Item.value = Item.sellPrice(0, 0, 0, 0);
        Item.ammo = ItemID.Grenade;
        Item.shoot = ModContent.ProjectileType<ThumperGrenadeIProj>();
        Item.shootSpeed = 1;
    }
}