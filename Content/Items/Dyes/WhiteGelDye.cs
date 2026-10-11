using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;

namespace Xenon.Content.Items.Dyes;

public class WhiteGelDye : ModItem
{
    public override void SetStaticDefaults()
    {
        if (!Main.dedServ)
        {
            GameShaders.Armor.BindShader(ModContent.ItemType<WhiteGelDye>(), new ArmorShaderData(Main.PixelShaderRef, "ArmorGel")).UseColor(0.20f, 0.20f, 0.20f);
        }

        Item.ResearchUnlockCount = 3;
    }

    public override void SetDefaults()
    {
        int dye = Item.dye;

        Item.CloneDefaults(ItemID.GelDye);

        Item.dye = dye;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.GelDye)
        .AddIngredient(ModContent.ItemType<WhiteGel>(), 10)
        .AddTile(TileID.DyeVat)
        .Register();
    }
}