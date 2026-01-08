using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.OresBarsGems;
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
        Item.DamageType = DamageClass.Ranged;

        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.knockBack = 1f;
        Item.value = Item.sellPrice(0, 0, 1, 10);
        Item.ammo = ModContent.ItemType<ExampleBolt>();
        Item.shoot = ModContent.ProjectileType<FireBoltProj>();
        Item.shootSpeed = 4.5f;
    }
}