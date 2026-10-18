using Avalon.Items.Material.Ores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.ModSupport.Avalon
{
    [ExtendsFromMod("Avalon")]
    public class AvalonRecipeChanges : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return XenonMod.AvalonContentEnabled;
        }

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                //IDGAF about sorting these properly. take what you get. Avalon doesnt sort these anyway, i just need these sorted differently
                //closest thing to sort is just... here?

                Recipe CopperOreNewCraft = Main.recipe[i];
                if (CopperOreNewCraft.HasIngredient(ModContent.ItemType<BronzeOre>()) && (CopperOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>()) && CopperOreNewCraft.HasResult(ItemID.CopperOre)))
                {
                    CopperOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe TinOreNewCraft = Main.recipe[i];
                if (TinOreNewCraft.HasIngredient(ItemID.CopperOre) && (TinOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && TinOreNewCraft.HasResult(ItemID.TinOre))
                {
                    TinOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe BronzeOreNewCraft = Main.recipe[i];
                if (BronzeOreNewCraft.HasIngredient(ItemID.TinOre) && (TinOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && TinOreNewCraft.HasResult(ModContent.ItemType<BronzeOre>()))
                {
                    BronzeOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe IronOreNewCraft = Main.recipe[i];
                if (IronOreNewCraft.HasIngredient(ModContent.ItemType<NickelOre>()) && (IronOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && IronOreNewCraft.HasResult(ItemID.IronOre))
                {
                    IronOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe LeadOreNewCraft = Main.recipe[i];
                if (LeadOreNewCraft.HasIngredient(ItemID.IronOre) && (LeadOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && LeadOreNewCraft.HasResult(ItemID.LeadOre))
                {
                    LeadOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe NickelOreNewCraft = Main.recipe[i];
                if (NickelOreNewCraft.HasIngredient(ItemID.LeadOre) && (NickelOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && NickelOreNewCraft.HasResult(ModContent.ItemType<NickelOre>()))
                {
                    NickelOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe SilverOreNewCraft = Main.recipe[i];
                if (SilverOreNewCraft.HasIngredient(ModContent.ItemType<ZincOre>()) && (SilverOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && SilverOreNewCraft.HasResult(ItemID.SilverOre))
                {
                    SilverOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe TungstenOreNewCraft = Main.recipe[i];
                if (TungstenOreNewCraft.HasIngredient(ItemID.SilverOre) && (TungstenOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && TungstenOreNewCraft.HasResult(ItemID.TungstenOre))
                {
                    TungstenOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe GoldOreNewCraft = Main.recipe[i];
                if (GoldOreNewCraft.HasIngredient(ModContent.ItemType<BismuthOre>()) && (GoldOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && GoldOreNewCraft.HasResult(ItemID.GoldOre))
                {
                    GoldOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe PlatinumOreNewCraft = Main.recipe[i];
                if (PlatinumOreNewCraft.HasIngredient(ItemID.GoldOre) && (PlatinumOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && PlatinumOreNewCraft.HasResult(ItemID.PlatinumOre))
                {
                    PlatinumOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }

                Recipe BismuthOreNewCraft = Main.recipe[i];
                if (BismuthOreNewCraft.HasIngredient(ItemID.PlatinumOre) && (BismuthOreNewCraft.HasIngredient(ModContent.ItemType<Sulphur>())) && BismuthOreNewCraft.HasResult(ModContent.ItemType<BismuthOre>()))
                {
                    BismuthOreNewCraft.SortAfterFirstRecipesOf(ItemID.GoldCoin);
                }
            }
        }
    }
}
