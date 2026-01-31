using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Sinking;
using Xenon.Content.Tiles.ActiveAndWiring;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Firing
{
    public class SandballTrapItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SandballTrap>());
            Item.mech = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<QuicksandBlock>(), 5);
            recipe.AddIngredient(ItemID.DartTrap, 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
    }
}