using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Projectiles.Ranged.Ammo.Bullet;

namespace Xenon.Content.Items.Ammo.Bullet;

public class IndiumBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 12;

        Item.DamageType = DamageClass.Ranged;
        Item.shoot = ModContent.ProjectileType<IndiumBulletProj>();
        Item.shootSpeed = 4.5f;

        Item.maxStack = Item.CommonMaxStack;
        Item.damage = 9;
        Item.knockBack = 3.5f;
        Item.consumable = true;

        Item.value = Item.sellPrice(0, 0, 0, 3);
        Item.ammo = AmmoID.Bullet;
    }
    public override void AddRecipes()
    {
        CreateRecipe(70)
            .AddIngredient(ItemID.MusketBall, 70)
            .AddIngredient(ModContent.ItemType<IndiumBar>())
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.SilverBullet)
            .Register();
    }
}