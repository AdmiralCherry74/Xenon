using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Projectiles.Ranged.Ammo.Bolts;

namespace Xenon.Content.Items.Ammo.Bolts;

public class MetalBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }
    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.damage = 10;
        Item.knockBack = 3f;
        Item.DamageType = DamageClass.Ranged;

        Item.ammo = ModContent.ItemType<ExampleBolt>();
        Item.shoot = ModContent.ProjectileType<MetalBoltProj>();
        Item.shootSpeed = 4;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;

        Item.value = Item.sellPrice(0, 0, 1, 0);
    }
    public override void AddRecipes()
    {
        CreateRecipe(25)
            .AddIngredient(RecipeGroupID.IronBar, 1)
            .AddIngredient(ModContent.ItemType<HardenedWhiteGel>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}