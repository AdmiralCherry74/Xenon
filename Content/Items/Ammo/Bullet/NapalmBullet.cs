using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Projectiles.Ranged.Ammo.Bullet;

namespace Xenon.Content.Items.Ammo.Bullet;

public class NapalmBullet : ModItem
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
        Item.shoot = ModContent.ProjectileType<NapalmBulletProj>();
        Item.shootSpeed = 4.5f;

        Item.maxStack = Item.CommonMaxStack;
        Item.damage = 6;
        Item.knockBack = 2.75f;
        Item.consumable = true;

        Item.value = Item.sellPrice(0, 0, 0, 5);
        Item.ammo = AmmoID.Bullet;
    }
    public override void AddRecipes()
    {
        CreateRecipe(50)
            .AddIngredient(ItemID.MusketBall, 50)
            .AddIngredient(ModContent.ItemType<Flint>(), 5)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.MeteorShot)
            .Register();
    }
}