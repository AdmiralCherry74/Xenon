using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Projectiles.Tools.Glowsticks;

namespace Xenon.Content.Items.Tools.Glowsticks
{
    public class ImpactGlowstick : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Glowsticks[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
            Item.shootSpeed = 6f;
            Item.shoot = ModContent.ProjectileType<ImpactGlowstickProj>();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 15;
            Item.useTime = 15;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ItemID.Glowstick, 5)
                .AddIngredient(ModContent.ItemType<WhiteGel>())
                .SortAfterFirstRecipesOf(ItemID.BouncyGlowstick)
                .Register();
        }
        public override void HoldItem(Player player)
        {
            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 1f, 1f, 1f);
        }

        public override void PostUpdate()
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.75f, 0.75f, 0.75f);
        }

    }
}