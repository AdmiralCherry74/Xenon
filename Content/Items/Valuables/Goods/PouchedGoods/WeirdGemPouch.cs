using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables.Goods.PouchedGoods
{
    public class WeirdGemPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Item.buyPrice(silver: 250);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.Pouch>());
            recipe.AddIngredient(ModContent.ItemType<Flint>(), 4);
            recipe.AddIngredient(ItemID.Amber, 4);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
        }
    }
}