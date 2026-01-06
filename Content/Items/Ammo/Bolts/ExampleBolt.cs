using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Projectiles.Ammo.Bolts;

namespace Xenon.Content.Items.Ammo.Bolts;

public class ExampleBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 9999;
        //Selene here. This was adapted from Example mods custom ammo gun. i kept some of the comments so I can remember what is doing what.
        //Every Bolt will use this Example Bolt as a way to have crossbow's use any type of bolt. Like Fire bolts
        //Item.shoot is commented out just in case
        //remove comments when making a proper bolt!
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 22;

        Item.damage = 10; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the item together
        Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?

        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
        Item.knockBack = 3f;
        Item.value = Item.sellPrice(0, 0, 0, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
        Item.ammo = Item.type; // Important. The first item in an ammo class sets the AmmoID to its type
        //Item.ammo = ModContent.ItemType<Bolt>(); This is commented out so I dont have to type the code every time
        //Item.shoot = ModContent.ProjectileType<InsertProjectile>(); // The projectile that weapons fire when using this item as ammunition.
        //Item.shootSpeed = 4;
    }
}