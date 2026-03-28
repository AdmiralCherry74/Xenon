using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;
using Xenon.Content.Items.Placeable.Furniture.Crafting;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.DriverHammers;
using Xenon.Content.Items.Tools.GardeningHoes;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Melee.Battleaxes;
using Xenon.Content.Items.Weapons.Melee.Boomerangs;
using Xenon.Content.Items.Weapons.Melee.Flails;
using Xenon.Content.Items.Weapons.Melee.Polearms;
using Xenon.Content.Items.Weapons.Melee.Swords;
using Xenon.Content.Items.Weapons.Melee.YoYos;
using Xenon.Content.Items.Weapons.Ranged.Bows;
using Xenon.Content.Items.Weapons.Summon.Caltrops;
using Xenon.Content.Tiles.Furniture.CraftingStations;

namespace Xenon.Common.Globals
{
    public class OreRecipeSorting : ModSystem
    {
        //cleverly using the fact that these recipes will load in the order to put them in, too properly sort them into the crafting ui
        public override void AddRecipes()
        {
            #region Tools, Weapons, and Armor

            #region Vanilla Ore crafting recipes

            #region Hoes
            //Copper Hoe
            Recipe.Create(ModContent.ItemType<CopperHoe>())
                .AddIngredient(ItemID.CopperBar, 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .SortAfterFirstRecipesOf(ItemID.CopperHammer)
                .AddTile(TileID.Anvils)
            .Register();

            //Tin Hoe
            Recipe.Create(ModContent.ItemType<TinHoe>())
                .AddIngredient(ItemID.TinBar, 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TinHammer)
                .Register();

            //Iron Hoe
            Recipe.Create(ModContent.ItemType<IronHoe>())
                .AddIngredient(ItemID.IronBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronHammer)
                .Register();

            //Lead Hoe
            Recipe.Create(ModContent.ItemType<LeadHoe>())
                .AddIngredient(ItemID.LeadBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadHammer)
                .Register();

            //Silver Hoe
            Recipe.Create(ModContent.ItemType<SilverHoe>())
                .AddIngredient(ItemID.SilverBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SilverHammer)
                .Register();

            //Tungsten Hoe
            Recipe.Create(ModContent.ItemType<TungstenHoe>())
                .AddIngredient(ItemID.TungstenBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TungstenHammer)
                .Register();

            //Gold Hoe
            Recipe.Create(ModContent.ItemType<GoldHoe>())
                .AddIngredient(ItemID.GoldBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.GoldHammer)
                .Register();

            //Platinum Hoe
            Recipe.Create(ModContent.ItemType<PlatinumHoe>())
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.PlatinumHammer)
                .Register();
            #endregion

            #region Battleaxes
            //Copper Battleaxe
            Recipe.Create(ModContent.ItemType<CopperBattleaxe>())
                .AddIngredient(ItemID.CopperBar, 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.CopperShortsword)
                .Register();

            //Tin Battleaxe
            Recipe.Create(ModContent.ItemType<TinBattleaxe>())
                .AddIngredient(ItemID.TinBar, 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TinShortsword)
                .Register();

            //Iron Battleaxe
            Recipe.Create(ModContent.ItemType<IronBattleaxe>())
                .AddIngredient(ItemID.IronBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronShortsword)
                .Register();

            //Lead Battleaxe
            Recipe.Create(ModContent.ItemType<LeadBattleaxe>())
                .AddIngredient(ItemID.LeadBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadShortsword)
                .Register();

            //Silver Battleaxe
            Recipe.Create(ModContent.ItemType<SilverBattleaxe>())
                .AddIngredient(ItemID.SilverBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SilverShortsword)
                .Register();

            //Tungsten Battleaxe
            Recipe.Create(ModContent.ItemType<TungstenBattleaxe>())
                .AddIngredient(ItemID.TungstenBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TungstenShortsword)
                .Register();

            //Gold Battleaxe
            Recipe.Create(ModContent.ItemType<GoldBattleaxe>())
                .AddIngredient(ItemID.GoldBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.GoldShortsword)
                .Register();

            //Platinum Battleaxe
            Recipe.Create(ModContent.ItemType<PlatinumBattleaxe>())
                .AddIngredient(ItemID.PlatinumBar, 9)
                .SortAfterFirstRecipesOf(ItemID.PlatinumShortsword)
                .AddTile(TileID.Anvils)
                .Register();
            #endregion

            #region Caltrops
            Recipe.Create(ModContent.ItemType<IronCaltrops>(), 5)
                .AddIngredient(ItemID.IronBar, 1)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronBow)
                .Register();

            Recipe.Create(ModContent.ItemType<LeadCaltrops>(), 5)
                .AddIngredient(ItemID.LeadBar, 1)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadBow)
                .Register();
            #endregion

            #region Corrupt Special Weapons
            //Battleaxe
            Recipe.Create(ModContent.ItemType<NightGnasher>())
                .AddIngredient(ItemID.DemoniteBar, 9)
                .AddIngredient(ItemID.ShadowScale, 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TheBreaker)
                .Register();

            //Spear
            Recipe.Create(ModContent.ItemType<TheEbonStabber>())
                .AddIngredient(ItemID.DemoniteBar, 12)
                .AddIngredient(ItemID.ShadowScale, 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<NightGnasher>())
                .Register();

            //Boomerang
            Recipe.Create(ModContent.ItemType<Depraverang>())
            .AddIngredient(ItemID.DemoniteBar, 8)
            .AddIngredient(ItemID.ShadowScale, 2)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.CorruptYoyo)
            .Register();
            #endregion

            #region Crimfied Special Weapons
            //Battleaxe
            Recipe.Create(ModContent.ItemType<JawSplitter>())
                .AddIngredient(ItemID.CrimtaneBar, 7)
                .AddIngredient(ItemID.TissueSample, 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.FleshGrinder)
                .Register();

            //Boomerang
            Recipe.Create(ModContent.ItemType<Zygomatarang>())
            .AddIngredient(ItemID.CrimtaneBar, 8)
            .AddIngredient(ItemID.TissueSample, 2)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.CrimsonYoyo)
            .Register();

            #endregion
            #endregion

            #region Aluminum Tools, Weapons, and Armor
            //Bar
            Recipe.Create(ModContent.ItemType<AluminumBar>())
                .AddIngredient(ModContent.ItemType<AluminumOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.CopperGreaves)
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<AluminumPickaxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBar>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<AluminumAxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 6)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<AluminumHammer>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<AluminumHoe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<AluminumBroadsword>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<AluminumShortsword>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 5)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<AluminumBattleaxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<AluminumBow>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBattleaxe>())
                .Register();

            //Helmet

            //Breastplate

            //Greaves
            #endregion

            #region Cinnabar Tools, Weapons, and Armor
            //Bar
            Recipe.Create(ModContent.ItemType<CinnabarBar>())
                .AddIngredient(ModContent.ItemType<CinnabarOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.IronGreaves)
                .Register();

            //Anvil
            Recipe.Create(ModContent.ItemType<CinnabarAnvilItem>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 6)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBar>())
                .AddTile(TileID.WorkBenches).Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<CinnabarPickaxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarAnvilItem>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<CinnabarAxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<CinnabarHammer>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<CinnabarHoe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<CinnabarBroadsword>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<CinnabarShortsword>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<CinnabarBattleaxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<CinnabarBow>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBattleaxe>())
                .Register();

            //Caltrop

            //Helmet

            //Breastplate

            //Greaves
            #endregion

            #region Indium Tools, Weapons, and Armor
            //Bar
            Recipe.Create(ModContent.ItemType<IndiumBar>())
                .AddIngredient(ModContent.ItemType<IndiumOreBlock>(), 4)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.SilverGreaves)
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<IndiumPickaxe>())
            .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBar>())
            .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<IndiumAxe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<IndiumHammer>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<IndiumHoe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<IndiumBroadsword>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<IndiumShortsword>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<IndiumBattleaxe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<IndiumBow>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBattleaxe>())
                .Register();

            //Helmet

            //Breastplate

            //Greaves
            #endregion

            #region Xieite Tools, Weapons, and Armor
            //Bar
            Recipe.Create(ModContent.ItemType<XieiteBar>())
                .AddIngredient(ModContent.ItemType<XieiteOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.GoldGreaves)
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<XieitePickaxe>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteBar>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<XieiteAxe>())
            .AddIngredient(ModContent.ItemType<XieiteBar>(), 8)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<XieitePickaxe>())
            .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<XieiteHammer>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteAxe>())
                .Register();
            //Hoe
            Recipe.Create(ModContent.ItemType<XieiteHoe>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<XieiteBroadsword>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<XieiteShortsword>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<XieiteBattleaxe>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<XieiteBow>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteBattleaxe>())
                .Register();

            //Helmet

            //Breastplate

            //Greaves
            #endregion

            #region Ingestane Tools, Weapons, and Armor
            //Bar
            Recipe.Create(ModContent.ItemType<IngestaneBar>())
            .AddIngredient(ModContent.ItemType<IngestaneOre>(), 3)
            .AddTile(TileID.Furnaces)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Zygomatarang>())
            .Register();

            //Fishing Rod

            //Bow
            Recipe.Create(ModContent.ItemType<SulfirBow>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<IngestaneBar>()) //change this to fishing rod later
            .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<DirtySwamp>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SulfirBow>())
                .Register();

            //Sword
            Recipe.Create(ModContent.ItemType<TheIndigestion>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DirtySwamp>())
                .Register();

            Recipe.Create(ItemID.NightsEdge)
                .AddIngredient(ModContent.ItemType<TheIndigestion>(), 1)
                .AddIngredient(ItemID.BladeofGrass, 1)
                .AddIngredient(ItemID.FieryGreatsword, 1)
                .AddIngredient(ItemID.Muramasa, 1)
                .AddTile(TileID.DemonAltar)
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<CausticHelmet>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 15)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheIndigestion>())
                .Register();

            //Scalemail
            Recipe.Create(ModContent.ItemType<CausticScalemail>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 25)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<CausticGreaves>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 20)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticScalemail>())
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<IngestedPickaxe>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticGreaves>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<Squasher>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 11)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IngestedPickaxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<Pukivator>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 5)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<Squasher>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<TheDisembowelment>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 9)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 2)
                .SortAfterFirstRecipesOf(ModContent.ItemType<Pukivator>())
                .AddTile(TileID.Anvils)
                .Register();

            //Spear
            Recipe.Create(ModContent.ItemType<TheToothpick>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheDisembowelment>())
                .Register();

            //Flail
            Recipe.Create(ModContent.ItemType<NauseaCudgel>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheToothpick>())
                .Register();

            //Yoyo
            Recipe.Create(ModContent.ItemType<TheDamp>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<NauseaCudgel>())
                .Register();
            #endregion
            #endregion
        }
    }
}