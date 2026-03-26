using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Ranged.Ammo.Bolts;


namespace Xenon.Content.Items.Ammo.Bolts;

public class UnholyBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.damage = 17;
        Item.knockBack = 1f;
        Item.DamageType = DamageClass.Ranged;

        Item.ammo = ModContent.ItemType<ExampleBolt>();
        Item.shoot = ModContent.ProjectileType<UnholyBoltProj>();
        Item.shootSpeed = 4.4f;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;

        Item.value = Item.sellPrice(0, 0, 1, 75);

    }
    public override void AddRecipes()
    {
        CreateRecipe(20)
            .AddIngredient(ItemID.WormTooth, 1)
            .AddIngredient(ModContent.ItemType<MetalBolt>(), 20)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}