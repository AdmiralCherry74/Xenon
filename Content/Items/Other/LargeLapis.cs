using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Other
{
    public class LargeLapis : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 26, 75);
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D itemTexture = Item.ModItem.GetTexture().Value;
            float num5 = Item.height - itemTexture.Height;
            float num6 = Item.width / 2 - itemTexture.Width / 2;

            Main.spriteBatch.Draw(itemTexture, new Vector2(Item.position.X - Main.screenPosition.X + itemTexture.Width / 2 + num6, Item.position.Y - Main.screenPosition.Y + itemTexture.Height / 2 + num5 + 2f), new Rectangle(0, 0, itemTexture.Width, itemTexture.Height), new Color(250, 250, 250, Main.mouseTextColor / 2), rotation, new Vector2(itemTexture.Width / 2, itemTexture.Height / 2), Main.mouseTextColor / 1000f + 0.8f, SpriteEffects.None, 0f);
        }
    }
}