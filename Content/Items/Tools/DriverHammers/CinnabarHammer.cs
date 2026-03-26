using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Tools.DriverHammers;

public class CinnabarHammer : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.hammer = 42;
        Item.knockBack = 5.5f;
        Item.damage = 8;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 20;
        Item.useAnimation = 28;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 36);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
