using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Consumables.GlugGlugs;
public class DeathforcePotion : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 30;

        // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
        ItemID.Sets.DrinkParticleColors[Type] = [
            new Color(0, 65, 0),
            ];
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 30;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 2);
        Item.buffType = ModContent.BuffType<Deathforce>();
        Item.buffTime = 28800;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddRecipeGroup("Ebonkoi", 1)
        .AddIngredient(ItemID.Moonglow)
        .AddIngredient(ItemID.Shiverthorn)
        .AddIngredient(ItemID.Waterleaf)
        .AddIngredient(ItemID.BottledWater)
        .AddTile(TileID.Bottles)
        .Register();
    }
}