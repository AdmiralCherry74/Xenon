using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Ranged.Bows;

class SulfirBow : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.UseSound = SoundID.Item5;
        Item.damage = 17;
        Item.scale = 1f;
        Item.shootSpeed = 6.7f;
        Item.useAmmo = AmmoID.Arrow;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.useTime = 27;
        Item.knockBack = 1f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 360;
        Item.useAnimation = 27;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .Register();
    }
}