using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Melee.Swords;
using Xenon.Content.Items.Weapons.Ranged.Bows;

namespace Xenon.Common.Globals
{

    public class XenonRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            //Beginning of Armor recipe groups
            #region wood recipe group
            RecipeGroup WoodenHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodHelmet)}", ItemID.WoodHelmet, ItemID.PalmWoodHelmet, ItemID.BorealWoodHelmet, ItemID.RichMahoganyHelmet, ItemID.CactusHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodHelmet), WoodenHelmet);
            //Wood Helmet recipe group

            RecipeGroup WoodenBreastplate = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodBreastplate)}", ItemID.WoodBreastplate, ItemID.PalmWoodBreastplate, ItemID.BorealWoodBreastplate, ItemID.RichMahoganyBreastplate, ItemID.CactusBreastplate);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodBreastplate), WoodenBreastplate);
            //Wood Breastplate recipe group

            RecipeGroup WoodGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodGreaves)}", ItemID.WoodGreaves, ItemID.PalmWoodGreaves, ItemID.BorealWoodGreaves, ItemID.RichMahoganyGreaves, ItemID.CactusLeggings);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodGreaves), WoodGreaves);
            //Wood Greaves recipe group
            #endregion

            #region copper tier recipe group
            RecipeGroup CopperHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperHelmet)}", ItemID.CopperHelmet, ItemID.TinHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperHelmet), CopperHelmet);
            //Copper Helmet recipe group

            RecipeGroup CopperChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperChainmail)}", ItemID.CopperChainmail, ItemID.TinChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperChainmail), CopperChainmail);
            //Copper Chainmail recipe group

            RecipeGroup CopperGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperGreaves)}", ItemID.CopperGreaves, ItemID.TinGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperGreaves), CopperGreaves);
            //Copper Greaves recipe group
            #endregion

            #region iron tier recipe group
            RecipeGroup IronHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronHelmet)}", ItemID.IronHelmet, ItemID.LeadHelmet, ItemID.AncientIronHelmet);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronHelmet), IronHelmet);
            //Iron Helmet recipe group

            RecipeGroup IronChainmail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronChainmail)}", ItemID.IronChainmail, ItemID.LeadChainmail);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronChainmail), IronChainmail);
            //Iron Chainmail recipe group

            RecipeGroup IronGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronGreaves)}", ItemID.IronGreaves, ItemID.LeadGreaves);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronGreaves), IronGreaves);
            //Iron Greaves recipe group
            #endregion

            #region silver tier recipe group
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
            #endregion

            #region gold tier recipe group

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
            #endregion

            #region evil tier recipe group
            RecipeGroup ShadowHelmet = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowHelmet)}", ItemID.ShadowHelmet, ItemID.CrimsonHelmet, ItemID.AncientShadowHelmet, (ModContent.ItemType<CausticHelmet>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowHelmet), ShadowHelmet);
            //Evil Helmet recipe group


            RecipeGroup ShadowScalemail = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScalemail)}", ItemID.ShadowScalemail, ItemID.CrimsonScalemail, ItemID.AncientShadowScalemail, (ModContent.ItemType<CausticScalemail>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScalemail), ShadowScalemail);
            //Evil Chestplate recipe group

            RecipeGroup ShadowGreaves = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowGreaves)}", ItemID.ShadowGreaves, ItemID.CrimsonGreaves, ItemID.AncientShadowGreaves, (ModContent.ItemType<CausticGreaves>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.ShadowGreaves), ShadowGreaves);
            //Evil Greaves recipe group
            #endregion
            //End of Armor recipe groups

            //Beginning of Pickaxe recipe groups
            #region copper tier recipe group
            RecipeGroup CopperPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperPickaxe)}", ItemID.CopperPickaxe, ItemID.TinPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperPickaxe), CopperPickaxe);
            //Tier 1 Pickaxe recipe group
            #endregion

            #region iron tier recipe group
            RecipeGroup IronPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronPickaxe)}", ItemID.IronPickaxe, ItemID.LeadPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronPickaxe), IronPickaxe);
            //Tier 2 Pickaxe recipe group
            #endregion

            #region silver tier recipe group
            RecipeGroup SilverPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverPickaxe)}", ItemID.SilverPickaxe, ItemID.TungstenPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverPickaxe), SilverPickaxe);
            //Tier 3 Pickaxe recipe group
            #endregion

            #region gold tier recipe group
            RecipeGroup GoldPickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldPickaxe)}", ItemID.GoldPickaxe, ItemID.PlatinumPickaxe);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldPickaxe), GoldPickaxe);
            //Tier 4 Pickaxe recipe group
            #endregion

            #region evil tier recipe group
            RecipeGroup NightmarePickaxe = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.NightmarePickaxe)}", ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, (ModContent.ItemType<IngestedPickaxe>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.NightmarePickaxe), NightmarePickaxe);
            //Evil Tier Pickaxe recipe group
            #endregion
            //End of Pickaxe recipe groups

            //Beginning of Broadsword recipe groups
            #region wood recipe group
            RecipeGroup WoodenSword = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodenSword)}", ItemID.WoodenSword, ItemID.PalmWoodSword, ItemID.BorealWoodSword, ItemID.RichMahoganySword, ItemID.CactusSword);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodenSword), WoodenSword);
            //Wooden Broadsword recipe groups
            #endregion

            #region copper tier recipe group
            RecipeGroup CopperBroadsword = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBroadsword)}", ItemID.CopperBroadsword, ItemID.TinBroadsword);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBroadsword), CopperBroadsword);
            //Tier 1 Broadsword recipe group
            #endregion

            #region iron tier recipe group
            RecipeGroup IronBroadsword = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronBroadsword)}", ItemID.IronBroadsword, ItemID.LeadBroadsword);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronBroadsword), IronBroadsword);
            //Tier 2 Broadsword recipe group
            #endregion

            #region silver tier recipe group
            RecipeGroup SilverBroadsword = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBroadsword)}", ItemID.SilverBroadsword, ItemID.TungstenBroadsword);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverBroadsword), SilverBroadsword);
            //Tier 3 Broadsword recipe group
            #endregion

            #region gold tier recipe group
            RecipeGroup GoldBroadsword = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBroadsword)}", ItemID.GoldBroadsword, ItemID.PlatinumBroadsword);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBroadsword), GoldBroadsword);
            //Tier 4 Broadsword recipe group
            #endregion

            #region evil tier recipe group
            RecipeGroup LightsBane = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.LightsBane)}", ItemID.LightsBane, ItemID.BloodButcherer, (ModContent.ItemType<TheIndigestion>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.LightsBane), LightsBane);
            //Tier Evil Broadsword recipe group
            #endregion region
            //End of Broadsword recipe groups

            //Beginning of Bow recipe groups
            #region wood recipe group
            RecipeGroup WoodenBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.WoodenBow)}", ItemID.WoodenBow, ItemID.PalmWoodBow, ItemID.BorealWoodBow, ItemID.RichMahoganyBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.WoodenBow), WoodenBow);
            //Wooden Bow recipe groups
            #endregion

            #region copper tier recipe group
            RecipeGroup CopperBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBow)}", ItemID.CopperBow, ItemID.TinBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBow), CopperBow);
            //Tier 1 Bow recipe group
            #endregion

            #region iron tier recipe group
            RecipeGroup IronBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.IronBow)}", ItemID.IronBow, ItemID.LeadBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronBow), IronBow);
            //Tier 2 Bow recipe group
            #endregion

            #region silver tier recipe group
            RecipeGroup SilverBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBow)}", ItemID.SilverBow, ItemID.TungstenBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverBow), SilverBow);
            //Tier 3 Bow recipe group
            #endregion

            #region gold tier recipe group
            RecipeGroup GoldBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBow)}", ItemID.GoldBow, ItemID.PlatinumBow);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBow), GoldBow);
            //Tier 4 Bow recipe group
            #endregion

            #region evil tier recipe group
            RecipeGroup DemonBow = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemonBow)}", ItemID.DemonBow, ItemID.TendonBow, (ModContent.ItemType<SulfirBow>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.DemonBow), DemonBow);
            //Tier Evil Bow recipe group
            #endregion region
            //End of Bow recipe groups

            #region Material recipe groups
            RecipeGroup EvilFish = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Ebonkoi)}", ItemID.Ebonkoi, ItemID.Hemopiranha, (ModContent.ItemType<Corrodoras>()));
            RecipeGroup.RegisterGroup(nameof(ItemID.Ebonkoi), EvilFish);
            //Evil Fish recipe group
            #endregion region

            #region Adding Modded items to vanilla recipe groups
            //Wood recipe group
            RecipeGroup groupwood = RecipeGroup.recipeGroups[RecipeGroupID.Wood];
            groupwood.ValidItems.Add(ModContent.ItemType<Bilewood>());
            groupwood.ValidItems.Add(ModContent.ItemType<JacarandaWood>());

            //Iron recipe group
            RecipeGroup groupiron = RecipeGroup.recipeGroups[RecipeGroupID.IronBar];
            groupiron.ValidItems.Add(ModContent.ItemType<CinnabarBar>());
            #endregion
        }
        public override void PostAddRecipes()
        {
            // return out if the config is off
            if (!ModContent.GetInstance<XenonConfig>().RequirePreviousOreTierForNext) return;
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                #region Beginning of armor recipe changes
                #region copper armor
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
                #endregion

                #region tin armor
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
                #endregion

                #region iron armor
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
                #endregion

                #region lead armor
                Recipe LeadHelmetCraft = Main.recipe[i];
                if (LeadHelmetCraft.HasIngredient(ItemID.LeadBar) && LeadHelmetCraft.HasTile(TileID.Anvils) && LeadHelmetCraft.HasResult(ItemID.LeadHelmet))
                {
                    LeadHelmetCraft.AddRecipeGroup("CopperHelmet");
                    if (LeadHelmetCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }

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
                #endregion

                #region silver armor
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
                #endregion

                #region tungsten armor
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
                #endregion

                #region gold armor
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
                #endregion

                #region platinum armor
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
                #endregion

                #region shadow armor
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
                #endregion

                #region crimson armor
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
                #endregion

                #region caustic armor
                Recipe CausticHelmetCraft = Main.recipe[i];
                if (CausticHelmetCraft.HasIngredient(ModContent.ItemType<IngestaneBar>()) && CausticHelmetCraft.HasTile(TileID.Anvils) && CausticHelmetCraft.HasResult(ModContent.ItemType<CausticHelmet>()))
                {
                    CausticHelmetCraft.AddRecipeGroup("GoldHelmet");
                    if (CausticHelmetCraft.TryGetIngredient(ModContent.ItemType<IngestaneBar>(), out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Crimson Helmet recipe

                Recipe CausticScalemailCraft = Main.recipe[i];
                if (CausticScalemailCraft.HasIngredient(ModContent.ItemType<IngestaneBar>()) && CausticScalemailCraft.HasTile(TileID.Anvils) && CausticScalemailCraft.HasResult(ModContent.ItemType<CausticScalemail>()))
                {
                    CausticScalemailCraft.AddRecipeGroup("GoldChainmail");
                    if (CausticScalemailCraft.TryGetIngredient(ModContent.ItemType<IngestaneBar>(), out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Crimson Scalemail recipe

                Recipe CausticGreavesCraft = Main.recipe[i];
                if (CausticGreavesCraft.HasIngredient(ModContent.ItemType<IngestaneBar>()) && CausticGreavesCraft.HasTile(TileID.Anvils) && CausticGreavesCraft.HasResult(ModContent.ItemType<CausticGreaves>()))
                {
                    CausticGreavesCraft.AddRecipeGroup("GoldGreaves");
                    if (CausticGreavesCraft.TryGetIngredient(ModContent.ItemType<IngestaneBar>(), out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                #endregion

                #region molten armor
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
                #endregion
                #endregion End of armor recipe changes

                //Beginning of Pickaxe recipe changes
                #region iron tier pickaxes
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
                #endregion

                #region silver tier pickaxe
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
                #endregion

                #region gold tier pickaxe
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
                #endregion

                #region evil and molten tier pickaxes
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
                #endregion
                //End of Pickaxe recipe changes

                //Beginning of Broadsword recipe changes
                #region copper tier broadsword
                Recipe CopperBroadswordCraft = Main.recipe[i];
                if (CopperBroadswordCraft.HasIngredient(ItemID.CopperBar) && CopperBroadswordCraft.HasTile(TileID.Anvils) && CopperBroadswordCraft.HasResult(ItemID.CopperBroadsword))
                {
                    CopperBroadswordCraft.AddRecipeGroup("WoodenSword");
                }
                //Copper Broadsword Recipe

                Recipe TinBroadswordCraft = Main.recipe[i];
                if (TinBroadswordCraft.HasIngredient(ItemID.TinBar) && TinBroadswordCraft.HasTile(TileID.Anvils) && TinBroadswordCraft.HasResult(ItemID.TinBroadsword))
                {
                    TinBroadswordCraft.AddRecipeGroup("WoodenSword");
                }
                //Tin Broadsword Recipe
                #endregion

                #region iron tier broadsword
                Recipe IronBroadswordCraft = Main.recipe[i];
                if (IronBroadswordCraft.HasIngredient(ItemID.IronBar) && IronBroadswordCraft.HasTile(TileID.Anvils) && IronBroadswordCraft.HasResult(ItemID.IronBroadsword))
                {
                    IronBroadswordCraft.AddRecipeGroup("CopperBroadsword");
                    if (IronBroadswordCraft.TryGetIngredient(ItemID.IronBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Iron Broadsword Recipe

                Recipe LeadBroadswordCraft = Main.recipe[i];
                if (LeadBroadswordCraft.HasIngredient(ItemID.LeadBar) && LeadBroadswordCraft.HasTile(TileID.Anvils) && LeadBroadswordCraft.HasResult(ItemID.LeadBroadsword))
                {
                    LeadBroadswordCraft.AddRecipeGroup("CopperBroadsword");
                    if (LeadBroadswordCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lead Broadsword Recipe
                #endregion

                #region silver tier broadsword
                Recipe SilverBroadswordCraft = Main.recipe[i];
                if (SilverBroadswordCraft.HasIngredient(ItemID.SilverBar) && SilverBroadswordCraft.HasTile(TileID.Anvils) && SilverBroadswordCraft.HasResult(ItemID.SilverBroadsword))
                {
                    SilverBroadswordCraft.AddRecipeGroup("IronBroadsword");
                    if (SilverBroadswordCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Silver Broadsword Recipe

                Recipe TungstenBroadswordCraft = Main.recipe[i];
                if (TungstenBroadswordCraft.HasIngredient(ItemID.TungstenBar) && TungstenBroadswordCraft.HasTile(TileID.Anvils) && TungstenBroadswordCraft.HasResult(ItemID.TungstenBroadsword))
                {
                    TungstenBroadswordCraft.AddRecipeGroup("IronBroadsword");
                    if (TungstenBroadswordCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tungsten Broadsword Recipe
                #endregion

                #region gold tier broadsword
                Recipe GoldBroadswordCraft = Main.recipe[i];
                if (GoldBroadswordCraft.HasIngredient(ItemID.GoldBar) && GoldBroadswordCraft.HasTile(TileID.Anvils) && GoldBroadswordCraft.HasResult(ItemID.GoldBroadsword))
                {
                    GoldBroadswordCraft.AddRecipeGroup("SilverBroadsword");
                    if (GoldBroadswordCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Gold Broadsword Recipe

                Recipe PlatinumBroadswordCraft = Main.recipe[i];
                if (PlatinumBroadswordCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumBroadswordCraft.HasTile(TileID.Anvils) && PlatinumBroadswordCraft.HasResult(ItemID.PlatinumBroadsword))
                {
                    PlatinumBroadswordCraft.AddRecipeGroup("SilverBroadsword");
                    if (PlatinumBroadswordCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Broadsword Recipe
                #endregion

                #region evil tier broadsword
                Recipe LightsBaneCraft = Main.recipe[i];
                if (LightsBaneCraft.HasIngredient(ItemID.DemoniteBar) && LightsBaneCraft.HasTile(TileID.Anvils) && LightsBaneCraft.HasResult(ItemID.LightsBane))
                {
                    LightsBaneCraft.AddRecipeGroup("GoldBroadsword");
                    if (LightsBaneCraft.TryGetIngredient(ItemID.DemoniteBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lights Bane Recipe

                Recipe BloodButchererCraft = Main.recipe[i];
                if (BloodButchererCraft.HasIngredient(ItemID.CrimtaneBar) && BloodButchererCraft.HasTile(TileID.Anvils) && BloodButchererCraft.HasResult(ItemID.BloodButcherer))
                {
                    BloodButchererCraft.AddRecipeGroup("GoldBroadsword");
                    if (BloodButchererCraft.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Blood Butcherer Recipe
                //End of Broadsword Recipe changes

                //Skipping Fiery Greatsword / Volcano because that is apart of Nights Edge recipe and Nights Edge also uses Lights Bane, Blood Butcherer, and Indegestion. would mean you have to get 2 copies of Lights Bane every time
                #endregion

                //Beginning of Bow recipe changes
                #region copper tier bow
                Recipe CopperBowCraft = Main.recipe[i];
                if (CopperBowCraft.HasIngredient(ItemID.CopperBar) && CopperBowCraft.HasTile(TileID.Anvils) && CopperBowCraft.HasResult(ItemID.CopperBow))
                {
                    CopperBowCraft.AddRecipeGroup("WoodenBow");
                }
                //Copper Bow Recipe

                Recipe TinBowCraft = Main.recipe[i];
                if (TinBowCraft.HasIngredient(ItemID.TinBar) && TinBowCraft.HasTile(TileID.Anvils) && TinBowCraft.HasResult(ItemID.TinBow))
                {
                    TinBowCraft.AddRecipeGroup("WoodenBow");
                }
                //Tin Bow Recipe
                #endregion

                #region iron tier bow
                Recipe IronBowCraft = Main.recipe[i];
                if (IronBowCraft.HasIngredient(ItemID.IronBar) && IronBowCraft.HasTile(TileID.Anvils) && IronBowCraft.HasResult(ItemID.IronBow))
                {
                    IronBowCraft.AddRecipeGroup("CopperBow");
                    if (IronBowCraft.TryGetIngredient(ItemID.IronBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Iron Bow Recipe

                Recipe LeadBowCraft = Main.recipe[i];
                if (LeadBowCraft.HasIngredient(ItemID.LeadBar) && LeadBowCraft.HasTile(TileID.Anvils) && LeadBowCraft.HasResult(ItemID.LeadBow))
                {
                    LeadBowCraft.AddRecipeGroup("CopperBow");
                    if (LeadBowCraft.TryGetIngredient(ItemID.LeadBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Lead Bow Recipe
                #endregion

                #region silver tier bow
                Recipe SilverBowCraft = Main.recipe[i];
                if (SilverBowCraft.HasIngredient(ItemID.SilverBar) && SilverBowCraft.HasTile(TileID.Anvils) && SilverBowCraft.HasResult(ItemID.SilverBow))
                {
                    SilverBowCraft.AddRecipeGroup("IronBow");
                    if (SilverBowCraft.TryGetIngredient(ItemID.SilverBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Silver Bow Recipe

                Recipe TungstenBowCraft = Main.recipe[i];
                if (TungstenBowCraft.HasIngredient(ItemID.TungstenBar) && TungstenBowCraft.HasTile(TileID.Anvils) && TungstenBowCraft.HasResult(ItemID.TungstenBow))
                {
                    TungstenBowCraft.AddRecipeGroup("IronBow");
                    if (TungstenBowCraft.TryGetIngredient(ItemID.TungstenBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tungsten Bow Recipe
                #endregion

                #region gold tier bow
                Recipe GoldBowCraft = Main.recipe[i];
                if (GoldBowCraft.HasIngredient(ItemID.GoldBar) && GoldBowCraft.HasTile(TileID.Anvils) && GoldBowCraft.HasResult(ItemID.GoldBow))
                {
                    GoldBowCraft.AddRecipeGroup("SilverBow");
                    if (GoldBowCraft.TryGetIngredient(ItemID.GoldBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Gold Bow Recipe

                Recipe PlatinumBowCraft = Main.recipe[i];
                if (PlatinumBowCraft.HasIngredient(ItemID.PlatinumBar) && PlatinumBowCraft.HasTile(TileID.Anvils) && PlatinumBowCraft.HasResult(ItemID.PlatinumBow))
                {
                    PlatinumBowCraft.AddRecipeGroup("SilverBow");
                    if (PlatinumBowCraft.TryGetIngredient(ItemID.PlatinumBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //PLatinum Bow Recipe
                #endregion

                #region evil and molten tier bow
                Recipe DemonBowCraft = Main.recipe[i];
                if (DemonBowCraft.HasIngredient(ItemID.DemoniteBar) && DemonBowCraft.HasTile(TileID.Anvils) && DemonBowCraft.HasResult(ItemID.DemonBow))
                {
                    DemonBowCraft.AddRecipeGroup("GoldBow");
                    if (DemonBowCraft.TryGetIngredient(ItemID.DemoniteBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Demon Bow Recipe

                Recipe TendonBowCraft = Main.recipe[i];
                if (TendonBowCraft.HasIngredient(ItemID.CrimtaneBar) && TendonBowCraft.HasTile(TileID.Anvils) && TendonBowCraft.HasResult(ItemID.TendonBow))
                {
                    TendonBowCraft.AddRecipeGroup("GoldBow");
                    if (TendonBowCraft.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //Tendon Bow Recipe

                Recipe MoltenFuryCraft = Main.recipe[i];
                if (MoltenFuryCraft.HasIngredient(ItemID.HellstoneBar) && MoltenFuryCraft.HasTile(TileID.Anvils) && MoltenFuryCraft.HasResult(ItemID.MoltenFury))
                {
                    MoltenFuryCraft.AddRecipeGroup("DemonBow");
                    if (MoltenFuryCraft.TryGetIngredient(ItemID.HellstoneBar, out Item ingredient))
                    {
                        ingredient.stack /= 2;
                    }
                }
                //End of Bow Recipe changes
                #endregion
                //Just gonna wait until the hardmode update to further update the recipes
            }
        }
        public override void AddRecipes()
        {
            //Beginning of Material recipe adding
            #region Magical recipe changes
            Recipe.Create(ItemID.SpellTome)
                .AddIngredient(ItemID.Book)
                .AddIngredient(ItemID.ManaCrystal, 3)
                .AddTile(TileID.Bookcases)
                //.SortAfterFirstRecipesOf(ItemID.Titties)
                .Register();
            #endregion

        }
    }
}