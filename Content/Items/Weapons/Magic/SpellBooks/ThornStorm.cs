using System;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Magic.SpellBookProj;
using Xenon.Content.Projectiles.Magic.StaveProj;

namespace Xenon.Content.Items.Weapons.Magic.SpellBooks
{
    public class ThornStorm : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 32;

            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 9;
            Item.knockBack = 3f;
            Item.crit = 0;
            Item.mana = 10;
            Item.shoot = ModContent.ProjectileType<ThornStormProj>();
            Item.shootSpeed = 20;

            Item.value = Item.sellPrice(gold: 1);
            Item.UseSound = SoundID.Item17;
            Item.rare = ItemRarityID.Orange;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 NewVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                NewVelocity *= 1f - Main.rand.NextFloat(0.2f);

                Projectile.NewProjectileDirect(
                    source,
                    position,
                    NewVelocity,
                    type,
                    damage,
                    knockback,
                    player.whoAmI
                    );
            }

            return false; // return false to stop vanilla from calling Projectile.NewProjectile.
        }
    }
}