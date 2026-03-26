using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.GardeningHoes;

public class IndiumHoe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.useTime = 20;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.GetGlobalItem<HoePower>().hoePower = 48;
        Item.knockBack = 2f;
        Item.damage = 6;
        Item.DamageType = DamageClass.Melee;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<IndiumBar>(), 5)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
