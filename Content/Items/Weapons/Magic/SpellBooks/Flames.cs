using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Magic.SpellBookProj;
using Xenon.Content.Projectiles.Magic.StaveProj;

namespace Xenon.Content.Items.Weapons.Magic.SpellBooks
{
    public class Flames : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 5;
            Item.knockBack = 0.1f;
            Item.crit = -2;
            Item.mana = 4;
            Item.shoot = ModContent.ProjectileType<FlamesProj>();
            Item.shootSpeed = 10;

            Item.value = Item.sellPrice(silver: 70);
            Item.UseSound = SoundID.Item34;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpellTome)
                .AddIngredient(ModContent.ItemType<Flint>(), 5)
                .AddTile(TileID.Bookcases)
                .SortBeforeFirstRecipesOf(ItemID.CrystalStorm)
                .Register();
        }
        //public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        //{
        //    float numberProjectiles = 5;
        //    for (int i = 0; i < numberProjectiles; i++)
        //    {
        //        Projectile.NewProjectile(position, type, damage, knockback, player.whoAmI);
        //    }
        //}
    }
}