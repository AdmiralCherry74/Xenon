
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Ammo.Gel;
using Xenon.Content.Projectiles.Magic.SpellBookProj;
using Xenon.Content.Projectiles.Ranged.Flames;

namespace Xenon.Content.Items.Weapons.Ranged.Flamethrowers
{
    public class Drizzlethrower : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 20;

            Item.useTime = 10;
            Item.useAnimation = 45;
            
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.consumeAmmoOnFirstShotOnly = true;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 14;
            Item.ArmorPenetration = 5;
            Item.knockBack = 0.5f;
            Item.crit = -2;
            Item.shoot = ProjectileID.Flames;
            Item.shootSpeed = 4.5f;
            Item.noMelee = true;
            Item.value = 20000;
            Item.UseSound = SoundID.Item34;
            Item.rare = ItemRarityID.Green;
            Item.useAmmo = AmmoID.Gel;
    
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
        }

        public override Vector2? HoldoutOffset() => new Vector2(5f, -2f);

        // TODO: add these to global recipes
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FlintlockPistol)
            .AddIngredient(ModContent.ItemType<GelCanister>(), 50)
            .AddRecipeGroup(RecipeGroupID.IronBar, 12)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Drizzlethrower>())
            .Register();
        }
    }
}