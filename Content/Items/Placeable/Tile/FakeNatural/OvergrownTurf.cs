using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.FakeNatural
{
    public class OvergrownTurf : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Xenon.Content.Tiles.NaturalTile.FakeNatural.OvergrownTurf>());
        }
    
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Xenon.Content.Items.Placeable.Tile.Artificial.CoarseDirt>(), 1);
            recipe.AddIngredient(ItemID.GrassSeeds, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}