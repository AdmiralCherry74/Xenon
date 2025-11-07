using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Traps.Contact
{
    public class FrozenLava : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FrozenLava>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 2);
            recipe.AddCondition(Condition.NearLava);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}