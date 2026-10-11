using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;

namespace Xenon.Content.Items.Dyes;

public class YellowAcidDye : ModItem
{
    //Thank You Example Mod - Selene
    public override void SetStaticDefaults()
    {
        // Avoid loading assets on dedicated servers. They don't use graphics cards.
        if (!Main.dedServ)
        {
            //I got this from "https://forums.terraria.org/index.php?threads/help-with-creating-modded-dyes.85080/"
            //It will need to be changed when updated to 1.4.5
            GameShaders.Armor.BindShader(ModContent.ItemType<YellowAcidDye>(), new ArmorShaderData(Main.PixelShaderRef, "ArmorAcid")).UseColor(1f, 1f, 0f);
        }

        Item.ResearchUnlockCount = 3;
    }

    public override void SetDefaults()
    {
        // Item.dye will already be assigned to this item prior to SetDefaults because of the above GameShaders.Armor.BindShader code in Load().
        // This code here remembers Item.dye so that information isn't lost during CloneDefaults.
        int dye = Item.dye;

        Item.CloneDefaults(ItemID.AcidDye); // Makes the item copy the attributes of the item "Gel Dye" Change "GelDye" to whatever dye type you want.

        Item.dye = dye;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.BottledWater)
        .AddIngredient(ModContent.ItemType<Liverwort>())
        .AddCondition(Condition.NearWater)
        .Register();
    }
}