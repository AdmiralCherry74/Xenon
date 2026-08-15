using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Magic.SplashPotionProj.PositiveEffectsProj;

namespace Xenon.Content.Items.Weapons.Magic.SplashPotions.PositiveEffects;
public class AmmoReservationSplashPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 30;
    }

    public override void SetDefaults()
    {
        Item.width = 24; // Hitbox width of the item.
        Item.height = 24; // Hitbox height of the item.
        Item.scale = 1f;

        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item106;
        Item.useTime = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.noMelee = true;
        Item.noUseGraphic = true;

        Item.damage = 30;
        Item.DamageType = DamageClass.Magic;
        Item.shootSpeed = 6f;
        Item.knockBack = 0.35f;
        Item.crit = -2147483646; //Splash potions wont crit, thats intended
        Item.shoot = ModContent.ProjectileType<AmmoReserveSplashPotionProj>();
        Item.consumable = true;

        Item.value = 1000;
        Item.rare = ItemRarityID.Green;
        Item.stack = 9999;
    }
    public override void AddRecipes()
    {
        CreateRecipe(3)
        .AddIngredient(ItemID.AmmoReservationPotion)
        .AddIngredient(ModContent.ItemType<Flint>())
        .AddTile(TileID.Bottles)
        .Register();

        CreateRecipe(3)
        .AddIngredient(ItemID.DoubleCod)
        .AddIngredient(ItemID.Moonglow)
        .AddIngredient(ItemID.BottledWater)
        .AddIngredient(ModContent.ItemType<Flint>())
        .AddTile(TileID.Bottles)
        .Register();
    }
}