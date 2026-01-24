using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Ammo.Bullet;
using Xenon.Content.Projectiles.Ranged.Ammo.Bullet;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Ranged.Arms
{
    public class DSR : ModItem
    {
        public override void SetDefaults()
        {
            //Thank you Zerona for the sprite!
            //Thank you Guardiangames for the code! I modified it a little
            Item.width = 2;
            Item.height = 120;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ModContent.RarityType<Xenonic>();
            Item.UseSound = SoundID.Item41;
            Item.value = Item.sellPrice(gold: 75);

            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.damage = 312;
            Item.knockBack = 15;
            Item.crit = 0;
            Item.useAmmo = ModContent.ItemType<AntiMaterialRound>();
            Item.shoot = ModContent.ProjectileType<AntiMaterialRoundProj>();
            Item.shootSpeed = 50;

            Item.autoReuse = false;
            Item.useTime = 65;
            Item.useAnimation = 65;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Make Bullets come out of muzzle
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -1);
        }
    }
}

//public override void AddRecipes()
//{
//    CreateRecipe()
//        .AddIngredient(ModContent.ItemType<DSRBody>())
//        .AddIngredient(ModContent.ItemType<DSRBarrel>())
//        .AddIngredient(ModContent.ItemType<DSRScope>())
//        .AddIngredient(ModContent.ItemType<DSRMag>())
//        .AddIngredient(ModContent.ItemType<DSRStock>())
//        .AddIngredient(ModContent.ItemType<DSRMuzzle>())
//        .AddIngredient(ItemID.LunarBar, 5)
//        .AddIngredient(ItemID.SoulofMight, 20)
//        .AddIngredient(ItemID.SoulofSight, 20)
//        .AddTile(TileID.LihzahrdFurnace)
//        .Register();
//