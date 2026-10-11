using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.SnowAndIce;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Snow
{
    public class FrostedGrassBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<FrostyGrass>());
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<PermafrostDirtIceBlock>());
            recipe1.AddCondition(Condition.InSnow);
            recipe1.AddCondition(Condition.InRain);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<PermafrostDirtBlock>());
            recipe2.AddCondition(Condition.InSnow);
            recipe1.AddCondition(Condition.InRain);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<PermafrostDirtIceBlock>());
            recipe3.AddIngredient(ItemID.GrassSeeds);
            recipe3.AddIngredient(ItemID.SnowBlock);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(ModContent.ItemType<PermafrostDirtBlock>());
            recipe4.AddIngredient(ItemID.GrassSeeds);
            recipe4.AddIngredient(ItemID.SnowBlock);
            recipe4.Register();
        }
    }
}