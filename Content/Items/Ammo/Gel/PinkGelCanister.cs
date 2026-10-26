using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Projectiles.Ranged.Ammo.Bullet;

namespace Xenon.Content.Items.Ammo.Gel;

public class PinkGelCanister : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 18;

        Item.DamageType = DamageClass.Ranged;
        Item.maxStack = Item.CommonMaxStack;

        Item.damage = 4;
        Item.knockBack = 0.1f;
        Item.shootSpeed = 2;

        Item.consumable = true;
        Item.value = Item.sellPrice(0, 0, 0, 3);
        Item.ammo = AmmoID.Gel;
    }

    // TODO: add these to global recipes
    public override void AddRecipes()
    {
        CreateRecipe(25)
            .AddIngredient(ModContent.ItemType<GelCanister>(), 25)
            .AddRecipeGroup("GoldBar", 5)
            .AddIngredient(ItemID.PinkGel, 1)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<GelCanister>())
            .Register();
    }
}