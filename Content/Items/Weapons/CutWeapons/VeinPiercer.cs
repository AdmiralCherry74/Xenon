using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.CutWeapons;

class VeinPiercer : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.UseSound = SoundID.Item5;
        Item.damage = 17;
        Item.scale = 1f;
        Item.shootSpeed = 5.8f;
        Item.useAmmo = AmmoID.Arrow;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 24;
        Item.knockBack = 0.1f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 9000;
        Item.useAnimation = 24;
        Item.rare = 3;
    }
    public override void AddRecipes()
    {
        Recipe Ti = CreateRecipe();
        Ti.AddIngredient(ItemID.TendonBow, 2);
        Ti.AddIngredient(ItemID.PlatinumBow, 1);
        Ti.AddIngredient(ItemID.CrimtaneBar, 3);
        Ti.AddIngredient(ItemID.HellstoneBar, 2);
        Ti.AddIngredient(ItemID.Bone, 3);
        Ti.AddIngredient(ItemID.TissueSample, 20);
        Ti.AddTile(TileID.DemonAltar);
        Ti.Register();
    }
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        if (type == ProjectileID.WoodenArrowFriendly)
        {
            type = ProjectileID.IchorArrow;
        }
    }
}