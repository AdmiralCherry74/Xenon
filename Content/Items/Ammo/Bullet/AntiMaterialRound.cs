using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Ammo.Bullet;

public class AntiMaterialRound : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.DamageType = DamageClass.Ranged;

        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.knockBack = 3f;

        Item.value = Item.sellPrice(0, 0, 0, 0);
        Item.ammo = Item.type;
    }
}