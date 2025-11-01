using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles;

namespace Xenon.Content.Items.Weapons.Summon.Caltrops;

public class LeadCaltrops : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 26;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.noUseGraphic = true;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Summon;
        Item.damage = 2;
        Item.knockBack = 0.25f;
        Item.crit = -4;
        Item.consumable = true;
        Item.maxStack = 50;
        Item.shoot = ModContent.ProjectileType<LeadCaltropsProj>();
        Item.shootSpeed = 8f;

        Item.value = Item.sellPrice(silver: 27);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.White;

    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float numberProjectiles = 5;
        float rotation = MathHelper.ToRadians(45);

        position += Vector2.Normalize(velocity) * 5f;

        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.5f; // Watch out for dividing by 0 if there is only 1 projectile.
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
        }

        return false;
    }
    public override void AddRecipes()
    {
        CreateRecipe(5)
            .AddIngredient(ItemID.LeadBar, 1)
            .AddTile(TileID.Anvils)
            .Register();
    }
}