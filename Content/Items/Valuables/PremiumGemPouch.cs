using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
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
            Item.value = Terraria.Item.buyPrice(gold: 10);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Pouch>());
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Garnet>(), 6);
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Lazuli>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Onyx>(), 1);
            recipe.AddIngredient(ItemID.Amber, 1);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}