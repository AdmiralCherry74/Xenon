using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials.WorldInfectionMaterials;

public class BoomerBile : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 0, 8, 50);
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Orange;
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.42f, 0.59f, 0.095f);
    }
}