using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Valuables
{
    public class UnstablePowder : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.rare = ModContent.RarityType<Purity>();
            Item.value = Terraria.Item.buyPrice(platinum: 1);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.Components.Pouch>());
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddIngredient(ItemID.ViciousMushroom);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}