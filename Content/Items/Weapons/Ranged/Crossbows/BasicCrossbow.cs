using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Projectiles.Ranged.Ammo.Bolts;

namespace Xenon.Content.Items.Weapons.Ranged.Crossbows;

class BasicCrossbow : ModItem
{
    public override void SetDefaults()
    {
        //The Basic Crossbow is the Crossbow that every other Crossbow will be adapted from. This may or may not be a dev item on official release of Xenon

        Item.width = 18;
        Item.height = 40;
        Item.scale = 1f;
        Item.UseSound = SoundID.Item5;

        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Ranged;
        Item.damage = 22;
        Item.knockBack = 1f;
        Item.crit = 0;
        Item.noMelee = true;
        Item.shootSpeed = 17f;
        Item.shoot = AmmoID.Arrow;
        Item.useAmmo = AmmoID.Arrow;

        Item.value = 360;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-0.25f, 1f);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddIngredient(ItemID.ShadowScale)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddIngredient(ItemID.TissueSample)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddIngredient(ModContent.ItemType<FreshChyme>())
            .AddTile(TileID.Anvils)
            .Register();
    }
}