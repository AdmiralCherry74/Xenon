using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.OresBarsGems;
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
        Item.DamageType = DamageClass.Ranged;

        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.knockBack = 3f;
        Item.value = Item.sellPrice(0, 0, 1, 0);
        Item.ammo = ModContent.ItemType<ExampleBolt>();
        Item.shoot = ModContent.ProjectileType<MetalBoltProj>();
        Item.shootSpeed = 4;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.ObsidianShield)
            //.AddIngredient(ModContent.ItemType<FireWired:3>)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}