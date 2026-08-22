using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Dusts.WaterSplashes;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Melee.Sword;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class BowelBlade : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 22;
        Item.useAnimation = 22;
        Item.useTurn = true;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.shoot = ModContent.ProjectileType<BileProjTest>();
        Item.shootsEveryUse = true;
        Item.shootSpeed = 10;
        Item.damage = 19;
        Item.knockBack = 5;
        Item.crit = 0;

        Item.value = Item.sellPrice(silver: 27);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        SoundEngine.PlaySound(SoundID.NPCDeath13, player.Center);
        float numberProjectiles = Main.rand.Next(2, 5); //Random Amounts Of Bile
        float rotation = MathHelper.ToRadians(15);

        position += Vector2.Normalize(velocity) * 10f;

        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))); // Watch out for dividing by 0 if there is only 1 projectile.
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage / 2, knockback, player.whoAmI);
        }

        return false; // return false to stop vanilla from calling Projectile.NewProjectile.
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (player.itemAnimation % 2 == 0)
        {
            SpecialUtilities.GetPointOnSwungItemPath(60f, 60f, 0.4f + 0.4f * Main.rand.NextFloat(), Item.scale, out var location2, out var outwardDirection2, player);
            Vector2 vector2 = outwardDirection2.RotatedBy((float)Math.PI / 2f * player.direction * player.gravDir);
            int DustType = ModContent.DustType<CorrosionDust>();
            if (Main.rand.NextBool(3))
                DustType = ModContent.DustType<CorrosionWaterSplash>();

            int num15 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType, player.velocity.X * 0.2f + player.direction * 3, player.velocity.Y * 0.2f, 140, default, 0.7f);
            Main.dust[num15].position = location2;
            Main.dust[num15].fadeIn = 1.2f;
            Main.dust[num15].noGravity = true;
            Main.dust[num15].velocity *= 0.25f;
            Main.dust[num15].velocity += vector2 * 5f;
            Main.dust[num15].velocity.Y *= 0.3f;
        }
    }
}