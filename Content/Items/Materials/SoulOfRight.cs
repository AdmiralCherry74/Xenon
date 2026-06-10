using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class SoulOfRight : ModItem
{
    public override void SetStaticDefaults()
    {
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemIconPulse[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.value = Item.buyPrice(silver: 1);
        Item.rare = ItemRarityID.Orange;
        Item.maxStack = 9999;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(124, 228, 112, 100);
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
        num7 *= Main.essScale;
        Lighting.AddLight((int)((Item.position.X + (float)(Item.width / 2)) / 16f), (int)((Item.position.Y + (float)(Item.height / 2)) / 16f), 0.15f * num7, 0.26f * num7, 0.095f * num7);
    }
}