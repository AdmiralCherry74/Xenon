using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables.Pouched
{
    public class PremiumGemPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Item.buyPrice(gold: 10);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.Pouch>());
            recipe.AddIngredient(ModContent.ItemType<Materials.Garnet>(), 6);
            recipe.AddIngredient(ModContent.ItemType<Materials.Lapis>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Materials.Onyx>(), 1);
            recipe.AddIngredient(ItemID.Amber, 1);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}