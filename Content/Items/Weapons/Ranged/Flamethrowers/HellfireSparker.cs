
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Magic.SpellBookProj;

namespace Xenon.Content.Items.Weapons.Ranged.Flamethrowers
{
    public class HellfireSparker : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 16;

            Item.useTime = 8;
            Item.useAnimation = 30;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumeAmmoOnFirstShotOnly = true;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 20;
            Item.ArmorPenetration = 7;
            Item.knockBack = 0.3f;
            Item.shoot = ProjectileID.Flames;
            Item.shootSpeed = 5.5f;
            Item.noMelee = true;
            Item.value = 20000;
            Item.UseSound = SoundID.Item34;
            Item.rare = ItemRarityID.Green;
            Item.useAmmo = AmmoID.Gel;
    
        }

        public override Vector2? HoldoutOffset() => new Vector2(5f, 0f);

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}

        }

        // TODO: add these to global recipes
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HellstoneBar, 10)
            .AddIngredient(ItemID.IllegalGunParts)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}