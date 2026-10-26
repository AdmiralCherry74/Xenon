using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Projectiles.Ranged.Ammo.Bullet;

namespace Xenon.Content.Items.Ammo.Gel;

public class GelCanister : ModItem
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

        Item.damage = 2;
        Item.knockBack = 0;
        Item.shootSpeed = 1;

        Item.consumable = true;
        Item.value = Item.sellPrice(0, 0, 0, 3);
        Item.ammo = AmmoID.Gel;
    }

    // TODO: add these to global recipes
    public override void AddRecipes()
    {
        CreateRecipe(25)
            .AddRecipeGroup(RecipeGroupID.IronBar, 1)
            .AddIngredient(ItemID.Gel, 5)
            .AddTile(TileID.Anvils)
            //.SortAfterFirstRecipesOf(ItemID.SilverBullet)
            .Register();
    }
}