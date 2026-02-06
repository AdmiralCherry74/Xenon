using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Ranged.Bows;

class IodineGreatbow : ModItem
{
    //The Iodine Greatbow is an upcoming bow for Insane mode. Iodine is planned to be the tier two ore. with this being the bow. not sure how ill make it unique though
    //Jona made the sprites for the Iodine Greatsword, Greatbow, and Bar. and since they were unused, he offered them and I took it. Thanks Jona!
    //Will not be introduced offically right now
    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 30;
        Item.UseSound = SoundID.Item5;
        Item.damage = 157;
        Item.scale = 2f;
        Item.shootSpeed = 6.7f;
        Item.useAmmo = AmmoID.Arrow;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 40;
        Item.knockBack = 4f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 3600;
        Item.useAnimation = 40;
        Item.rare = ItemRarityID.Master;
    }
}

//public override void AddRecipes()
//CreateRecipe()
//    .AddIngredient(ModContent.ItemType<IodineBar>(), 20)
//    .AddTile(TileID.Anvils)
//    .Register();