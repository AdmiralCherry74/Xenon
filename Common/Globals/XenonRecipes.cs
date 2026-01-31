using System.Collections;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Tools.MiningPickaxes;

namespace Xenon.Common.Globals
{

    public class XenonRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            //Beginning of Armor recipe groups
            //Beginning of Wooden Armor recipe groups
            RecipeGroup WoodenHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodHelmet)}", ItemID.WoodHelmet, ItemID.PalmWoodHelmet, ItemID.BorealWoodHelmet, ItemID.RichMahoganyHelmet, ItemID.CactusHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodHelmet), WoodenHelmet);
            //Wood Helmet recipe group

            RecipeGroup WoodenBreastplate = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodBreastplate)}", ItemID.WoodBreastplate, ItemID.PalmWoodBreastplate, ItemID.BorealWoodBreastplate, ItemID.RichMahoganyBreastplate, ItemID.CactusBreastplate);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodBreastplate), WoodenBreastplate);
            //Wood Breastplate recipe group

            RecipeGroup WoodGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodGreaves)}", ItemID.WoodGreaves, ItemID.PalmWoodGreaves, ItemID.BorealWoodGreaves, ItemID.RichMahoganyGreaves, ItemID.CactusLeggings);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodGreaves), WoodGreaves);
            //Wood Greaves recipe group
            //End of Wooden Armor recipe groups

            //Beginning of Tier 1 ore Armor recipe groups
            RecipeGroup CopperHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperHelmet)}", ItemID.CopperHelmet, ItemID.TinHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperHelmet), CopperHelmet);
            //Copper Helmet recipe group

            RecipeGroup CopperChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperChainmail)}", ItemID.CopperChainmail, ItemID.TinChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperChainmail), CopperChainmail);
            //Copper Chainmail recipe group

            RecipeGroup CopperGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperGreaves)}", ItemID.CopperGreaves, ItemID.TinGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperGreaves), CopperGreaves);
            //Copper Greaves recipe group
            //End of Tier 1 ore Armor recipe groups

            //Beginning of Tier 2 ore Armor recipe groups
            RecipeGroup IronHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronHelmet)}", ItemID.IronHelmet, ItemID.LeadHelmet, ItemID.AncientIronHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronHelmet), IronHelmet);
            //Iron Helmet recipe group

            RecipeGroup IronChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronChainmail)}", ItemID.IronChainmail, ItemID.LeadChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronChainmail), IronChainmail);
            //Iron Chainmail recipe group

            RecipeGroup IronGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronGreaves)}", ItemID.IronGreaves, ItemID.LeadGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronGreaves), IronGreaves);
            //Iron Greaves recipe group
            //End of Tier 2 ore Armor recipe groups

            //Beginning of Tier 3 ore Armor recipe groups
            RecipeGroup SilverHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverHelmet)}", ItemID.SilverHelmet, ItemID.TungstenHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverHelmet), SilverHelmet);
            //Silver Helmet recipe group

            RecipeGroup SilverChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronChainmail)}", ItemID.SilverChainmail, ItemID.TungstenChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverChainmail), SilverChainmail);
            //Silver Chainmail recipe group

            RecipeGroup SilverGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronGreaves)}", ItemID.SilverGreaves, ItemID.TungstenGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverGreaves), SilverGreaves);
            //Silver Greaves recipe group
            //End of Tier 3 ore Armor recipe groups

            //Beginning of Tier 4 ore Armor recipe groups
            RecipeGroup GoldHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldHelmet)}", ItemID.GoldHelmet, ItemID.PlatinumHelmet, ItemID.AncientGoldHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldHelmet), GoldHelmet);
            //Gold Helmet recipe group

            RecipeGroup GoldChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldChainmail)}", ItemID.GoldChainmail, ItemID.PlatinumChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldChainmail), GoldChainmail);
            //Gold Chainmail recipe group

            RecipeGroup GoldGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldGreaves)}", ItemID.GoldGreaves, ItemID.PlatinumGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldGreaves), GoldGreaves);
            //Gold Greaves recipe group
            //End of Tier 4 ore Armor recipe groups

            //Beginning of Evil ore Armor recipe groups
            RecipeGroup ShadowHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowHelmet)}", ItemID.ShadowHelmet, ItemID.CrimsonHelmet, ItemID.AncientShadowHelmet, (ModContent.ItemType<CausticHelmet>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowHelmet), ShadowHelmet);
            //Evil Helmet recipe group

            RecipeGroup ShadowScalemail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScalemail)}", ItemID.ShadowScalemail, ItemID.CrimsonScalemail, ItemID.AncientShadowScalemail, (ModContent.ItemType<CausticScalemail>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScalemail), ShadowScalemail);
            //Evil Chestplate recipe group

            RecipeGroup ShadowGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowGreaves)}", ItemID.ShadowGreaves, ItemID.CrimsonGreaves, ItemID.AncientShadowGreaves, (ModContent.ItemType<CausticGreaves>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowGreaves), ShadowGreaves);
            //Evil Greaves recipe group
            //End of Evil ore Armor recipe groups
            //End of Armor recipe groups

            //Beginning of Pickaxe recipe groups
            //Beginning of Tier 1 Pickaxe recipe groups
            RecipeGroup CopperPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperPickaxe)}", ItemID.CopperPickaxe, ItemID.TinPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperPickaxe), CopperPickaxe);
            //Tier 1 Pickaxe recipe group

            //Beginning of Tier 2 Pickaxe recipe groups
            RecipeGroup IronPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronPickaxe)}", ItemID.IronPickaxe, ItemID.LeadPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronPickaxe), IronPickaxe);
            //Tier 2 Pickaxe recipe group

            //Beginning of Tier 3 Pickaxe recipe groups
            RecipeGroup SilverPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverPickaxe)}", ItemID.SilverPickaxe, ItemID.TungstenPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverPickaxe), SilverPickaxe);
            //Tier 3 Pickaxe recipe group

            //Beginning of Tier 4 Pickaxe recipe groups
            RecipeGroup GoldPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldPickaxe)}", ItemID.GoldPickaxe, ItemID.PlatinumPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldPickaxe), GoldPickaxe);
            //Tier 4 Pickaxe recipe group

            //Beginning of Evil Tier Pickaxe recipe groups
            RecipeGroup NightmarePickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.NightmarePickaxe)}", ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, (ModContent.ItemType<IngestedPickaxe>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.NightmarePickaxe), NightmarePickaxe);
            //Evil Tier Pickaxe recipe group
            //End of Pickaxe recipe groups


        }
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                //Beginning of armor recipe changes
                //Beginning of Copper armor recipe changes
                Recipe CopperHelmetCraft = Main.recipe[i];
                if (CopperHelmetCraft.HasIngredient(ItemID.CopperBar) && CopperHelmetCraft.HasTile(TileID.Anvils) && CopperHelmetCraft.HasResult(ItemID.CopperHelmet))
                {
                    CopperHelmetCraft.AddRecipeGroup("WoodHelmet");
                }
                //Copper Helmet recipe

                Recipe CopperChainmailCraft = Main.recipe[i];
                if (CopperChainmailCraft.HasIngredient(ItemID.CopperBar) && CopperChainmailCraft.HasTile(TileID.Anvils) && CopperChainmailCraft.HasResult(ItemID.CopperChainmail))
                {
                    CopperChainmailCraft.AddRecipeGroup("WoodBreastplate");
                }
                //Copper Chainmail recipe

                Recipe CopperGreavesCraft = Main.recipe[i];
                if (CopperGreavesCraft.HasIngredient(ItemID.CopperBar) && CopperGreavesCraft.HasTile(TileID.Anvils) && CopperGreavesCraft.HasResult(ItemID.CopperGreaves))
                {
                    CopperGreavesCraft.AddRecipeGroup("WoodGreaves");
                }
                //Copper Greaves recipe
                //End of Copper armor recipe changes

                //Beginning of Tin armor recipe changes
                Recipe TinHelmetCraft = Main.recipe[i];
                if (TinHelmetCraft.HasIngredient(ItemID.TinBar) && TinHelmetCraft.HasTile(TileID.Anvils) && TinHelmetCraft.HasResult(ItemID.TinHelmet))
                {
                    TinHelmetCraft.AddRecipeGroup("WoodHelmet");
                }
                //Tin Helmet recipe

                Recipe TinChainmailCraft = Main.recipe[i];
                if (TinChainmailCraft.HasIngredient(ItemID.TinBar) && TinChainmailCraft.HasTile(TileID.Anvils) && TinChainmailCraft.HasResult(ItemID.TinChainmail))
                {
                    TinChainmailCraft.AddRecipeGroup("WoodBreastplate");
                }
                //Tin Chainmail recipe

                Recipe TinGreavesCraft = Main.recipe[i];
                if (TinGreavesCraft.HasIngredient(ItemID.TinBar) && TinGreavesCraft.HasTile(TileID.Anvils) && TinGreavesCraft.HasResult(ItemID.TinGreaves))
                {
                    TinGreavesCraft.AddRecipeGroup("WoodGreaves");
                }
                //Tin Greaves recipe
                //End of Tin armor recipe changes

                //Beginning of Iron armor recipe changes
                Recipe IronHelmetCraft = Main.recipe[i];
                if (IronHelmetCraft.HasIngredient(ItemID.IronBar) && IronHelmetCraft.HasTile(TileID.Anvils) && IronHelmetCraft.HasResult(ItemID.IronHelmet))
                {
                    IronHelmetCraft.AddRecipeGroup("CopperHelmet");
                    if (IronHelmetCraft.TryGetIngredient(ItemID.IronBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Iron Helmet recipe

                Recipe IronChainmailCraft = Main.recipe[i];
                if (IronChainmailCraft.HasIngredient(ItemID.IronBar) && IronChainmailCraft.HasTile(TileID.Anvils) && IronChainmailCraft.HasResult(ItemID.IronChainmail))
                {
                    IronChainmailCraft.AddRecipeGroup("CopperChainmail");
                    if (IronChainmailCraft.TryGetIngredient(ItemID.IronBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Iron Chainmail recipe

                Recipe IronGreavesCraft = Main.recipe[i];
                if (IronGreavesCraft.HasIngredient(ItemID.IronBar) && IronGreavesCraft.HasTile(TileID.Anvils) && IronGreavesCraft.HasResult(ItemID.IronGreaves))
                {
                    IronGreavesCraft.AddRecipeGroup("CopperGreaves");
                    if (IronGreavesCraft.TryGetIngredient(ItemID.IronBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Iron Greaves recipe
                //End of Iron armor recipe changes

                //Beginning of Lead armor recipe changes
                Recipe LeadHelmetCraft = Main.recipe[i];
                if (LeadHelmetCraft.HasIngredient(ItemID.LeadBar) && LeadHelmetCraft.HasTile(TileID.Anvils) && LeadHelmetCraft.HasResult(ItemID.LeadHelmet))
                {
                    LeadHelmetCraft.AddRecipeGroup("CopperHelmet");
                    if (LeadHelmetCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lead Helmet recipe

                Recipe LeadChainmailCraft = Main.recipe[i];
                if (LeadChainmailCraft.HasIngredient(ItemID.LeadBar) && LeadChainmailCraft.HasTile(TileID.Anvils) && LeadChainmailCraft.HasResult(ItemID.LeadChainmail))
                {
                    LeadChainmailCraft.AddRecipeGroup("CopperChainmail");
                    if (LeadChainmailCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lead Chainmail recipe

                Recipe LeadGreavesCraft = Main.recipe[i];
                if (LeadGreavesCraft.HasIngredient(ItemID.LeadBar) && LeadGreavesCraft.HasTile(TileID.Anvils) && LeadGreavesCraft.HasResult(ItemID.LeadGreaves))
                {
                    LeadGreavesCraft.AddRecipeGroup("CopperGreaves");
                    if (LeadGreavesCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lead Greaves recipe
                //End of Lead armor recipe changes

                //Beginning of Silver armor recipe changes
                Recipe SilverHelmetCraft = Main.recipe[i];
                if (SilverHelmetCraft.HasIngredient(ItemID.SilverBar) && SilverHelmetCraft.HasTile(TileID.Anvils) && SilverHelmetCraft.HasResult(ItemID.SilverHelmet))
                {
                    SilverHelmetCraft.AddRecipeGroup("IronHelmet");
                    if (SilverHelmetCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Silver Helmet recipe

                Recipe SilverChainmailCraft = Main.recipe[i];
                if (SilverChainmailCraft.HasIngredient(ItemID.SilverBar) && SilverChainmailCraft.HasTile(TileID.Anvils) && SilverChainmailCraft.HasResult(ItemID.SilverChainmail))
                {
                    SilverChainmailCraft.AddRecipeGroup("IronChainmail");
                    if (SilverChainmailCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Silver Chainmail recipe

                Recipe SilverGreavesCraft = Main.recipe[i];
                if (SilverGreavesCraft.HasIngredient(ItemID.SilverBar) && SilverGreavesCraft.HasTile(TileID.Anvils) && SilverGreavesCraft.HasResult(ItemID.SilverGreaves))
                {
                    SilverGreavesCraft.AddRecipeGroup("IronGreaves");
                    if (SilverGreavesCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Silver Greaves recipe
                //End of Silver armor recipe changes

                //Beginning of Tungsten armor recipe changes
                Recipe TungstenHelmetCraft = Main.recipe[i];
                if (TungstenHelmetCraft.HasIngredient(ItemID.TungstenBar) && TungstenHelmetCraft.HasTile(TileID.Anvils) && TungstenHelmetCraft.HasResult(ItemID.TungstenHelmet))
                {
                    TungstenHelmetCraft.AddRecipeGroup("IronHelmet");
                    if (TungstenHelmetCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tungsten Helmet recipe

                Recipe TungstenChainmailCraft = Main.recipe[i];
                if (TungstenChainmailCraft.HasIngredient(ItemID.TungstenBar) && TungstenChainmailCraft.HasTile(TileID.Anvils) && TungstenChainmailCraft.HasResult(ItemID.TungstenChainmail))
                {
                    TungstenChainmailCraft.AddRecipeGroup("IronChainmail");
                    if (TungstenChainmailCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tungsten Chainmail recipe

                Recipe TungstenGreavesCraft = Main.recipe[i];
                if (TungstenGreavesCraft.HasIngredient(ItemID.TungstenBar) && TungstenGreavesCraft.HasTile(TileID.Anvils) && TungstenGreavesCraft.HasResult(ItemID.TungstenGreaves))
                {
                    TungstenGreavesCraft.AddRecipeGroup("IronGreaves");
                    if (TungstenGreavesCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tungsten Greaves recipe
                //End of Tungsten armor recipe changes

                //Beginning of Gold armor recipe changes
                Recipe GoldHelmetCraft = Main.recipe[i];
                if (GoldHelmetCraft.HasIngredient(ItemID.GoldBar) && GoldHelmetCraft.HasTile(TileID.Anvils) && GoldHelmetCraft.HasResult(ItemID.GoldHelmet))
                {
                    GoldHelmetCraft.AddRecipeGroup("SilverHelmet");
                    if (GoldHelmetCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Gold Helmet recipe

                Recipe GoldChainmailCraft = Main.recipe[i];
                if (GoldChainmailCraft.HasIngredient(ItemID.GoldBar) && GoldChainmailCraft.HasTile(TileID.Anvils) && GoldChainmailCraft.HasResult(ItemID.GoldChainmail))
                {
                    GoldChainmailCraft.AddRecipeGroup("SilverChainmail");
                    if (GoldChainmailCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Gold Chainmail recipe

                Recipe GoldGreavesCraft = Main.recipe[i];
                if (GoldGreavesCraft.HasIngredient(ItemID.GoldBar) && GoldGreavesCraft.HasTile(TileID.Anvils) && GoldGreavesCraft.HasResult(ItemID.GoldGreaves))
                {
                    GoldGreavesCraft.AddRecipeGroup("SilverGreaves");
                    if (GoldGreavesCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Gold Greaves recipe
                //End of Gold armor recipe changes

                //Beginning of Platinum armor recipe changes
                Recipe PlatinumHelmetCraft = Main.recipe[i];
                if (PlatinumHelmetCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumHelmetCraft.HasTile(TileID.Anvils) && PlatinumHelmetCraft.HasResult(ItemID.PlatinumHelmet))
                {
                    PlatinumHelmetCraft.AddRecipeGroup("SilverHelmet");
                    if (PlatinumHelmetCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Platinum Helmet recipe

                Recipe PlatinumChainmailCraft = Main.recipe[i];
                if (PlatinumChainmailCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumChainmailCraft.HasTile(TileID.Anvils) && PlatinumChainmailCraft.HasResult(ItemID.PlatinumChainmail))
                {
                    PlatinumChainmailCraft.AddRecipeGroup("SilverChainmail");
                    if (PlatinumChainmailCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Platinum Chainmail recipe

                Recipe PlatinumGreavesCraft = Main.recipe[i];
                if (PlatinumGreavesCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumGreavesCraft.HasTile(TileID.Anvils) && PlatinumGreavesCraft.HasResult(ItemID.PlatinumGreaves))
                {
                    PlatinumGreavesCraft.AddRecipeGroup("SilverGreaves");
                    if (PlatinumGreavesCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Platinum Greaves recipe
                //End of Platinum armor recipe changes

                //Beginning of Shadow armor recipe changes
                Recipe ShadowHelmetCraft = Main.recipe[i];
                if (ShadowHelmetCraft.HasIngredient(ItemID.DemoniteBar) && ShadowHelmetCraft.HasTile(TileID.Anvils) && ShadowHelmetCraft.HasResult(ItemID.ShadowHelmet))
                {
                    ShadowHelmetCraft.AddRecipeGroup("GoldHelmet");
                    if (ShadowHelmetCraft.TryGetIngredient(ItemID.DemoniteBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Shadow Helmet recipe

                Recipe ShadowScalemailCraft = Main.recipe[i];
                if (ShadowScalemailCraft.HasIngredient(ItemID.DemoniteBar) && ShadowScalemailCraft.HasTile(TileID.Anvils) && ShadowScalemailCraft.HasResult(ItemID.ShadowScalemail))
                {
                    ShadowScalemailCraft.AddRecipeGroup("GoldChainmail");
                    if (ShadowScalemailCraft.TryGetIngredient(ItemID.DemoniteBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Shadow Scalemail recipe

                Recipe ShadowGreavesCraft = Main.recipe[i];
                if (ShadowGreavesCraft.HasIngredient(ItemID.DemoniteBar) && ShadowGreavesCraft.HasTile(TileID.Anvils) && ShadowGreavesCraft.HasResult(ItemID.ShadowGreaves))
                {
                    ShadowGreavesCraft.AddRecipeGroup("GoldGreaves");
                    if (ShadowGreavesCraft.TryGetIngredient(ItemID.DemoniteBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Shadow Greaves recipe
                //End of Shadow armor recipe changes

                //Beginning of Crimson armor recipe changes
                Recipe CrimsonHelmetCraft = Main.recipe[i];
                if (CrimsonHelmetCraft.HasIngredient(ItemID.CrimtaneBar) && CrimsonHelmetCraft.HasTile(TileID.Anvils) && CrimsonHelmetCraft.HasResult(ItemID.CrimsonHelmet))
                {
                    CrimsonHelmetCraft.AddRecipeGroup("GoldHelmet");
                    if (CrimsonHelmetCraft.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Crimson Helmet recipe

                Recipe CrimsonScalemailCraft = Main.recipe[i];
                if (CrimsonScalemailCraft.HasIngredient(ItemID.CrimtaneBar) && CrimsonScalemailCraft.HasTile(TileID.Anvils) && CrimsonScalemailCraft.HasResult(ItemID.CrimsonScalemail))
                {
                    CrimsonScalemailCraft.AddRecipeGroup("GoldChainmail");
                    if (CrimsonScalemailCraft.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Crimson Scalemail recipe

                Recipe CrimsonGreavesCraft = Main.recipe[i];
                if (CrimsonGreavesCraft.HasIngredient(ItemID.CrimtaneBar) && CrimsonGreavesCraft.HasTile(TileID.Anvils) && CrimsonGreavesCraft.HasResult(ItemID.CrimsonGreaves))
                {
                    CrimsonGreavesCraft.AddRecipeGroup("GoldGreaves");
                    if (CrimsonGreavesCraft.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Crimson Greaves recipe
                //End of Crimson armor recipe changes

                //We skip Caustic armor cause we can just code it into the actual items themselves

                //Beginning of Molten armor recipe changes
                Recipe MoltenHelmetCraft = Main.recipe[i];
                if (MoltenHelmetCraft.HasIngredient(ItemID.HellstoneBar) && MoltenHelmetCraft.HasTile(TileID.Anvils) && MoltenHelmetCraft.HasResult(ItemID.MoltenHelmet))
                {
                    MoltenHelmetCraft.AddRecipeGroup("ShadowHelmet");
                    if (MoltenHelmetCraft.TryGetIngredient(ItemID.HellstoneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Molten Helmet recipe

                Recipe MoltenBreastplateCraft = Main.recipe[i];
                if (MoltenBreastplateCraft.HasIngredient(ItemID.HellstoneBar) && MoltenBreastplateCraft.HasTile(TileID.Anvils) && MoltenBreastplateCraft.HasResult(ItemID.MoltenBreastplate))
                {
                    MoltenBreastplateCraft.AddRecipeGroup("ShadowScalemail");
                    if (MoltenBreastplateCraft.TryGetIngredient(ItemID.HellstoneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Molten BreastplateCraft recipe

                Recipe MoltenGreavesCraft = Main.recipe[i];
                if (MoltenGreavesCraft.HasIngredient(ItemID.HellstoneBar) && MoltenGreavesCraft.HasTile(TileID.Anvils) && MoltenGreavesCraft.HasResult(ItemID.MoltenGreaves))
                {
                    MoltenGreavesCraft.AddRecipeGroup("ShadowGreaves");
                    if (MoltenGreavesCraft.TryGetIngredient(ItemID.HellstoneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Molten Greaves recipe
                //End of Molten armor recipe changes
                //End of armor recipe changes

                //Beginning of Pickaxe recipe changes
                Recipe IronPickaxeCraft = Main.recipe[i];
                if (IronPickaxeCraft.HasIngredient(ItemID.IronBar) && IronPickaxeCraft.HasTile(TileID.Anvils) && IronPickaxeCraft.HasResult(ItemID.IronPickaxe))
                {
                    IronPickaxeCraft.AddRecipeGroup("CopperPickaxe");
                    IronPickaxeCraft.RemoveIngredient(ItemID.Wood);
                }
                //Iron Pickaxe Recipe

                Recipe LeadPickaxeCraft = Main.recipe[i];
                if (LeadPickaxeCraft.HasIngredient(ItemID.LeadBar) && LeadPickaxeCraft.HasTile(TileID.Anvils) && LeadPickaxeCraft.HasResult(ItemID.LeadPickaxe))
                {
                    LeadPickaxeCraft.AddRecipeGroup("CopperPickaxe");
                    LeadPickaxeCraft.RemoveIngredient(ItemID.Wood);
                }
                //Lead Pickaxe Recipe

                Recipe SilverPickaxeCraft = Main.recipe[i];
                if (SilverPickaxeCraft.HasIngredient(ItemID.SilverBar) && SilverPickaxeCraft.HasTile(TileID.Anvils) && SilverPickaxeCraft.HasResult(ItemID.SilverPickaxe))
                {
                    SilverPickaxeCraft.AddRecipeGroup("IronPickaxe");
                    SilverPickaxeCraft.RemoveIngredient(ItemID.Wood);
                    if (SilverPickaxeCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack -= 2;
                    }
                }
                //Silver Pickaxe Recipe

                Recipe TungstenPickaxeCraft = Main.recipe[i];
                if (TungstenPickaxeCraft.HasIngredient(ItemID.TungstenBar) && TungstenPickaxeCraft.HasTile(TileID.Anvils) && TungstenPickaxeCraft.HasResult(ItemID.TungstenPickaxe))
                {
                    TungstenPickaxeCraft.AddRecipeGroup("IronPickaxe");
                    TungstenPickaxeCraft.RemoveIngredient(ItemID.Wood);
                    if (TungstenPickaxeCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack -= 2;
                    }
                }
                //Tungsten Pickaxe Recipe

                Recipe GoldPickaxeCraft = Main.recipe[i];
                if (GoldPickaxeCraft.HasIngredient(ItemID.GoldBar) && GoldPickaxeCraft.HasTile(TileID.Anvils) && GoldPickaxeCraft.HasResult(ItemID.GoldPickaxe))
                {
                    GoldPickaxeCraft.AddRecipeGroup("SilverPickaxe");
                    GoldPickaxeCraft.RemoveIngredient(ItemID.Wood);
                    if (GoldPickaxeCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack -= 2;
                    }
                }
                //Gold Pickaxe Recipe

                Recipe PlatinumPickaxeCraft = Main.recipe[i];
                if (PlatinumPickaxeCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumPickaxeCraft.HasTile(TileID.Anvils) && PlatinumPickaxeCraft.HasResult(ItemID.PlatinumPickaxe))
                {
                    PlatinumPickaxeCraft.AddRecipeGroup("SilverPickaxe");
                    PlatinumPickaxeCraft.RemoveIngredient(ItemID.Wood);
                    if (PlatinumPickaxeCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack -= 2;
                    }
                }
                //Platinum Pickaxe Recipe

                Recipe NightmarePickaxeCraft = Main.recipe[i];
                if (NightmarePickaxeCraft.HasIngredient(ItemID.DemoniteBar) && NightmarePickaxeCraft.HasTile(TileID.Anvils) && NightmarePickaxeCraft.HasResult(ItemID.NightmarePickaxe))
                {
                    NightmarePickaxeCraft.AddRecipeGroup("GoldPickaxe");
                }
                //Nightmare Pickaxe Recipe

                Recipe DeathbringerPickaxeCraft = Main.recipe[i];
                if (DeathbringerPickaxeCraft.HasIngredient(ItemID.CrimtaneBar) && DeathbringerPickaxeCraft.HasTile(TileID.Anvils) && DeathbringerPickaxeCraft.HasResult(ItemID.DeathbringerPickaxe))
                {
                    DeathbringerPickaxeCraft.AddRecipeGroup("GoldPickaxe");
                }
                //Deathrbinger Pickaxe Recipe

                Recipe MoltenPickaxeCraft = Main.recipe[i];
                if (MoltenPickaxeCraft.HasIngredient(ItemID.HellstoneBar) && MoltenPickaxeCraft.HasTile(TileID.Anvils) && MoltenPickaxeCraft.HasResult(ItemID.MoltenPickaxe))
                {
                    MoltenPickaxeCraft.AddRecipeGroup("NightmarePickaxe");
                    if (MoltenPickaxeCraft.TryGetIngredient(ItemID.HellstoneBar, out Item ingredient))
                    {
                        ingredient.stack -= 5;
                    }
                }
                //Molten Pickaxe Recipe
                //End of Pickaxe recipe changes

                //Just gonna wait until the hardmode update to further update the recipes
            }
        }
    }
}