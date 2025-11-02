using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
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
            Item.value = Terraria.Item.buyPrice(gold: 35);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Valuables.GemPouch>());
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Valuables.PremiumGemPouch>());
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Pouch>());
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}