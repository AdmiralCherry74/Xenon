using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting
{
    public class HeliumMossparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ActiveAndWiring.Lighting.HeliumMossparkBlock>());
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[Item.type].Value, position, frame, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 iPos = Item.position - Main.screenPosition;
            spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[Item.type].Value, Item.position - Main.screenPosition, null, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RainbowMoss);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}