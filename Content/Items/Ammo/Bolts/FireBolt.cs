using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Ranged.Ammo.Bolts;

namespace Xenon.Content.Items.Ammo.Bolts;

public class FireBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.damage = 12;
        Item.knockBack = 1f;
        Item.DamageType = DamageClass.Ranged;

        Item.ammo = ModContent.ItemType<ExampleBolt>();
        Item.shoot = ModContent.ProjectileType<FireBoltProj>();
        Item.shootSpeed = 4.5f;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;

        Item.value = Item.sellPrice(0, 0, 1, 10);

    }
    public override void AddRecipes()
    {
        CreateRecipe(10)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<MetalBolt>(), 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}