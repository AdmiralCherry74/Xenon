using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
{
    public class GemPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Terraria.Item.buyPrice(gold: 15);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Materials.Pouch>());
            recipe.AddIngredient(ItemID.Amethyst, 6);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddIngredient(ItemID.Emerald, 3);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}