using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables.Pouched
{
    public class ExoticGemPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Evil>();
            Item.value = Item.buyPrice(gold: 35);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GemPouch>());
            recipe.AddIngredient(ModContent.ItemType<PremiumGemPouch>());
            recipe.AddIngredient(ModContent.ItemType<Materials.Pouch>());
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}