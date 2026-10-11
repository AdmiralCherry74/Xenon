using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;

namespace Xenon.Content.Items.Dyes;

public class PurpleAcidDye : ModItem
{
    public override void SetStaticDefaults()
    {
        if (!Main.dedServ)
        {
            //It will need to be changed when updated to 1.4.5
            GameShaders.Armor.BindShader(ModContent.ItemType<PurpleAcidDye>(), new ArmorShaderData(Main.PixelShaderRef, "ArmorAcid")).UseColor(1f, 0f, 1f);
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
        .AddIngredient(ItemID.Deathweed)
        .AddCondition(Condition.NearWater)
        .Register();
    }
}