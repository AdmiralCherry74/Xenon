using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.MiningPickaxes;

public class AluminumdPickaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.pick = 35;
        Item.knockBack = 2f;
        Item.damage = 4;
        Item.useTime = 22;
        Item.useAnimation = 18;
        Item.width = 34;
        Item.height = 34;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<AluminumBar>(), 8)
            .AddIngredient(ItemID.Wood, 4)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
