using Avalon.Items.Material.Bars;
using Avalon.Items.Tools.PreHardmode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;
namespace Xenon.ModSupport.Avalon.Content.Items.Tools.GardeningHoes;

[ExtendsFromMod("Avalon")]
public class BismuthHoe : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.GetGlobalItem<HoePower>().hoePower = 59;
        Item.knockBack = 1f;
        Item.damage = 8;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 15;
        Item.useAnimation = 18;
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
            .AddIngredient(ModContent.ItemType<BismuthBar>(), 5)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<BismuthHammer>())
            .Register();
    }
}
