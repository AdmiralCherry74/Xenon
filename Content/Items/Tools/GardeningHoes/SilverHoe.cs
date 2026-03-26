using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Common.Globals;
namespace Xenon.Content.Items.Tools.GardeningHoes;

public class SilverHoe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.GetGlobalItem<HoePower>().hoePower = 35;
        Item.knockBack = 1f;
        Item.damage = 5;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 11;
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
            .AddIngredient(ItemID.SilverBar, 5)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
