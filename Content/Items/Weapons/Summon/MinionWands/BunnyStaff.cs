using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Minions;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Projectiles.Summoner.Minions;

namespace Xenon.Content.Items.Weapons.Summon.MinionWands
{
    public class BunnyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true; // This lets the player target anywhere on the whole screen while using a controller
            ItemID.Sets.LockOnIgnoresCollision[Type] = true;

            ItemID.Sets.StaffMinionSlotsRequired[Type] = 1f; // The default value is 1, but other values are supported. See the docs for more guidance.
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.damage = 8;
            Item.knockBack = 3f;
            Item.mana = 9;

            Item.value = Item.sellPrice(silver: 50);
            Item.UseSound = SoundID.Item44;
            Item.rare = ItemRarityID.White;

            // These below are needed for a minion weapon
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.shoot = ModContent.ProjectileType<BunnyMinionCopperProj>();
            Item.buffType = ModContent.BuffType<BunnyMinionBuff>();
            // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position, limited by the gameplay range
            position = Main.MouseWorld;
            player.LimitPointToPlayerReachableArea(ref position);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            if (Main.rand.NextBool(3))
            {
                Item.shoot = ModContent.ProjectileType<BunnyMinionTinProj>();
            }
            else if (Main.rand.NextBool(2))
            {
                Item.shoot = ModContent.ProjectileType<BunnyMinionAluminumProj>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<BunnyMinionCopperProj>();
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddIngredient(ItemID.Mushroom, 4)
                .AddIngredient(ItemID.CopperBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddIngredient(ItemID.Mushroom, 4)
                .AddIngredient(ItemID.TinBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddIngredient(ItemID.Mushroom, 4)
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}