using Avalon.Items.Material.Bars;
using Avalon.Items.Tools.PreHardmode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;

namespace Xenon.ModSupport.Avalon.Content.Items.Tools.GardeningHoes;

[ExtendsFromMod("Avalon")]
public class ZincHoe : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.GetGlobalItem<HoePower>().hoePower = 49;
        Item.knockBack = 1f;
        Item.damage = 6;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 19;
        Item.useAnimation = 20;
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
            .AddIngredient(ModContent.ItemType<ZincBar>(), 5)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
