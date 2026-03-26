using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.GardeningHoes;

public class AluminumHoe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.useTime = 15;
        Item.useAnimation = 21;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.GetGlobalItem<HoePower>().hoePower = 35;
        Item.knockBack = 2f;
        Item.damage = 4;
        Item.DamageType = DamageClass.Melee;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<AluminumBar>(), 4)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
