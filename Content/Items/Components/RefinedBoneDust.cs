using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Components
{
    public class RefinedBoneDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = 3;
            Item.value = Item.buyPrice(silver: 10);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Pouch>());
            recipe.AddIngredient(ItemID.PurificationPowder);
            recipe.AddIngredient(ModContent.ItemType<CursedBoneDust>(), 5);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}