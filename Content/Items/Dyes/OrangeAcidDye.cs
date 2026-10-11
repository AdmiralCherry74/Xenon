using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;

namespace Xenon.Content.Items.Dyes;

public class OrangeAcidDye : ModItem
{
    public override void SetStaticDefaults()
    {
        if (!Main.dedServ)
        {
            GameShaders.Armor.BindShader(ModContent.ItemType<OrangeAcidDye>(), new ArmorShaderData(Main.PixelShaderRef, "ArmorAcid")).UseColor(1f, 0.5f, 0f);
        }

        Item.ResearchUnlockCount = 3;
    }

    public override void SetDefaults()
    {
        int dye = Item.dye;

        Item.CloneDefaults(ItemID.AcidDye);

        Item.dye = dye;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.BottledWater)
        .AddIngredient(ItemID.Daybloom)
        .AddCondition(Condition.NearWater)
        .Register();
    }
}