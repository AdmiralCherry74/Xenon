using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Armor.PreHardmode;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.EvilMaterials;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Items.Placeable.Furniture.Crafting;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone;
using Xenon.Content.Items.Placeable.Wall.Natural.Stone;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.DriverHammers;
using Xenon.Content.Items.Tools.FishingRods;
using Xenon.Content.Items.Tools.GardeningHoes;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Magic.Staves;
using Xenon.Content.Items.Weapons.Melee.Battleaxes;
using Xenon.Content.Items.Weapons.Melee.Boomerangs;
using Xenon.Content.Items.Weapons.Melee.Flails;
using Xenon.Content.Items.Weapons.Melee.Polearms;
using Xenon.Content.Items.Weapons.Melee.Swords;
using Xenon.Content.Items.Weapons.Melee.YoYos;
using Xenon.Content.Items.Weapons.Ranged.Bows;
using Xenon.Content.Items.Weapons.Summon.Caltrops;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class RecipeSorting : ModSystem
    {
        //cleverly using the fact that these recipes will load in the order to put them in, too properly sort them into the crafting ui
        public override void AddRecipes()
        {
            #region Building Block
            #region Gem based blocks
            #region Combined Gems
            //Amethyst Block
            Recipe.Create(ModContent.ItemType<AmethystBlockItem>(), 2)
                .AddIngredient(ItemID.Amethyst, 10)
                .AddTile(TileID.WorkBenches)
                .SortBeforeFirstRecipesOf(ItemID.AmethystGemsparkBlock)
                .Register();

            //Amethyst Wall
            Recipe.Create(ModContent.ItemType<AmethystWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmethystBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmethystBlockItem>())
                .AddIngredient(ModContent.ItemType<AmethystWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystWallItem>())
                .Register();

            //Jade Block
            Recipe.Create(ModContent.ItemType<JadeBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Jade>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBlockItem>())
                .Register();

            //Jade Wall
            Recipe.Create(ModContent.ItemType<JadeWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<JadeBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<JadeBlockItem>())
                .AddIngredient(ModContent.ItemType<JadeWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeWallItem>())
                .Register();

            //Topaz Block
            Recipe.Create(ModContent.ItemType<TopazBlockItem>(), 2)
                .AddIngredient(ItemID.Topaz, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBlockItem>())
                .Register();

            //Topaz Wall
            Recipe.Create(ModContent.ItemType<TopazWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<TopazBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<TopazBlockItem>())
                .AddIngredient(ModContent.ItemType<TopazWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazWallItem>())
                .Register();

            //Sapphire Block
            Recipe.Create(ModContent.ItemType<SapphireBlockItem>(), 2)
                .AddIngredient(ItemID.Sapphire, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBlockItem>())
                .Register();

            //Sapphire Wall
            Recipe.Create(ModContent.ItemType<SapphireWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<SapphireBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<SapphireBlockItem>())
                .AddIngredient(ModContent.ItemType<SapphireWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireWallItem>())
                .Register();

            //Garnet Block
            Recipe.Create(ModContent.ItemType<GarnetBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Garnet>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBlockItem>())
                .Register();

            //Garnet Wall
            Recipe.Create(ModContent.ItemType<GarnetWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<GarnetBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetBlockItem>())
                .AddIngredient(ModContent.ItemType<GarnetWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetWallItem>())
                .Register();

            //Emerald Block
            Recipe.Create(ModContent.ItemType<EmeraldBlockItem>(), 2)
                .AddIngredient(ItemID.Emerald, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBlockItem>())
                .Register();

            //Emerald Wall
            Recipe.Create(ModContent.ItemType<EmeraldWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<EmeraldBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<EmeraldBlockItem>())
                .AddIngredient(ModContent.ItemType<EmeraldWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldWallItem>())
                .Register();

            //Ruby Block
            Recipe.Create(ModContent.ItemType<RubyBlockItem>(), 2)
                .AddIngredient(ItemID.Ruby, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBlockItem>())
                .Register();

            //Ruby Wall
            Recipe.Create(ModContent.ItemType<RubyWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<RubyBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<RubyBlockItem>())
                .AddIngredient(ModContent.ItemType<RubyWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyWallItem>())
                .Register();

            //Lapis Block
            Recipe.Create(ModContent.ItemType<LapisBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Lapis>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBlockItem>())
                .Register();

            //Lapis Wall
            Recipe.Create(ModContent.ItemType<LapisWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<LapisBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<LapisBlockItem>())
                .AddIngredient(ModContent.ItemType<LapisWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisWallItem>())
                .Register();

            //Diamond Block
            Recipe.Create(ModContent.ItemType<DiamondBlockItem>(), 2)
                .AddIngredient(ItemID.Diamond, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBlockItem>())
                .Register();

            //Diamond Wall
            Recipe.Create(ModContent.ItemType<DiamondWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<DiamondBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<DiamondBlockItem>())
                .AddIngredient(ModContent.ItemType<DiamondWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondWallItem>())
                .Register();

            //Amber Block
            Recipe.Create(ModContent.ItemType<AmberBlockItem>(), 2)
                .AddIngredient(ItemID.Amber, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBlockItem>())
                .Register();

            //Amber Wall
            Recipe.Create(ModContent.ItemType<AmberWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmberBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmberBlockItem>())
                .AddIngredient(ModContent.ItemType<AmberWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberWallItem>())
                .Register();
            #endregion

            #region Gemspark
            Recipe.Create(ModContent.ItemType<JadeGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Jade>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.AmethystGemsparkBlock)
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Garnet>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.SapphireGemsparkBlock)
                .Register();

            Recipe.Create(ModContent.ItemType<LapisGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Lapis>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.RubyGemsparkBlock)
                .Register();
            #endregion

            #region Gem Bricks
            //Amethyst Brick
            Recipe.Create(ModContent.ItemType<AmethystBrickItem>(), 1)
                .AddIngredient(ModContent.ItemType<AmethystBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.RedBrickWall)
                .Register();

            //Amethyst Brick Wall
            Recipe.Create(ModContent.ItemType<AmethystBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmethystBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmethystBrickItem>())
                .AddIngredient(ModContent.ItemType<AmethystBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickWallItem>())
                .Register();

            //Jade Brick
            Recipe.Create(ModContent.ItemType<JadeBrickItem>())
                .AddIngredient(ModContent.ItemType<JadeBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickItem>())
                .Register();

            //Jade Brick Wall
            Recipe.Create(ModContent.ItemType<JadeBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<JadeBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<JadeBrickItem>())
                .AddIngredient(ModContent.ItemType<JadeBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickWallItem>())
                .Register();

            //Topaz Brick
            Recipe.Create(ModContent.ItemType<TopazBrickItem>())
                .AddIngredient(ModContent.ItemType<TopazBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickItem>())
                .Register();

            //Topaz Brick Wall
            Recipe.Create(ModContent.ItemType<TopazBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<TopazBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<TopazBrickItem>())
                .AddIngredient(ModContent.ItemType<TopazBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickWallItem>())
                .Register();

            //Sapphire Brick
            Recipe.Create(ModContent.ItemType<SapphireBrickItem>())
                .AddIngredient(ModContent.ItemType<SapphireBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickItem>())
                .Register();

            //Sapphire Brick Wall
            Recipe.Create(ModContent.ItemType<SapphireBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<SapphireBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<SapphireBrickItem>())
                .AddIngredient(ModContent.ItemType<SapphireBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickWallItem>())
                .Register();

            //Garnet Brick
            Recipe.Create(ModContent.ItemType<GarnetBrickItem>())
                .AddIngredient(ModContent.ItemType<GarnetBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickItem>())
                .Register();

            //Garnet Brick Wall
            Recipe.Create(ModContent.ItemType<GarnetBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<GarnetBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetBrickItem>())
                .AddIngredient(ModContent.ItemType<GarnetBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickWallItem>())
                .Register();

            //Emerald Brick
            Recipe.Create(ModContent.ItemType<EmeraldBrickItem>())
                .AddIngredient(ModContent.ItemType<EmeraldBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickItem>())
                .Register();

            //Emerald Brick Wall
            Recipe.Create(ModContent.ItemType<EmeraldBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<EmeraldBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<EmeraldBrickItem>())
                .AddIngredient(ModContent.ItemType<EmeraldBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickWallItem>())
                .Register();

            //Ruby Brick
            Recipe.Create(ModContent.ItemType<RubyBrickItem>())
                .AddIngredient(ModContent.ItemType<RubyBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickItem>())
                .Register();

            //Ruby Brick Wall
            Recipe.Create(ModContent.ItemType<RubyBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<RubyBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<RubyBrickItem>())
                .AddIngredient(ModContent.ItemType<RubyBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickWallItem>())
                .Register();

            //Lapis Brick
            Recipe.Create(ModContent.ItemType<LapisBrickItem>())
                .AddIngredient(ModContent.ItemType<LapisBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickItem>())
                .Register();

            //Lapis Brick Wall
            Recipe.Create(ModContent.ItemType<LapisBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<LapisBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<LapisBrickItem>())
                .AddIngredient(ModContent.ItemType<LapisBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickWallItem>())
                .Register();

            //Diamond Brick
            Recipe.Create(ModContent.ItemType<DiamondBrickItem>())
                .AddIngredient(ModContent.ItemType<DiamondBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickItem>())
                .Register();

            //Diamond Brick Wall
            Recipe.Create(ModContent.ItemType<DiamondBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<DiamondBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<DiamondBrickItem>())
                .AddIngredient(ModContent.ItemType<DiamondBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickWallItem>())
                .Register();

            //Amber Brick
            Recipe.Create(ModContent.ItemType<AmberBrickItem>())
                .AddIngredient(ModContent.ItemType<AmberBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickItem>())
                .Register();

            //Amber Brick Wall
            Recipe.Create(ModContent.ItemType<AmberBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmberBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmberBrickItem>())
                .AddIngredient(ModContent.ItemType<AmberBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBrickWallItem>())
                .Register();
            #endregion
            #endregion

            #region Stone based blocks
            //Smooth Stone
            Recipe.Create(ModContent.ItemType<SmoothStoneItem>(), 1)
            .AddIngredient(ItemID.StoneBlock, 2)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ItemID.GrayBrickWall)
            .Register();
            #endregion

            #region Catacombs
            #region Red Catacombs
            #endregion
            #endregion
            #endregion

            #region Ore and Wood based gear, tools, weapons and armor recipes

            #region Vanilla Ore based Recipes

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

            #region Xenon Wood Recipes
            #region Bilewood
            //Bilewood Helmet
            Recipe.Create(ModContent.ItemType<BilewoodHelmet>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 20)
                .SortAfterFirstRecipesOf(ItemID.EbonwoodBow)
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Breastplate
            Recipe.Create(ModContent.ItemType<BilewoodBreastplate>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 30)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodHelmet>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Greaves
            Recipe.Create(ModContent.ItemType<BilewoodGreaves>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 25)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodBreastplate>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Broadsword
            Recipe.Create(ModContent.ItemType<BilewoodBroadsword>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 7)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodGreaves>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Hammer
            Recipe.Create(ModContent.ItemType<BilewoodHammer>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 8)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodBroadsword>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Bow
            Recipe.Create(ModContent.ItemType<BilewoodBow>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 10)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodHammer>())
                .AddTile(TileID.WorkBenches)
                .Register();
            #endregion

            #region JacarandaWood
            //Jacarandawood Helmet
            Recipe.Create(ModContent.ItemType<JacarandawoodHelmet>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 20)
                .SortAfterFirstRecipesOf(ItemID.PalmWoodBow)
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Breastplate
            Recipe.Create(ModContent.ItemType<JacarandawoodBreastplate>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 30)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodHelmet>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Greaves
            Recipe.Create(ModContent.ItemType<JacarandawoodGreaves>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 25)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodBreastplate>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Broadsword
            Recipe.Create(ModContent.ItemType<JacarandawoodBroadsword>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 7)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodGreaves>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Hammer
            Recipe.Create(ModContent.ItemType<JacarandawoodHammer>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 8)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodBroadsword>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Bow
            Recipe.Create(ModContent.ItemType<JacarandawoodBow>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 10)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodHammer>())
                .AddTile(TileID.WorkBenches)
                .Register();
            #endregion
            #endregion

            #region Aluminum Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<AluminumBar>())
                .AddIngredient(ModContent.ItemType<AluminumOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.CopperWatch)
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

            //Jade Staff
            Recipe.Create(ModContent.ItemType<JadeStaff>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 10)
                .AddIngredient(ModContent.ItemType<Jade>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<AluminumHelmet>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 12)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<AluminumChainmail>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<AluminumGreaves>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 16)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<AluminumWatch>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumGreaves>())
                .Register();
            #endregion

            #region Cinnabar Recipes
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
            Recipe.Create(ModContent.ItemType<CinnabarHelmet>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBow>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<CinnabarChainmail>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<CinnabarGreaves>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarChainmail>())
                .Register();
            #endregion

            #region Indium Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<IndiumBar>())
                .AddIngredient(ModContent.ItemType<IndiumOreBlock>(), 4)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.SilverWatch)
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

            //Garnet Staff
            Recipe.Create(ModContent.ItemType<GarnetStaff>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
                .AddIngredient(ModContent.ItemType<Garnet>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<IndiumHelmet>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<IndiumChainmail>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<IndiumGreaves>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<IndiumWatch>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumGreaves>())
                .Register();
            #endregion

            #region Xieite Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<XieiteBar>())
                .AddIngredient(ModContent.ItemType<XieiteOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.GoldWatch)
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

            //Lapis Staff
            Recipe.Create(ModContent.ItemType<LapisStaff>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 10)
                .AddIngredient(ModContent.ItemType<Lapis>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<XieiteHelmet>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<XieiteChainmail>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 30)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<XieiteGreaves>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<XieiteWatch>())
                .AddIngredient(ModContent.ItemType<XieiteBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<XieiteGreaves>()) //change to greaves later
                .Register();
            #endregion

            #region Ingestane Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<IngestaneBar>())
            .AddIngredient(ModContent.ItemType<IngestaneOre>(), 3)
            .AddTile(TileID.Furnaces)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Depraverang>())
            .Register();

            //Fishing Rod
            Recipe.Create(ModContent.ItemType<Regurgitator>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<IngestaneBar>())
            .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<SulfirBow>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Regurgitator>())
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