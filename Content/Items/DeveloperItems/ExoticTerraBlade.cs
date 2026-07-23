using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Sword;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.DeveloperItems;

public class ExoticTerraBlade : ModItem
//test weapon and shit. this is meant to be broken and unobtainable
{
    private int fireDelay = 5;
    public override void SetDefaults()
    {
        Item.width = 58;
        Item.height = 64;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 1000000;
        Item.knockBack = 0f;
        Item.crit = 100;
        Item.shoot = ModContent.ProjectileType<ExoticTerraBeam>();
        Item.shootSpeed = 16;

        Item.value = Item.buyPrice(gold: 20);
        Item.UseSound = SoundID.Item1;
        Item.rare = ModContent.RarityType<Xenonic>();
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float numberProjectiles = 9; // 3, 4, or 5 shots
        float rotation = MathHelper.ToRadians(45);

        position += Vector2.Normalize(velocity) * 45f;
        velocity *= 1f; // Slow the projectile down to 1/5th speed so we can see it. This is only here because this example shares ModItem.SetDefaults code with other examples. If you are making your own weapon just change Item.shootSpeed as normal.

        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))); // Watch out for dividing by 0 if there is only 1 projectile.
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
        }

        return false; // return false to stop vanilla from calling Projectile.NewProjectile.
    }
}